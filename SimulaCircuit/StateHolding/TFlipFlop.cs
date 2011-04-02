using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public class TFlipFlop : FlipFlop
    {
        public TFlipFlop(Clock clock, IOutput input, bool initialState = false): base(clock, input, initialState)
        {
        }

        protected override bool StateChange()
        {
            return state ^ Input.Output;
        }
    }
}
