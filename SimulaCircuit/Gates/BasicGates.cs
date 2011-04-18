using System.Linq;

namespace SimulaCircuit.Gates
{
    public class AndGate : Gate
    {
        public AndGate(){}
        public AndGate(params IInputsOutput[] inputs) : base(inputs) { }

        protected override bool Func()
        {
            return Inputs.Aggregate(true,(a,b) => a && b[0]);
        }
    }

    public class OrGate : Gate
    {
        public OrGate(){}
        public OrGate(params IInputsOutput[] inputs) : base(inputs) { }

        protected override bool Func()
        {
            return Inputs.Aggregate(false,(a,b) => a || b[0]);
        }
    }

    public class XorGate : Gate
    {
        public XorGate(){}
        public XorGate(params IInputsOutput[] inputs) : base(inputs) { }

        protected override bool Func()
        {
            return Inputs.Aggregate(false,(a,b) => a ^ b[0]);
        }
    }

    public class Inverter : Gate1
    {
        public Inverter(){}
        public Inverter(IInputsOutput input) : base(input) { }

        protected override bool Func()
        {
            return !Inputs[0][0];
        }
    }
}
