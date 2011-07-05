using System.Collections.Generic;
using System.Windows.Controls;
using WPF.JoshSmith.Controls;

namespace SimulaCircuit.GUI
{
    public class CanvasManager
    {
        private TabControl tc;
        private Dictionary<string, TabCanvas> tabs = new Dictionary<string, TabCanvas>();

        public CanvasManager(TabControl tc)
        {
            this.tc = tc;
        }

        public TabCanvas this[string id]
        {
            get { return tabs[id]; }
        }

        public TabCanvas Add(string id, string header)
        {
            var dc = new DragCanvas {Name = "canvas_" + id};
            var ti = new TabItem {Name = "tab_" + id, Header = header, Content = dc};
            tc.Items.Add(ti);
            var tci = new TabCanvas(ti, dc);
            tabs.Add(id, tci);
            return tci;
        }

        public void Remove(string id)
        {
            tc.Items.Remove(tabs[id]);
            tabs.Remove(id);
        }

        public class TabCanvas
        {
            public TabItem TabItem { get; set; }
            public DragCanvas Canvas { get; set; }

            public TabCanvas(TabItem tabItem, DragCanvas canvas)
            {
                TabItem = tabItem;
                Canvas = canvas;
            }
        }
    }
}
