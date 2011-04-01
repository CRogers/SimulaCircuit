using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulaCircuit.Gates;
using SimulaCircuit.SignalGenerators;
using SimulaCircuit.StateHolding;

namespace Tests
{
    [TestClass]
    public class StateHolding
    {
        Clock c = new Clock(10);
        Wire t = new Wire(new True());
        Wire f = new Wire(new False());

        bool ready = false;

        private void SetReady()
        {
            ready = true;
        }

        private void WaitUntilReady()
        {
            while(!ready)
                Thread.Sleep(1);
            ready = false;
        }

        [TestMethod]
        public void FlipFlop()
        {

            FlipFlop ff = new FlipFlop(c, t);
            Assert.IsTrue(ff.Output);

            c.Tick += SetReady;

            ff.Input = f;
            WaitUntilReady();
            Assert.IsFalse(ff.Output);

            WaitUntilReady();
            Assert.IsFalse(ff.Output);

            ff.Input = t;
            WaitUntilReady();
            Assert.IsTrue(ff.Output);

            c.Tick -= SetReady;
        }
    }
}
