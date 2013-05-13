using System;
using StopLossKata.Messages;

namespace StopLossKata.Rules
{
    public class StopLossSellRule: IStopLossRule
    {
        private readonly TimeoutRule _timeoutRule;
        
        public StopLossSellRule()
        {
            _timeoutRule = new TimeoutRule();
        }


        public bool ShouldExecute(Price sellPrice, Price currentPrice, TimeSpan timeout)
        {
            if (currentPrice.Value < sellPrice.Value)
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
