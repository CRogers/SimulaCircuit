using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public class FlipFlop : IOutput
    {
        private bool state;

        public Clock Clock { get; set; }
        public IOutput Input { get; set; }

        public bool Output { get; private set; }

        public FlipFlop(Clock clock, IOutput input)
        {
            Input = input;
            Output = input.Output;

            Clock = clock;
            clock.Tick += () => state = Input.Output;
            clock.Tock += () => Output = state;
        }
    }
}
