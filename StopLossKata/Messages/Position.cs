using System;

namespace StopLossKata.Messages
{
    public class Position
    {
        public decimal Price  { get; set; }
        public TimeSpan Timeout { get; set; }
        public DateTime Timestamp { get; set; }
    }
}