using SimulaCircuit.SignalGenerators;

namespace SimulaCircuit.StateHolding
{
    /// <summary>
    /// Inputs:
    ///     0: Data
    /// Outputs:
    ///     0: 
    /// </summary>
    public abstract class FlipFlop : InputsOutput
    {
        protected bool state;

        public Clock Clock { get; set; }

        protected FlipFlop(Clock clock, Pin input, bool initialState = false) : base(1,2)
        {
            Inputs = new[] { input };
            state = initialState;
            outputs[0] = state;
            outputs[1] = state;

            Clock = clock;
            clock.Tick += () => state = StateChange();
            clock.Tock += () =>
                              {
                                  outputs[0] = state;
                                  outputs[1] = !state;
                              };
        }

        protected abstract bool StateChange();
    }
}
