using System;
using NUnit.Framework;

namespace StopLossKata.Tests.Rules
{
    [TestFixture]
    public abstract class StopLossAdjustmentRuleConcern<T>
        where T: new()
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

        protected virtual void Given()
        {
            
        }

        protected virtual void When()
        {
            
        }
    }
}
