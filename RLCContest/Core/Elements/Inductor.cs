#region Using
using System;
using System.Numerics;

#endregion

namespace Core.Elements
{

    /// <summary>
    /// Класс катушки индуктивности.
    /// </summary>
    #region Attributes
    [Serializable] 
    #endregion
    public class Inductor : IElement
    {
        #region Private Members
        /// <summary>
        ///     Наименование.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Индуктивность.
        /// </summary>
        private double _value;

        #endregion

        #region Constructors
        /// <summary>
        ///     Создает новый <see cref="Inductor" />.
        ///     С нулевым номиналом и наименованием Inductor.
        /// </summary>
        public Inductor()
            : this("New Inductor", 0)
        {
        }

        /// <summary>
        ///     Создает новый <see cref="Inductor" />.
        /// </summary>
        /// <param name="name">
        ///     Наименование компонента.
        /// </param>
        /// <param name="value">
        ///     Номинал.
        /// </param>
        public Inductor(string name, double value)
        {
            Name = name;
            Value = value;
        } 
        #endregion

        #region Implementation of IElement

        /// <summary>
        ///     Вызывается при изменении номинала.
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
                    throw new ArgumentException("The name of the coil can not be empty.");
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Значение.
        /// </summary>
        public double Value
        {
            get => _value;

            set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException("Inductance can not be negative.");
                }
                if (!(Math.Abs(value - _value) > 0.0001))
                {
                    return;
                }

                _value = value;
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Рассчет сопротивления.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Комплексное число.</returns>
        public Complex CalculateZ(double frequency)
        {
            if ( frequency < 0 )
            {
                throw new ArgumentException("The frequency can not be negative.");
            }
            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion

        #region Implementation of ICloneable

        /// <inheritdoc />
        public object Clone()
        {
            return new Inductor(Name, Value);
        }

        #endregion
    }
}