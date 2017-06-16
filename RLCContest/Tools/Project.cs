using System;
using System.Collections.Generic;

using Core;

namespace Tools
{
    [Serializable]
    public class Project : ICloneable
    {
        private List<double> _frequencies;
        private List<IComponent> _circuits;

        public Project()
        {
            _frequencies = new List<double>();
            _circuits = new List<IComponent>();
        }

        public List<double> Frequencies
        {
            get
            {
                if ( _frequencies != null )
                {
                    return _frequencies;
                }
                _frequencies = new List<double>();
                return _frequencies;
            }
            set => _frequencies = value;
        }

        public List<IComponent> Circuits
        {
            get
            {
                if ( _circuits != null )
                {
                    return _circuits;
                }
                _circuits = new List<IComponent>();
                return _circuits;
            }
            set => _circuits = value;
        }

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