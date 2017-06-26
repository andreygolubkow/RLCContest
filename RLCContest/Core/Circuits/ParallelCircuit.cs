#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

#endregion

namespace Core.Circuits
{
    /// <summary>
    /// Электрическая цепь с параллельным соединением элементов.
    /// </summary>
    #region Attributes

    [Serializable]
    #endregion
    public class ParallelCircuit : CircuitBase
    {

        #region Implementation of CircuitBase

        /// <inheritdoc />
        public override Complex CalculateZ(double frequency)
        {
            Complex mult;
            Complex sum;
            mult = Components.Count > 0 ? new Complex(1, 1) : new Complex(0, 0);
            sum = new Complex(0, 0);
            foreach (IComponent component in ComponentsList)
            {
                mult *= component.CalculateZ(frequency);
                sum += component.CalculateZ(frequency);
            }
            return mult/sum;
        }

        #endregion

    }
}
