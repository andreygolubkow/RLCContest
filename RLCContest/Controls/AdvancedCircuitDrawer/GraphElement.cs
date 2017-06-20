using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls.AdvancedCircuitDrawer
{
    public partial class GraphElement : UserControl
    {
        public GraphElement()
        {
            InitializeComponent();
        }

        public Image Image
        {
            set
            {
                pictureBox1.Image = value;
            }
        }

        public List<GraphElement> In { get; set; } = new List<GraphElement>();
        public List<GraphElement> Out { get; set; } = new List<GraphElement>();
    }
}
