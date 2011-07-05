using System;
using System.Xml.Serialization;

namespace SimulaCircuit
{
    public interface IInputsOutput
    {
        Pin[] Inputs { get; set; }
        bool this[int i] { get; }
        ulong Id { get; }
        Pin ToPin(int pinNum);
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

        public virtual Pin[] Inputs { get; set; }

        public int NumInputs { get { return Inputs.Length; } }
        public int NumOutputs { get { return outputs.Length; } }

        protected InputsOutput()
        {
            Id = IdManager.Next(this);
        }

        protected InputsOutput(int numInputs, int numOutputs) : this()
        {
            Inputs = new Pin[numInputs];
            outputs = new bool[numOutputs];
        }


        public virtual Pin ToPin(int pinNum)
        {
            return new Pin(Id, pinNum);
        }
    }
}
