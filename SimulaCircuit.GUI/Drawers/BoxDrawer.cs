using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimulaCircuit.GUI.Drawers
{
    public class BoxDrawer : IDrawable
    {
        public void Draw(Canvas c, InputsOutput io)
        {
            const double pinGap = 10;
            const double pinLength = 10;
            var rect = new Rectangle{Width = 100, Height = 100, Stroke = Brushes.Black, Fill = Brushes.White};
            c.Children.Add(rect);

            for(int i = 0; i < io.NumInputs; i++)
            {
                var y = pinGap*(i+1);
                c.Children.Add(new Line {X1 = 0, X2 = pinLength, Y1 = y, Y2 = y, Stroke = Brushes.Black});
                var tb = new TextBlock{ Text = i.ToString() };
                c.Children.Add(tb);
                Canvas.SetLeft(tb, pinGap*2);
                Canvas.SetTop(tb, y);
            }
        }
    }
}
