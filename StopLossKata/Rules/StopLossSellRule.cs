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


        public bool ShouldSell(Position sellPosition, PriceChangedMessage priceChangedMessage)
        {

            if (_timeoutRule.HasTimeoutExpired(sellPosition.Timestamp,
                                                 priceChangedMessage.Timestamp,
                                                 sellPosition.Timeout))
            {
                if (priceChangedMessage.Price < sellPosition.Price)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
