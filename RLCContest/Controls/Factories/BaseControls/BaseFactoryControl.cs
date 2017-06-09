using System;
using System.Globalization;
using System.Numerics;
using System.Windows.Forms;

namespace Controls.Factories.BaseControls
{
    public partial class BaseFactoryControl : UserControl
    {
        private Complex _impedanceComplex;

        protected BaseFactoryControl()
        {
            InitializeComponent();
            _impedanceComplex = new Complex(0,0);
        }

        public event EventHandler CreateButtonClick;

        public event EventHandler ModifyButtonClick;

        public event EventHandler RemoveButtonClick;

        public event EventHandler ClearButtonClick;

        public double Frequency
        {
            get => frequencyValueTextBox.TextLength>0 ? Convert.ToDouble(frequencyValueTextBox.Text) : 0;
            set => frequencyValueTextBox.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
        }

        public Complex Impedance
        {
            get
            {
                return _impedanceComplex;
            }
            set 
            {
                _impedanceComplex = value;
                zValue.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
            }
        }

        private void CreateNewButtonClick(object sender, EventArgs e)
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

        private void CalculateZButtonClick(object sender, EventArgs e)
        {

        }
    }
}
