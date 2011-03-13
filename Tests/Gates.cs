using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulaCircuit.Gates;

namespace Tests
{
    [TestClass]
    public class Gates
    {
        [TestMethod]
        public void AndGate()
        {
            var ag = new AndGate {Inputs = new[] {true, true, true, true, false}};
            Assert.IsFalse(ag.Output);

            ag.Inputs = new[] {true,true,true,true,true};
            Assert.IsTrue(ag.Output);
        }

        [TestMethod]
        public void OrGate()
        {
            var or = new OrGate { Inputs = new[] { true, true, true, true, false } };
            Assert.IsTrue(or.Output);

            or.Inputs = new[] { false, false, false, false, false };
            Assert.IsFalse(or.Output);

            or.Inputs = new[] { false,false,false,false,false,false,false,false,false,false,true };
            Assert.IsTrue(or.Output);
        }

        [TestMethod]
        public void XorGate()
        {
            var xg = new XorGate { Inputs = new[] { true, false, true } };
            Assert.IsFalse(xg.Output);

            xg.Inputs = new[] { true, false, true, true };
            Assert.IsTrue(xg.Output);
        }

        [TestMethod]
        public void Inverter()
        {
            var i = new Inverter();

            i.Inputs[0] = true;
            Assert.IsFalse(i.Output);

            i.Inputs[0] = false;
            Assert.IsTrue(i.Output);
        }
    }
}
