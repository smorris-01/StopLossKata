using System;
using FluentAssertions;
using NUnit.Framework;

namespace StopLossKata.Tests.Domain.StopLossOrder.Adjust
{
    public class When_sell_price_increases_after_adjustment_timeout : RuleConcernForStopLossAdjustmentRule
    {
        protected override void Given()
        {
            SellPrice = 10.0m;
            AdjustmentTimeout = new TimeSpan(0, 0, 15);
            PositionTimestamp = new DateTime(2000, 12, 13, 13, 01, 00);

            NewPrice = 10.5m;
            NewTimestamp = PositionTimestamp.Add(AdjustmentTimeout);
            
            base.Given();
        }

        [Test]
        public void Then_adjustment_should_be_pending()
        {
            Result.Should().Be(true);
        }
    }
}