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
        event EventHandler ValueChanged;
        #endregion

        #region Properties
        double Value { get; set; } 
        #endregion
    }
}
