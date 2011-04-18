using System;

namespace SimulaCircuit.SignalGenerators
{
    public abstract class Clock : InputsOutput
    {
        public event Action Tick;
        public event Action Tock;

        public Action AfterAll { get; set; }
        public ulong Step { get; protected set; }

        public override bool this[int i] { get { return outputs[0]; } }


        protected virtual void Do()
        {
            outputs[0] = !outputs[0];
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
