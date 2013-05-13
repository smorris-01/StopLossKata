using System;
using StopLossKata.Messages;

namespace StopLossKata.Rules
{
    public class StopLossAdjustmentRule
    {
        private readonly TimeoutRule _timeoutRule;

        public StopLossAdjustmentRule()
        {
            // TODO: dependency injection
            _timeoutRule = new TimeoutRule();
        }


        public bool ShouldAdjust (Position sellPosition, PriceChangedMessage priceChangedMessage, TimeSpan adjustmentTimeout)
        
        {
            if (_timeoutRule.HasTimeoutExpired(
                sellPosition.Timestamp, priceChangedMessage.Timestamp, adjustmentTimeout))
            {
                if (priceChangedMessage.Price > sellPosition.Price)
                {
                    return true;
                }
            }
            return false;
        }
    }
}