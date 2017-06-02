using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Любой компонент электрической цепи.
    /// </summary>
    public interface IComponent
    {
        string Name { get; set; }

        Complex CalculateZ(double frequency);
    }
}
