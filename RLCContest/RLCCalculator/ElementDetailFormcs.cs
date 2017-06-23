#region Using
using System;
using System.Drawing;
using System.Windows.Forms;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Elements;

using Tools;

#endregion

namespace RLCCalculator
{
    public partial class ElementDetailForm : Form
    {
        #region Private Fields
        private BaseElementControl _elementControl;

        #endregion

        #region Constructors
        public ElementDetailForm(IElement element = null)
        {
            InitializeComponent();

            capacitorElementControl.Location = new Point(12, 52);
            resistorElementControl.Location = new Point(12, 52);
            inductorElementControl.Location = new Point(12, 52);
            Size = new Size(286, 198);


            if (element != null)
            {
                if (element is Resistor)
                {
                    _elementControl = resistorElementControl;
                    componentTypeComboBox.SelectedIndex = 2;
                }
                else if (element is Capacitor)
                {
                    _elementControl = capacitorElementControl;
                    componentTypeComboBox.SelectedIndex = 0;
                }
                else if (element is Inductor)
                {
                    _elementControl = inductorElementControl;
                    componentTypeComboBox.SelectedIndex = 1;
                }

                _elementControl.Visible = true;
                _elementControl.Element = element;
            }
        }
        #endregion

        #region Public Properties
        public IElement Element => _elementControl.Element;
        #endregion

        #region Private Methods
        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            if (_elementControl == null)
            {
                MessageBox.Show(@"You must create an element");
                return;
            }
            try
            {
                if (_elementControl.Element.Name.Length == 0)
                {
                    throw new Exception("You must enter a valid name");
                }
                _elementControl.Element.TryLoad();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ComponentTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            capacitorElementControl.Visible = componentTypeComboBox.SelectedIndex == 0;
            inductorElementControl.Visible = componentTypeComboBox.SelectedIndex == 1;
            resistorElementControl.Visible = componentTypeComboBox.SelectedIndex == 2;

            _elementControl = componentTypeComboBox.SelectedIndex == 0 ? capacitorElementControl : _elementControl;
            _elementControl = componentTypeComboBox.SelectedIndex == 1 ? inductorElementControl : _elementControl;
            _elementControl = componentTypeComboBox.SelectedIndex == 2 ? resistorElementControl : _elementControl;
        } 
        #endregion
    }
}
