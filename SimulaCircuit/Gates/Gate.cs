using System;
using SimulaCircuit.Attributes;

namespace SimulaCircuit.Gates
{
    /// <summary>
    /// A gate has a variable number of inputs and one single output.
    /// </summary>
    [VariableInputs, Serializable]
    public abstract class Gate : InputsOutput, IXmlSerializable<Gate>
    {
        protected Gate(params Pin[] inputs)
        {
            Inputs = inputs;
            outputs = new bool[1];
        }

        protected Gate(int numInputs) : base(numInputs,1)
        {
        }

        public override bool this[int i] 
        {
            get { return Func(); }
        }

        protected abstract bool Func();
    }
}
