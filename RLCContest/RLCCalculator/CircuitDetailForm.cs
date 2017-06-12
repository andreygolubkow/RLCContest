using System.Windows.Forms;

using Core;
using Core.Circuits;

namespace RLCCalculator
{
    public partial class CircuitDetailForm : Form
    {
        

        public CircuitDetailForm()
        {
            InitializeComponent();
        }

        public ICircuit Circuit
        {
            set
            {
                if ( value is SerialCircuit )
                {
                    serialCircuitControl.Circuit = value;
                }
            }
        }

        private void CircuitDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }
    }
}
