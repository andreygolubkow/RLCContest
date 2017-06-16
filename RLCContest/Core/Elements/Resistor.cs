namespace Core.Elements
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Резистор.
    /// </summary>
    [Serializable]
    public class Resistor : IElement
    {
        /// <summary>
        ///     Наименование резистора.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Номинал резистора.
        /// </summary>
        private double _value;

        /// <summary>
        ///     Пустой контруктор для <see cref="Resistor" />.
        ///     Номинал = 0.
        ///     Наименование компонента:"Resistor".
        /// </summary>
        public Resistor()
        {
            Value = 0;
            Name = "Resistor";
        }

        /// <summary>
        ///     Конструктор <see cref="Resistor" />.
        /// </summary>
        /// <param name="name">
        ///     Наименование элемента.
        /// </param>
        /// <param name="value">
        ///     Сопротивление.
        /// </param>
        public Resistor(string name, double value)
        {
            Value = value;
            Name = name;
        }

        #region Implementation of IElement

        /// <summary>
        ///     Срабатывает при изменении сопротивления.
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        ///     Название элемента.
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                if ( value.Length == 0 )
                {
                    throw new ArgumentException("The name of the resistor can not be empty.");
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Сопротивление резистора.
        /// </summary>
        public double Value
        {
            get => _value;

            set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException("Resistance can not be negative.");
                }

                _value = value;
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Рассчет сопротивления.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Сопростивление резистора, не зависит от частоты.</returns>
        public Complex CalculateZ(double frequency)
        {
            if ( frequency < 0 )
            {
                throw new ArgumentException("The frequency can not be negative.");
            }
            return new Complex(Value, 0);
        }

        #endregion

        #region Implementation of ICloneable

        /// <inheritdoc />
        public object Clone()
        {
            return new Resistor(Name, Value);
        }

        #endregion
    }
}