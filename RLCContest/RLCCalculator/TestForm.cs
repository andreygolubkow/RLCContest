using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RLCCalculator
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void openFreqListEditor_Click(object sender, EventArgs e)
        {
            var freqEditor = new FrequencyEditorForm(new List<double>());
            freqEditor.Show();
        }

        private void openWithTestListButton_Click(object sender, EventArgs e)
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

        private void OpenFreqListForTestButton_Click(object sender, EventArgs e)
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
    }
}
