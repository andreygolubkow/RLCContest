﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using Tools;

namespace RLCCalculator
{
    public partial class FrequencyEditorForm : Form
    {
        private List<double> _freqDoubles;

        public FrequencyEditorForm(List<double> frequencies)
        {
            InitializeComponent();
            _freqDoubles = frequencies;
            doubleBindingSource.DataSource = _freqDoubles;

        }

        public List<double> Frequencies => _freqDoubles; 

        private void AddButtonClick(object sender, EventArgs e)
        {
            if ( frequencyTextBox.Text.Length == 0 )
            {
                MessageBox.Show(@"You must enter the frequency");
                return;
            }
            try
            {
                doubleBindingSource.Add(Convert.ToDouble(frequencyTextBox.Text.Trim()));
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

        private void RemoveButtonClick(object sender, EventArgs e)
        {
            if (frequenciesListBox.SelectedIndex == -1)
            {
                MessageBox.Show(@"You must select an item");
                return;
            }
            doubleBindingSource.RemoveCurrent();
        }

        private void FrequencyTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            Validators.DoubleEnterValidate(frequencyTextBox.Text, e);
        }
    }
}
