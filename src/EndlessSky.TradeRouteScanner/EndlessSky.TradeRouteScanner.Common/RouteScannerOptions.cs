using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class RouteScannerOptions
    {
        public int MaxJumps { get; set; } = 3; // Max jumps from the start system

        public int MinProfitPerUnit { get; set; } = 100; // Min 100 credits per unit per trade
    }
}
