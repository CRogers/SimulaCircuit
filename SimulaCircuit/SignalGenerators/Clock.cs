using System;

namespace SimulaCircuit.SignalGenerators
{
    public abstract class Clock : IOutput
    {
        public event Action Tick;
        public event Action Tock;

        public Action AfterAll { get; set; }
        public ulong Step { get; protected set; }

        private bool output;
        public bool this[int i] { get { return output; } }
        public ulong Id { get; private set; }

        protected Clock()
        {
            Id = IdManager.Next(this);
        }

        protected virtual void Do()
        {
            output = !output;
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
