using System;
using FluentAssertions;
using NUnit.Framework;

namespace StopLossKata.Tests.Rules.StopLossAdjustmentRule
{
    public class When_sell_price_increases_before_adjustment_timeout : ConcernForStopLossRule<StopLossKata.Rules.StopLossAdjustmentRule>
    {
        protected override void Given()
        {
            base.Given();

            SellPrice = 10.0m;
            SellTimestamp = new DateTime(2000, 12, 13, 13, 01, 00);

            RuleTimeout = new TimeSpan(0, 0, 15);

            NewPrice = 10.5m;
            NewTimestamp = SellTimestamp.Add(RuleTimeout).AddSeconds(-1);
        }


        [Test]
        public void Then_adjustment_should_not_be_pending()
        {
            Result.Should().Be(false);
        }
    }
}