// //RLCContest->Core->ParallelCircuit.cs
// //andreygolubkow Андрей Голубков

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Core.Circuits
{
    [Serializable]
    public class ParallelCircuit : ICircuit
    {
        private readonly List<IComponent> _components;
        private string _name;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Contains(IComponent item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void CopyTo(IComponent[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove(IComponent item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc />
        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Implementation of IList<IComponent>

        /// <inheritdoc />
        public int IndexOf(IComponent item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Insert(int index, IComponent item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IComponent this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Implementation of ICircuit



        /// <inheritdoc />
        public IList<IComponent> Components
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
