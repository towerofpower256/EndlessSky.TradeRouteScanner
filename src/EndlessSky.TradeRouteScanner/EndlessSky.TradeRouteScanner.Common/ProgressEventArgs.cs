using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class ProgressEventArgs : EventArgs
    {
        public bool ValueUpdate { get; set; } = false;

        public bool StatusUpdate { get; set; } = false;

        public int Value { get; set; } = 0;

        public int MaxValue { get; set; } = 0;

        public string Message { get; set; } = string.Empty;

        public ProgressEventStatus Status { get; set; } = ProgressEventStatus.Working;

        public ProgressEventArgs(string message)
        {
            Message = message;
        }

        public ProgressEventArgs(int value, int maxValue, string message)
        {
            Value = value;
            MaxValue = maxValue;
            Message = message;
            ValueUpdate = true;
        }

        public ProgressEventArgs(int value, int maxValue, ProgressEventStatus status, string message)
        {
            Value = value;
            MaxValue = maxValue;
            Status = status;
            Message = message;
            ValueUpdate = true;
            StatusUpdate = true;
        }

        public ProgressEventArgs(ProgressEventStatus status, string message)
        {
            Status = status;
            Message = message;
            StatusUpdate = true;
        }
    }

    public enum ProgressEventStatus
    {
        Working,
        Complete,
        Error
    }
}
