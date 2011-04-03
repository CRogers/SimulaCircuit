using WPF.JoshSmith.Controls;

namespace SimulaCircuit.GUI
{
    public class CanvasManager
    {
        public DragCanvas Canvas { get; set; }

        public CanvasManager(DragCanvas canvas)
        {
            Canvas = canvas;
        }
    }
}
