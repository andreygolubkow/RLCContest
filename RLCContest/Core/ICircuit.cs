#region Using
using System;
using System.Collections.Generic;

#endregion
namespace Core
{
    public interface ICircuit : IComponent, IList<IComponent>
    {
        #region Events 
        event EventHandler CircuitChanged;
        #endregion

        #region Properties
        IList<IComponent> Components { get; } 
        #endregion
    }
}
