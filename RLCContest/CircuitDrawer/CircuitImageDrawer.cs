using Core;
using Core.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Circuits;

namespace CircuitGraphics
{
    public static class CircuitImageDrawer
    {

        private delegate void DrawElementProcedure(Graphics graphics);
        private delegate void DrawCircuitProcedure(Graphics graphics, ICircuit circuit);

        private static readonly Pen standartPen = new Pen(Color.Black);
        private const  int inputLineLength = 10;
        private const int outputLineLength = 20;

        public static Bitmap GetImage(this ICircuit circuit)
        {
            if ( circuit is SerialCircuit serial )
            {
                return GetCircuitImage(serial);
            }
            if ( circuit is ParallelCircuit parallel )
            {
                return GetCircuitImage(parallel);
            }
            return new Bitmap(0,0);
        }

        private static Bitmap GetCircuitImage(SerialCircuit circuit)
        {
            var size = GetSize(circuit);

            var bitmap = new Bitmap(size.Width,size.Height);
            int x = 0;
            int y = size.Height/2;

            using (Graphics g = Graphics.FromImage(bitmap))
            {

                foreach (IComponent component in circuit)
                {
                    if ( component is IElement element )
                    {
                        var elementImage = GetElementImage(element);
                        g.DrawImage(elementImage, new Point(x,y-elementImage.Height/2));
                        x += GetSize(element).Width;
                    }
                    else if ( component is ICircuit circuitComponent )
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
                        g.DrawImage(circuitImage, new Point(x , y - circuitImage.Height / 2));
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

            int x = inputLineLength;
            int y = 0;

            var firstComponent = circuit.FirstOrDefault();
            var lastElement = circuit.LastOrDefault();
            if (firstComponent == null || lastElement == null)
            {
                return bitmap;
            }
            int firstHeight= GetSize(firstComponent).Height;
            int lastHeight = GetSize(lastElement).Height;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(standartPen, 0, size.Height/2, 10, size.Height/2);
                g.DrawLine(standartPen, 0, size.Height / 2 -1, 10, size.Height / 2 - 1);

                g.DrawLine(standartPen, x, y+firstHeight/2,x,size.Height-lastHeight/2);
                g.DrawLine(standartPen, x+1, y + firstHeight/2, x+1, size.Height - lastHeight / 2);
                foreach (var component in circuit)
                {
                    if (component is IElement element)
                    {
                        var elementImage = GetElementImage(element);
                        g.DrawImage(elementImage, new Point(x, y ));
                        g.DrawLine(standartPen, x+elementImage.Width,y+elementImage.Height/2, bitmap.Width-8, y + elementImage.Height / 2);
                        g.DrawLine(standartPen, x + elementImage.Width, y + elementImage.Height/2 -1, bitmap.Width -8, y + elementImage.Height / 2 - 1);
                        y += elementImage.Height;
                    }
                    else if (component is ICircuit circuitComponent)
                    {
                        Bitmap circuitImage  = new Bitmap(1,1);
                        if ( circuitComponent is SerialCircuit  sc)
                        {
                            circuitImage = GetCircuitImage(sc);
                        } else if ( circuitComponent is ParallelCircuit pc )
                        {
                            circuitImage = GetCircuitImage(pc);
                        }
                        g.DrawImage(circuitImage, new Point(x, y ));
                        g.DrawLine(standartPen, x + circuitImage.Width, y + circuitImage.Height / 2, bitmap.Width -8, y + circuitImage.Height / 2);
                        g.DrawLine(standartPen, x + circuitImage.Width, y + circuitImage.Height / 2 - 1, bitmap.Width - 8, y + circuitImage.Height / 2 - 1);
                        y += circuitImage.Height;
                    }
                }

                g.DrawLine(standartPen, bitmap.Width - 8, firstHeight / 2, bitmap.Width - 8, size.Height - lastHeight / 2);
                g.DrawLine(standartPen, bitmap.Width - 7, firstHeight / 2, bitmap.Width - 7, size.Height - lastHeight / 2);

                g.DrawLine(standartPen, bitmap.Width - 8, bitmap.Height / 2, bitmap.Width, bitmap.Height / 2);
                g.DrawLine(standartPen, bitmap.Width - 8, bitmap.Height / 2-1, bitmap.Width, bitmap.Height / 2 -1);

            }
            return bitmap;
        }

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
            return new Size(1,1);
        }

        private static Size GetSize(IElement component)
        {
            return new Size(50,50);
        }

        private static Size GetSize(ICircuit circuit)
        {
            if ( circuit is SerialCircuit serialCircuit )
            {
                return GetSize(serialCircuit);
            }
            else if (circuit is ParallelCircuit parallelCircuit)
            {
                return GetSize(parallelCircuit);
            }
            return new Size(1,1);
        }


        private static Size GetSize(SerialCircuit circuit)
        {
            var size = circuit.Count > 0 ? new Size(0, 0) : new Size(1, 1);
            foreach (IComponent component in circuit)
            {
                if ( component is IElement element )
                {
                    size.Height = size.Height < GetSize(element).Height ? GetSize(element).Height : size.Height;
                    size.Width = size.Width + GetSize(element).Width;
                }
                else if ( component is SerialCircuit sc )
                {
                    var scSize = GetSize(sc);
                    size.Height = size.Height < scSize.Height ? scSize.Height : size.Height;
                    size.Width = size.Width + scSize.Width;
                }
                else if ( component is ParallelCircuit pc )
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
            var size = circuit.Count > 0 ? new Size(0, 0) : new Size(1, 1);
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
            size.Width += inputLineLength + outputLineLength;
            return size;
        }

        #region Element Drawers
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

        private  static void DrawResistor(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(10, 17, 30, 16));

            graphics.DrawLine(standartPen, 0, 24, 10, 24);
            graphics.DrawLine(standartPen, 0, 25, 10, 25);
            graphics.DrawLine(standartPen, 40, 24, 49, 24);
            graphics.DrawLine(standartPen, 40, 25, 49, 25);
        }

        private static void DrawCapacitor(Graphics graphics)
        {
            graphics.DrawLine(standartPen, 20, 17, 20, 32);
            graphics.DrawLine(standartPen, 29, 17, 29, 32);

            graphics.DrawLine(standartPen, 0, 24, 20, 24);
            graphics.DrawLine(standartPen, 0, 25, 20, 25);
            graphics.DrawLine(standartPen, 29, 24, 49, 24);
            graphics.DrawLine(standartPen, 29, 25, 49, 25);
        }

        private static void DrawInductor(Graphics graphics)
        {

            graphics.DrawBezier(standartPen, 20,24,20,20,24,20,24,24);
            graphics.DrawBezier(standartPen, 24, 24, 24, 20, 28, 20, 28, 24);
            graphics.DrawBezier(standartPen, 28, 24, 28, 20, 32, 20, 32, 24);
            graphics.DrawBezier(standartPen, 32, 24, 32, 20, 36, 20, 36, 24);
            graphics.DrawBezier(standartPen, 36, 24, 36, 20, 40, 20, 40, 24);

            graphics.DrawLine(standartPen, 0, 24, 20, 24);
            graphics.DrawLine(standartPen, 0, 25, 20, 25);
            graphics.DrawLine(standartPen, 40, 24, 49, 24);
            graphics.DrawLine(standartPen, 40, 25, 49, 25);
        }

#endregion
    }
}
