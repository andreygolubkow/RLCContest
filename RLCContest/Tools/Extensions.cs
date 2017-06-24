#region Using
using System;

using Core;

#endregion

namespace Tools
{

    /// <summary>
    /// Содержит методы расширения.
    /// </summary>
    public static class Extensions
    {
        #region Public Methods
        /// <summary>
        /// Метод расширения для проверки правильности создания компонента эл. цепи
        /// </summary>
        /// <param name="element">Элемент.</param>
        public static void TryLoad(this IComponent element)
        {
            try
            {
                IComponent el = element;
                string unused = el.Name;
                el.CalculateZ(0);
            }
            catch (Exception exception)
            {
                throw new Exception("Can not load element {0}", exception);
            }
        }

        #endregion
    }
    }
