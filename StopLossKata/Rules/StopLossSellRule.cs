using System;
using StopLossKata.Messages;

namespace StopLossKata.Rules
{
    public class StopLossSellRule
    {
        private readonly TimeoutRule _timeoutRule;
        
        public StopLossSellRule()
        {
            _timeoutRule = new TimeoutRule();
        }


        public bool ShouldSell(Price sellPrice, Price currentPrice, TimeSpan sellTimeout)
        {
            if (currentPrice.Value < sellPrice.Value)
            {
                if (_timeoutRule.HasTimeoutExpired(sellPrice.Timestamp, currentPrice.Timestamp, sellTimeout))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
