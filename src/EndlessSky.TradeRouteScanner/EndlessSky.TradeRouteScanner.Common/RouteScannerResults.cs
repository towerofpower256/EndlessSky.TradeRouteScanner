using EndlessSky.TradeRouteScanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class RouteScannerResults
    {
        public RouteScannerRunCollection AllRuns { get; set; } = new RouteScannerRunCollection();
    }
}
