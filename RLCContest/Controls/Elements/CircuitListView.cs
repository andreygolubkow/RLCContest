using System;
using System.ComponentModel;
using System.Windows.Forms;

using Core;

using IComponent = Core.IComponent;

namespace Controls.Elements
{
    public partial class CircuitListView : UserControl
    {
        private ICircuit _circuit;

        public CircuitListView()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public ICircuit Circuit
        {
            set
            {
                if ( _circuit != null )
                {
                    _circuit.CircuitChanged -= CircuitChanged;
                }
                
                _circuit = value;
                if (value != null)
                {
                    _circuit.CircuitChanged += CircuitChanged;
                    FillList(_circuit);
                }
            }
            get
            {
                return _circuit;

            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public IComponent Current
        {
            get
            {
                if ( _circuit == null )
                {
                    return null;
                }
                if ( listBox.SelectedIndex == -1 )
                {
                    return null;
                }
                return _circuit[listBox.SelectedIndex];
            }
        }

        private void FillList(ICircuit circuit)
        {
            listBox.Items.Clear();
            foreach (IComponent e in circuit)
            {
                listBox.Items.Add(e.Name);
            }
        }

        private void CircuitChanged(object sender, EventArgs e)
        {
            FillList(_circuit);
        }
    }
}
