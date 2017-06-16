// //RLCContest->Core->ParallelCircuit.cs
// //andreygolubkow Андрей Голубков

#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

#endregion

namespace Core.Circuits
{
    [Serializable]
    public class ParallelCircuit : ICircuit
    {
        private readonly List<IComponent> _components;

        /// <inheritdoc />
        public event EventHandler CircuitChanged;

        public ParallelCircuit()
        {
            _components = new List<IComponent>();
        }

        #region Implementation of IComponent

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public Complex CalculateZ(double frequency)
        {
            Complex mult;
            Complex sum;
            if ( Components.Count > 0 )
            {
                mult = new Complex(1, 1);
            }
            else
            {
                mult = new Complex(0, 0);
            }
            sum = new Complex(0, 0);
            foreach (IComponent component in _components)
            {
                mult *= component.CalculateZ(frequency);
                sum += component.CalculateZ(frequency);
            }
            return mult/sum;
        }

        #endregion

        #region Implementation of IEnumerable

        /// <inheritdoc />
        public IEnumerator<IComponent> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<IComponent>

        /// <inheritdoc />
        public void Add(IComponent item)
        {
            if ( item == null )
            {
                throw new ArgumentException("You can not add an object of this type.");
            }
            if ( FindComponent(item.Name) != null )
            {
                throw new ArgumentException("A component with this name already exists.");
            }
            _components.Add(item);
            SubscribeToComponent(item);

            CircuitChanged?.Invoke(this, new EventArgs());
        }

        /// <inheritdoc />
        public void Clear()
        {
            foreach (IComponent component in _components)
            {
                UnsubscribeToComponent(component);
            }
            _components.Clear();
        }

        /// <inheritdoc />
        public bool Contains(IComponent item)
        {
            return _components.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(IComponent[] array, int arrayIndex)
        {
            _components.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public bool Remove(IComponent item)
        {
            if ( item == null )
            {
                throw new ArgumentException("The object is not a component.");
            }
            if ( _components.Remove(item) )
            {
                UnsubscribeToComponent(item);
                CircuitChanged?.Invoke(this, new EventArgs());
                return true;
            }
            return false;
        }

        /// <inheritdoc />
        public int Count => _components.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        #endregion

        #region Implementation of IList<IComponent>

        /// <inheritdoc />
        public int IndexOf(IComponent item)
        {
            return _components.IndexOf(item);
        }

        /// <inheritdoc />
        public void Insert(int index, IComponent item)
        {
            if ( item == null )
            {
                throw new ArgumentException("The object is not a component.");
            }
            _components.Insert(index, item);
            SubscribeToComponent(item);

            CircuitChanged?.Invoke(this, new EventArgs());
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            IComponent component = _components[index];
            _components.RemoveAt(index);
            UnsubscribeToComponent(component);
            CircuitChanged?.Invoke(this, new EventArgs());
        }

        /// <inheritdoc />
        public IComponent this[int index]
        {
            get => _components[index];
            set
            {
                IComponent component = value != null && FindComponent(value.Name) == null
                    ? value
                    : throw new ArgumentException("The object is not a component.");
                UnsubscribeToComponent(_components[index]);
                _components[index] = component;
                SubscribeToComponent(_components[index]);
                CircuitChanged?.Invoke(this, new EventArgs());
            }
        }

        #endregion

        #region Implementation of ICircuit

        /// <inheritdoc />
        public IList<IComponent> Components => _components;

        #endregion

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
            if ( component is ICircuit circuit )
            {
                circuit.CircuitChanged += CircuitCircuitChanged;
            }
            else if ( component is IElement element )
            {
                element.ValueChanged += CircuitCircuitChanged;
            }
        }

        private void UnsubscribeToComponent(IComponent component)
        {
            if ( component is ICircuit circuit )
            {
                circuit.CircuitChanged -= CircuitCircuitChanged;
            }
            else if ( component is IElement element )
            {
                element.ValueChanged -= CircuitCircuitChanged;
            }
        }

        #region Implementation of ICloneable

        /// <inheritdoc />
        public object Clone()
        {
            var c = new ParallelCircuit
                    {
                        Name = Name
                    };
            foreach (IComponent e in this)
            {
                if ( e is IElement el )
                {
                    c.Add((IElement)el.Clone());
                }
                else if ( e is ICircuit ci )
                {
                    c.Add((ICircuit)ci.Clone());
                }
            }
            return c;
        }

        #endregion
    }
}
