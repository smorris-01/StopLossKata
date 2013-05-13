using System;
using FluentAssertions;
using NUnit.Framework;

namespace StopLossKata.Tests.Rules.StopLossSellRule
{
    public class When_sell_price_decreases_before_sell_timeout : ConcernForStopLossSellRule
    {
        protected override void Given()
        {
            SellPrice = 10.0m;
            SellTimestamp = new DateTime(2000, 12, 13, 13, 01, 00);

            RuleTimeout = new TimeSpan(0, 0, 15);

            NewPrice = 9.5m;
            NewTimestamp = SellTimestamp.Add(RuleTimeout).AddSeconds(-1);

            base.Given();
        }

        [Test]
        public void Then_sell_should_not_be_pending()
        {
            Result.Should().Be(false);
        }

    }
}