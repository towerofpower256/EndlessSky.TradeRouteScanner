using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    [Serializable]
    public class TradeMapComodity
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Price}";
        }
    }
}
