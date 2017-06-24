#region Using
using System; 
#endregion

namespace Core
{
    /// <summary>
    ///     Элемент электрической цепи.
    /// </summary>
    public interface IElement : IComponent
    {
        #region Events

        /// <summary>
        /// Событие, возникающее при изменении свойств данного компонента.
        /// </summary>
        event EventHandler ValueChanged;
        #endregion

        #region Properties
        /// <summary>
        /// Характеристика для данного компонента.
        /// </summary>
        double Value { get; set; } 
        #endregion
    }
}
