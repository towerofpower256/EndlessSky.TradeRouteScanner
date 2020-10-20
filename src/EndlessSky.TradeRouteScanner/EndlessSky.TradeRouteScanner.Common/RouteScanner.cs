using EndlessSky.TradeRouteScanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class RouteScanner
    {
        public RouteScannerResults Scan(TradeMap map)
        {
            return Scan(map, new RouteScannerOptions());
        }

        public RouteScannerResults Scan(TradeMap map, RouteScannerOptions options)
        {
            var r = new RouteScannerResults();

            // Build a list of profitable runs
            // Loop through systems
            // Get list of systems within the max jump limit
            // Go through each system in the list, compare comodity prices
            // If the price is greater than the desired threshold, add it to the run list

            foreach (var startSystem in map.Systems)
            {
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
                            foreach (var link in destSystem.Links)
                            {
                                if (link.System == null) continue;
                                if (link.System == startSystem) continue; // Ignore it if it's start system
                                if (seenSystems.Contains(link.System)) continue;

                                // New system
                                seenSystems.Add(link.System);
                                systemsInRange.Add(link.System);
                                systemCheckStackNext.Push(link.System);
                            }
                        }
                    }

                    // Make the next stack the current stack
                    systemCheckStack = systemCheckStackNext;
                }
            }

            return r;
        }

        private void ScanForRuns(TradeMapSystem startSystem, TradeMapSystem destinationSystem, int jumpsAway, RouteScannerRunCollection runCollection, RouteScannerOptions options)
        {

            // Go through each comodity sold here, and compare against all 
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
        private void ScanForRoutes(TradeMapSystem startSystem, RouteScannerOptions options)
        {
            List<TradeMapSystem> seenSystems = new List<TradeMapSystem>();
            Stack<RouteScannerRun> routeStack = new Stack<RouteScannerRun>();
            
            foreach (var run in startSystem.Runs)
            {

            }
        }
    }
}
