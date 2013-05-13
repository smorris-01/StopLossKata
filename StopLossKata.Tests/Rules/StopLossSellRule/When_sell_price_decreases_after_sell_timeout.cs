using System;
using FluentAssertions;
using NUnit.Framework;

namespace StopLossKata.Tests.Rules.StopLossSellRule
{
    public class When_sell_price_decreases_after_sell_timeout : RuleConcernForStopLossSellRule
    {
        protected override void Given()
        {
            SellPrice = 10.0m;
            SellTimestamp = new DateTime(2000, 12, 13, 13, 01, 00);

            RuleTimeout = new TimeSpan(0, 0, 15);

            NewPrice = 9.5m;
            NewTimestamp = SellTimestamp.Add(RuleTimeout);

            base.Given();
        }
 
        [Test]
        public void Then_sell_should_be_pending()
        {
            Result.Should().Be(true);
        }

    }
}