using System;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Circuits;

namespace Controls.Elements.SingleControls.Circuits
{
    public partial class SerialCircuitControl : BaseCircuitControl
    {
        public SerialCircuitControl()
        {
            InitializeComponent();
            _circuit = new SerialCircuit();
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
                if ( _circuit != null )
                {
                    _circuit.CircuitChanged -= CircuitChanged;
                }
                
                if (value == null)
                {
                    _circuit = new SerialCircuit();
                    return;
                }
                if ( !(value is SerialCircuit circuit) )
                {
                    throw new ArgumentException("Объект не являестся SerialCircuit");
                }
                base.Circuit = circuit;
                ElementName = circuit.Name;
                _circuit.CircuitChanged += CircuitChanged;
                
            }
        }

        private void CircuitChanged(object sender, EventArgs e)
        {
            
        }
    }
}
