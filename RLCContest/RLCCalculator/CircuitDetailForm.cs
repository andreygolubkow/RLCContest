using System;
using System.Drawing;
using System.Windows.Forms;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Circuits;

namespace RLCCalculator
{
    public partial class CircuitDetailForm : Form
    {
        private BaseCircuitControl _circuitControl;
        private FormOpenMode _mode;

        public CircuitDetailForm(FormOpenMode mode = FormOpenMode.Create)
        {
            InitializeComponent();

            Size = new Size(304, 362);
            serialCircuitControl.Location = new Point(12, 60);
            parallelCircuitControl.Location = new Point(12, 60);

            _mode = mode;
            switch ( mode )
            {
                case FormOpenMode.Create:
                    
                    circuitTypeComboBox.Enabled = true;
                    createButton.Visible = true;
                   
                    break;
                case FormOpenMode.Edit:
                   
                    circuitTypeComboBox.Enabled = false;
                   
                    break;
                case FormOpenMode.LiveEdit:
                   
                    circuitTypeComboBox.Enabled = false;
                    break;
            }
            
        }

        public ICircuit Circuit
        {
            set
            {
                if ( value is SerialCircuit )
                {
                    circuitTypeComboBox.SelectedIndex = 0;
                    _circuitControl.Circuit = value;
                }
                if (value is ParallelCircuit)
                {
                    circuitTypeComboBox.SelectedIndex = 1;
                    _circuitControl.Circuit = value;
                }
            }
            get
            {
                return _circuitControl.Circuit;
            }
        }


        private void CircuitDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( _mode == FormOpenMode.LiveEdit )
            {
                e.Cancel = true;
                Visible = false;
            }

        }

        private void removeElementButton_Click(object sender, System.EventArgs e)
        {
            _circuitControl.Remove(_circuitControl.CurrentComponent);
        }

        private void addComponentButton_Click(object sender, System.EventArgs e)
        {
            var componentForm = new ElementDetailForm(null);
            if ( componentForm.ShowDialog() == DialogResult.OK )
            {
                _circuitControl.Add(componentForm.Element);
            }
        }

        private void circuitTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            if ( circuitTypeComboBox.SelectedIndex == 0 )
            {
                _circuitControl = serialCircuitControl;
            }
            if (circuitTypeComboBox.SelectedIndex == 1)
            {
                _circuitControl = parallelCircuitControl;
            }

            serialCircuitControl.Visible = circuitTypeComboBox.SelectedIndex == 0;
            parallelCircuitControl.Visible = circuitTypeComboBox.SelectedIndex == 1;

            if ( _mode == FormOpenMode.Create )
            {
                _circuitControl.Circuit = null;
            }
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void createButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                ICircuit circuit = _circuitControl.Circuit;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch ( Exception exception )
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void addSubcircuitButton_Click(object sender, EventArgs e)
        {
            var circuitForm = new CircuitDetailForm(FormOpenMode.Create);
            if (circuitForm.ShowDialog() == DialogResult.OK)
            {
                _circuitControl.Add(circuitForm.Circuit);
            }
        }

        private void editElementButton_Click(object sender, EventArgs e)
        {
            if ( _circuitControl.CurrentComponent is IElement element )
            {
                var elementForm = new ElementDetailForm(element);
                if ( elementForm.ShowDialog() == DialogResult.OK )
                {
                    var  a = elementForm.Element;
                }
            }
            else if (_circuitControl.CurrentComponent is ICircuit circuit)
            {
                 var circuitForm = new CircuitDetailForm(FormOpenMode.Edit);
                circuitForm.Circuit = circuit;
                circuitForm.ShowDialog();
            }
        }

        private void okEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                ICircuit circuit = _circuitControl.Circuit;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
