#region Using
using System;
using System.Drawing;
using System.Windows.Forms;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Circuits;

using Tools;

#endregion

namespace RLCCalculator
{
    public partial class CircuitDetailForm : Form
    {
        #region Private Fields
        private BaseCircuitControl _circuitControl;
        private readonly FormOpenMode _mode;

        #endregion

        #region Constructors
        public CircuitDetailForm(FormOpenMode mode = FormOpenMode.Create)
        {
            InitializeComponent();

            Size = new Size(304, 362);
            serialCircuitControl.Location = new Point(12, 60);
            parallelCircuitControl.Location = new Point(12, 60);

            _mode = mode;
            switch (mode)
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }

        }
        #endregion

        #region Public Properties
        public ICircuit Circuit
        {
            set
            {
                if (value is SerialCircuit)
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
            get => _circuitControl.Circuit;
        }


        #endregion

        #region Private Methods
        private void CircuitDetailFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mode == FormOpenMode.LiveEdit)
            {
                e.Cancel = true;
                Visible = false;
            }

        }

        private void RemoveElementButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You must create circuit  to delete items");
                return;
            }
            if (_circuitControl.CurrentComponent == null)
            {
                MessageBox.Show(@"You must select an item to delete");
                return;
            }
            _circuitControl.Remove(_circuitControl.CurrentComponent);
        }

        private void AddComponentButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You need to select an electrical circuit to add elements");
                return;
            }
            var componentForm = new ElementDetailForm(null);
            if (componentForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _circuitControl.Add(componentForm.Element);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
        }

        private void CircuitTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {

            if (circuitTypeComboBox.SelectedIndex == 0)
            {
                _circuitControl = serialCircuitControl;
            }
            if (circuitTypeComboBox.SelectedIndex == 1)
            {
                _circuitControl = parallelCircuitControl;
            }

            serialCircuitControl.Visible = circuitTypeComboBox.SelectedIndex == 0;
            parallelCircuitControl.Visible = circuitTypeComboBox.SelectedIndex == 1;

            if (_mode == FormOpenMode.Create)
            {
                _circuitControl.Circuit = null;
            }
        }

        private void CreateButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You need to select an electrical circuit to create circuit");
                return;
            }
            try
            {
                if (_circuitControl.Circuit.Name.Length == 0)
                {
                    throw new Exception("You must enter a valid name");
                }
                ICircuit circuit = _circuitControl.Circuit;
                if (circuit == null)
                {
                    throw new ArgumentNullException(nameof(circuit));
                }
                circuit.TryLoad();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void AddSubcircuitButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You need to select an electrical circuit to add elements");
                return;
            }
            var circuitForm = new CircuitDetailForm(FormOpenMode.Create);
            if (circuitForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _circuitControl.Add(circuitForm.Circuit);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void EditElementButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You must create circuit to edit");
                return;
            }
            if (_circuitControl.CurrentComponent == null)
            {
                MessageBox.Show(@"You must select an item to edit");
                return;
            }
            if (_circuitControl.CurrentComponent is IElement element)
            {
                var elementForm = new ElementDetailForm(element);
                if (elementForm.ShowDialog() == DialogResult.OK)
                {
                }
            }
            else if (_circuitControl.CurrentComponent is ICircuit circuit)
            {
                var circuitForm = new CircuitDetailForm(FormOpenMode.Edit)
                {
                    Circuit = circuit
                };
                circuitForm.ShowDialog();
            }
        } 
        #endregion
    }
}
