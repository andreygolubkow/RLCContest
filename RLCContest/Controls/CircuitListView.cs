using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;

using IComponent = Core.IComponent;

namespace Controls
{
    public partial class CircuitListView : UserControl
    {
        private ICircuit _circuit;

        public CircuitListView()
        {
            InitializeComponent();
        }

        public ICircuit Circuit
        {
            set
            {
                if ( _circuit != null )
                {
                    _circuit.CircuitChanged -= CircuitChanged;
                }
                _circuit = value;
                _circuit.CircuitChanged += CircuitChanged;
            }
            get
            {
                return _circuit;

            }
        }

        private void FillList(ICircuit circuit)
        {
            listBox.Items.Clear();
            foreach (IComponent e in _circuit)
            {
                listBox.Items.Add(e.Name);
            }
        }

        private void CircuitChanged(object sender, EventArgs e)
        {
            FillList(_circuit);
        }
    }
}
