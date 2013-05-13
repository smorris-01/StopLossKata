using System;
using NSubstitute;
using NSubstitute.Exceptions;
using NUnit.Framework;
using StopLossKata.Messages;
using StopLossKata.Rules;
using Target = StopLossKata;

namespace StopLossKata.Tests.Domain.StopLossOrderBroker
{
    [TestFixture]
    public class When_broker_should_execute_sale
    {
        private Target.Domain.StopLossOrderBroker _broker;

        private Price _oldPrice = new Price
            {
                Value = 123m,
                Timestamp = DateTime.MinValue,
            };

        private Price _newPrice = new Price
            {
                Value = 321m,
                Timestamp = DateTime.MaxValue,
            };


        public void Setup()
        {
            _broker = new Target.Domain.StopLossOrderBroker();
            
            var substituteRule = Substitute.For<IStopLossRule>();
            substituteRule.ShouldExecute(Arg.Any<Price>(), Arg.Any<Price>(), Arg.Any<TimeSpan>()).Returns(true);
            _broker.SellRule = substituteRule;

            var positionAcquiredMessage = new PositionAcquiredMessage { Price = _oldPrice};
            _broker.Handle(positionAcquiredMessage);

            var priceChangedMessage = new PriceChangedMessage { Price = _newPrice };
            _broker.Handle(priceChangedMessage);
        }
        
        [Test]
        public void Then_a_new_position_is_acquired()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Then_the_new_position_should_reflect_the_new_price()
        {
            throw new NotImplementedException();
        }

    }
}