using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF.JoshSmith.Controls;

namespace SimulaCircuit.GUI
{
    public class TabCanvasManager
    {
        Random r = new Random();

        private MainWindow mw;
        private Dictionary<string, TabCanvasItem> tabs = new Dictionary<string, TabCanvasItem>();

        public TabCanvasManager(MainWindow mw)
        {
            this.mw = mw;
        }

        public TabItem Add(string id, string header)
        {
            var ellipse = new Ellipse {Fill = Brushes.Green, Width = 30.0, Height = 30.0};
            var canvas = new DragCanvas {Name = "canvas_" + id};
            canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, r.NextDouble()*100);
            Canvas.SetTop(ellipse, r.NextDouble() * 100);
            var ti = new TabItem { Name = "tab_"+id, Header = header, Content = canvas};
            var tci = new TabCanvasItem(ti, canvas);

            mw.tcDraw.Items.Add(ti);
            tabs.Add(id, tci);
            return ti;
        }

        public void Remove(string id)
        {
            mw.tcDraw.Items.Remove(tabs[id]);
            tabs.Remove(id);
        }

        public bool Exists(string id)
        {
            return tabs.ContainsKey(id);
        }


        internal class TabCanvasItem
        {
            public TabItem TabItem { get; set; }
            public DragCanvas Canvas { get; set; }

            public TabCanvasItem(TabItem tabItem, DragCanvas canvas)
            {
                TabItem = tabItem;
                Canvas = canvas;
            }
        }
    }
}
