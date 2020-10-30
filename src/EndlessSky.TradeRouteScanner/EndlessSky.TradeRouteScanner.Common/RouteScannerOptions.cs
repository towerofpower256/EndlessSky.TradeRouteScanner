using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class RouteScannerOptions
    {
        public int RunMaxJumps { get; set; } = 3; // Max jumps from the start system

        public int RouteMaxStops { get; set; } = 5; // Max number of stops a route can have

        public int MinProfitPerUnit { get; set; } = 150; // Min credits per unit per trade

        public int MinProfitPerRouteRun { get; set; } = 150; // The route's profit must be (number of runs x min profit per route run) minimum

        public int MinRouteScore { get; set; } = 220; // Min score for an acceptable route
    }
}
