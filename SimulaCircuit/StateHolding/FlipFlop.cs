using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public abstract class FlipFlop : InputsOutput
    {
        protected bool state;

        public Clock Clock { get; set; }

        protected FlipFlop(Clock clock, IInputsOutput input, bool initialState = false)
        {
            Inputs = new[] { input };
            state = initialState;
            outputs[0] = state;

            Clock = clock;
            clock.Tick += () => state = StateChange();
            clock.Tock += () => outputs[0] = state;
        }

        protected abstract bool StateChange();
    }
}
