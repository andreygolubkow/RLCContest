#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

#endregion

namespace Core.Circuits
{

    #region Attributes
    [Serializable]
    #endregion

    /// <summary>
    ///     Цепь с последовательным соеднинением элементов.
    /// </summary>
    public class SerialCircuit : ICircuit
    {
        #region Private Members
        private readonly List<IComponent> _components;
        private string _name;
        #endregion


        #region Events
        public event EventHandler CircuitChanged;
        #endregion

        #region Constructors
        public SerialCircuit()
        {
            _components = new List<IComponent>();
        } 
        #endregion

        #region Implementation of IComponent

        public string Name
        {
            get => _name;
            set
            {
                if ( FindComponent(value) != null )
                {
                    throw new ArgumentException("A component with this name already exists.");
                }
                _name = value;
            }
        }

        public void Add(IComponent component)
        {
            if ( component == null )
            {
                throw new ArgumentException("You can not add an object of this type.");
            }
            if ( FindComponent(component.Name) != null )
            {
                throw new ArgumentException("A component with this name already exists.");
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
                throw new ArgumentException("The object is not a component.");
            }
            return _components.IndexOf(component);
        }

        public void Insert(int index, IComponent component)
        {
            if ( component == null )
            {
                throw new ArgumentException("The object is not a component.");
            }
            _components.Insert(index, component);
            SubscribeToComponent(component);

            CircuitChanged?.Invoke(this, new EventArgs());
        }

        public bool Remove(IComponent component)
        {
            if ( component == null )
            {
                throw new ArgumentException("The object is not a component.");
            }
            if ( _components.Remove(component) )
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
                IComponent component = value != null && FindComponent(value.Name) == null
                    ? value
                    : throw new ArgumentException("An element with this name already exists.");
                UnsubscribeToComponent(_components[index]);
                _components[index] = component;
                SubscribeToComponent(_components[index]);
                CircuitChanged?.Invoke(this, new EventArgs());
            }
        }

        public IList<IComponent> Components => _components;

        public Complex CalculateZ(double frequency)
        {
            var z = new Complex(0, 0);
            _components.ForEach(c => z += c.CalculateZ(frequency));
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

        #region Implementation of IEnumerable

        /// <inheritdoc />
        public IEnumerator GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        #endregion

        #region Implementation of ICloneable

        /// <inheritdoc />
        public object Clone()
        {
            var c = new SerialCircuit
                    {
                        Name = Name
                    };
            foreach (IComponent e in this)
            {
                if (e is IElement el)
                {
                    c.Add((IElement)el.Clone());
                }
                else if (e is ICircuit ci)
                {
                    c.Add((ICircuit)ci.Clone());
                }
            }
            return c;
        }

        #endregion

        #region Private Methods
        private IComponent FindComponent(string name)
        {
            return _components.FirstOrDefault(c => c.Name == name);
        }

        private void CircuitCircuitChanged(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender, e);
        }

        private void SubscribeToComponent(IComponent component)
        {
            if (component is ICircuit circuit)
            {
                circuit.CircuitChanged += CircuitCircuitChanged;
            }
            else if (component is IElement element)
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
            else if (component is IElement element)
            {
                element.ValueChanged -= CircuitCircuitChanged;
            }
        }

        #endregion

    }
}
