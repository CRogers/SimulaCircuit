using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    public class FlipFlop : IOutput
    {
        public Clock Clock { get; set; }
        public IOutput Input { get; set; }

        public bool Output { get; private set; }

        public FlipFlop(Clock clock, IOutput input)
        {
            Input = input;
            Output = input.Output;

            Clock = clock;
            clock.Tick += () => Output = Input.Output;
        }
    }
}
