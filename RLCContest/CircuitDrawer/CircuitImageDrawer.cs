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
    public static class CircuitImageDrawer
    {

        #region Private Members
        private delegate void DrawElementProcedure(Graphics graphics);

        private static readonly Pen _standartPen = new Pen(Color.Black);
        private static readonly Size _emptyImageSize = new Size(1,1);
        private static readonly Size _elementSize = new Size(50, 50);

        private const int InputLineLength = 10;
        private const int OutputLineLength = 20;
        private const int ImageDellimitterConst = 2;
        private const int ParallelConnectorMargin = 8;

        #endregion

        #region Public Methods
        public static Bitmap GetImage(this ICircuit circuit)
        {
            if (circuit is SerialCircuit serial)
            {
                return GetCircuitImage(serial);
            }
            if (circuit is ParallelCircuit parallel)
            {
                return GetCircuitImage(parallel);
            }
            return new Bitmap(0, 0);
        }

        #endregion

        #region Private Methods

        #region Circuit Drawers
        private static Bitmap GetCircuitImage(SerialCircuit circuit)
        {
            var size = GetSize(circuit);

            var bitmap = new Bitmap(size.Width, size.Height);
            int x = 0;
            int y = size.Height / ImageDellimitterConst;

            using (Graphics g = Graphics.FromImage(bitmap))
            {

                foreach (IComponent component in circuit)
                {
                    if (component is IElement element)
                    {
                        var elementImage = GetElementImage(element);
                        g.DrawImage(elementImage, new Point(x, y - elementImage.Height / ImageDellimitterConst));
                        x += GetSize(element).Width;
                    }
                    else if (component is ICircuit circuitComponent)
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

        private static Bitmap GetCircuitImage(ParallelCircuit circuit)
        {
            var size = GetSize(circuit);

            var bitmap = new Bitmap(size.Width, size.Height);

            int x = InputLineLength;
            int y = 0;

            var firstComponent = circuit.FirstOrDefault();
            var lastElement = circuit.LastOrDefault();
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
                foreach (var component in circuit)
                {
                    if (component is IElement element)
                    {
                        var elementImage = GetElementImage(element);
                        g.DrawImage(elementImage, new Point(x, y));
                        g.DrawLine(_standartPen, x + elementImage.Width, y + elementImage.Height / ImageDellimitterConst, bitmap.Width - ParallelConnectorMargin, y + elementImage.Height / ImageDellimitterConst);
                        g.DrawLine(_standartPen, x + elementImage.Width, y + elementImage.Height / ImageDellimitterConst - 1, bitmap.Width - ParallelConnectorMargin, y + elementImage.Height / ImageDellimitterConst - 1);
                        y += elementImage.Height;
                    }
                    else if (component is ICircuit circuitComponent)
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
        private static Size GetSize(IComponent component)
        {
            if (component is ICircuit circuit)
            {
                return GetSize(circuit);
            }
            else if (component is IElement element)
            {
                return GetSize(element);
            }
            return new Size(_emptyImageSize.Width, _emptyImageSize.Height);
        }

        private static Size GetSize(IElement component)
        {
            return new Size(_elementSize.Width, _elementSize.Width);
        }

        private static Size GetSize(ICircuit circuit)
        {
            if (circuit is SerialCircuit serialCircuit)
            {
                return GetSize(serialCircuit);
            }
            else if (circuit is ParallelCircuit parallelCircuit)
            {
                return GetSize(parallelCircuit);
            }
            return new Size(1, 1);
        }


        private static Size GetSize(SerialCircuit circuit)
        {
            var size = circuit.Count > 0 ? new Size(0, 0) : new Size(_emptyImageSize.Width, _emptyImageSize.Height);
            foreach (IComponent component in circuit)
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

        private static Size GetSize(ParallelCircuit circuit)
        {
            var size = circuit.Count > 0 ? new Size(0, 0) : new Size(_emptyImageSize.Width, _emptyImageSize.Height);
            foreach (var component in circuit)
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

        private static Bitmap GetElementImage(IElement component)
        {
            DrawElementProcedure drawer = ElementDrawProcedureSelector(component);

            var bitmap = new Bitmap(GetSize(component).Height, GetSize(component).Width);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                drawer(g);
            }
            return bitmap;
        }


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

        private static void DrawResistor(Graphics graphics)
        {
            graphics.DrawRectangle(_standartPen, new Rectangle(10, 17, 30, 16));

            graphics.DrawLine(_standartPen, 0, 24, 10, 24);
            graphics.DrawLine(_standartPen, 0, 25, 10, 25);
            graphics.DrawLine(_standartPen, 40, 24, _elementSize.Width, 24);
            graphics.DrawLine(_standartPen, 40, 25, _elementSize.Width, 25);
        }

        private static void DrawCapacitor(Graphics graphics)
        {
            graphics.DrawLine(_standartPen, 20, 17, 20, 32);
            graphics.DrawLine(_standartPen, 29, 17, 29, 32);

            graphics.DrawLine(_standartPen, 0, 24, 20, 24);
            graphics.DrawLine(_standartPen, 0, 25, 20, 25);
            graphics.DrawLine(_standartPen, 29, 24, _elementSize.Width, 24);
            graphics.DrawLine(_standartPen, 29, 25, _elementSize.Width, 25);
        }

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
