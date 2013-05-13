using System;
using StopLossKata.Messages;

namespace StopLossKata.Tests.Rules.StopLossSellRule
{
    public abstract class ConcernForStopLossSellRule: ConcernForStopLossRule<StopLossKata.Rules.StopLossSellRule>
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

            Result = Rule.ShouldExecute(sellPrice, currentPrice, RuleTimeout);
        }
    }
}