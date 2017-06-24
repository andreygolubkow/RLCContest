#region Using
using System;
using System.Collections.Generic; 
#endregion

namespace Core
{
    /// <summary>
    /// Проект.
    /// Содержит в себе список частот и список эл. цепей(эл. компонентов).
    /// </summary>
    #region Attributes
    [Serializable] 
    #endregion
    public class Project : ICloneable
    {
        #region Private Members

        /// <summary>
        /// Список частот. 
        /// </summary>
        private List<double> _frequencies;

        /// <summary>
        /// Список эл. цепей.
        /// </summary>
        private List<IComponent> _circuits;

        #endregion

        #region Constructors

        /// <summary>
        /// Создает проект с пустыми списками частот и эл.цепей.
        /// </summary>
        public Project()
        {
            _frequencies = new List<double>();
            _circuits = new List<IComponent>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Список частот.
        /// </summary>
        public List<double> Frequencies
        {
            get
            {
                if (_frequencies != null)
                {
                    return _frequencies;
                }
                _frequencies = new List<double>();
                return _frequencies;
            }
            set => _frequencies = value;
        }

        /// <summary>
        /// Список эл.цепей.
        /// </summary>
        public List<IComponent> Circuits
        {
            get
            {
                if (_circuits != null)
                {
                    return _circuits;
                }
                _circuits = new List<IComponent>();
                return _circuits;
            }
            set => _circuits = value;
        } 
        #endregion

        #region Implementation of ICloneable

        /// <inheritdoc />
        public object Clone()
        {
            var proj = new Project
                       {
                           Circuits = new List<IComponent>(),
                           Frequencies = new List<double>()
                       };
            foreach (double f in Frequencies)
            {
                proj.Frequencies.Add(f);
            }

            foreach (IComponent component in Circuits)
            {
                if ( component is ICircuit c )
                {
                    proj.Circuits.Add((ICircuit)c.Clone());
                }
            }
            return proj;
        }

        #endregion
    }
}