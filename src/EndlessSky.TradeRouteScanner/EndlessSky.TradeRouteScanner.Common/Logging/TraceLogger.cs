using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Tracing;
using System.Diagnostics;

namespace EndlessSky.TradeRouteScanner.Common.Logging
{
    public class TraceLogger : ILogger
    {
        public void Debug(string msg)
        {
            Trace.TraceInformation("DEBUG " + msg);
        }

        public void Error(string msg)
        {
            Trace.TraceError(msg);
        }

        public void Info(string msg)
        {
            Trace.TraceInformation(msg);
        }

        public void Warn(string msg)
        {
            Trace.TraceWarning(msg);
        }
    }
}
