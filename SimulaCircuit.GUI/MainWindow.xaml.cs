using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using SimulaCircuit.GUI.Data;
using SimulaCircuit.GUI.Drawers;
using SimulaCircuit.Gates;

namespace SimulaCircuit.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CanvasManager cm;

        public MainWindow()
        {
            InitializeComponent();
            cm = new CanvasManager(tcDraw);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cm.Add("lol", "lol1");
            cm.Add("pol", "lol2");
            var ellipse = new Ellipse { Fill = Brushes.Green, Width = 30.0, Height = 30.0 };
            Canvas.SetLeft(ellipse, 0);
            Canvas.SetTop(ellipse, 0);
            cm["pol"].Canvas.Children.Add(ellipse);

            var ci = new CircuitItem<AndGate, BoxDrawer>(cm["lol"].Canvas, new AndGate(Pin.True, Pin.True, Pin.True, Pin.False), new BoxDrawer());
            ci.Draw();
        }
    }

    
}
