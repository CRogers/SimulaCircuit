using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulaCircuit;
using SimulaCircuit.Gates;

namespace Tests
{
    /// <summary>
    /// Summary description for BasicCircuits
    /// </summary>
    [TestClass]
    public class BasicCircuits
    {
        Pin t = new True().ToPin(0);
        Pin f = new False().ToPin(0);

        [TestMethod]
        public void CustomXor()
        {
            // a XOR b = (a AND ¬b) OR (¬a AND b)
            Wire a = new Wire(f), b = new Wire(f);
            var xor = new OrGate(new AndGate(a.ToPin(0), new Inverter(b.ToPin(0)).ToPin(0)).ToPin(0), new AndGate(new Inverter(a.ToPin(0)).ToPin(0), b.ToPin(0)).ToPin(0));

            Assert.AreEqual(false ^ false, xor[0]);

            a.Inputs[0] = f; b.Inputs[0] = t;
            Assert.AreEqual(false ^ true, xor[0]);

            a.Inputs[0] = t; b.Inputs[0] = f;
            Assert.AreEqual(true ^ false, xor[0]);

            a.Inputs[0] = t; b.Inputs[0] = t;
            Assert.AreEqual(true ^ true, xor[0]);
        }
    }
}
