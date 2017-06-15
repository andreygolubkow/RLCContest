using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;

namespace RLCCalculator
{
    public partial class CircuitGraphicView : Form
    {
        public CircuitGraphicView(ICircuit circuit)
        {
            InitializeComponent();

            circuitDrawerControl.DrawCircuit(circuit);
        }
    }
}
