using System;

namespace StopLossKata.Rules
{
    public class TimeoutRule
    {
        internal bool HasTimeoutExpired(DateTime intial, DateTime subsequent, TimeSpan timeout)
        {
            TimeSpan difference = subsequent.Subtract(intial);
            if (difference >= timeout)
            {
                return true;
            }

            return false;
        } 
    }
}