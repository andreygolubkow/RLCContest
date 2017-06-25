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
//TODO расставь отступы между объвлениями регионов и строками кода внутри них везде одинаково
//TODO чтобы код везде был идентичен - либо с отсутпами, либо без