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
        }

        public ElementControl Element
        {
            get
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
                catch ( Exception )
                {
                    MessageBox.Show("В поле номинал введено не число.");
                }
                var name = elementName.Text;
                double value = Convert.ToDouble(elementValue.Text);

                if ( selectedElement.ToLower() == "резистор" )
                {
                    return new ElementControl(new Resistor(name,value));
                }
                if (selectedElement.ToLower() == "конденсатор")
                {
                    return new ElementControl(new Capacitor(name, value));
                }
                if (selectedElement.ToLower() == "индуктивность")
                {
                    return new ElementControl(new Inductor(name, value));
                }
                throw new Exception("Нельзя создать элемента типа "+ elementsComboBox.SelectedText);
            }
        }
    }
}
