using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;

using static System.Drawing.Color;

namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = new AdjacencyGraph<string,TaggedEdge<string,string>>();
            g.AddVertex("Часы");
            g.AddVertex("Носки");
            g.AddEdge(new TaggedEdge<string, string>("Часы", "Носки", "a"));
            var graphViz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(g, @".\", QuickGraph.Graphviz.Dot.GraphvizImageType.Png);
            graphViz.FormatVertex += FormatVertex;
            graphViz.FormatEdge += FormatEdge;
            graphViz.Generate(new FileDotEngine(), "ww");
            Console.ReadLine();
        }
        private static void FormatVertex(object sender, FormatVertexEventArgs<string> e)
        {
            e.VertexFormatter.Label = e.Vertex;
            e.VertexFormatter.Shape = GraphvizVertexShape.Box;
            e.VertexFormatter.StrokeColor = GraphvizColor.LightYellow;
            e.VertexFormatter.Font = new GraphvizFont(name: FontFamily.GenericSansSerif.ToString(), sizeInPoints: 12);
        }
        private static void FormatEdge(object sender, FormatEdgeEventArgs<string, TaggedEdge<string, string>> e)
        {
            e.EdgeFormatter.Head.Label = e.Edge.Target;
            e.EdgeFormatter.Tail.Label = e.Edge.Source;
            e.EdgeFormatter.Font = new GraphvizFont(FontFamily.GenericSansSerif.ToString(), 8);
        }
    }
}
        }
    }
}
