using EndlessSky.TradeRouteScanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class RouteScanner
    {
        public void Scan(TradeMap map)
        {
            return Scan(map, new RouteScannerOptions());
        }

        public void Scan(TradeMap map, RouteScannerOptions options)
        {
            var r = new RouteScannerResults();

            // Build a list of profitable runs
            // Loop through systems
            // Get list of systems within the max jump limit
            // Go through each system in the list, compare comodity prices
            // If the price is greater than the desired threshold, add it to the run list

            foreach (var system in map.Systems)
            {
                List<TradeMapSystem> systemsInRange = new List<TradeMapSystem>();
                Stack<TradeMapSystem> systemCheckStack = new Stack<TradeMapSystem>();

                // Add this system's links to the "to do" stack
                systemCheckStack.
            }
        }
    }
}
