using System;
using System.Numerics;

namespace Core
{
    /// <summary>
    ///     Любой компонент электрической цепи.
    /// </summary>
    public interface IComponent : ICloneable
    {
        string Name { get; set; }

        Complex CalculateZ(double frequency);
    }
}
