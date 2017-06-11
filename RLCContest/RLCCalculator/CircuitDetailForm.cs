using System.Windows.Forms;

using Core;

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
                circuitFactoryControl.Circuit = value;
            }
        }

        private void CircuitDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }
    }
}
