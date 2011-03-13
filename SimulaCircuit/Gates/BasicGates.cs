using System.Linq;

namespace SimulaCircuit.Gates
{
    public class AndGate : Gate
    {
        protected override bool Func()
        {
            return Inputs.Aggregate((a,b) => a && b);
        }
    }

    public class OrGate : Gate
    {
        protected override bool Func()
        {
            return Inputs.Aggregate((a, b) => a || b);
        }
    }

    public class XorGate : Gate
    {
        protected override bool Func()
        {
            return Inputs.Aggregate((a,b) => a ^ b);;
        }
    }

    public class Inverter : Gate1
    {
        protected override bool Func()
        {
            return !Inputs[0];
        }
    }
}
