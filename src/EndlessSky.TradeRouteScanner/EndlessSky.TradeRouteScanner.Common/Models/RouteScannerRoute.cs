using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    public class RouteScannerRoute
    {
        public RouteScannerRunCollection Runs { get; set; } = new RouteScannerRunCollection();

        public int TotalProfit { get; set; }

        public int TotalJumps { get; set; }

        public int TotalStops => Runs.Count;

        public float ProfitPerStop { get { return (float) TotalProfit / (float) TotalStops; } }

        public float ProfitPerJump { get { return (float)TotalProfit / (float)TotalJumps; } }
    }
}
