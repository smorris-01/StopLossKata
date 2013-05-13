using System;
using StopLossKata.Messages;
using StopLossKata.Rules;

namespace StopLossKata.Domain
{
    public class StopLossOrder: IStopLossOrder
    {
        internal IStopLossRule SellRule { get; set; }

        public PositionAcquiredMessage Position { get; private set; }
        
        private TimeSpan _sellTimeout;
        
        public StopLossOrder()
        {
            // TODO: constructor injection
            SellRule = new StopLossSellRule();
        }


        public void Handle(PositionAcquiredMessage message)
        {
            Position = message;
        }

        public void Handle(PriceChangedMessage message)
        {
            if (SellRule.ShouldExecute(Position.Price, message.Price, _sellTimeout))
            {
                throw new NotImplementedException();
            }
        }
    }
}
