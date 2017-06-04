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

        public void Add(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentException("Нельзя добавить объект данного типа.");
            }
            if (FindComponent(component.Name) != null)
            {
                throw new ArgumentException("Компонент с таким именем уже существует.");
            }
            _components.Add(component);
            SubscribeToComponent(component);

            CircuitChanged?.Invoke(this, new EventArgs());
        }

        public bool Contains(IComponent value)
        {
            return _components.Contains(value);
        }

        public void Clear()
        {
            foreach (IComponent component in _components)
            {
                UnsubscribeToComponent(component);
            }
            _components.Clear();
        }

        public void CopyTo(IComponent[] array, int arrayIndex)
        {
            _components.CopyTo(array, arrayIndex);
        }

        public int IndexOf(IComponent component)
        {
            if ( component == null )
            {
                throw new ArgumentException("Объект не является компонентом.");
            }
            return  _components.IndexOf(component);
        }

        public void Insert(int index, IComponent component)
        {
            if ( component == null )
            {
                throw new ArgumentException("Объект не является компонентом.");
            }
            _components.Insert(index, component);
            SubscribeToComponent(component);

            CircuitChanged?.Invoke(this, new EventArgs());

        }

        public bool Remove(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentException("Объект не является компонентом.");
            }
            if (_components.Remove(component))
            {
                UnsubscribeToComponent(component);
                CircuitChanged?.Invoke(this, new EventArgs());
                return true;
            }
            return false;
        }

        public int Count => _components.Count;

        public bool IsReadOnly => false;

        public void RemoveAt(int index)
        {
            IComponent component = _components[index];
            _components.RemoveAt(index);
            UnsubscribeToComponent(component);
            CircuitChanged?.Invoke(this, new EventArgs());
        }

        public IComponent this[int index]
        {
            get => _components[index];
            set
            {
                IComponent component = ((value != null) && (FindComponent(value.Name) == null))
                    ? value
                    : throw new ArgumentException("Элемент с таким именем уже существует.");
                UnsubscribeToComponent(_components[index]);
                _components[index] = component;
                SubscribeToComponent(_components[index]);
                CircuitChanged?.Invoke(this, new EventArgs());
            }
        }

        public IList<IComponent> Components => _components;

        public Complex CalculateZ(double frequency)
        {
            var z = new Complex(0,0);
            _components.ForEach(c=>z+=c.CalculateZ(frequency));
            return z;
        }

        #endregion

        #region Implementation of IEnumerable

        /// <inheritdoc />
        IEnumerator<IComponent> IEnumerable<IComponent>.GetEnumerator()
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

        #region Implementation of IEnumerable

        /// <inheritdoc />
        public IEnumerator GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        #endregion
    }
}
