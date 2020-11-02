using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    [Serializable]
    public class TradeMap
    {
        public TradeMapSystemCollection Systems { get; set; } = new TradeMapSystemCollection();

        public TradeMapPlanetCollection Planets { get; set; } = new TradeMapPlanetCollection();
    }
}
