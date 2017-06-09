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
        
        public MainForm()
        {
            InitializeComponent();
            _project = new Project();
            _calculatorZ = new CalculatorZForm();
            _calculatorZ.VisibleChanged += FormCalculatorZVisibleChanged;
#if DEBUG
            var testForm = new TestForm();
            testForm.Show();
#endif
        }

        private void FormCalculatorZVisibleChanged(object sender, EventArgs e)
        {
            zCalculatorToolStripMenuItem.Checked = _calculatorZ.Visible;
        }

        private void frequenciesMenuItem_Click(object sender, System.EventArgs e)
        {
            var freqEditorForm = new FrequencyEditorForm(_project.Frequencies);
            freqEditorForm.ShowDialog();
            _project.Frequencies = freqEditorForm.Frequencies;
            _calculatorZ.Frequencies = _project.Frequencies;
        }

        private void zCalculatorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if ( _calculatorZ == null )
            {
                _calculatorZ = new CalculatorZForm();
                _calculatorZ.Frequencies = _project.Frequencies;
            }
            _calculatorZ.Visible = zCalculatorToolStripMenuItem.Checked;
        }

        private void iComponentBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if ( _calculatorZ == null )
            {
                _calculatorZ = new CalculatorZForm();
                _calculatorZ.Frequencies = _project.Frequencies;
            }
            _calculatorZ.Circuit = (ICircuit)iComponentBindingSource.Current;
        }

        private void testCircuitsToolStripMenuItem_Click(object sender, System.EventArgs e)
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
    }
}
