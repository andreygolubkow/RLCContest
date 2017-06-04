using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace Core
{
    public interface ICircuit : IComponent, IList<IComponent>
    {
        event EventHandler CircuitChanged;

        IList<IComponent> Components { get; }

    }
}
