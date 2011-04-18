using System;
using System.Xml.Serialization;

namespace SimulaCircuit.Gates
{
    [Serializable]
    public abstract class Gate : XmlSerializable<Gate>, IOutput
    {
        [XmlArray]
        public IOutput[] Inputs { get; set; }

        [XmlAttribute]
        public ulong Id { get; protected set; }

        protected Gate(){}

        protected Gate(params IOutput[] inputs)
        {
            Id = IdManager.Next();
            Inputs = inputs;
        }

        public bool this[int i] 
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
