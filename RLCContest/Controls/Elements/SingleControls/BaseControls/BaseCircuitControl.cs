using System;
using System.ComponentModel;
using System.Windows.Forms;

using Core;

namespace Controls.Elements.SingleControls.BaseControls
{
    public partial class BaseCircuitControl : UserControl
    {
        private event EventHandler _currentChanged;

        protected ICircuit _circuit;

        protected BaseCircuitControl()
        {
            InitializeComponent();
        }
        
        public event EventHandler CurrentChanged
        {
            add => _currentChanged += value;
            remove => _currentChanged -= value;
        }

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

        public void Add(Core.IComponent component)
        {
            _circuit.Add(component);
        }

        public void Remove(Core.IComponent component)
        {
            _circuit.Remove(component);
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

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if ( _circuit != null )
            {
                if ( nameTextBox.Text.Length > 0 )
                {
                    _circuit.Name = nameTextBox.Text;
                }
            }
        }
    }
}
