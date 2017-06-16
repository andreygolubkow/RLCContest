using System;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Circuits;

namespace Controls.Elements.SingleControls.Circuits
{
    public partial class ParallelCircuitControl : BaseCircuitControl
    {
        public ParallelCircuitControl()
        {
            InitializeComponent();

            _circuit = new ParallelCircuit();
            _circuit.CircuitChanged += CircuitChanged;
        }

        public override ICircuit Circuit
        {
            get
            {
                _circuit.Name = ElementName;
                return _circuit;
            }
            set
            {
                if (!(value is ParallelCircuit) && value != null)
                {
                    throw new ArgumentException("Объект не являестся ParallelCircuit");
                }
                if (_circuit != null)
                {
                    _circuit.CircuitChanged -= CircuitChanged;
                }
                if (value == null)
                {
                    _circuit = new ParallelCircuit();

                }
                else
                {
                    _circuit = value;
                }

                base.Circuit = _circuit;
                _circuit.CircuitChanged += CircuitChanged;

            }
        }

        private void CircuitChanged(object sender, EventArgs e)
        {

        }
    }
}
