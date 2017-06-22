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
        string Name { get; set; }
        #endregion

        #region Methods
        Complex CalculateZ(double frequency); 
        #endregion
    }
}
