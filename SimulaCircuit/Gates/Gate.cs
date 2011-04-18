using System;
using System.Xml.Serialization;
using SimulaCircuit;

namespace SimulaCircuit.Gates
{
    [Serializable]
    public abstract class Gate : XmlSerializable<Gate>, IOutput
    {
        [XmlArray]
        public IOutput[] Inputs { get; set; }

        protected Gate(){}

        protected Gate(params IOutput[] inputs)
        {
            Inputs = inputs;
        }

        public bool Output 
        {
            get { return Func(); }
        }

        protected abstract bool Func();
    }

    public abstract class Gate1 : Gate
    {
        protected Gate1()
        {
            Inputs = new IOutput[1];
        }

        protected Gate1(IOutput input)
        {
            Inputs = new[] {input};
        }
    }
}
