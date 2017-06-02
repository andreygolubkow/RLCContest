#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

#endregion

namespace Core.Circuits
{
    /// <summary>
    ///     Цепь с последовательным соеднинением элементов.
    /// </summary>
    public class SerialCircuit : ICircuit
    {
        private readonly List<IComponent> _components;
        private string _name;

        public event EventHandler CircuitChanged;

        public SerialCircuit()
        {
            _components = new List<IComponent>();
        }

        #region Implementation of IComponent

        public string Name
        {
            get => _name;
            set
            {
                if ( FindComponent(value) != null )
                {
                    throw new ArgumentException("Компонент с таким именем уже существует.");
                }
                _name = value;
            }
        }

        public IComponent this[int index] => _components[index];

        public void AddComponent(IComponent component)
        {
            if (FindComponent(component.Name) != null)
            {
                throw new ArgumentException("Компонент с таким именем уже существует.");
            }
            _components.Add(component);
            SubscribeToComponent(component);

            CircuitChanged?.Invoke(this, new EventArgs());
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
            UnsubscribeToComponent(component);

            CircuitChanged?.Invoke(this, new EventArgs());
        }

        public Complex CalculateZ(double frequency)
        {
            var z = new Complex(0,0);
            _components.ForEach(c=>z+=c.CalculateZ(frequency));
            return z;
        }

        #endregion

        #region Implementation of IEnumerable

        /// <summary>Возвращает перечислитель, осуществляющий перебор коллекции.</summary>
        /// <returns>Объект <see cref="T:System.Collections.IEnumerator" />, который может использоваться для перебора коллекции.</returns>
        public IEnumerator GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        #endregion

        private IComponent FindComponent(string name)
        {
            return _components.FirstOrDefault(c => c.Name == name);
        }

        private void CircuitCircuitChanged(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender,e);
        }

        private void SubscribeToComponent(IComponent component)
        {
            if (component is ICircuit circuit)
            {
                circuit.CircuitChanged += CircuitCircuitChanged;
            }
            else
            if (component is IElement element)
            {
                element.ValueChanged += CircuitCircuitChanged;
            }
        }

        private void UnsubscribeToComponent(IComponent component)
        {
            if (component is ICircuit circuit)
            {
                circuit.CircuitChanged -= CircuitCircuitChanged;
            }
            else
            if (component is IElement element)
            {
                element.ValueChanged -= CircuitCircuitChanged;
            }
        }

    }
}
