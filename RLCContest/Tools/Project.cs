

using System.Collections.Generic;

namespace Tools
{
    public class Project
    {
        private List<double> _frequencies;

        public Project()
        {
            _frequencies = new List<double>();
        }

        public List<double> Frequencies
        {
            get
            {
                if ( _frequencies != null )
                {
                    return _frequencies;
                }
                return new List<double>();
            }
            set => _frequencies = value;
        }
    }
}