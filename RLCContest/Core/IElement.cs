using System;

namespace Core
{
    /// <summary>
    /// Элемент электрической цепи.
    /// </summary>
    public interface IElement : IComponent
    {
        event EventHandler ValueChanged;
        double Value { get; set; }
    }
}
