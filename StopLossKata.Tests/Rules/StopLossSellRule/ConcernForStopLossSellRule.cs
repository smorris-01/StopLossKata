using System;
using StopLossKata.Messages;
using StopLossKata.Tests.Rules;

namespace StopLossKata.Tests.Domain.StopLossOrder.Sell
{
    public abstract class RuleConcernForStopLossSellRule: StopLossAdjustmentRuleConcern<StopLossKata.Rules.StopLossSellRule>
    {
        protected decimal SellPrice;
        protected TimeSpan SellTimeout;
        protected DateTime PositionTimestamp;
        
        protected decimal NewPrice;
        protected DateTime NewTimestamp;

        protected bool? Result = null;

        
        protected override void When()
        {
            base.When();

            var sellPosition = new Position
            {
                Price = SellPrice,
                Timeout = SellTimeout,
                Timestamp = PositionTimestamp,
            };

            var message = new PriceChangedMessage
            {
                Price = NewPrice,
                Timestamp = NewTimestamp,
            };

            Result = Rule.ShouldSell(sellPosition, message);
        }
    }
}