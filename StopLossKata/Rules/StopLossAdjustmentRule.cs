﻿using System;
using StopLossKata.Messages;

namespace StopLossKata.Rules
{
    public class StopLossAdjustmentRule: StopLossRule
    {
        public TimeSpan Timeout { get; internal set; }
        
        private readonly TimeoutRule _timeoutRule;

        public StopLossAdjustmentRule()
        {
            // TODO: dependency injection
            _timeoutRule = new TimeoutRule();
           
        }

        public override bool ShouldExecute()
        {
            if (Position.Price.Value < CurrentPrice.Price.Value)
            {
                if (_timeoutRule.HasTimeoutExpired(Position.Price.Timestamp, CurrentPrice.Price.Timestamp, Timeout))
                {
                    return true;
                }
            }
            return false;
        }
    }
}