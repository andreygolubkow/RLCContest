#region Using

using System;
using System.Drawing;
using System.Linq;

using Core;
using Core.Circuits;
using Core.Elements;

#endregion

namespace CircuitDrawer
{
    /// <summary>
    /// Класс отрисовщика схем.
    /// </summary>
    public static class CircuitImageDrawer
    {

        #region Private Members
        /// <summary>
        /// Процедура рисования элемента.
        /// </summary>
        /// <param name="graphics"></param>
        private delegate void DrawElementProcedure(Graphics graphics);
        
        /// <summary>
        /// Стандартная кисть для линий.
        /// </summary>
        private static readonly Pen _standartPen = new Pen(Color.Black);

        /// <summary>
        /// Размер пустого битмапа.
        /// </summary>
        private static readonly Size _emptyImageSize = new Size(1,1);

        /// <summary>
        /// Размер простейшего элемента эл.цепи     
        /// </summary>
        private static readonly Size _elementSize = new Size(50, 50);

        /// <summary>
        /// Длина входной линии.
        /// </summary>
        private const int InputLineLength = 10;

        /// <summary>
        /// Длина выходной линии.
        /// </summary>
        private const int OutputLineLength = 20;

        /// <summary>
        /// Делитель изображения. Определяет в какой части будет находится входная и выходная линии.
        /// </summary>
        private const int ImageDellimitterConst = 2;

        /// <summary>
        /// Определяет где будет находиться выходная вертикальная линий у параллельной цепи.
        /// </summary>
        private const int ParallelConnectorMargin = 8;

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Метод позволяющий отрисовать(вернуть битмап) эл. цепь.
        /// </summary>
        /// <param name="circuitBase">Электическая цепь.</param>
        /// <returns>Рисунок эл. цепи.</returns>
        public static Bitmap GetImage(this CircuitBase circuitBase)
        {
            if (circuitBase is SerialCircuit serial)
            {
                return GetCircuitImage(serial);
            }
            if (circuitBase is ParallelCircuit parallel)
            {
                return GetCircuitImage(parallel);
            }
            return new Bitmap(0, 0);
        }

        #endregion

        #region Private Methods

        #region Circuit Drawers

