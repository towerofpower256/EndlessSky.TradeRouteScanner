using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public interface ILogger
    {
        void Debug(string msg);
        void Info(string msg);
        void Warn(string msg);
        void Error(string msg);
    }
}
