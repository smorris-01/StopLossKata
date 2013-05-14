using System;
using FluentAssertions;
using NUnit.Framework;
using StopLossKata.Messages;

namespace StopLossKata.Tests.Rules.StopLossSellRule
{
    public class When_sell_price_increases_after_sell_timeout 
    {
        private StopLossKata.Rules.StopLossSellRule _rule;

        private const int TimeoutSeconds = 10;
        private TimeSpan _timeout = new TimeSpan(0, 0, TimeoutSeconds);

        private const decimal Price = 20m;

        private PositionAcquiredMessage _positionAcquiredMessage = new PositionAcquiredMessage 
        { Price = new Price { Timestamp = DateTime.MinValue, Value = Price } };

        private PriceChangedMessage _priceIncreasedAfterTimeoutMessage = new PriceChangedMessage 
        { Price = new Price { Timestamp = DateTime.MinValue.AddSeconds(TimeoutSeconds + 1), Value = Price + 1 } };


        [SetUp]
        public void Setup()
        {
            _rule = new StopLossKata.Rules.StopLossSellRule();
            _rule.Timeout = _timeout;
            _rule.Handle(_positionAcquiredMessage);
            _rule.Handle(_priceIncreasedAfterTimeoutMessage);
        }
 
        [Test]
        public void Then_position_should_have_changed()
        {
            _rule.Position.Should().NotBe(_positionAcquiredMessage);
        }

        [Test]
        public void Then_position_price_should_be_new_price()
        {
            _rule.Position.Price.Should().Be(_priceIncreasedAfterTimeoutMessage.Price);
        }

    }
}