        /// <summary>
        /// Метод отрисовывающий последовательную электрическую цепь.
        /// </summary>
        /// <param name="circuitBase">Электрическая цепь с последовательным соедининением.</param>
        /// <returns>Рисунок эл. цепи.</returns>
        private static Bitmap GetCircuitImage(SerialCircuit circuitBase)
        {
            var size = GetSize(circuitBase);

            var bitmap = new Bitmap(size.Width, size.Height);
            int x = 0;
            int y = size.Height / ImageDellimitterConst;

            using (Graphics g = Graphics.FromImage(bitmap))
            {

                foreach (IComponent component in circuitBase)
                {
                    if (component is IElement element)
                    {
                        var elementImage = GetElementImage(element);
                        g.DrawImage(elementImage, new Point(x, y - elementImage.Height / ImageDellimitterConst));
                        x += GetSize(element).Width;
                    }
                    else if (component is CircuitBase circuitComponent)
                    {
                        Bitmap circuitImage = new Bitmap(_emptyImageSize.Width, _emptyImageSize.Height);
                        if (circuitComponent is SerialCircuit sc)
                        {
                            circuitImage = GetCircuitImage(sc);
                        }
                        else if (circuitComponent is ParallelCircuit pc)
                        {
                            circuitImage = GetCircuitImage(pc);
                        }
                        g.DrawImage(circuitImage, new Point(x, y - circuitImage.Height / ImageDellimitterConst));
                        x += GetSize(circuitComponent).Width;
                    }
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Метод отрисовывающий эл. цепь с параллельным соединением.
        /// </summary>
        /// <param name="circuitBase">Эл. цепь с параллельным соединением.</param>
        /// <returns>Рисунок эл. цепи.</returns>
        private static Bitmap GetCircuitImage(ParallelCircuit circuitBase)
        {
            var size = GetSize(circuitBase);

            var bitmap = new Bitmap(size.Width, size.Height);

            int x = InputLineLength;
            int y = 0;

            var firstComponent = circuitBase.FirstOrDefault();
            var lastElement = circuitBase.LastOrDefault();
            if (firstComponent == null || lastElement == null)
            {
                return bitmap;
            }
            int firstHeight = GetSize(firstComponent).Height;
            int lastHeight = GetSize(lastElement).Height;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(_standartPen, 0, size.Height / ImageDellimitterConst, InputLineLength, size.Height / ImageDellimitterConst);
                g.DrawLine(_standartPen, 0, size.Height / ImageDellimitterConst - 1, InputLineLength, size.Height / ImageDellimitterConst - 1);

                g.DrawLine(_standartPen, x, y + firstHeight / ImageDellimitterConst, x, size.Height - lastHeight / ImageDellimitterConst);
                g.DrawLine(_standartPen, x + 1, y + firstHeight / ImageDellimitterConst, x + 1, size.Height - lastHeight / ImageDellimitterConst);
                foreach (var component in circuitBase)
                {
                    if (component is IElement element)
                    {
                        var elementImage = GetElementImage(element);
                        g.DrawImage(elementImage, new Point(x, y));
                        g.DrawLine(_standartPen, x + elementImage.Width, y + elementImage.Height / ImageDellimitterConst, bitmap.Width - ParallelConnectorMargin, y + elementImage.Height / ImageDellimitterConst);
                        g.DrawLine(_standartPen, x + elementImage.Width, y + elementImage.Height / ImageDellimitterConst - 1, bitmap.Width - ParallelConnectorMargin, y + elementImage.Height / ImageDellimitterConst - 1);
                        y += elementImage.Height;
                    }
                    else if (component is CircuitBase circuitComponent)
                    {
                        Bitmap circuitImage = new Bitmap(1, 1);
                        if (circuitComponent is SerialCircuit sc)
                        {
                            circuitImage = GetCircuitImage(sc);
                        }
                        else if (circuitComponent is ParallelCircuit pc)
                        {
                            circuitImage = GetCircuitImage(pc);
                        }
                        g.DrawImage(circuitImage, new Point(x, y));
                        g.DrawLine(_standartPen, x + circuitImage.Width, y + circuitImage.Height / ImageDellimitterConst, bitmap.Width - ParallelConnectorMargin, y + circuitImage.Height / ImageDellimitterConst);
                        g.DrawLine(_standartPen, x + circuitImage.Width, y + circuitImage.Height / ImageDellimitterConst - 1, bitmap.Width - ParallelConnectorMargin, y + circuitImage.Height / ImageDellimitterConst - 1);
                        y += circuitImage.Height;
                    }
                }

                g.DrawLine(_standartPen, bitmap.Width - ParallelConnectorMargin, firstHeight / ImageDellimitterConst, bitmap.Width - ParallelConnectorMargin, size.Height - lastHeight / ImageDellimitterConst);
                g.DrawLine(_standartPen, bitmap.Width - ParallelConnectorMargin - 1, firstHeight / ImageDellimitterConst, bitmap.Width - ParallelConnectorMargin - 1, size.Height - lastHeight / ImageDellimitterConst);

                g.DrawLine(_standartPen, bitmap.Width - ParallelConnectorMargin, bitmap.Height / ImageDellimitterConst, bitmap.Width, bitmap.Height / ImageDellimitterConst);
                g.DrawLine(_standartPen, bitmap.Width - ParallelConnectorMargin, bitmap.Height / ImageDellimitterConst - 1, bitmap.Width, bitmap.Height / ImageDellimitterConst - 1);

            }
            return bitmap;
        } 
        #endregion

        #region Get Size Methods

        /// <summary>
        /// Вычисляет размер любого компонента эл. цепи.
        /// </summary>
        /// <param name="component">Компонент эл. цепи.</param>
        /// <returns>Размер рисунка компонента эл. цепи.</returns>
        private static Size GetSize(IComponent component)
        {
            if (component is CircuitBase circuit)
            {
                return GetSize(circuit);
            }
            else if (component is IElement element)
            {
                return GetSize(element);
            }
            return new Size(_emptyImageSize.Width, _emptyImageSize.Height);
        }

        /// <summary>
        /// Вычисляет размер элемента эл. цепи.
        /// </summary>
        /// <param name="component">Элемент эл. цепи.</param>
        /// <returns>Размер рисунка элемента эл. цепи.</returns>
        private static Size GetSize(IElement component)
        {
            return new Size(_elementSize.Width, _elementSize.Width);
        }

        /// <summary>
        /// Вычисляет размер рисунка эл. цепи.
        /// </summary>
        /// <param name="circuitBase">Эл. цепь.</param>
        /// <returns>Размер рисунка эл. цепи.</returns>
        private static Size GetSize(CircuitBase circuitBase)
        {
            if (circuitBase is SerialCircuit serialCircuit)
            {
                return GetSize(serialCircuit);
            }
            else if (circuitBase is ParallelCircuit parallelCircuit)
            {
                return GetSize(parallelCircuit);
            }
            return new Size(1, 1);
        }

        /// <summary>
        /// Вычисляет размер рисунка эл. цепи с последовательным соединением.
        /// </summary>
        /// <param name="circuitBase">Эл. цепь с последовательным соединением.</param>
        /// <returns>Размер рисунка эл.цепи.</returns>
        private static Size GetSize(SerialCircuit circuitBase)
        {
            var size = circuitBase.Count > 0 ? new Size(0, 0) : new Size(_emptyImageSize.Width, _emptyImageSize.Height);
            foreach (IComponent component in circuitBase)
            {
                if (component is IElement element)
                {
                    size.Height = size.Height < GetSize(element).Height ? GetSize(element).Height : size.Height;
                    size.Width = size.Width + GetSize(element).Width;
                }
                else if (component is SerialCircuit sc)
                {
                    var scSize = GetSize(sc);
                    size.Height = size.Height < scSize.Height ? scSize.Height : size.Height;
                    size.Width = size.Width + scSize.Width;
                }
                else if (component is ParallelCircuit pc)
                {
                    var pcSize = GetSize(pc);
                    size.Height = size.Height < pcSize.Height ? pcSize.Height : size.Height;
                    size.Width = size.Width + pcSize.Width;
                }
            }
            return size;
        }

        /// <summary>
        /// Вычисляет размер рисунка эл. цепи с параллельным соединением.
        /// </summary>
        /// <param name="circuitBase">Эл. цепь с параллельным соединением.</param>
        /// <returns>Размер рисунка эл.цепи.</returns>
        private static Size GetSize(ParallelCircuit circuitBase)
        {
            var size = circuitBase.Count > 0 ? new Size(0, 0) : new Size(_emptyImageSize.Width, _emptyImageSize.Height);
            foreach (var component in circuitBase)
            {
                if (component is IElement element)
                {
                    size.Height = size.Height + GetSize(element).Height;
                    size.Width = size.Width < GetSize(element).Width ? GetSize(element).Width : size.Width;
                }
                else if (component is SerialCircuit sc)
                {
                    var scSize = GetSize(sc);
                    size.Width = size.Width < scSize.Width ? scSize.Width : size.Width;
                    size.Height = size.Height + scSize.Height;
                }
                else if (component is ParallelCircuit pc)
                {
                    var pcSize = GetSize(pc);
                    size.Width = size.Width < pcSize.Width ? pcSize.Width : size.Width;
                    size.Height = size.Height + pcSize.Height;
                }
            }
            size.Width += InputLineLength + OutputLineLength;
            return size;
        }

        #endregion

        #region Element Drawers
        
        /// <summary>
        /// Рисует элемент электрической цепи.
        /// </summary>
        /// <param name="element">Элемент эл. цепи.</param>
        /// <returns>Рисунок элемента эл. цепи.</returns>
        private static Bitmap GetElementImage(IElement element)
        {
            DrawElementProcedure drawer = ElementDrawProcedureSelector(element);

            var bitmap = new Bitmap(GetSize(element).Height, GetSize(element).Width);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                drawer(g);
            }
            return bitmap;
        }

        /// <summary>
        /// Выбирает метод рисования элемента эл.цепи.
        /// </summary>
        /// <param name="element">Элмент эл. цепи.</param>
        /// <returns>Метод отрисовки элемента.</returns>
        private static DrawElementProcedure ElementDrawProcedureSelector(IElement element)
        {
            if (element is Resistor)
            {
                return DrawResistor;
            }
            if (element is Capacitor)
            {
                return DrawCapacitor;
            }
            if (element is Inductor)
            {
                return DrawInductor;
            }
            throw new NotImplementedException("Unknown element");
        }

        /// <summary>
        /// Рисует резистор.
        /// </summary>
        /// <param name="graphics">Поверхность рисования GDI+.</param>
        private static void DrawResistor(Graphics graphics)
        {
            graphics.DrawRectangle(_standartPen, new Rectangle(10, 17, 30, 16));

            graphics.DrawLine(_standartPen, 0, 24, 10, 24);
            graphics.DrawLine(_standartPen, 0, 25, 10, 25);
            graphics.DrawLine(_standartPen, 40, 24, _elementSize.Width, 24);
            graphics.DrawLine(_standartPen, 40, 25, _elementSize.Width, 25);
        }

        /// <summary>
        /// Рисует конденсатор.
        /// </summary>
        /// <param name="graphics">Поверхность рисования GDI+.</param>
        private static void DrawCapacitor(Graphics graphics)
        {
            graphics.DrawLine(_standartPen, 20, 17, 20, 32);
            graphics.DrawLine(_standartPen, 29, 17, 29, 32);

            graphics.DrawLine(_standartPen, 0, 24, 20, 24);
            graphics.DrawLine(_standartPen, 0, 25, 20, 25);
            graphics.DrawLine(_standartPen, 29, 24, _elementSize.Width, 24);
            graphics.DrawLine(_standartPen, 29, 25, _elementSize.Width, 25);
        }

        /// <summary>
        /// Рисует катушку индуктивности.
        /// </summary>
        /// <param name="graphics">Поверхность рисования GDI+.</param>
        private static void DrawInductor(Graphics graphics)
        {

            graphics.DrawBezier(_standartPen, 20, 24, 20, 20, 24, 20, 24, 24);
            graphics.DrawBezier(_standartPen, 24, 24, 24, 20, 28, 20, 28, 24);
            graphics.DrawBezier(_standartPen, 28, 24, 28, 20, 32, 20, 32, 24);
            graphics.DrawBezier(_standartPen, 32, 24, 32, 20, 36, 20, 36, 24);
            graphics.DrawBezier(_standartPen, 36, 24, 36, 20, 40, 20, 40, 24);

            graphics.DrawLine(_standartPen, 0, 24, 20, 24);
            graphics.DrawLine(_standartPen, 0, 25, 20, 25);
            graphics.DrawLine(_standartPen, 40, 24, _elementSize.Width, 24);
            graphics.DrawLine(_standartPen, 40, 25, _elementSize.Width, 25);
        }

        #endregion 

        #endregion
    }
}
