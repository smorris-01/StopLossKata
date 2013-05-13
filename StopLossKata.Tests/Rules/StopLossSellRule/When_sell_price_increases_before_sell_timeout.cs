using System;
using FluentAssertions;
using NUnit.Framework;

namespace StopLossKata.Tests.Domain.StopLossOrder.Sell
{
    public class When_sell_price_increases_before_sell_timeout : RuleConcernForStopLossSellRule
    {
        protected override void Given()
        {
            SellPrice = 10.0m;
            SellTimeout = new TimeSpan(0, 0, 15);
            PositionTimestamp = new DateTime(2000, 12, 13, 13, 01, 00);

            NewPrice = 9.5m;
            NewTimestamp = PositionTimestamp.Add(SellTimeout).AddSeconds(-1);

            base.Given();
        }

        [Test]
        public void Then_sell_should_not_be_pending()
        {
            Result.Should().Be(false);
        }

    }
}