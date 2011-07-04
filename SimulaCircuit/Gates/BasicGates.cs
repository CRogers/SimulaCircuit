using System.Linq;

namespace SimulaCircuit.Gates
{
    public class AndGate : Gate
    {
        public AndGate(params Pin[] inputs) : base(inputs) { }

        protected override bool Func()
        {
            return Inputs.Aggregate(true, (a, b) => a && b.Value);
        }
    }

    public class OrGate : Gate
    {
        public OrGate(params Pin[] inputs) : base(inputs) { }

        protected override bool Func()
        {
            return Inputs.Aggregate(false, (a, b) => a || b.Value);
        }
    }

    public class XorGate : Gate
    {
        public XorGate(params Pin[] inputs) : base(inputs) { }

        protected override bool Func()
        {
            return Inputs.Aggregate(false, (a, b) => a ^ b.Value);
        }
    }

    public class Inverter : Gate
    {
        public Inverter(Pin input) : base(input) { }

        protected override bool Func()
        {
            return !Inputs[0].Value;
        }
    }
}
