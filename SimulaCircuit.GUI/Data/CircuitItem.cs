using System;
using System.Windows.Controls;
using System.Xml.Serialization;
using WPF.JoshSmith.Controls;

namespace SimulaCircuit.GUI.Data
{
    [Serializable]
    public class CircuitItem<T, D> : InputsOutput, IXmlSerializable<CircuitItem<T,D>> where T : InputsOutput where D : IDrawable
    {
        [XmlAttribute]
        public double Left
        {
            get { return Canvas.GetLeft(DragCanvas); }
            set { Canvas.SetLeft(DragCanvas, value); }
        }

        [XmlAttribute]
        public double Top
        {
            get { return Canvas.GetTop(DragCanvas); }
            set { Canvas.SetTop(DragCanvas, value); }
        }

        [XmlAttribute]
        public string ItemType { get; set; }

        public DragCanvas DragCanvas;

        [XmlElement]
        private T item;
        private D drawer;


        public override bool this[int i]
        {
            get { return item[i]; }
        }

        public override Pin[] Inputs
        {
            get { return item.Inputs; }
            set { item.Inputs = value; }
        }

        public ulong Id
        {
            get { return item.Id; }
        }


        public CircuitItem(Canvas c, T item, D drawer)
        {
            item = item;
            this.drawer = drawer;
            DragCanvas = new DragCanvas();
            c.Children.Add(DragCanvas);
        }



        public void Draw()
        {
            drawer.Draw(DragCanvas, item);
        }
    }
}
