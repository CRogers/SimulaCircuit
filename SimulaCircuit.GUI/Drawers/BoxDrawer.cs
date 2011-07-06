using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimulaCircuit.GUI.Drawers
{
    public class BoxDrawer : IDrawable
    {
        private double pinGap = 10;
        public double PinGap
        {
            get { return pinGap; }
            set { pinGap = value; }
        }

        private double pinLength = 10;
        public double PinLength
        {
            get { return pinLength; }
            set { pinLength = value; }
        }

        public virtual void Draw(Canvas c, InputsOutput io)
        {
            double width = 70;
            double height = (Math.Max(io.NumInputs, io.NumOutputs) + 1)*pinGap;
            DrawName(c,io);
            DrawBox(c,io, width, height);
            DrawInputs(c,io,height);
            DrawOutputs(c,io,width,height);
        }

        protected virtual void DrawName(Canvas c, InputsOutput io)
        {
            var tb = new TextBlock {Text = io.Name};
            c.Children.Add(tb);
            Canvas.SetLeft(tb, 0);
            Canvas.SetTop(tb,-20);
        }

        protected virtual void DrawBox(Canvas c, InputsOutput io, double width, double height)
        {
            var rect = new Rectangle { Width = width, Height = height, Stroke = Brushes.Black, Fill = Brushes.White };
            c.Children.Add(rect);
        }

        protected virtual void DrawInputs(Canvas c, InputsOutput io, double height)
        {
            DrawInputsOutputs(c,io.NumInputs,height,0,pinLength*2);
        }

        protected virtual void DrawOutputs(Canvas c, InputsOutput io, double width, double height)
        {
            DrawInputsOutputs(c,io.NumOutputs,height,width-pinLength,width-pinLength*2.5);
        }

        private void DrawInputsOutputs(Canvas c, int pins, double height, double lineOffset, double textOffset)
        {
            var startHeight = (height - (pins+1) * pinGap) / 2;
            for (int i = 0; i < pins; i++)
            {
                var y = startHeight + pinGap * (i + 1);
                c.Children.Add(new Line { X1 = lineOffset, X2 = lineOffset + pinLength, Y1 = y, Y2 = y, Stroke = Brushes.Black });
                var tb = new TextBlock { Text = i.ToString() };
                c.Children.Add(tb);
                Canvas.SetLeft(tb, textOffset);
                Canvas.SetTop(tb, y-pinGap*0.75);
            }
        }
    }
}
