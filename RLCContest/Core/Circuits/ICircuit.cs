using System;
using System.Collections.Generic;
using System.Numerics;

using Core.Elements;

namespace Core.Circuits
{
    /// <summary>
    /// Интерфейс электической цепи.
    /// </summary>
    public interface ICircuit
    {
        /// <summary>
        /// Событие. Изменение в эл. цепи.
        /// </summary>
        event EventHandler CircuitChanged;

        /// <summary>
        /// Список элементов эл. цепи.
        /// </summary>
        List<IElement> Elements { get; set; }

        /// <summary>
        /// Рассчет Z для массива частот.
        /// </summary>
        /// <param name="frequencies"> Массив частот.</param>
        /// <returns>Массив сопротивлений.</returns>
        Complex[] CalculateZ(double[] frequencies);

    }
}
