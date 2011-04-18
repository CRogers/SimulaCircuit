using System;
using System.Linq;
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
            while(!ready) ;
            ready = false;
        }

        [TestMethod]
        public void DFlipFlop()
        {
            DFlipFlop ff = new DFlipFlop(c, t, true);
            Assert.IsTrue(ff[0]);

            ff.Inputs[0] = f;
            c.Go();
            Assert.IsFalse(ff[0]);

            c.Go();
            Assert.IsFalse(ff[0]);

            ff.Inputs[0] = t;
            c.Go();
            Assert.IsTrue(ff[0]);
        }

        [TestMethod]
        public void TFlipFlop()
        {
            var tff = new TFlipFlop(c, t, true);
            Assert.IsTrue(tff[0]);

            c.Go();
            Assert.IsFalse(tff[0]);

            tff.Inputs[0] = f;
            c.Go();
            Assert.IsFalse(tff[0]);

            tff.Inputs[0] = t;
            c.Go();
            Assert.IsTrue(tff[0]);
        }

        [TestMethod]
        public void JKFlipFlop()
        {
            var jkff = new JKFlipFlop(c, f, f);
            Assert.IsFalse(jkff[0]);

            c.Go();
            Assert.IsFalse(jkff[0]);

            jkff.Inputs[0] = t;
            c.Go();
            Assert.IsTrue(jkff[0]);

            jkff.Inputs[1] = t;
            c.Go();
            Assert.IsFalse(jkff[0]);

            jkff.Inputs[0] = t;
            c.Go();
            Assert.IsTrue(jkff[0]);

        }

        [TestMethod]
        public void ShiftRegister()
        {
            var ffs = new DFlipFlop(c, f).Unfold(ff => new DFlipFlop(c, ff), max: 8).ToArray();
            ffs[0].Inputs[0] = t;

            for (int i = 0; i < 8; i++)
            {
                c.Go();
                for (int j = 0; j < i; j++)
                    Assert.IsTrue(ffs[j][0]);
            }
        }

        [TestMethod]
        public void LoopDevice()
        {
            var ffs = new DFlipFlop(c, f).Unfold(ff => new DFlipFlop(c, ff), max: 8).ToArray();
            ffs[0].Inputs[0] = new Inverter(ffs[ffs.Length - 1]);


            for (int i = 0; i < 8; i++)
            {
                c.Go();
                for (int j = 0; j < i; j++)
                    Assert.IsTrue(ffs[j][0]);
            }

            for (int i = 0; i < 8; i++)
            {
                c.Go();
                for (int j = 0; j < i; j++)
                    Assert.IsFalse(ffs[j][0]);
            }
        }
    }
}
