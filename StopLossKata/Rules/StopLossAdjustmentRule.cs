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


        public bool ShouldExecute (Price sellPrice, Price currentPrice, TimeSpan timeout)
        {
            if (sellPrice.Value < currentPrice.Value)
            {
                if (_timeoutRule.HasTimeoutExpired(sellPrice.Timestamp, currentPrice.Timestamp, timeout))
                {
                    return true;
                }
            }
            return false;
        }
    }
}