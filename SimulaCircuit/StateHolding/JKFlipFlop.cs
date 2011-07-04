using SimulaCircuit.Gates;
using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public class JKFlipFlop : FlipFlop
    {
        // J = Inputs[0], K = Inputs[1]

        public JKFlipFlop(Clock clock, Pin j, Pin k, bool initialState = false)
            : base(clock, new Pin(0,0), initialState)
        {
            Inputs = new[] { j, k };
        }

        protected override bool StateChange()
        {
            return (Inputs[0].Value && !state) || (!Inputs[1].Value && state);
        }
    }
}
