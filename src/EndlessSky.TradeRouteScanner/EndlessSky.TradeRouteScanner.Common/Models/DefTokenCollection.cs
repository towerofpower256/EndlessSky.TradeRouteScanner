using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    [Serializable]
    public class DefTokenCollection : List<string>
    {
        public DefTokenCollection Add(string a)
        {
            base.Add(a);
            return this;
        }
    }
}
