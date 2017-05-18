using System;
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
        public ElementControl()
        {
            InitializeComponent();
            elementName.Text = "";
            elementValue.Text = "";
            elementPicture.Image = null;
        }

        public ElementControl(string name, double value, Type type)
        {
            InitializeComponent();
            if ( type == typeof(Resistor) )
            {
                _element = new Resistor(name, value);
                elementPicture.Image = RLCControls.Properties.Resources.Resistor;
            }
            if (type == typeof(Capacitor))
            {
                _element = new Capacitor(name, value);
                elementPicture.Image = RLCControls.Properties.Resources.Capasitor;
            }
            if (type == typeof(Inductor))
            {
                _element = new Inductor(name, value);
                elementPicture.Image = RLCControls.Properties.Resources.Inductor;
            }
            elementName.Text = _element.Name;
            elementValue.Text = Convert.ToString(_element.Value, CultureInfo.CurrentCulture);

        }

        public ElementControl(IElement element)
        {
            InitializeComponent();
            _element = element;
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
        public double Value
        {
            get
            {
                return _element.Value;
            }

            set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException("Сопротивление не может быть меньше 0.");
                }
                _element.Value = value;
                elementValue.Text = Convert.ToString(_element.Value, CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Наименование резистора.
        /// </summary>
        public string Name
        {
            get
            {
                return _element.Name;
            }

            set
            {
                if ( value.Length == 0 )
                {
                    throw new ArgumentException("Название не может быть пустым.");
                }
                _element.Name = value;
                elementName.Text = _element.Name;
            }
        }

        /// <summary>
        /// Получение элемента.
        /// </summary>
        public IElement Element => _element;

        [DefaultValue(null)]
        public IElement InputElement { get; set; }

        [DefaultValue(null)]
        public IElement OutputElement { get; set; }

    }
}
