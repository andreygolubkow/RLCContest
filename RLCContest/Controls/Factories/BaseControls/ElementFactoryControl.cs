using System;
using System.Drawing;
using System.Windows.Forms;

using Controls.Factories.BaseControls;
using Controls.SingleControls.BaseControls;

namespace Controls.Factories.Elements
{
    public partial class ElementFactoryControl : BaseFactoryControl
    {
        private BaseElementControl _elementControl;

        public ElementFactoryControl()
        {
            InitializeComponent();
            for (int i = 0; i < Controls.Count; i++)
            {
                if ( Controls[i] is BaseElementControl ctrl)
                {
                    ctrl.Location = new Point(3, 65);
                }
            }
            //inductorElementControl.Location = new Point(3, 65);
            //capacitorElementControl.Location = new Point(3, 65);
            //resistorElementControl.Location = new Point(3, 65);
            Size = new Size(352, 269);
            elementTypeComboBox.SelectedIndex = 0;
        }

        private void elementTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            /*
             *  0=Capacitor
             *  1=Inductor
             *  2=Resistor
             */
            switch (elementTypeComboBox.SelectedIndex)
            {
                case 0:
                    _elementControl = capacitorElementControl;
                    break;
                case 1:
                    _elementControl = inductorElementControl;
                    break;
                case 2:
                    _elementControl = resistorElementControl;
                    break;
                default:
                    _elementControl = null;
                    throw new Exception("Не присвоен тип элемента.");
            }
            capacitorElementControl.Visible = elementTypeComboBox.SelectedIndex == 0;
            inductorElementControl.Visible = elementTypeComboBox.SelectedIndex == 1;
            resistorElementControl.Visible = elementTypeComboBox.SelectedIndex == 2;
            _elementControl.CleaFields();
        }

        private void calculateZButton_Click(object sender, EventArgs e)
        {
            if ( _elementControl != null )
            {
                try
                {
                    Impedance = _elementControl.Element.CalculateZ(Frequency);
                }
                catch ( Exception exception )
                {
                    MessageBox.Show(exception.Message);
                }
                
            }
        }

        private void ElementFactoryControl_ClearButtonClick(object sender, EventArgs e)
        {
            _elementControl.CleaFields();
        }
    }
}
