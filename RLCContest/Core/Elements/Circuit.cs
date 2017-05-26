using System;
using System.Collections.Generic;
using System.Numerics;

namespace Core.Elements
{
    class Circuit : IElement
    {
        private string _name;
        private double _value;

        /// <summary>
        /// Дорожка A и дорожка Б. Элементы должны подключатсья либо между ними, либо на одну дорожку
        /// </summary>
        private List<IElement> _aRoad;
        private List<IElement> _bRoad;

        public Circuit()
        {
            _aRoad = new List<IElement>();
            _bRoad = new List<IElement>();
        }

        /// <summary>
        /// Добавление парралельного элемента
        /// </summary>
        /// <param name="element"></param>
        public void AddParrallel(IElement element)
        {
               
        }



        #region Implementation of IElement

        public event EventHandler ValueChanged;

        /// <summary>
        /// Название элемента.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Значение.
        /// </summary>
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Рассчет сопротивления.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Комплексное сопротивление.</returns>
        public Complex CalculateZ(double frequency)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
