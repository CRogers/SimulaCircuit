using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public class DFlipFlop : FlipFlop
    {
        public override string Name { get { return "D_FLIP_FLOP"; } }
        public DFlipFlop(Clock clock, Pin input, bool initialState = false)
            : base(clock, input, initialState)
        {
        }

        protected override bool StateChange()
        {
            return Inputs[0].Value;
        }
    }
}
