#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

#endregion

namespace Core.Circuits
{

    /// <summary>
    /// Эл. цепь с последовательным соединеним элементов.
    /// </summary>
    #region Attributes
    [Serializable]
    #endregion
    public class SerialCircuit : ICircuit
    {
        #region Private Members

        /// <summary>
        /// Список компонентов эл. цепи.
        /// </summary>
        private readonly List<IComponent> _components;

        /// <summary>
        /// Наименование эл. цепи.
        /// </summary>
        private string _name;
        #endregion


        #region Events

        /// <inheritdoc/>
        public event EventHandler CircuitChanged;
        #endregion

        #region Constructors

        /// <summary>
        /// Создает экземпляр эл. цепи с последовательным соединением.  
        /// </summary>
        public SerialCircuit()
        {
            _components = new List<IComponent>();
        }
        #endregion

        #region Implementation of IComponent

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public bool Contains(IComponent value)
        {
            return _components.Contains(value);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            foreach (IComponent component in _components)
            {
                UnsubscribeToComponent(component);
            }
            _components.Clear();
        }

        /// <inheritdoc/>
        public void CopyTo(IComponent[] array, int arrayIndex)
        {
            _components.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        public int IndexOf(IComponent component)
        {
            if ( component == null )
            {
                throw new ArgumentException("The object is not a component.");
            }
            return _components.IndexOf(component);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public int Count => _components.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => false;

        /// <inheritdoc/>
        public void RemoveAt(int index)
        {
            IComponent component = _components[index];
            _components.RemoveAt(index);
            UnsubscribeToComponent(component);
            CircuitChanged?.Invoke(this, new EventArgs());
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public IList<IComponent> Components => _components;

        /// <inheritdoc/>
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

        /// <summary>
        /// Ищет компонент с указанным именем.
        /// </summary>
        /// <param name="name">Имя комопнента.</param>
        /// <returns>Компонент или null.</returns>
        private IComponent FindComponent(string name)
        {
            return _components.FirstOrDefault(c => c.Name == name);
        }

        /// <summary>
        /// Срабатывает при изменении компонента внутри цепи.
        /// </summary>
        /// <param name="sender">Компонент который изменился.</param>
        /// <param name="e">Аргументы события.</param>
        private void Circuit_Changed(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Подписывается на события изменения компонента.
        /// </summary>
        /// <param name="component">Компонент эл. цепи.</param>
        private void SubscribeToComponent(IComponent component)
        {
            if (component is ICircuit circuit)
            {
                circuit.CircuitChanged += Circuit_Changed;
            }
            else if (component is IElement element)
            {
                element.ValueChanged += Circuit_Changed;
            }
        }

        /// <summary>
        /// Отписывается от события измения компонента.
        /// </summary>
        /// <param name="component">Компонент эл.цепи.</param>
        private void UnsubscribeToComponent(IComponent component)
        {
            if (component is ICircuit circuit)
            {
                circuit.CircuitChanged -= Circuit_Changed;
            }
            else if (component is IElement element)
            {
                element.ValueChanged -= Circuit_Changed;
            }
        }

        #endregion

    }
}
