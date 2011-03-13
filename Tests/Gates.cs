using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulaCircuit.Gates;

namespace Tests
{
    [TestClass]
    public class Gates
    {
        True t = new True();
        False f = new False();

        [TestMethod]
        public void AndGate()
        {
            var ag = new AndGate { Inputs = new IOutput[] { t, t, t, t, f } };
            Assert.IsFalse(ag.Output);

            ag.Inputs = new[] {t,t,t,t,t};
            Assert.IsTrue(ag.Output);
        }

        [TestMethod]
        public void OrGate()
        {
            var or = new OrGate { Inputs = new IOutput[] { t, t, t, t, f } };
            Assert.IsTrue(or.Output);

            or.Inputs = new[] { f, f, f, f, f };
            Assert.IsFalse(or.Output);

            or.Inputs = new IOutput[] { f,f,f,f,f,f,f,f,f,f,t };
            Assert.IsTrue(or.Output);
        }

        [TestMethod]
        public void XorGate()
        {
            var xg = new XorGate { Inputs = new IOutput[] { t, f, t } };
            Assert.IsFalse(xg.Output);

            xg.Inputs = new IOutput[] { t, f, t, t };
            Assert.IsTrue(xg.Output);
        }

        [TestMethod]
        public void Inverter()
        {
            var i = new Inverter();

            i.Inputs[0] = t;
            Assert.IsFalse(i.Output);

            i.Inputs[0] = f;
            Assert.IsTrue(i.Output);
        }
    }
}
