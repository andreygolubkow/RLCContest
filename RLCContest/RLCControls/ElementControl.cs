using System;
using System.ComponentModel;
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
        }

        public ElementControl(string name, double value, Type type)
        {
            InitializeComponent();
            if ( type == typeof(Resistor) )
            {
                _element = new Resistor(name, value);
            }
            if (type == typeof(Capacitor))
            {
                _element = new Capacitor(name, value);
            }
            if (type == typeof(Inductor))
            {
                _element = new Inductor(name, value);
            }

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
