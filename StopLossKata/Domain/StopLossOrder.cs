using System;
using StopLossKata.Messages;
using StopLossKata.Rules;

namespace StopLossKata.Domain
{
    public class StopLossOrder: IStopLossOrder
    {
        internal Rules.StopLossAdjustmentRule AdjustmentRule { get; private set; }

        public PositionAcquiredMessage Position { get; private set; }
        
        private TimeSpan _sellTimeout;

        public StopLossOrder()
        {
            // TODO: constructor injection
            AdjustmentRule = new StopLossAdjustmentRule();
        }


        public void Handle(PositionAcquiredMessage message)
        {
            Position = message;
            // TODO: remove delegation when messages are on a bus
            AdjustmentRule.Handle(message);
        }

        public void Handle(PriceChangedMessage message)
        {
            throw new NotImplementedException();
        }


        //public void Handle(PriceChangedMessage message)
        //{
        //    if (SellRule.ShouldExecute(Position.Price, message.Price, _sellTimeout))
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
