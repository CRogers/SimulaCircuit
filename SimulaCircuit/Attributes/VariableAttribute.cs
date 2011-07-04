using System;

namespace SimulaCircuit.Attributes
{
    public class VariableAttribute : Attribute
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public VariableAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public VariableAttribute() : this(0,int.MaxValue){}
    }

    public class VariableOutputsAttribute : VariableAttribute
    {
    }

    public class VariableInputsAttribute : VariableAttribute
    {
    }
}
