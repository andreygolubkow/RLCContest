using System;
using System.Numerics;
using System.Runtime.Serialization;

namespace Core.Elements
{
    [Serializable]
    public class Capacitor : IElement
    {
        private string _name;
        private double _value;

        public Capacitor()
        {
            Name = "Capacitor";
            Value = 0;
        }

        public Capacitor(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #region Implementation of IElement

        /// <summary>
        /// Событие, вызывается когда изменено значение.
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Название элемента.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if ( value.Length == 0 )
                {
                    throw new ArgumentException("Имя должно быть не пустым.");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Номинал.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException("Ёмкость не должна быть меньше нуля.");
                }
                _value = value;
                ValueChanged?.Invoke(this,new EventArgs());
            }
        }

        /// <summary>
        /// Рассчет сопротивления.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Комплексное сопротивление.</returns>
        public Complex CalculateZ(double frequency)
        {
            if (frequency < 0)
            {
                throw new ArgumentException("Частота не может быть отрицательной.");
            }
            return new Complex(0, -1 / (2 * Math.PI * frequency * Value));
        }

        #endregion

    }
}
