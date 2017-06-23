#region Using
using System;
using System.ComponentModel;
using System.Windows.Forms;

using Core;

#endregion

namespace Controls.Elements.SingleControls.BaseControls
{
    #region Attributes
    [Serializable]
    #endregion
    public partial class BaseCircuitControl : UserControl
    {

        #region Protected Fields
        protected ICircuit _circuit;
        #endregion

        #region Constructors
        protected BaseCircuitControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public virtual ICircuit Circuit
        {
            get => _circuit;
            set
            {
                _circuit = value;
                ElementName = value.Name;
                circuitListView.Circuit = _circuit;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public Core.IComponent CurrentComponent => circuitListView.Current;

        public string ElementName
        {
            get
            {
                return nameTextBox.Text;
            }
            set
            {
                nameTextBox.Text = value;
            }
        }
        #endregion

        #region Public Methods
        public void Add(Core.IComponent component)
        {
            _circuit.Add(component);
        }

        public void Remove(Core.IComponent component)
        {
            _circuit.Remove(component);
        }
        #endregion

        #region Private Methods
        private void NameTextBoxTextChanged(object sender, EventArgs e)
        {
            if (_circuit != null)
            {
                if (nameTextBox.Text.Length > 0)
                {
                    _circuit.Name = nameTextBox.Text;
                }
            }
        } 
        #endregion
    }
}
