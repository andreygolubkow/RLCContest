﻿using System.Numerics;
using System.Runtime.Serialization;

namespace Core
{
    /// <summary>
    /// Любой компонент электрической цепи.
    /// </summary>
    public interface IComponent
    {
        string Name { get; set; }

        Complex CalculateZ(double frequency);
    }
}
