#region Using
using System;
using System.Numerics;

#endregion
namespace Core.Elements
{
    #region Attributes
    [Serializable] 
    #endregion
    /// <summary>
    /// Резистор.
    /// </summary>
    public class Resistor : IElement
    {
        #region Private Members
        /// <summary>
        ///     Наименование резистора.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Номинал резистора.
        /// </summary>
        private double _value;
        #endregion

        #region Constructors
        /// <summary>
        ///     Пустой контруктор для <see cref="Resistor" />.
        ///     Номинал = 0.
        ///     Наименование компонента:"Resistor".
        /// </summary>
        public Resistor()
            : this("New Resistor", 0)
        {
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
        #endregion

        #region Implementation of IElement

        /// <summary>
        ///     Срабатывает при изменении сопротивления.
        /// </summary>
        public event EventHandler ValueChanged;
        //TODO убрать отступ между строк в блоке set
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