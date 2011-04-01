using System.Timers;

namespace SimulaCircuit.SignalGenerators
{
    public class TimerClock : Clock
    {
        private readonly Timer timer = new Timer();

        public TimerClock(double interval)
        {
            timer.Interval = interval;
            timer.Elapsed += (o,e) => Do();
            timer.Start();
        }
    }
}
