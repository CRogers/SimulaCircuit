using System;

namespace SimulaCircuit.Gates
{
    [Serializable]
    public abstract class Gate : InputsOutput, IXmlSerializable<Gate>
    {
        protected Gate(){}

        protected Gate(params IInputsOutput[] inputs)
        {
            Inputs = inputs;
        }

        public override bool this[int i] 
        {
            get { return Func(); }
        }

        protected abstract bool Func();
    }

    public abstract class Gate1 : Gate
    {
        protected Gate1()
        {
            Inputs = new IInputsOutput[1];
        }

        protected Gate1(IInputsOutput input)
        {
            Inputs = new[] {input};
        }
    }
}
