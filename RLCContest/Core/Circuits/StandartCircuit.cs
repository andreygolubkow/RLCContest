using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

using Core.Elements;

namespace Core.Circuits
{
    //R1 + R2*R3/(R2+R3)
    /// <summary>
    /// Стандартная электическая цепь.
    /// </summary>
    public class StandartCircuit : ICircuit
    {
        private List<IElement> _elements;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public StandartCircuit()
        {
            Elements = new List<IElement>();
        }

        /// <summary>
        /// Событие вызивается при изменеии параметров элементов в цепи.
        /// </summary>
        public event EventHandler CircuitChanged;

        /// <summary>
        /// Список элементов цепи.
        /// </summary>
        public List<IElement> Elements
        {
            get => _elements;
            set
            {
                _elements = value ?? throw new ArgumentException("Нельзя вместо списка подать null.");
                foreach (IElement element in _elements)
                {
                    element.ValueChanged += OnElementValueChanged;
                }
            }
        }

        /// <summary>
        /// Срабатываем по событию изменения параметров элемента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnElementValueChanged(object sender, EventArgs e)
        {
            if ( sender is IElement  && !_elements.Contains((IElement)sender))
            {
                ((IElement)sender).ValueChanged -= OnElementValueChanged;
            }
            CircuitChanged?.Invoke(this,new EventArgs());
        }

        /// <summary>
        /// Рассчет Z для частот.
        /// </summary>
        /// <param name="frequencies">Массив частот.</param>
        /// <returns>Массив сопротивлений Z.</returns>
        public Complex[] CalculateZ(double[] frequencies)
        {
            if ( Elements.Count == 0 )
            {
                throw new ArgumentException("Нет элементов для рассчета");
            }
            if ( frequencies.Where(f => f < 0).Any() )
            {
                throw new ArgumentException("Невозможно рассчитать Z для отрицательной частоты.");
            }
            var zArray = new Complex[frequencies.Length];
            for (var i = 0; i < frequencies.Length; i++)
            {
                var z = new Complex(0,0);
                z = Elements.Aggregate(z, (current, element) => current + element.CalculateZ(frequencies[i]));
                zArray[i] = z;
            }
            return zArray;
        }


    }
}
