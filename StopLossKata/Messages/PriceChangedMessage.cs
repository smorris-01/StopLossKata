using System;

namespace StopLossKata.Messages
{
    public class PriceChangedMessage
    {
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }
    }
}