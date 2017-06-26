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
    /// Базовый класс эл. цепи.
    /// </summary>
    [Serializable]
    public abstract class CircuitBase : IComponent, IList<IComponent>
    {
        #region Protected Fields
        /// <summary>
        /// Список элементов эл. цепи.
        /// </summary>
        protected List<IComponent> ComponentsList = new List<IComponent>();
        #endregion

        #region Events
        /// <inheritdoc/>
        public virtual event EventHandler CircuitChanged;
        #endregion

        #region Public Properties
        /// <inheritdoc />
        public IList<IComponent> Components => ComponentsList; 
        #endregion

        #region Implementation of IComponent
        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public virtual Complex CalculateZ(double frequency) => new Complex(0, 0);
        #endregion

        #region Implementation of IList
        /// <inheritdoc />
        public int Count => ComponentsList.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public IEnumerator<IComponent> GetEnumerator()
        {
            return ComponentsList.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ComponentsList.GetEnumerator();
        }

        /// <inheritdoc />
        public void Add(IComponent item)
        {
            if (item == null)
            {
                throw new ArgumentException("You can not add an object of this type.");
            }
            if (FindComponent(item.Name) != null)
            {
                throw new ArgumentException("A component with this name already exists.");
            }
            ComponentsList.Add(item);
            SubscribeToComponent(item);

            CircuitChanged?.Invoke(this, new EventArgs());
        }

        /// <inheritdoc />
        public void Clear()
        {
            foreach (IComponent component in ComponentsList)
            {
                UnsubscribeToComponent(component);
            }
            ComponentsList.Clear();
        }

        /// <inheritdoc />
        public bool Contains(IComponent item)
        {
            return ComponentsList.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(IComponent[] array, int arrayIndex)
        {
            ComponentsList.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public bool Remove(IComponent item)
        {
            if (item == null)
            {
                throw new ArgumentException("The object is not a component.");
            }
            if (ComponentsList.Remove(item))
            {
                UnsubscribeToComponent(item);
                CircuitChanged?.Invoke(this, new EventArgs());
                return true;
            }
            return false;
        }

        /// <inheritdoc />
        public int IndexOf(IComponent item)
        {
            return ComponentsList.IndexOf(item);
        }

        /// <inheritdoc />
        public void Insert(int index, IComponent item)
        {
            if (item == null)
            {
                throw new ArgumentException("The object is not a component.");
            }
            ComponentsList.Insert(index, item);
            SubscribeToComponent(item);

            CircuitChanged?.Invoke(this, new EventArgs());
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            IComponent component = ComponentsList[index];
            ComponentsList.RemoveAt(index);
            UnsubscribeToComponent(component);
            CircuitChanged?.Invoke(this, new EventArgs());
        }

        /// <inheritdoc />
        public IComponent this[int index]
        {
            get => ComponentsList[index];
            set
            {
                IComponent component = value != null && FindComponent(value.Name) == null
                    ? value
                    : throw new ArgumentException("The object is not a component.");
                UnsubscribeToComponent(ComponentsList[index]);
                ComponentsList[index] = component;
                SubscribeToComponent(ComponentsList[index]);
                CircuitChanged?.Invoke(this, new EventArgs());
            }
        }
        #endregion

        #region Implementation of IClonable
        /// <inheritdoc />
        public object Clone()
        {
            var c = new ParallelCircuit
            {
                Name = Name
            };
            foreach (IComponent e in this)
            {
                if (e is IElement el)
                {
                    c.Add((IElement)el.Clone());
                }
                else if (e is CircuitBase ci)
                {
                    c.Add((CircuitBase)ci.Clone());
                }
            }
            return c;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Ищет в эл.цепи компонент с указанным именем.
        /// </summary>
        /// <param name="name">Название компонента.</param>
        /// <returns>Компонент эл.цепи или null</returns>
        private IComponent FindComponent(string name)
        {
            return ComponentsList.FirstOrDefault(c => c.Name == name);
        }

        /// <summary>
        /// Срабатывает при изменеии компонетов эл.цепи.
        /// Вызывает событие изменения эл.цепи.
        /// </summary>
        /// <param name="sender"> Источник события.</param>
        /// <param name="e">Параметры события.</param>
        private void CircuitCircuitChanged(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Подписывается на событие изменения компонента.
        /// </summary>
        /// <param name="component">Компонент.</param>
        private void SubscribeToComponent(IComponent component)
        {
            if (component is CircuitBase circuit)
            {
                circuit.CircuitChanged += CircuitCircuitChanged;
            }
            else if (component is IElement element)
            {
                element.ValueChanged += CircuitCircuitChanged;
            }
        }

        /// <summary>
        /// Отписывается от события изменения компонента.
        /// </summary>
        /// <param name="component">Компонент.</param>
        private void UnsubscribeToComponent(IComponent component)
        {
            if (component is CircuitBase circuit)
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