using System.Threading;

namespace SimulaCircuit.SignalGenerators
{
    public class FastClock : Clock
    {
        public FastClock()
        {
            var t = new Thread(new ThreadStart(delegate { while (true) Do(); }));
            t.Start();
        }
    }
}
