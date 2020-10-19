using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    public class DefNode
    {
        public DefTokenCollection Tokens { get; set; }

        public DefNodeCollection ChildNodes { get; set; }
    }
}
