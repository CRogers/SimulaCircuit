using SimulaCircuit.Gates;
using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public class JKFlipFlop : FlipFlop
    {
        // Hide input
        private new IOutput Input { get; set; }

        public IOutput J { get; set; }
        public IOutput K { get; set; }

        public JKFlipFlop(Clock clock, IOutput j, IOutput k, bool initialState = false) : base(clock, new True(), initialState)
        {
            J = j;
            K = k;
        }

        protected override bool StateChange()
        {
            return (J.Output && !state) || (!K.Output && state);
        }
    }
}
