using System;

using Controls.SingleControls.BaseControls;

using Core;
using Core.Circuits;

namespace Controls.SingleControls.Circuits
{
    public partial class SerialCircuitControl : BaseCircuitControl
    {
        public SerialCircuitControl()
        {
            InitializeComponent();
            _circuit = new SerialCircuit();
            ListDataSource = _circuit;
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
                if (value == null)
                {
                    _circuit = new SerialCircuit();
                    return;
                }
                if ( !(value is SerialCircuit circuit) )
                {
                    throw new ArgumentException("Объект не являестся SerialCircuit");
                }
                _circuit = circuit;
                ElementName = circuit.Name;
                ListDataSource = _circuit;
            }
        }
    }
}
