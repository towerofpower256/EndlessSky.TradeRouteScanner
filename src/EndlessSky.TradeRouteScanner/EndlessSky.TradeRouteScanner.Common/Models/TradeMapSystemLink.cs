using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    public class TradeMapSystemLink
    {
        public string Name { get; set; }

        public TradeMapSystem System { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
