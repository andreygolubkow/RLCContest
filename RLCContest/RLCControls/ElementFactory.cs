using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core.Elements;

namespace RLCControls
{
    public partial class ElementFactory : UserControl
    {
        public ElementFactory()
        {
            InitializeComponent();
#if DEBUG
            debugGetElement.Visible = true;
#endif
        }

        public ElementControl GetElementControl()
        {
            string selectedElement = (string)elementsComboBox.SelectedItem;
            if (elementName.Text.Length == 0)
            {
                throw new ArgumentException("Заполните поле 'Наименование'");
            }
            try
            {
                if (Convert.ToDouble(elementValue.Text, CultureInfo.CurrentCulture) < 0)
                {
                    throw new ArgumentException("Заполните поле 'Номинал'");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("В поле номинал введено не число.");
            }
            string name = elementName.Text;
            double value = Convert.ToDouble(elementValue.Text);
            IElement element;
            switch (selectedElement.ToLower())
            {
                case "резистор":
                    element = new Resistor(name, value);
                    break;
                case "емкость":
                    element = new Capacitor(name, value);
                    break;
                case "индуктивность":
                    element = new Inductor(name, value);
                    break;
                default:
                    throw new Exception("Нельзя создать элемента типа " + elementsComboBox.SelectedText);
            }
            return new ElementControl(element);
        }

        private void debugGetElement_Click(object sender, EventArgs e)
        {
            ElementControl element = GetElementControl();
            MessageBox.Show(element.Name);
        }
    }
}
