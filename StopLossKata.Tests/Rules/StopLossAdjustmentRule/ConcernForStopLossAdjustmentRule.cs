using System;
using StopLossKata.Messages;
using StopLossKata.Tests.Rules;

namespace StopLossKata.Tests.Domain.StopLossOrder.Adjust
{
    public abstract class RuleConcernForStopLossAdjustmentRule : StopLossAdjustmentRuleConcern<StopLossKata.Rules.StopLossAdjustmentRule>
    {
        protected TimeSpan AdjustmentTimeout;

        
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

            Result = Rule.ShouldAdjust(sellPosition, message, AdjustmentTimeout);
        }
    }
}