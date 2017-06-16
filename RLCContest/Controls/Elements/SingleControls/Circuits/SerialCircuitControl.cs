using System;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Circuits;

namespace Controls.Elements.SingleControls.Circuits
{
    [Serializable]
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
                if (!(value is SerialCircuit) && value != null)
                {
                    throw new ArgumentException("Объект не являестся SerialCircuit");
                }
                if ( _circuit != null )
                {
                    _circuit.CircuitChanged -= CircuitChanged;
                }
                if ( value == null )
                {
                    _circuit = new SerialCircuit();

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
