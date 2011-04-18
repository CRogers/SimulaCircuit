using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimulaCircuit.Gates;

namespace Tests
{
    /// <summary>
    /// Summary description for BasicCircuits
    /// </summary>
    [TestClass]
    public class BasicCircuits
    {
        True t = new True();
        False f = new False();

        [TestMethod]
        public void CustomXor()
        {
            // a XOR b = (a AND ¬b) OR (¬a AND b)
            Wire a = new Wire(f), b = new Wire(f);
            var xor = new OrGate(new AndGate(a, new Inverter(b)), new AndGate(new Inverter(a), b));

            Assert.AreEqual(false ^ false, xor[0]);

            a.Input = f; b.Input = t;
            Assert.AreEqual(false ^ true, xor[0]);

            a.Input = t; b.Input = f;
            Assert.AreEqual(true ^ false, xor[0]);

            a.Input = t; b.Input = t;
            Assert.AreEqual(true ^ true, xor[0]);
        }
    }
}
