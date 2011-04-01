using System;
using System.Timers;

namespace SimulaCircuit.SignalGenerators
{
    public class Clock : IOutput
    {
        private Timer timer = new Timer();

        public event Action Tick;
        public event Action Tock;
        public Action AfterAll;
        public ulong Step { get; private set; }

        public bool Output { get; private set; }

        public Clock(double interval)
        {
            timer.Interval = interval;
            timer.Elapsed += Do;
            timer.Start();
        }


        private void Do(object o, EventArgs ea)
        {
            Output = !Output;
            Step++;
            if (Tick != null)
                Tick();
            if (Tock != null)
                Tock();
            if (AfterAll != null)
                AfterAll();
        }
    }
}
