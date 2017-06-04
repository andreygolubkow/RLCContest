using System;
using System.ComponentModel;
using System.Windows.Forms;

using Core;

namespace Controls
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
                iComponentBindingSource.DataSource = _circuit;
            } 
        }

        public void Add(Core.IComponent component)
        {
            iComponentBindingSource.Add(component);
        }

        public void Remove(Core.IComponent component)
        {
            iComponentBindingSource.Remove(component);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public Core.IComponent CurrentComponent => (Core.IComponent)iComponentBindingSource.Current;

        private void iComponentBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            _currentChanged?.Invoke(sender,e);
        }

        protected string ElementName
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

        protected ICircuit ListDataSource
        {
            set
            {
                iComponentBindingSource.DataSource = value;
            }
        }
    }
}
