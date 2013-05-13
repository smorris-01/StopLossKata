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

            var sellPrice = new Price
                {
                    Value = SellPrice,
                    Timestamp = PositionTimestamp,
                };

            var currentPrice = new Price
                {
                    Value = NewPrice,
                    Timestamp = NewTimestamp,
                };

            Result = Rule.ShouldAdjust(sellPrice, currentPrice, AdjustmentTimeout);
        }
    }
}