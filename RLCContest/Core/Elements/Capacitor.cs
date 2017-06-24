#region Using

using System;
using System.Numerics;

#endregion

namespace Core.Elements
{
    /// <summary>
    /// Конденсатор.
    /// </summary>
    #region Attrubutes
    [Serializable] 
    #endregion
    public class Capacitor : IElement
    {
        #region Private Members

        /// <summary>
        /// Наименование конденсатора.
        /// </summary>
        private string _name;

        /// <summary>
        /// Емкость конденсатора.
        /// </summary>
        private double _value;
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр конденсатора.
        /// С именем New Capacitor и емкостью 0. 
        /// </summary>
        public Capacitor()
            : this("New Capacitor", 0)
        {
        }
        
        /// <summary>
        /// Инициализирует новый экземпляр класса конденсатора.
        /// </summary>
        /// <param name="name">Название конденсатора.</param>
        /// <param name="value">Емкость конденсатора.</param>
        public Capacitor(string name, double value)
        {
            Name = name;
            Value = value;
        } 
        #endregion

        #region Implementation of IElement

        /// <summary>
        /// Событие, вызывается когда изменено значение.
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
                    throw new ArgumentException("The name must not be empty.");
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
                    throw new ArgumentException("The capacity must not be less than zero.");
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
        /// Рассчет сопротивления.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Комплексное сопротивление.</returns>
        public Complex CalculateZ(double frequency)
        {
            if ( frequency < 0 )
            {
                throw new ArgumentException("The frequency can not be negative.");
            }
            return new Complex(0, -1 / (2 * Math.PI * frequency * Value));
        }

        #endregion

        #region Implementation of ICloneable

        /// <inheritdoc />
        public object Clone()
        {
            return new Capacitor(Name, Value);
        }

        #endregion
    }
}
