#region Using

using System;
using System.Numerics;

#endregion

namespace Core.Elements
{
    #region Attrubutes
    [Serializable] 
    #endregion
    public class Capacitor : IElement
    {
        #region Private Members
        private string _name;
        private double _value;
        #endregion

        #region Constructors
        public Capacitor()
            : this("New Capacitor", 0)
        {
        }

        public Capacitor(string name, double value)
        {
            Name = name;
            Value = value;
        } 
        #endregion

        #region Implementation of IElement

        /// <summary>
        ///     Событие, вызывается когда изменено значение.
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
        ///     Номинал.
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
                _value = value;
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Рассчет сопротивления.
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
