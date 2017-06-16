// //RLCContest->Tools->Extensions.cs
// //andreygolubkow Андрей Голубков

using System;

using Core;

namespace Tools
{
    public static class Extensions
    {
        /// <summary>
        /// Метод расширения для проверки правильности создания компонента эл. цепи
        /// </summary>
        /// <param name="element"></param>
        public static void TryLoad(this IComponent element)
        {
            try
            {
                IComponent el = element;
                string unused = el.Name;
                el.CalculateZ(0);
            }
            catch ( Exception exception )
            {
                throw new Exception("Can not load element {0}", exception);
            }
        }
    }
}
