using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    public class RouteScannerRun
    {
        public string StartSystemName { get; set; }

        public TradeMapSystem StartSystem { get; set; }

        public string EndSystemName { get; set; }

        public TradeMapSystem EndSystem { get; set; }

        public string Comodity { get; set; }

        public int Profit { get; set; }

        public int Jumps { get; set; }
    }
}
