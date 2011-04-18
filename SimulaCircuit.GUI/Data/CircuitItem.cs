using System;
using System.Windows.Controls;
using System.Xml.Serialization;
using WPF.JoshSmith.Controls;

namespace SimulaCircuit.GUI.Data
{
    [Serializable]
    public class CircuitItem<T> : XmlSerializable<CircuitItem<T>>, IOutput where T : IOutput
    {
        private int left;
        [XmlAttribute]
        public int Left
        {
            get { return left; }
            set
            {
                left = value;
                DragCanvas.SetLeft(Canvas, value);
            }
        }

        private int top;
        [XmlAttribute]
        public int Top
        {
            get { return top; }
            set
            {
                top = value;
                DragCanvas.SetTop(Canvas, value);
            }
        }

        [XmlAttribute]
        public string ItemType { get; set; }

        public Canvas Canvas;
        private T item;


        public bool Output
        {
            get { return item.Output; }
        }


        public CircuitItem(DragCanvas dc, T item)
        {
            this.item = item;
            Canvas = new Canvas();
            dc.Children.Add(Canvas);
        }
    }
}
