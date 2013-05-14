using System;
using StopLossKata.Messages;

namespace StopLossKata.Rules
{
    public interface IStopLossRule
    {
        bool ShouldExecute();
        void Execute();
    }
}