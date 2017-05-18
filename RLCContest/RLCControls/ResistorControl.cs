using System;
using System.Windows.Forms;

using Core.Elements;

namespace RLCControls
{
    public partial class ResistorControl: UserControl
    {
        private Resistor _resistor;
        public ResistorControl()
        {
            InitializeComponent();
            _resistor = new Resistor();
        }

        public ResistorControl(string name, double value)
        {
            InitializeComponent();
            _resistor = new Resistor(name,value);
        }

        /// <summary>
        /// Номинал резистора.
        /// </summary>
        public double Value
        {
            get
            {
                return _resistor.Value;
            }

            set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException("Сопротивление не может быть меньше 0.");
                }
                _resistor.Value = value;
            }
        }

        /// <summary>
        /// Наименование резистора.
        /// </summary>
        public string Name
        {
            get
            {
                return _resistor.Name;
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
        public IElement Element => _resistor;
    }
}
