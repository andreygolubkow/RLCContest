#region Using

using System;
using System.Collections.Generic;

#endregion

namespace Core
{
    public interface ICircuit : IComponent, IList<IComponent>
    {
        #region Events 

        /// <summary>
        /// Событие возникает при изменении электрической цепи или её компонентов. 
        /// </summary>
        event EventHandler CircuitChanged;
        #endregion

        #region Properties
        
        /// <summary>
        /// Список компонентов эл. цепи.
        /// </summary>
        IList<IComponent> Components { get; } 
        #endregion
    }
}
