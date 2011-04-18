using SimulaCircuit.Gates;
using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public class JKFlipFlop : FlipFlop
    {
        // J = Inputs[0], K = Inputs[1]

        public JKFlipFlop(Clock clock, IInputsOutput j, IInputsOutput k, bool initialState = false)
            : base(clock, new True(), initialState)
        {
            Inputs = new[] { j, k };
        }

        protected override bool StateChange()
        {
            return (Inputs[0][0] && !state) || (!Inputs[1][0] && state);
        }
    }
}
