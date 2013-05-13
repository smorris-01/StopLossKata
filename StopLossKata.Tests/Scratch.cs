using System;
using System.Collections.Generic;
using NUnit.Framework;
using StopLossKata.Domain;
using StopLossKata.Messages;

namespace StopLossKata.Tests
{
    [TestFixture]
    class Scratch
    {
        class MessageInfo
        {
            public Type MessageType;
            public Price Price;
        }

        private IList<PriceMessage> _messages = new List<PriceMessage>
            {
                new PositionAcquiredMessage 
                { Price = new Price { Value = 10m, Timestamp = new DateTime(2000, 01, 01)}},
                new PriceChangedMessage
                { Price = new Price { Value = 10.1m, Timestamp = new DateTime(2000, 01, 01).AddSeconds(1)}},
            };

        private StopLossKata.Domain.StopLossOrder _order = new StopLossOrder();


        [Test]
        public void Run()
        {
            //foreach (var message in _messages)
            //{
            //    _order.Handle(message);
            //}

            var messageInfo = new MessageInfo
                {
                    MessageType = typeof(PositionAcquiredMessage),
                    Price = new Price {Value = 10m, Timestamp = DateTime.MinValue}
                };


            //_order.Handle(messageInfo as messageInfo.MessageType);

        }


    }
}
