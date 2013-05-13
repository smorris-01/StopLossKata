using System;
using NUnit.Framework;
using StopLossKata.Messages;
using StopLossKata.Rules;

namespace StopLossKata.Tests.Rules
{
    [TestFixture]
    public abstract class ConcernForStopLossRule<T>
        where T: IStopLossRule, new()
    {
        protected decimal SellPrice;
        protected DateTime SellTimestamp;

        protected decimal NewPrice;
        protected DateTime NewTimestamp;

        protected TimeSpan RuleTimeout;


        protected bool? Result = null;

        
        protected T Rule { get; private set; }


        [SetUp]
        public void Setup()
        {
            Rule = new T();
            
            Given();
            When();
        }

        /// <summary>
        /// override this method to define custom Given steps.
        /// </summary>
        protected virtual void Given()
        {}

        /// <summary>
        /// override this method to define custom When steps.
        /// </summary>
        protected virtual void When()      
        {
            var sellPrice = new Price
                {
                    Value = SellPrice,
                    Timestamp = SellTimestamp,
                };

            var currentPrice = new Price
                {
                    Value = NewPrice,
                    Timestamp = NewTimestamp,
                };

            Result = Rule.ShouldExecute(sellPrice, currentPrice, RuleTimeout);
        }
    }
}
