﻿namespace Core.Elements
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
        /// Наименование резистора.
        /// </summary>
        private string _name;

        /// <summary>
        /// Номинал резистора.
        /// </summary>
        private double _value;

        /// <summary>
        /// Пустой контруктор для <see cref="Resistor"/>.
        /// Номинал = 0.
        /// Наименование компонента:"Resistor".
        /// </summary>
        public Resistor()
        {
            this.Value = 0;
            this.Name = "Resistor";
        }

        /// <summary>
        /// Конструктор <see cref="Resistor"/>.
        /// </summary>
        /// <param name="name">
        /// Наименование элемента.
        /// </param>
        /// <param name="value">
        /// Сопротивление.
        /// </param>
        public Resistor(string name, double value)
        {
            this.Value = value;
            this.Name = name;
        }

        #region Implementation of IElement

        /// <summary>
        /// Срабатывает при изменении сопротивления.
        /// </summary>
        [field: NonSerializedAttribute()]
        public event EventHandler ValueChanged;

        /// <summary>
        /// Название элемента.
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Наименование резистора не может быть пустым.");
                }

                this._name = value;
            }
        }

        /// <summary>
        /// Сопротивление резистора.
        /// </summary>
        public double Value
        {
            get => this._value;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Сопротивление не может быть отрицательным.");
                }

                this._value = value;
                this.ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Рассчет сопротивления.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Сопростивление резистора, не зависит от частоты.</returns>
        public Complex CalculateZ(double frequency)
        {
            if (frequency < 0)
            {
                throw new ArgumentException("Частота не может быть отрицательной.");
            }
            return new Complex(Value, 0);
        }

        #endregion
    }
}