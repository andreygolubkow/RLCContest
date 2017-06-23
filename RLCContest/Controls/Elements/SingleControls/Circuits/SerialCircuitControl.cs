#region Using
using System;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Circuits;

#endregion

namespace Controls.Elements.SingleControls.Circuits
{
    #region Attributes
    [Serializable]
    #endregion
    public partial class SerialCircuitControl : BaseCircuitControl
    {
        #region Constructors
        public SerialCircuitControl()
        {
            InitializeComponent();
            _circuit = new SerialCircuit();
        }

        #endregion

        #region Public Properties
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
                if (_circuit != null)
                {
                }
                if (value == null)
                {
                    _circuit = new SerialCircuit();

                }
                else
                {
                    _circuit = value;
                }

                base.Circuit = _circuit;
            }
        } 
        #endregion
    }
}
