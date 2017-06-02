using System;
using System.Collections;
using System.Dynamic;

namespace Core
{
    public interface ICircuit : IComponent, IEnumerable
    {
        event EventHandler CircuitChanged;

        IComponent this[int index] {get;}

        void AddComponent(IComponent component);

        void RemoveComponent(IComponent component);

    }
}
