using System;
using StopLossKata.Messages;
using StopLossKata.Rules;

namespace StopLossKata.Domain
{
    public class StopLossOrderBroker: IStopLossOrderBroker
    {
        internal IStopLossRule SellRule { get; set; }
        
        private Price _sellPrice;
        private Price _currentPrice;

        private TimeSpan _sellTimeout;
        
        public StopLossOrderBroker()
        {
            // TODO: constructor injection
            SellRule = new StopLossSellRule();
        }


        public void Handle(PositionAcquiredMessage message)
        {
            _sellPrice = message.Price;
        }

        public void Handle(PriceChangedMessage message)
        {
            _currentPrice = message.Price;
            
            if (SellRule.ShouldExecute(_sellPrice, _currentPrice, _sellTimeout))
            {
                throw new NotImplementedException();
            }
        }


        public bool ShouldSell()
        {
            throw new NotImplementedException();
        }

        public bool ShouldAdjust()
        {
            throw new NotImplementedException();     
        }
    }
}
