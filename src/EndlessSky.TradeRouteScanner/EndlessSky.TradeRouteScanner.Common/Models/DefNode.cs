using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    [Serializable]
    public class DefNode
    {
        public DefTokenCollection Tokens { get; set; } = new DefTokenCollection();

        public DefNodeCollection ChildNodes { get; set; } = new DefNodeCollection();
    }
}
