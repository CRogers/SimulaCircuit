namespace SimulaCircuit.SignalGenerators
{
    public class BlockingClock : Clock
    {
        public override string Name { get { return "BLOCKING_CLOCK"; } }
        public void Go()
        {
            Do();
        }
    }
}
