#region Using
using System;
using System.Numerics; 
#endregion

namespace Core
{
    /// <summary>
    ///     Любой компонент электрической цепи.
    /// </summary>
    public interface IComponent : ICloneable
    {
        #region Properties

        /// <summary>
        /// Наимнование компонента эл. цепи. 
        /// </summary>
        string Name { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Рассчет комплексного сопротивления для данного компонента.
        /// </summary>
        /// <param name="frequency">Частота, для которой требуется рассчить.</param>
        /// <returns>Комплексное сопротивление компонента.</returns>
        Complex CalculateZ(double frequency); 
        #endregion
    }
}
