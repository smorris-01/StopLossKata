using System;
using StopLossKata.Messages;

namespace StopLossKata.Tests.Rules.StopLossAdjustmentRule
{
    public abstract class RuleConcernForStopLossAdjustmentRule : StopLossAdjustmentRuleConcern<StopLossKata.Rules.StopLossAdjustmentRule>
    {
        protected override void When()
        {
            base.When();

            var sellPrice = new Price
                {
                    Value = SellPrice,
                    Timestamp = SellTimestamp,
                };

            var currentPrice = new Price
                {
                    Value = NewPrice,
                    Timestamp = NewTimestamp,
                };

            Result = Rule.ShouldAdjust(sellPrice, currentPrice, RuleTimeout);
        }
    }
}