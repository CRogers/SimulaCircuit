using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public abstract class FlipFlop : IOutput
    {
        protected bool state;

        public Clock Clock { get; set; }
        public IOutput Input { get; set; }

        public bool Output { get; private set; }

        protected FlipFlop(Clock clock, IOutput input, bool initialState = false)
        {
            Input = input;
            state = initialState;
            Output = state;

            Clock = clock;
            clock.Tick += () => state = StateChange();
            clock.Tock += () => Output = state;
        }

        protected abstract bool StateChange();
    }
}
