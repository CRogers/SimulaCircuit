using System;
using System.Timers;

namespace SimulaCircuit.SignalGenerators
{
    public class Clock : IOutput
    {
        private Timer timer = new Timer();

        public event Action Tick;
        public ulong Step { get; private set; }

        public bool Output { get; private set; }

        public Clock(double interval)
        {
            timer.Interval = interval;
            timer.Elapsed += Tock;
            timer.Start();
        }


        private void Tock(object o, EventArgs ea)
        {
            Output = !Output;
            Step++;
            if(Tick != null)
                Tick();
        }
    }
}
