using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    public class TradeMapSystem
    {
        public string Name { get; set; }

        public Collection<TradeMapSystemLink> Links { get; set; } = new Collection<TradeMapSystemLink>();

        public List<TradeMapComodity> Comodities { get; set; } = new List<TradeMapComodity>();

        public RouteScannerRunCollection Runs { get; set; } = new RouteScannerRunCollection();

        public List<string> NamedObjects { get; set; } = new List<string>();

        public bool CanTrade { get; set; } = false;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
