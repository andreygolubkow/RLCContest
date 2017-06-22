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
    public class CircuitImageDrawer
    {

        private delegate void DrawElementProcedure(Graphics graphics);
        private delegate void DrawCircuitProcedure(Graphics graphics, ICircuit circuit);

        public CircuitImageDrawer()
        {
        
        }

        public Bitmap GetCircuitImage(SerialCircuit circuit)
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
                    else if ( component is SerialCircuit serialCircuit )
                    {
                        var serialCircuitImage = GetCircuitImage(serialCircuit);
                        g.DrawImage(serialCircuitImage, new Point(x , y - serialCircuitImage.Height / 2));
                        x += GetSize(serialCircuit).Width;
                    }
                }
            }
            return bitmap;
        }

        public Bitmap GetCircuitImage(ParallelCircuit circuit)
        {
            var size = GetSize(circuit);

            var bitmap = new Bitmap(size.Width, size.Height);
            int x = 0;
            int y = size.Height / 2;

            using (Graphics g = Graphics.FromImage(bitmap))
            {

                
            }
            return bitmap;
        }

        private Bitmap GetElementImage(IElement component)
        {
            DrawElementProcedure drawer = ElementDrawProcedureSelector(component);

            var bitmap = new Bitmap(GetSize(component).Height, GetSize(component).Width);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                drawer(g);
            }
            return bitmap;
        }


        private Size GetSize(IElement component)
        {
            return new Size(50,50);
        }

        private Size GetSize(SerialCircuit circuit)
        {
            var size = new Size(0,0);
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

        private Size GetSize(ParallelCircuit circuit)
        {
            return new Size(0,0);
        }

        #region Element Drawers
        private DrawElementProcedure ElementDrawProcedureSelector(IElement element)
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
            throw new NotImplementedException();
        }

        private static void DrawResistor(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(10, 17, 30, 16));

            graphics.DrawLine(new Pen(Color.Black), 0, 24, 10, 24);
            graphics.DrawLine(new Pen(Color.Black), 0, 25, 10, 25);
            graphics.DrawLine(new Pen(Color.Black), 40, 24, 49, 24);
            graphics.DrawLine(new Pen(Color.Black), 40, 25, 49, 25);
        }

        private static void DrawCapacitor(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black), 20, 17, 20, 32);
            graphics.DrawLine(new Pen(Color.Black), 29, 17, 29, 32);

            graphics.DrawLine(new Pen(Color.Black), 0, 24, 20, 24);
            graphics.DrawLine(new Pen(Color.Black), 0, 25, 20, 25);
            graphics.DrawLine(new Pen(Color.Black),29, 24, 49, 24);
            graphics.DrawLine(new Pen(Color.Black), 29, 25, 49, 25);
        }

        private static void DrawInductor(Graphics graphics)
        {
            graphics.DrawArc(new Pen(Color.Black), new Rectangle(10, 24, 20, 13), 0, 180);

            graphics.DrawLine(new Pen(Color.Black), 0, 24, 20, 24);
            graphics.DrawLine(new Pen(Color.Black), 0, 25, 20, 25);
            graphics.DrawLine(new Pen(Color.Black), 40, 24, 29, 24);
            graphics.DrawLine(new Pen(Color.Black), 40, 25, 29, 25);
        }

#endregion
    }
}
