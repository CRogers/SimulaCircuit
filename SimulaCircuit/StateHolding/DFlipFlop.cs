using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public class DFlipFlop : FlipFlop
    {
        public DFlipFlop(Clock clock, IInputsOutput input, bool initialState = false)
            : base(clock, input, initialState)
        {
        }

        protected override bool StateChange()
        {
            return Inputs[0][0];
        }
    }
}
