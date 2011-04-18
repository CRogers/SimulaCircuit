using System;
using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public abstract class FlipFlop : IOutput
    {
        protected bool state;

        public Clock Clock { get; set; }
        public IOutput Input { get; set; }

        protected bool output;
        public bool this[int i]
        {
            get { return output; } 
            private set { output = value; }
        }
        public ulong Id { get; protected set; }

        protected FlipFlop(Clock clock, IOutput input, bool initialState = false)
        {
            Id = IdManager.Next();

            Input = input;
            state = initialState;
            output = state;

            Clock = clock;
            clock.Tick += () => state = StateChange();
            clock.Tock += () => output = state;
        }

        protected abstract bool StateChange();
    }
}
