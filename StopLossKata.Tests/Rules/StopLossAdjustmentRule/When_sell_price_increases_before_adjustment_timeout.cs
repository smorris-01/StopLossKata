using System;
using FluentAssertions;
using NUnit.Framework;
using StopLossKata.Messages;

namespace StopLossKata.Tests.Rules.StopLossAdjustmentRule
{
    public class When_sell_price_increases_before_adjustment_timeout
    {
        private StopLossKata.Rules.StopLossAdjustmentRule _rule;

        private TimeSpan _timeout = new TimeSpan(0, 0, 15);

        private PositionAcquiredMessage _positionAcquiredMessage =
            new PositionAcquiredMessage { Price = new Price { Timestamp = DateTime.MinValue, Value = 10m } };

        private PriceChangedMessage _priceIncreasedBeforeTimeoutMessage =
            new PriceChangedMessage { Price = new Price { Timestamp = DateTime.MinValue, Value = 11m } };


        [SetUp]
        public void Setup()
        {
            _rule = new StopLossKata.Rules.StopLossAdjustmentRule();
            _rule.Timeout = _timeout;
            _rule.Handle(_positionAcquiredMessage);
            _rule.Handle(_priceIncreasedBeforeTimeoutMessage);
        }

        [Test]
        public void Then_the_position_should_remain_unchanged()
        {
            _rule.Position.Should().Be(_positionAcquiredMessage);
        }

        [Test]
        public void Then_the_position_price_should_remain_unchanged()
        {
            _rule.Position.Price.Should().Be(_positionAcquiredMessage.Price);
        }

    }
}