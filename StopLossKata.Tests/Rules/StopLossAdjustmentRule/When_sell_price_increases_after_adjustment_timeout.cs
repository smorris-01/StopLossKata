using System;
using FluentAssertions;
using NUnit.Framework;
using StopLossKata.Messages;

namespace StopLossKata.Tests.Rules.StopLossAdjustmentRule
{
    [TestFixture]
    public class When_sell_price_increases_after_adjustment_timeout
    {
        private StopLossKata.Rules.StopLossAdjustmentRule _rule;

        private TimeSpan _timeout = new TimeSpan(0, 0, 15);

        private PositionAcquiredMessage _positionAcquiredMessage = 
            new PositionAcquiredMessage 
            { Price = new Price { Timestamp = DateTime.MinValue, Value = 10m}};

        private PriceChangedMessage _priceIncreasedAfterTimeoutMessage =
            new PriceChangedMessage 
            { Price = new Price { Timestamp = DateTime.MinValue.AddSeconds(15), Value = 11m } };


        [SetUp]
        public void Setup()
        {
            _rule = new StopLossKata.Rules.StopLossAdjustmentRule();
            _rule.Timeout = _timeout;
            _rule.Handle(_positionAcquiredMessage);
            _rule.Handle(_priceIncreasedAfterTimeoutMessage);
        }
  
        [Test]
        public void Then_a_new_position_should_be_acquired()
        {
            _rule.Position.Should().NotBe(_positionAcquiredMessage);
        }

        [Test]
        public void Then_the_new_position_price_should_be_the_new_price()
        {
            _rule.Position.Price.Should().Be(_priceIncreasedAfterTimeoutMessage.Price);
        }

    }
}