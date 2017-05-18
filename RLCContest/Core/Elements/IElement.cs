namespace Core.Elements
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Элемент цепи.
    /// </summary>
    public interface IElement
    {

        /// <summary>
        /// Вызывается при изменении значения.
        /// </summary>
        event EventHandler ValueChanged;

        /// <summary>
        /// Название элемента.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Рассчет сопротивления.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Комплексное сопротивление.</returns>
        Complex CalculateZ(double frequency);
    }
}

