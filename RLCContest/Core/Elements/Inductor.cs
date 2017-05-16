namespace Core.Elements
{
    using System;
    using System.Numerics;

    /// <summary>
    /// The inductor.
    /// </summary>
    public class Inductor : IElement
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        private string _name;

        /// <summary>
        /// Индуктивность.
        /// </summary>
        private double _value;

        /// <summary>
        /// Создает новый <see cref="Inductor"/>.
        /// С нулевым номиналом и наименованием Inductor.
        /// </summary>
        public Inductor()
        {
            Value = 0;
            Name = "Inductor";
        }

        /// <summary>
        /// Создает новый <see cref="Inductor"/>.
        /// </summary>
        /// <param name="name">
        /// Наименование компонента.
        /// </param>
        /// <param name="value">
        /// Номинал.
        /// </param>
        public Inductor(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #region Implementation of IElement

        /// <summary>
        /// Вызывается при изменении номинала.
        /// </summary>
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
                    throw new ArgumentException("Наименование катушки не может быть пустым.");
                }

                this._name = value;
            }
        }

        /// <summary>
        /// Значение.
        /// </summary>
        public double Value
        {
            get
            {
                return this._value;
            }

            set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException("Индуктивность не может быть отрицательной.");
                }

                this._value = value;
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Рассчет сопротивления.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Комплексное число.</returns>
        public Complex CalculateZ(double frequency) => 2 * Math.PI * frequency * this.Value;

        #endregion
    }
}