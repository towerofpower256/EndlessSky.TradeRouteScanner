using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class ProgressEventSource
    {
        public event EventHandler<ProgressEventArgs> ProgressEvent;

        public void DoEvent(object sender, ProgressEventArgs args)
        {
            ProgressEvent?.Invoke(sender, args);
        }
    }
}
