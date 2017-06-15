// //RLCContest->Controls->SerialToParralelAdapter.cs
// //andreygolubkow Андрей Голубков

using System;
using System.Drawing;
using System.Numerics;

using Core;

namespace Controls
{
    public class SerialToParralelAdapter : IElement
    {

        public Image Image { get; set; }

        #region Implementation of IComponent

        /// <inheritdoc />
        public string Name
        {
            get
            {
                return "";
            }
            set
            {
                return;
            }
        }

        /// <inheritdoc />
        public Complex CalculateZ(double frequency)
        {
            return new Complex(0,0);
        }

        #endregion

        #region Implementation of IElement

        /// <inheritdoc />
        public event EventHandler ValueChanged;

        /// <inheritdoc />
        public double Value { get; set; }
        #endregion
    }
}
