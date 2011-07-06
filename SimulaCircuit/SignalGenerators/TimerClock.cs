using System.Timers;

namespace SimulaCircuit.SignalGenerators
{
    public class TimerClock : Clock
    {
        public override string Name { get { return "TIMER_CLOCK"; } }
        private readonly Timer timer = new Timer();

        public TimerClock(double interval)
        {
            timer.Interval = interval;
            timer.Elapsed += (o,e) => Do();
            timer.Start();
        }
    }
}
