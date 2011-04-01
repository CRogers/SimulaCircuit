using System;

namespace SimulaCircuit.SignalGenerators
{
    public abstract class Clock : IOutput
    {
        public event Action Tick;
        public event Action Tock;

        public Action AfterAll { get; set; }
        public ulong Step { get; protected set; }
        public bool Output { get; protected set; }

        protected void Do()
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
