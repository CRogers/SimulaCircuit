using System;
using System.Xml.Serialization;

namespace SimulaCircuit
{
    public interface IInputsOutput
    {
        Pin[] Inputs { get; set; }
        bool this[int i] { get; }
        int Id { get; }
        Pin ToPin(int pinNum);
    }

    [Serializable]
    public abstract class InputsOutput : IInputsOutput
    {
        [XmlAttribute]
        public virtual int Id { get; private set; }

        protected bool[] outputs;
        public virtual bool this[int i]
        {
            get { return outputs[i]; } 
        }

        public virtual Pin[] Inputs { get; set; }

        public int NumInputs { get { return Inputs == null ? 0 : Inputs.Length; } }
        public int NumOutputs { get { return outputs == null ? 0 : outputs.Length; } }

        protected InputsOutput()
        {
            InitId();
        }

        protected virtual void InitId()
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
