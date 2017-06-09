using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLCCalculator
{
    public partial class CircuitDetailForm : Form
    {
        public CircuitDetailForm()
        {
            InitializeComponent();
        }

        private void CircuitDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }
    }
}
