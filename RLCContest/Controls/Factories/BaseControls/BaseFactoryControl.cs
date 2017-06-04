using System;
using System.Globalization;
using System.Windows.Forms;

namespace Controls.Factories.BaseControls
{
    public partial class BaseFactoryControl : UserControl
    {
        protected BaseFactoryControl()
        {
            InitializeComponent();
        }

        public event EventHandler CreateButtonClick;

        public event EventHandler ModifyButtonClick;

        public event EventHandler RemoveButtonClick;

        public event EventHandler ClearButtonClick;

        public double Frequency
        {
            get => Convert.ToDouble(frequencyValueTextBox.TextLength);
            set => frequencyValueTextBox.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
        }

        public double Impedance
        {
            get => Convert.ToDouble(zValue.Text);
            set => zValue.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
        }

        private void createNewButton_Click(object sender, EventArgs e)
        {
            CreateButtonClick?.Invoke(sender,e);
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            ModifyButtonClick?.Invoke(sender, e);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            RemoveButtonClick?.Invoke(sender, e);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearButtonClick?.Invoke(sender, e);
        }

        private void calculateZButton_Click(object sender, EventArgs e)
        {

        }
    }
}
