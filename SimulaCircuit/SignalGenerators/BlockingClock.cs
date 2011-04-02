namespace SimulaCircuit.SignalGenerators
{
    public class BlockingClock : Clock
    {
        public void Go()
        {
            Do();
        }
    }
}
