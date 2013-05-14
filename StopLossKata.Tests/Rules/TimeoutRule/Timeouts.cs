using System;
using FluentAssertions;
using NUnit.Framework;

namespace StopLossKata.Tests.Rules.TimeoutRule
{
    [TestFixture]
    public class Timeouts
    {
        private StopLossKata.Rules.TimeoutHelper Subject { get; set; }


        [SetUp]
        public void Setup()
        {
            Subject = new StopLossKata.Rules.TimeoutHelper();
        }


        [TestCase("2000/01/01 00:00:00", "2000/01/01 00:00:00", "00:00:00", true)]
        [TestCase("2000/01/01 00:00:00", "2000/01/01 00:00:01", "00:00:00", true)]
        [TestCase("2000/01/01 00:00:00", "2000/01/01 00:00:00", "00:00:01", false)]
        [TestCase("2000/01/01 00:00:00", "2000/01/01 00:00:09", "00:00:10", false)]
        [TestCase("2000/01/01 00:00:00", "2000/01/01 00:00:11", "00:00:10", true)]

        [TestCase("2012/12/13 13:14:15", "2012/12/13 13:14:15", "01:01:01", false)]
        [TestCase("2012/12/13 13:14:15", "2012/12/13 13:14:15", "00:00:00", true)]
        [TestCase("2012/12/13 13:14:15", "2012/12/13 13:14:15", "00:00:01", false)]
        [TestCase("2012/12/13 13:14:15", "2012/12/13 13:14:24", "00:00:10", false)]
        [TestCase("2012/12/13 13:14:15", "2012/12/13 13:14:25", "00:00:10", true)]
        public void Should_evaluate_timeout(
            string firstTimestampAsString, 
            string secondTimestampAsString,                                               
            string timeoutAsString, 
            bool expectedResult)
        {
            DateTime firstTimestamp = DateTime.Parse(firstTimestampAsString);
            DateTime actionTimestamp = DateTime.Parse(secondTimestampAsString);
            TimeSpan timeout = TimeSpan.Parse(timeoutAsString);

            bool actualResult = Subject.HasTimeoutExpired(firstTimestamp, actionTimestamp, timeout);
            actualResult.Should().Be(expectedResult);
        }

    }
}