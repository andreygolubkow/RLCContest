using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using CircuitDrawer;

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
           

            var pc1 = new ParallelCircuit();
            pc1.Name = "PPC1";
            pc1.Add(new Resistor("r1",1));
            pc1.Add(new Inductor("IN1",2));

            var pc2 = new ParallelCircuit();
            pc2.Name = "PPC2";
            pc2.Add(new Inductor("IN11", 2));
            pc2.Add(new Resistor("r11", 1));

            var sc1 = new SerialCircuit();
            sc1.Name = "sc1";
            sc1.Add(new Capacitor("CCCC1",1));
            sc1.Add(pc1);

            var sc3 = new SerialCircuit();
            sc3.Name = "sc3";
            sc3.Add(new Capacitor("C3C1", 1));
            sc3.Add(new Resistor("C3C2", 1));

            var sc2 = new SerialCircuit();
            sc2.Name = "sc2";
            sc2.Add(pc2);
            sc2.Add(new Capacitor("C2",2));

            var pc = new ParallelCircuit();
            pc.Name = "PC1";
            pc.Add(sc1);
            pc.Add(sc3);
            pc.Add(sc2);




            graphicTestPictureBox.Image = pc.GetImage();
        }
    }
}
