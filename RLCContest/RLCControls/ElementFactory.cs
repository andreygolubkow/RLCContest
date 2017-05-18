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

        public UserControl Element
        {
            get
            {
                string selectedElement = elementsComboBox.SelectedText;
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
                    return new ElementControl(name,value);
                }
                if (selectedElement.ToLower() == "конденсатор")
                {

                }
                if (selectedElement.ToLower() == "индуктивность")
                {

                }
                throw new Exception("Нельзя создать элемента типа "+ elementsComboBox.SelectedText);
            }
        }
    }
}
