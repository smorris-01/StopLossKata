using System;

namespace StopLossKata.Messages
{
    public class PositionAcquiredMessage
    {
        public Position SellPosition { get; set; }
        
        /// <summary>
        /// The amount of time to wait before increasing the sell price
        /// </summary>
        public TimeSpan AdjustmentTimeout { get; set; }
    }
}
