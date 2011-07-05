using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.JoshSmith.Controls;

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
            cm["lol"].Canvas.Children.Add(ellipse);

        }
    }

    
}
