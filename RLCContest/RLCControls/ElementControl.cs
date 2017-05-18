using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

using Core.Elements;

namespace RLCControls
{
    public partial class ElementControl: UserControl
    {
        private IElement _element;

        public ElementControl(IElement element)
        {
            _element = element;
            InitializeComponent();
            if ( element is Resistor )
            {
                elementPicture.Image = RLCControls.Properties.Resources.Resistor;
            }
            if (element is Capacitor)
            {
                elementPicture.Image = RLCControls.Properties.Resources.Capasitor;
            }
            if (element is Inductor)
            {
                elementPicture.Image = RLCControls.Properties.Resources.Inductor;
            }
            elementName.Text = _element.Name;
            elementValue.Text = Convert.ToString(_element.Value, CultureInfo.CurrentCulture);

        }

        /// <summary>
        /// Номинал резистора.
        /// </summary>
        public double ElementValue => _element?.Value ?? 0;

        /// <summary>
        /// Наименование резистора.
        /// </summary>
        public string ElementName => _element != null ? _element.Name : "NullElementName";

        /// <summary>
        /// Получение элемента.
        /// </summary>
        public IElement Element => _element;

        [DefaultValue(null)]
        public List<ElementControl> InputElements { get; set; }

        [DefaultValue(null)]
        public List<ElementControl> OutputElements { get; set; }

        private void elementPicture_MouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}
