#region Using
using System;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Circuits;

#endregion
namespace Controls.Elements.SingleControls.Circuits
{
    /// <summary>
    /// Элемент управления для эл. цепи с параллельным соединением.
    /// </summary>
    public partial class ParallelCircuitControl : BaseCircuitControl
    {
        #region Constructors

        /// <summary>
        /// Создает экземпляр элемента управления.
        /// </summary>
        public ParallelCircuitControl()
        {
            InitializeComponent();
            _circuit = new ParallelCircuit();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Электрическая цепь.
        /// </summary>
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
            }
        } 
        #endregion
    }
}
