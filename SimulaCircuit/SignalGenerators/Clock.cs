using System;
using System.Timers;

namespace SimulaCircuit.SignalGenerators
{
    public class Clock : IOutput
    {
        private Timer timer = new Timer();

        public bool output;
        public bool Output
        {
            get { return output; }
        }

        public Clock(double interval)
        {
            timer.Interval = interval;
            timer.Elapsed += Tick;
            timer.Start();
        }

        private void Tick(object o, EventArgs ea)
        {
            output = !output;
        }
    }
}
