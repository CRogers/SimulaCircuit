using System;
using System.Windows.Controls;
using System.Xml.Serialization;
using WPF.JoshSmith.Controls;

namespace SimulaCircuit.GUI.Data
{
    [Serializable]
    public class CircuitItem<T, D> : InputsOutput, IXmlSerializable<CircuitItem<T,D>> where T : InputsOutput where D : IDrawable
    {
        public override string Name { get { return item.Name; } }

        [XmlAttribute]
        public double Left
        {
            get { return Canvas.GetLeft(Canvas); }
            set { Canvas.SetLeft(Canvas, value); }
        }

        [XmlAttribute]
        public double Top
        {
            get { return Canvas.GetTop(Canvas); }
            set { Canvas.SetTop(Canvas, value); }
        }

        [XmlAttribute]
        public string ItemType { get; set; }

        public Canvas Canvas;

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

        public int Id
        {
            get { return item.Id; }
        }


        public CircuitItem(Canvas c, T item, D drawer)
        {
            this.item = item;
            this.drawer = drawer;
            Canvas = new Canvas();
            Canvas.SetLeft(Canvas, 0);
            Canvas.SetTop(Canvas, 0);
            c.Children.Add(Canvas);
        }



        public void Draw()
        {
            drawer.Draw(Canvas, item);
        }
    }
}
