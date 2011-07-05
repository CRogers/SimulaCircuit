using System.Windows.Controls;

namespace SimulaCircuit.GUI
{
    public interface IDrawable
    {
        void Draw(Canvas c, InputsOutput io);
    }
}
