﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulaCircuit;
using SimulaCircuit.Gates;

namespace Tests
{
    [TestClass]
    public class Gates
    {
        Pin t = new True().ToPin(0);
        Pin f = new False().ToPin(0);

        [TestMethod]
        public void AndGate()
        {
            var ag = new AndGate(t, t, t, t, f);
            Assert.IsFalse(ag[0]);

            ag.Inputs = new[] {t,t,t,t,t};
            Assert.IsTrue(ag[0]);
        }

        [TestMethod]
        public void OrGate()
        {
            var or = new OrGate(t, t, t, t, f);
            Assert.IsTrue(or[0]);

            or.Inputs = new[] { f, f, f, f, f };
            Assert.IsFalse(or[0]);

            or.Inputs = new[] { f,f,f,f,f,f,f,f,f,f,t };
            Assert.IsTrue(or[0]);
        }

        [TestMethod]
        public void XorGate()
        {
            var xg = new XorGate(t, f, t);
            Assert.IsFalse(xg[0]);

            xg.Inputs = new[] { t, f, t, t };
            Assert.IsTrue(xg[0]);
        }

        [TestMethod]
        public void Inverter()
        {
            var i = new Inverter(t);
            Assert.IsFalse(i[0]);

            i.Inputs[0] = f;
            Assert.IsTrue(i[0]);
        }
    }
}
