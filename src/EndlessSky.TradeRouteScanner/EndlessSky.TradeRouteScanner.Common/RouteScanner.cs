using EndlessSky.TradeRouteScanner.Common.Logging;
using EndlessSky.TradeRouteScanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class RouteScanner
    {
        public ProgressEventSource ProgressEvents = new ProgressEventSource();

        ILogger _log;
        bool _working = false;
        CancellationToken _ct;
        RouteScannerOptions _options;

        public RouteScanner()
        {
            _log = new DummyLogger();
        }

        public void SetLogging(ILogger log)
        {
            _log = log;
        }

        private void DoProgress(ProgressEventArgs args)
        {
            ProgressEvents.DoEvent(this, args);
        }

        public RouteScannerResults Scan(TradeMap map, RouteScannerOptions options)
        {
            return Scan(map, options, CancellationToken.None);
        }

        public RouteScannerResults Scan(TradeMap map, RouteScannerOptions options, CancellationToken ct)
        {
            if (_working) throw new InvalidOperationException("Already working");
            _working = true;
            _log.Info("Starting route scan");

            _ct = ct;

            _options = options;

            var r = new RouteScannerResults();

            // Build a list of profitable runs
            // Loop through systems
            // Get list of systems within the max jump limit
            // Go through each system in the list, compare comodity prices
            // If the price is greater than the desired threshold, add it to the run list

            TradeMapSystemCollection systemCollection;
            List<string> validMapBoundSystems = new List<string>();
            if (options.MapBounds.Count > 0)
            {
                // Gather map bounds
                systemCollection = new TradeMapSystemCollection();
                foreach (var system in map.Systems)
                {
                    foreach (var mapBound in options.MapBounds)
                    {
                        var mapBoundSystem = mapBound.Key.ToLower();
                        if (mapBoundSystem == system.Name.ToLower())
                        {
                            validMapBoundSystems.Add(mapBoundSystem);
                            GetSystemsInJumpRange(map, system, systemCollection, mapBound.Value);
                            continue;
                        }
                    }
                }

                // Validate
                foreach (var mapBound in options.MapBounds)
                {
                    if (!validMapBoundSystems.Contains(mapBound.Key.ToLower()))
                        throw new IndexOutOfRangeException($"Map bound system name isn't a known system '{mapBound.Key}'");
                }
            }
            else
            {
                // Do for all systems
                systemCollection = map.Systems;
            }


            for (var iSS=0; iSS < systemCollection.Count; iSS++)
            {
                ct.ThrowIfCancellationRequested();

                var startSystem = systemCollection[iSS];

                if (!startSystem.CanTrade) continue; // Don't care about system's that can't trade.

                _log.Debug($"Scanning runs for system: {startSystem.Name}");
                DoProgress(new ProgressEventArgs(iSS, map.Systems.Count, ProgressEventStatus.Working, $"Scanning runs for '{startSystem.Name}' ({iSS+1}/{systemCollection.Count})"));

                // Clear this system's runs, in case
                startSystem.Runs.Clear();
                List<TradeMapSystem> seenSystems = new List<TradeMapSystem>();
                List<TradeMapSystem> systemsInRange = new List<TradeMapSystem>();
                Stack<TradeMapSystem> systemCheckStack = new Stack<TradeMapSystem>();
                Stack<TradeMapSystem> systemCheckStackNext;

                // Add this system's links to the "to do" stack
                foreach (var link in startSystem.Links)
                {
                    ct.ThrowIfCancellationRequested();
                    if (link.System == null) continue;
                    if (link.System == startSystem) continue; // Ignore it if it's start system
                    systemsInRange.Add(link.System);
                    systemCheckStack.Push(link.System);
                }

                for (int jumpCount = 1; jumpCount <= options.RunMaxJumps; jumpCount++)
                {
                    ct.ThrowIfCancellationRequested();
                    systemCheckStackNext = new Stack<TradeMapSystem>(); // Ready to compile the next list of jumps

                    // Find new systems in the check stack
                    while (systemCheckStack.Count > 0)
                    {
                        ct.ThrowIfCancellationRequested();
                        var destSystem = systemCheckStack.Pop();

                        // Check for profitable runs to this system
                        if (destSystem.CanTrade) // Avoid systems that have comodity data, but can't actually trade
                            ScanForRuns(startSystem, destSystem, jumpCount, r.AllRuns, options);

                        // Check for jumps away from this system
                        // but only if we're under the jump limit
                        if (jumpCount < options.RunMaxJumps)
                        {
                            //_log.Debug($"{jumpCount} under jump limit {options.RunMaxJumps}, looking for more destinations");
                            foreach (var link in destSystem.Links)
                            {
                                if (link.System == null) continue;
                                if (link.System == startSystem) continue; // Ignore it if it's start system
                                if (seenSystems.Contains(link.System)) continue;

                                // New system
                                //_log.Debug($"Enquing system '{link.System.Name}'");
                                seenSystems.Add(link.System);
                                systemsInRange.Add(link.System);
                                systemCheckStackNext.Push(link.System);
                            }
                        } 
                        else
                        {
                            //_log.Debug($"Hit jump limit, not going further");
                        }
                    }

                    // Make the next stack the current stack
                    systemCheckStack = systemCheckStackNext;
                }
            }

            // Scan for routes
            _log.Info("Starting scan for routes");

            TradeMapSystemCollection systemsToRoute;

            if (options.StartSystems.Count == 0)
            {
                // No systems specified, do them all
                systemsToRoute = systemCollection;
            }
            else
            {
                // Systems are specified.
                // Resolve them to systems
                systemsToRoute = new TradeMapSystemCollection();
                foreach (var system in map.Systems)
                {
                    if (options.StartSystems.Contains(system.Name.ToLower()))
                        systemsToRoute.Add(system);
                }
            }

            for (var iSS = 0; iSS < systemsToRoute.Count; iSS++)
            {
                ct.ThrowIfCancellationRequested();
                var startSystem = systemsToRoute[iSS];

                DoProgress(new ProgressEventArgs(iSS, systemsToRoute.Count, ProgressEventStatus.Working, $"Scanning routes for '{startSystem.Name}' ({iSS+1}/{systemsToRoute.Count})"));
                ScanForRoutes(startSystem, r.AllRoutes, options);
            }

            //DoProgress(new ProgressEventArgs(ProgressEventStatus.Complete, $"Route scanning complete"));
            _working = false;
            return r;
        }

        private void ScanForRuns(TradeMapSystem startSystem, TradeMapSystem destinationSystem, int jumpsAway, RouteScannerRunCollection runCollection, RouteScannerOptions options)
        {

            // Go through each comodity sold here, and compare against all 
            //_log.Debug($"Scanning for profitable runs between '{startSystem.Name}' and '{destinationSystem.Name}'");
            foreach (var startComodity in startSystem.Comodities)
            {
                foreach (var destComodity in destinationSystem.Comodities)
                {
                    _ct.ThrowIfCancellationRequested();
                    if (startComodity.Name == destComodity.Name)
                    {
                        // Comodity matches
                        // Compare prices
                        var profit = destComodity.Price - startComodity.Price;
                        if (profit >= options.MinProfitPerUnit)
                        {
                            // Profit is over threshold
                            var newRun = new RouteScannerRun()
                            {
                                Comodity = startComodity.Name,
                                StartSystem = startSystem,
                                StartSystemName = startSystem.Name,
                                EndSystem = destinationSystem,
                                EndSystemName = destinationSystem.Name,
                                Profit = profit,
                                Jumps = jumpsAway
                            };

                            _log.Debug($"{newRun}");

                            // Add runs to the all runs collection
                            runCollection.Add(newRun);

                            // Add run to that system
                            startSystem.Runs.Add(newRun);
                        }
                    }
                }
            }
        }

        // Walk through runs to try and find profitable circular routes that start and end in the same system
        private void ScanForRoutes(TradeMapSystem startSystem, ICollection<RouteScannerRoute> routeCollection, RouteScannerOptions options)
        {
            _ct.ThrowIfCancellationRequested();
            _log.Info($"Scanning for profitable routes starting from '{startSystem.Name}'");
            var foundRoutes = new List<RouteScannerRoute>(); // Build a list of routes found
            Stack<RouteScannerRun> tradeRunStack = new Stack<RouteScannerRun>();
            Stack<Stack<RouteScannerRun>> tradeRunQueueStack = new Stack<Stack<RouteScannerRun>>();

            // Start off the run queue
            _log.Debug("Enqueuing start system's runs");
            var newQueueStack = new Stack<RouteScannerRun>();
            foreach (var run in startSystem.Runs)
            {
                _log.Debug($"Enqueuing run: {run}");
                newQueueStack.Push(run);
            }
            tradeRunQueueStack.Push(newQueueStack);

            // Work the queues, while there are queues to work
            while (tradeRunQueueStack.Count > 0)
            {
                _ct.ThrowIfCancellationRequested();
                _log.Debug($"tradeRunQueueStack: {tradeRunQueueStack.Count}");
                // Get the queue at the top of the stack
                var tradeRunQueue = tradeRunQueueStack.Peek();
                _log.Debug($"tradeRunQueue: {tradeRunQueue.Count}");

                // If the queue is empty, pop it, and go back down a level
                if (tradeRunQueue.Count <= 0)
                {
                    _log.Debug("tradeRunQueue empty for this step, going back a level");
                    tradeRunQueueStack.Pop();

                    if (tradeRunStack.Count > 0)
                    {
                        tradeRunStack.Pop();
                        continue;
                    }
                    else
                    {
                        // Hit the end, finished processing this start system
                        return;
                    }
                } 
                else
                {
                    // Have a queue to work on
                    // Take it from the queue
                    var thisRun = tradeRunQueue.Pop();

                    _log.Debug($"Checking run: {thisRun}");

                    // Don't double-back on runs. 
                    // If this run is already in the stack, don't scan it again.
                    if (tradeRunStack.Contains(thisRun))
                    {
                        _log.Debug("Already checked this run, skipping to avoid looped routes");
                        continue;
                    }

                    tradeRunStack.Push(thisRun);

                    // If this trade run ends at the start system, it's good.
                    // Save it as a route
                    if (thisRun.EndSystem.Name == startSystem.Name)
                    {
                        _log.Debug("Route ends back at start, this is a complete route");

                        var newTradeRoute = new RouteScannerRoute();
                        foreach (var run in tradeRunStack.ToArray().Reverse())
                        {
                            newTradeRoute.StartSystem = startSystem;
                            newTradeRoute.Runs.Add(run);
                        }
                        UpdateRoute(newTradeRoute);

                        if (newTradeRoute.Score < options.MinRouteScore)
                        {
                            _log.Debug($"Ignoring route, score {newTradeRoute.Score} min {options.MinRouteScore}");
                        } 
                        else if (routeCollection.FirstOrDefault(r => r.Hash == newTradeRoute.Hash) != null)
                        {
                            _log.Debug($"Ignoring route, similar route already found");
                        }
                        else if (options.SingleRoutePerStartSystem)
                        {
                            // Check that a route doesn't already exist for this system
                            var currentRouteForStartSystem = routeCollection.FirstOrDefault(r => r.StartSystem == startSystem);
                            if (currentRouteForStartSystem != null)
                            {
                                if (currentRouteForStartSystem.Score >= newTradeRoute.Score)
                                {
                                    _log.Debug("Ignoring route, single route mode active and new route scored less than existing route");
                                }
                                else
                                {
                                    _log.Debug("New route more profitable than existing route");
                                    routeCollection.Remove(currentRouteForStartSystem);
                                    routeCollection.Add(newTradeRoute);
                                }
                            }
                            else
                            {
                                routeCollection.Add(newTradeRoute);
                            }
                        }
                        else
                        {
                            _log.Debug("Saving route");
                            routeCollection.Add(newTradeRoute);
                        }

                        // Don't try to walk further than this.
                        //tradeRunQueueStack.Pop();
                        tradeRunStack.Pop();
                        continue;
                    }

                    // If we haven't hit the run limit, see if there's any runs to walk through from this system
                    if (tradeRunStack.Count < options.RouteMaxStops)
                    {
                        _log.Debug($"{tradeRunStack.Count} is under the stop limit {options.RouteMaxStops}, enqueuing this stop's trade runs");
                        // Add a new trade run queue to the queue stack
                        newQueueStack = new Stack<RouteScannerRun>();
                        foreach (var nextRun in thisRun.EndSystem.Runs)
                        {
                            if (!options.AllowSameStopBuySell && nextRun.Comodity == thisRun.Comodity)
                            {
                                // Don't buy the comodity that you just sold
                                _log.Debug("Skipping this run, don't buy what was just sold");
                                continue;
                            }

                            _log.Debug($"Enqueuing run: {nextRun}");
                            newQueueStack.Push(nextRun);
                        }

                        if (newQueueStack.Count > 0)
                            tradeRunQueueStack.Push(newQueueStack);
                        else
                        {
                            _log.Debug("No more runs from this system");
                            tradeRunStack.Pop();
                            continue;
                        }
                    } 
                    else
                    {
                        _log.Debug($"Stop limit {options.RouteMaxStops} has been met, not looking any deeper");
                        tradeRunStack.Pop();
                    }
                }
            } // End of worker loop
        }

        private RouteScannerRoute UpdateRoute(RouteScannerRoute route)
        {
            UpdateRouteHash(route);

            int totalProfit = 0;
            int totalJumps = 0;
            float pps = 0.0f;
            float ppj = 0.0f;
            foreach (var run in route.Runs)
            {
                totalProfit += run.Profit;
                totalJumps += run.Jumps;
            }

            pps = totalProfit / route.Runs.Count;
            ppj = totalProfit / totalJumps;

            route.TotalProfit = totalProfit;
            route.TotalJumps = totalJumps;
            route.ProfitPerRun = pps;
            route.ProfitPerJump = ppj;

            UpdateRouteScore(route);


            return route;
        }

        private RouteScannerRoute UpdateRouteScore(RouteScannerRoute route)
        {
            route.ScoreTrail.Clear();

            // Start the score with the profit per run
            float score = route.ProfitPerRun;
            route.ScoreTrail.Add($"Base score: {score}");

            // Apply weight per run
            // Use an exponential type equasion. A little more is a little weight, a lot more is a LOT of weight.
            int runCountWeight = (route.Runs.Count * _options.ScoreWeightPerRun) * route.Runs.Count;
            score += runCountWeight;
            route.ScoreTrail.Add($"Route length score: {runCountWeight}");

            // Apply weight per duplicate trades
            int duplicateTradeCount = 0;
            var seenTrades = new List<string>();
            foreach (var run in route.Runs)
            {
                var buyTrade = $"b;{run.StartSystemName};{run.Comodity}";
                var sellTrade = $"s;{run.EndSystemName};{run.Comodity}";

                if (seenTrades.Contains(buyTrade))
                    duplicateTradeCount++;
                else
                    seenTrades.Add(buyTrade);

                if (seenTrades.Contains(sellTrade))
                    duplicateTradeCount++;
                else
                    seenTrades.Add(sellTrade);
            }
            int duplicateTradeWeight = duplicateTradeCount * _options.ScoreWeightPerDuplicateTrade;
            score += duplicateTradeWeight;
            route.ScoreTrail.Add($"Repeat trade score: {duplicateTradeWeight}");

            route.Score = score;

            return route;
        }

        private RouteScannerRoute UpdateRouteHash(RouteScannerRoute route)
        {
            // Generate a hash of the runs in the route.
            // A route that has the same runs but in a different order should result in the same hash.

            // Create the string
            var runs = new List<string>();
            foreach (var run in route.Runs)
            {
                runs.Add($"{run.StartSystemName},{run.EndSystemName},{run.Comodity}");
            }
            runs.Sort();

            // MD5 it
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(string.Join("|", runs));
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                route.Hash = sb.ToString();
            }

            return route;
        }

        private TradeMapSystemCollection GetSystemsInJumpRange(TradeMap map, TradeMapSystem startSystem, TradeMapSystemCollection systemCollection, int jumpRange)
        {
            // Traverse outwards from the start system using links.
            // Build a collection of systems within the specified jump radius from the start system

            TradeMapSystemCollection seenSystems = new TradeMapSystemCollection();
            if (!systemCollection.Contains(startSystem)) systemCollection.Add(startSystem);
            Stack<TradeMapSystem> systemStack = new Stack<TradeMapSystem>();
            systemStack.Push(startSystem);
            Stack<TradeMapSystem> nextSystemStack;

            int jumpCount = 1;
            while (jumpCount <= jumpRange && systemStack.Count > 0)
            {
                // Start the next stack
                nextSystemStack = new Stack<TradeMapSystem>();

                // Add all of the linked systems
                while (systemStack.Count > 0)
                {
                    var thisSystem = systemStack.Pop();
                    if (seenSystems.Contains(thisSystem)) continue;

                    foreach (var link in thisSystem.Links)
                    {
                        if (link.System == null) continue;
                        if (link.System == startSystem) continue; // Ignore it if it's start system

                        // Good link
                        nextSystemStack.Push(link.System);
                        if (!systemCollection.Contains(link.System)) systemCollection.Add(link.System);
                        seenSystems.Add(thisSystem);
                    }
                }

                // Done with stack, ready the next stack
                systemStack = nextSystemStack;

                jumpCount++;
            }

            return systemCollection;
        }
    }
}
