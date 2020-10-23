using EndlessSky.TradeRouteScanner.Common.Logging;
using EndlessSky.TradeRouteScanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class RouteScanner
    {
        ILogger _log;

        public RouteScanner()
        {
            _log = new DummyLogger();
        }

        public void SetLogging(ILogger log)
        {
            _log = log;
        }

        public RouteScannerResults Scan(TradeMap map)
        {
            return Scan(map, new RouteScannerOptions());
        }

        public RouteScannerResults Scan(TradeMap map, RouteScannerOptions options)
        {
            _log.Info("Starting route scan");
            _log.Debug($"RunMaxJumps: {options.RunMaxJumps}");
            _log.Debug($"RouteMaxStops: {options.RouteMaxStops}");
            _log.Debug($"MinProfitPerUnit: {options.MinProfitPerUnit}");
            _log.Debug($"MinProfitPerRouteRun: {options.MinProfitPerRouteRun}");

            var r = new RouteScannerResults();

            // Build a list of profitable runs
            // Loop through systems
            // Get list of systems within the max jump limit
            // Go through each system in the list, compare comodity prices
            // If the price is greater than the desired threshold, add it to the run list

            foreach (var startSystem in map.Systems)
            {
                _log.Debug($"Scanning runs for system: {startSystem.Name}");
                // Clear this system's runs, in case
                startSystem.Runs.Clear();
                List<TradeMapSystem> seenSystems = new List<TradeMapSystem>();
                List<TradeMapSystem> systemsInRange = new List<TradeMapSystem>();
                Stack<TradeMapSystem> systemCheckStack = new Stack<TradeMapSystem>();
                Stack<TradeMapSystem> systemCheckStackNext;

                // Add this system's links to the "to do" stack
                foreach (var link in startSystem.Links)
                {
                    if (link.System == null) continue;
                    if (link.System == startSystem) continue; // Ignore it if it's start system
                    systemsInRange.Add(link.System);
                    systemCheckStack.Push(link.System);
                }

                for (int jumpCount = 1; jumpCount <= options.RunMaxJumps; jumpCount++)
                {
                    //_log.Debug($"JUMP {jumpCount}");
                    systemCheckStackNext = new Stack<TradeMapSystem>(); // Ready to compile the next list of jumps

                    // Find new systems in the check stack
                    while (systemCheckStack.Count > 0)
                    {
                        var destSystem = systemCheckStack.Pop();

                        // Check for profitable runs to this system
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
            foreach (var startSystem in map.Systems)
            {
                ScanForRoutes(startSystem, r.AllRoutes, options);
            }

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
                _log.Debug($"tradeRunQueueStack: {tradeRunQueueStack.Count}");
                // Get the queue at the top of the stack
                var tradeRunQueue = tradeRunQueueStack.Peek();
                _log.Debug($"tradeRunQueue: {tradeRunQueue.Count}");

                // If the queue is empty, pop it, and go back down a level
                if (tradeRunQueue.Count <= 0)
                {
                    _log.Debug("tradeRunQueue empty for this step, going back a level");
                    tradeRunQueueStack.Pop();
                    tradeRunStack.Pop();
                    continue;
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
                        _log.Info("Route ends back at start, this is a complete route");

                        var newTradeRoute = new RouteScannerRoute();
                        foreach (var run in tradeRunStack.ToArray())
                        {
                            newTradeRoute.Runs.Add(run);
                            newTradeRoute.TotalProfit += run.Profit;
                        }

                        _log.Debug("Saving route");
                        routeCollection.Add(newTradeRoute);

                        // Don't try to walk further than this.
                        tradeRunQueueStack.Pop();
                        tradeRunStack.Pop();
                        continue;
                    }

                    // If we haven't hit the run limit, see if there's any runs to walk through from this system
                    if (tradeRunStack.Count < options.RouteMaxStops)
                    {
                        _log.Debug($"{tradeRunStack.Count} is under the stop limit {options.RouteMaxStops}, enqueuing this stop's trade runs");
                        // Add a new trade run queue to the queue stack
                        newQueueStack = new Stack<RouteScannerRun>();
                        foreach (var run in thisRun.EndSystem.Runs)
                        {
                            _log.Debug($"Enqueuing run: {run}");
                            newQueueStack.Push(run);
                        }
                        if (newQueueStack.Count > 0)
                            tradeRunQueueStack.Push(newQueueStack);
                        else
                        {
                            _log.Debug("This system doesn't have any runs, nothing enqueued");
                            tradeRunStack.Pop();
                        }
                    } 
                    else
                    {
                        _log.Debug($"Stop limit {options.RouteMaxStops} has been met, not looking any deeper");
                    }
                }
            } // End of worker loop
        }
    }
}
