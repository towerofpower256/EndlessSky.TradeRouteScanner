using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    public class RouteScannerRun
    {
        public string StartSystem { get; set; }

        public string EndSystem { get; set; }

        public string Comodity { get; set; }

        public int Value { get; set; }
    }
}
