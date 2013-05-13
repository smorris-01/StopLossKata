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

            Result = Rule.ShouldSell(sellPrice, currentPrice, SellTimeout);
        }
    }
}