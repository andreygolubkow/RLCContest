using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Controls.CircuitDrawer;

using Core;
using Core.Circuits;
using Core.Elements;

namespace Controls.AdvancedCircuitDrawer
{
    public partial class AdvancedCircuitDrawer : UserControl
    {
        private GraphElement _graph;
        private Graphics _graphics;

        public AdvancedCircuitDrawer() 
        {
            InitializeComponent();

            

        }

        public void DrawLine(Point point1,Point point2)
        {
            Graphics gr = _graphics;
            Pen p = new Pen(Color.Black);// цвет линии и ширина
            p.Width = 2;
            Point p1 = point1;// первая точка
            Point p2 = point2;// вторая точка
            gr.DrawLine(p, p1, p2);// рисуем линию
        }

        private void  Draw(GraphElement graph,int x,int y)
        {

            graph.Location = new Point(x, y);
                Controls.Add(graph);

            
            int xx = x+20;
            int yy = y;

            if ( graph.Out.Count == 1 )
            {
                xx += 70;
                Draw(graph.Out[0], xx, yy);
                DrawLine(new Point(graph.Location.X,graph.Location.Y+24), new Point(xx, yy+24));
                return;
            }

            xx += 50;

            foreach (var item in graph.Out)
            {
                if (!Controls.Contains(item))
                {
                    yy += 70;
                    Draw(item, xx, yy);
                }
                DrawLine(new Point(graph.Location.X+50, graph.Location.Y + 24), new Point(item.Location.X, item.Location.Y + 24));
            }
        }

        private void AdvancedCircuitDrawer_Paint(object sender, PaintEventArgs e)
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _graphics = this.CreateGraphics();

            ICircuit c2 = new ParallelCircuit();
            c2.Name = "PC1";
            c2.Add(new Resistor("RR1", 2));
            c2.Add(new Resistor("RR2", 2));
            c2.Add(new Resistor("RR3", 2));
            c2.Add(new Capacitor("CC3", 2));


            var c3 = new SerialCircuit();
            c3.Name = "SC2";
            c3.Add(new Capacitor("C3C3", 5));
            c3.Add(new Resistor("C3R1",3));

            c2.Add(c3);

            _graph = CircuitAdapter.CircuitToGraph(c2).In;


            Draw(_graph, 0, 200);
        }
    }
}
