using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Controls.CircuitDrawer;

using Core;
using Core.Circuits;
using Core.Elements;

namespace RLCCalculator
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void OpenFreqListEditorClick(object sender, EventArgs e)
        {
            var freqEditor = new FrequencyEditorForm(new List<double>());
            freqEditor.Show();
        }

        private void OpenWithTestListButtonClick(object sender, EventArgs e)
        {
            var list = new List<double>
                       {
                           15.1,
                           22.1,
                           1.9
                       };
            var freqEditor = new FrequencyEditorForm(list);
            freqEditor.Show();
        }

        private void OpenFreqListForTestButtonClick(object sender, EventArgs e)
        {
            var listA = new List<double>
                       {
                           15.1,
                           22.1,
                           1.9
                       };
            var freqEditor = new FrequencyEditorForm(listA);
            freqEditor.ShowDialog();
            List<double> listB = freqEditor.Frequencies;
            if ( !listA.SequenceEqual(listB) )
            {
                throw new Exception("Sequences not equals");
            }
        }

        private void buildGraphButton_Click(object sender, EventArgs e)
        {
            ICircuit circuit = new SerialCircuit();
            circuit.Name = "SC1";
            circuit.Add(new Resistor("R1", 5));
            circuit.Add(new Capacitor("C1", 2));

            var graph = CircuitAdapter.CircuitToGraph(circuit);


            ICircuit c2 = new ParallelCircuit();
            c2.Add(new Resistor("RR1", 2));
            c2.Add(new Resistor("RR2", 2));

            circuit.Add(c2);

            circuit.Add(new Resistor("r3", 3));
            
        }
    }
}
