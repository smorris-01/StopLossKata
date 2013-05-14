using System;
using FluentAssertions;
using NUnit.Framework;
using StopLossKata.Messages;

namespace StopLossKata.Tests.Rules.StopLossSellRule
{
    public class When_sell_price_decreases_after_sell_timeout
    {
        private StopLossKata.Rules.StopLossSellRule _rule;

        private const int TimeoutSeconds = 10;
        private TimeSpan _timeout = new TimeSpan(0, 0, TimeoutSeconds);

        private const decimal Price = 20m;
        
        private PositionAcquiredMessage _positionAcquiredMessage =
            new PositionAcquiredMessage 
            { Price = new Price { Timestamp = DateTime.MinValue, Value = Price } };

        private PriceChangedMessage _priceDecreasedAfterTimeoutMessage =
            new PriceChangedMessage 
            { Price = new Price { Timestamp = DateTime.MinValue.AddSeconds(TimeoutSeconds + 1), Value = Price - 1 } };


        [SetUp]
        public void Setup()
        {
            _rule = new StopLossKata.Rules.StopLossSellRule();
            _rule.Timeout = _timeout;
            _rule.Handle(_positionAcquiredMessage);
            _rule.Handle(_priceDecreasedAfterTimeoutMessage);
        }


        [Test]
        public void Then_position_should_remain_unchanged()
        {
            _rule.Position.Should().Be(_positionAcquiredMessage);
        }

    }
}