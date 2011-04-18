using System;
using System.Xml.Serialization;

namespace SimulaCircuit.GUI.Data
{
    [Serializable]
    public class CircuitItem<T> : XmlSerializable<CircuitItem<T>>, IOutput where T : IOutput
    {
        [XmlAttribute]
        public int Left { get; set; }

        [XmlAttribute]
        public int Top { get; set; }

        [XmlAttribute]
        public string ItemType { get; set; }

        private T item;


        public bool Output
        {
            get { return item.Output; }
        }
    }
}
