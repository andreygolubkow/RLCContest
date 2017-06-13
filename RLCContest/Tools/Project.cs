

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Core;

namespace Tools
{
    [Serializable]
    public class Project
    {
        private List<double> _frequencies;
        private List<Core.IComponent> _circuits;

        public Project()
        {
            _frequencies = new List<double>();
            _circuits  = new List<IComponent>();
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
    }
}