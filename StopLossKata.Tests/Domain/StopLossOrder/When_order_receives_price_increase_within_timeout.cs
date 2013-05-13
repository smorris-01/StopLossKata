using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using StopLossKata.Messages;

namespace StopLossKata.Tests.Domain.StopLossOrder
{
    [TestFixture]
    public class When_order_receives_price_increase_within_timeout
    {
        

        // TODO: handle list of  messages...
        //private IList<PriceMessage> _messages = new List<PriceMessage>
        //    {
        //        new PositionAcquiredMessage 
        //        { Price = new Price { Value = 10m, Timestamp = new DateTime(2000, 01, 01)}},
        //        new PriceChangedMessage
        //        { Price = new Price { Value = 10.1m, Timestamp = new DateTime(2000, 01, 01).AddSeconds(1)}},
        //    };

        private PositionAcquiredMessage message01 =
            new PositionAcquiredMessage
                {Price = new Price {Value = 10m, Timestamp = new DateTime(2000, 01, 01)}};

        private PriceChangedMessage message02 =
            new PriceChangedMessage
                {Price = new Price {Value = 10.1m, Timestamp = new DateTime(2000, 01, 01).AddSeconds(1)}};
            

        private StopLossKata.Domain.StopLossOrder _order;

        [SetUp]
        public void Setup()
        {
            _order = new StopLossKata.Domain.StopLossOrder();
            
            // TODO: handle list of messages
            _order.Handle(message01);
            _order.Handle(message02);
        }

        [Test]
        public void Then_the_original_position_should_remain_unchanged()
        {
            _order.Position.Should().Be(message01);
        }

    }
}