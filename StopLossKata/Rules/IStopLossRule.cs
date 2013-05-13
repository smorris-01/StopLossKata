using System;
using StopLossKata.Messages;

namespace StopLossKata.Rules
{
    public interface IStopLossRule
    {
        bool ShouldExecute(Price sellPrice, Price currentPrice, TimeSpan timeout);
    }
}