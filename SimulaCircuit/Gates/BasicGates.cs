using System.Linq;

namespace SimulaCircuit.Gates
{
    public class AndGate : Gate
    {
        protected override bool Func()
        {
            return Inputs.Aggregate(true,(a,b) => a && b.Output);
        }
    }

    public class OrGate : Gate
    {
        protected override bool Func()
        {
            return Inputs.Aggregate(false,(a,b) => a || b.Output);
        }
    }

    public class XorGate : Gate
    {
        protected override bool Func()
        {
            return Inputs.Aggregate(false,(a,b) => a ^ b.Output);
        }
    }

    public class Inverter : Gate1
    {
        protected override bool Func()
        {
            return !Inputs[0].Output;
        }
    }
}
