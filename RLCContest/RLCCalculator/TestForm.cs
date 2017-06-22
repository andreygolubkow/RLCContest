using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Core;
using Core.Circuits;
using Core.Elements;
using CircuitGraphics;

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
            CircuitImageDrawer drawer = new CircuitImageDrawer();

            var circuit = new SerialCircuit();
            circuit.Add(new Resistor());
            circuit.Add(new Capacitor());

            graphicTestPictureBox.Image = drawer.GetCircuitImage(circuit);
        }
    }
}
