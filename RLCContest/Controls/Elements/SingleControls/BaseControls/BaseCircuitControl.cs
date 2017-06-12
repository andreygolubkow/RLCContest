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

        private void IComponentBindingSourceCurrentItemChanged(object sender, EventArgs e)
        {
            _currentChanged?.Invoke(sender,e);
        }

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

        private void elementsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
