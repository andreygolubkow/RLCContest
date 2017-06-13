using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using Tools;

namespace RLCCalculator
{
    public partial class FrequencyEditorForm : Form
    {
        public FrequencyEditorForm(List<double> frequencies)
        {
            InitializeComponent();
            frequenciesListBox.Items.Clear();
            foreach (double frequency in frequencies)
            {
                frequenciesListBox.Items.Add(Convert.ToString(frequency, CultureInfo.InvariantCulture));
            }
        }

        public List<double> Frequencies => (from object frequency in frequenciesListBox.Items select Convert.ToDouble(frequency, CultureInfo.InvariantCulture)).ToList();

        private void addButton_Click(object sender, EventArgs e)
        {
            if ( frequencyTextBox.Text.Length == 0 )
            {
                MessageBox.Show("You must enter the frequency");
                return;
            }
            try
            {
                frequenciesListBox.Items.Add(frequencyTextBox.Text.Trim());
                frequencyTextBox.Text = "";
            }
            catch ( Exception exception )
            {
                MessageBox.Show(@"You did not enter a number");
#if DEBUG
                MessageBox.Show(exception.Message);
#endif

            }

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (frequenciesListBox.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an item");
                return;
            }
            frequenciesListBox.Items.Remove(frequenciesListBox.SelectedItem);
        }

        private void frequencyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validators.DoubleEnterValidate(frequencyTextBox.Text, e);
        }
    }
}
