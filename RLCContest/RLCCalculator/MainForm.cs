using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Core;
using Core.Circuits;
using Core.Elements;

using Tools;

namespace RLCCalculator
{
    public partial class MainForm : Form
    {
        private Project _project;

        private CalculatorZForm _calculatorZ;
        private CircuitDetailForm _circuitDetailForm;

        public MainForm()
        {
            InitializeComponent();
            _project = new Project();
            _project.Circuits = new List<IComponent>();
            _project.Frequencies = new List<double>();
            iComponentBindingSource.DataSource = _project.Circuits;
            _calculatorZ = new CalculatorZForm();
            _circuitDetailForm = new CircuitDetailForm(FormOpenMode.LiveEdit);
        }

        private void frequenciesMenuItem_Click(object sender, EventArgs e)
        {
            var freqEditorForm = new FrequencyEditorForm(_project.Frequencies);
            freqEditorForm.ShowDialog();
            _project.Frequencies = freqEditorForm.Frequencies;
            _calculatorZ.Frequencies = _project.Frequencies;
        }

        private void zCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( _calculatorZ == null )
            {
                _calculatorZ = new CalculatorZForm();
                _calculatorZ.Frequencies = _project.Frequencies;
            }
            _calculatorZ.Visible = true;
        }

        private void iComponentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if ( _calculatorZ == null )
            {
                _calculatorZ = new CalculatorZForm();
                _calculatorZ.Frequencies = _project.Frequencies;
            }
            _calculatorZ.Circuit = (ICircuit)iComponentBindingSource.Current;
            _circuitDetailForm.Circuit = (ICircuit)iComponentBindingSource.Current;
        }

        private void testCircuitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c1 = new SerialCircuit();
            c1.Name = "C1";
            c1.Add(new Resistor("R1",12));
            c1.Add(new Capacitor("Cap1",1.2));
            var c2 = new SerialCircuit();
            c2.Name = "C2";
            c2.Add(new Inductor("I1", 12));
            c2.Add(new Capacitor("Cap1", 1.2));
            var list = new List<IComponent>();
            list.Add(c1);
            list.Add(c2);
            iComponentBindingSource.DataSource = list;

        }

        private void circuitEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _circuitDetailForm.Visible = true;
        }

        private void refreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iComponentBindingSource.ResetBindings(false);
        }

        private void newCircuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var circuitForm = new CircuitDetailForm(FormOpenMode.Create);
            if (circuitForm.ShowDialog() == DialogResult.OK)
            {
                iComponentBindingSource.Add(circuitForm.Circuit);
            }
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _project = new Project();
            _project.Frequencies = new List<double>();
            _project.Circuits = new List<IComponent>();
            iComponentBindingSource.DataSource = _project.Circuits;
            _calculatorZ.Frequencies = _project.Frequencies;
            _calculatorZ.Circuit = null;
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( openFileDialog.ShowDialog() == DialogResult.OK )
            {
                DataSerializer.DeserializeBin(openFileDialog.FileName,ref _project);
                iComponentBindingSource.DataSource = _project.Circuits;
                _calculatorZ.Frequencies = _project.Frequencies;
                _calculatorZ.Circuit = null;
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                iComponentBindingSource.DataSource = null;
                _calculatorZ.Circuit = null;
                _circuitDetailForm.Circuit = null;
                GC.Collect();
                DataSerializer.SerializeBin(saveFileDialog.FileName, _project);
            }
        }
    }
}
