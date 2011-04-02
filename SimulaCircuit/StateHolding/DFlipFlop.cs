using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public class DFlipFlop : FlipFlop
    {
        public DFlipFlop(Clock clock, IOutput input, bool initialState = false) : base(clock, input, initialState)
        {
        }

        protected override bool StateChange()
        {
            return Input.Output;
        }
    }
}
