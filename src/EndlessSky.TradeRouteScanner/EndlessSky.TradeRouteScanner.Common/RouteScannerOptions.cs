using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class RouteScannerOptions
    {
        public int RunMaxJumps { get; set; } = 3; // Max jumps from the start system

        public int RouteMaxStops { get; set; } = 5; // Max number of stops a route can have

        public int MinProfitPerUnit { get; set; } = 100; // Min credits per unit per trade

        public int MinProfitPerRouteRun { get; set; } = 0; // The route's profit must be (number of runs x min profit per route run) minimum

        public int MinRouteScore { get; set; } = 0; // Min score for an acceptable route

        public bool AllowSameStopBuySell { get; set; } = false; // Allow buying the comodity that you just sold at the same system

        public bool SingleRoutePerStartSystem { get; set; } = false; // Only allow 1 route per system, the highest scored.

        public int ScoreWeightPerRun { get; set; } = 5; // Bonus or penalty added to the score per stop.

        public int ScoreWeightPerDuplicateTrade { get; set; } = -20; // Buying / selling the same comodity at the same place affects the market negatively. Weight duplicate trades, typically to penalise them.

        public Collection<string> StartSystems { get; private set; } = new Collection<string>(); // List of systems to start the route scanner from

        public Dictionary<string, int> MapBounds { get; private set; } = new Dictionary<string, int>();
    }
}
