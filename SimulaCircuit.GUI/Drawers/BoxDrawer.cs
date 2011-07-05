using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF.JoshSmith.Controls;

namespace SimulaCircuit.GUI.Drawers
{
    public class BoxDrawer : IDrawable
    {
        public void Draw(Canvas c, InputsOutput io)
        {
            double pinGap = 10;
            double pinLength = 10;

            for(int i = 0; i < io.NumInputs; i++)
            {
                var y = pinGap*(i+1);
                c.Children.Add(new Line {X1 = 0, X2 = pinLength, Y1 = y, Y2 = y});
                var tb = new TextBlock();
                c.Children.Add(tb);
                Canvas.SetLeft(tb, pinGap*2);
                Canvas.SetTop(tb, y);
            }
        }
    }
}
