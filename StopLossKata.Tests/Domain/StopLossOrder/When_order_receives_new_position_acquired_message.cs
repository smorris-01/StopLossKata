using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using StopLossKata.Messages;

namespace StopLossKata.Tests.Domain.StopLossOrder
{
    [TestFixture]
    public class When_order_receives_new_position_acquired_message
    {
        // TODO: handle list of  messages...
        
        private PositionAcquiredMessage message01 =
            new PositionAcquiredMessage
                {Price = new Price {Value = 10m, Timestamp = new DateTime(2000, 01, 01)}};

        private PositionAcquiredMessage message02 =
            new PositionAcquiredMessage 
            { Price = new Price { Value = 10m, Timestamp = new DateTime(2000, 01, 01).AddSeconds(1) } };
    

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
        public void Then_the_position_should_now_be_the_new_position()
        {
            _order.Position.Should().Be(message02);
        }
    }
}