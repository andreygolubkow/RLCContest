using System;
using System.Collections;
using System.Collections.Generic;

namespace Core
{
    public interface ICircuit : IComponent, IList<IComponent>
    {
        event EventHandler CircuitChanged;

        IList<IComponent> Components { get; }

    }
}
