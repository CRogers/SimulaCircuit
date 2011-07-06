using System.Threading;

namespace SimulaCircuit.SignalGenerators
{
    public class FastClock : Clock
    {
        public override string Name { get { return "FAST_CLOCK"; } }
        public FastClock()
        {
            var t = new Thread(new ThreadStart(delegate { while (true) Do(); }));
            t.Start();
        }
    }
}
