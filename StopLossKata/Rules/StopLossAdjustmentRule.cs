using System;

namespace StopLossKata.Rules
{
    public class StopLossAdjustmentRule: StopLossRule
    {
        public TimeSpan Timeout { get; internal set; }
        
        public override bool ShouldExecute()
        {
            if (Position.Price.Value < CurrentPrice.Price.Value)
            {
                if (TimeoutHelper.HasTimeoutExpired(Position.Price.Timestamp, CurrentPrice.Price.Timestamp, Timeout))
                {
                    return true;
                }
            }
            return false;
        }
    }
}