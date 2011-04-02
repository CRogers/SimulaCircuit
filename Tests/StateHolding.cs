using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulaCircuit;
using SimulaCircuit.Gates;
using SimulaCircuit.SignalGenerators;
using SimulaCircuit.StateHolding;

namespace Tests
{
    [TestClass]
    public class StateHolding
    {
        BlockingClock c = new BlockingClock();
        Wire t = new Wire(new True());
        Wire f = new Wire(new False());
        TimeSpan ts = new TimeSpan(1000);

        bool ready = false;


        public StateHolding()
        {
            c.AfterAll += () => ready = true;
        }


        private void WaitUntilReady()
        {
            while(!ready)
            {
            }
            ready = false;
        }

        [TestMethod]
        public void FlipFlop()
        {
            FlipFlop ff = new FlipFlop(c, t);
            Assert.IsTrue(ff.Output);

            ff.Input = f;
            c.Go();
            Assert.IsFalse(ff.Output);

            c.Go();
            Assert.IsFalse(ff.Output);

            ff.Input = t;
            c.Go();
            Assert.IsTrue(ff.Output);
        }

        [TestMethod]
        public void ShiftRegister()
        {
            var ffs = new FlipFlop(c, f).Unfold(ff => new FlipFlop(c, ff), max: 8).ToArray();
            ffs[0].Input = t;

            for (int i = 0; i < 8; i++)
            {
                c.Go();
                for (int j = 0; j < i; j++)
                    Assert.IsTrue(ffs[j].Output);
            }
        }

        [TestMethod]
        public void LoopDevice()
        {
            var ffs = new FlipFlop(c, f).Unfold(ff => new FlipFlop(c, ff), max: 8).ToArray();
            ffs[0].Input = new Inverter(ffs[ffs.Length - 1]);


            for (int i = 0; i < 8; i++)
            {
                c.Go();
                for (int j = 0; j < i; j++)
                    Assert.IsTrue(ffs[j].Output);
            }

            for (int i = 0; i < 8; i++)
            {
                c.Go();
                for (int j = 0; j < i; j++)
                    Assert.IsFalse(ffs[j].Output);
            }
        }
    }
}
