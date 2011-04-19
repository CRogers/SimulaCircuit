using System;
using System.Xml.Serialization;

namespace SimulaCircuit
{
    public interface IInputsOutput
    {
        IInputsOutput[] Inputs { get; set; }
        bool this[int i] { get; }
        ulong Id { get; }
    }

    [Serializable]
    public abstract class InputsOutput : IInputsOutput
    {
        [XmlAttribute]
        public ulong Id { get; private set; }

        protected bool[] outputs;
        public virtual bool this[int i]
        {
            get { return outputs[i]; } 
        }

        public virtual IInputsOutput[] Inputs { get; set; }

        protected InputsOutput()
        {
            Id = IdManager.Next(this);
            outputs = new bool[1];
        }
    }
}
