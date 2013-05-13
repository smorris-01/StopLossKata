using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StopLossKata.Infrastructure
{
    interface ITimer
    {
        void Start();
        void Stop();
        ElapsedEventHandler Elapsed(object sender, ElapsedEventArgs e);
    }
}
