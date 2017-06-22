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
        private readonly Size ElementStandartSize = new Size(50,50);

        private delegate void DrawElementProcedure(Graphics graphics);
        private delegate void DrawCircuitProcedure(Graphics graphics, ICircuit circuit);

        public CircuitImageDrawer()
        {
        
        }

        public Bitmap GetCircuitImage(SerialCircuit circuit)
        {

            var bitmap = new Bitmap(300,300);
            int x = 150;
            int y = 150;

            using (Graphics g = Graphics.FromImage(bitmap))
            {

                foreach (IComponent component in circuit)
                {
                    if ( component is IElement element )
                    {
                        g.DrawImage( GetElementImage(element), new Point(x,y));
                        x += ElementStandartSize.Width;
                    }
                }

            }

            return bitmap;
        }

        private Bitmap GetElementImage(IElement component)
        {
            DrawElementProcedure drawer = ElementDrawProcedureSelector(component);

            var bitmap = new Bitmap(ElementStandartSize.Width,ElementStandartSize.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                drawer(g);
            }
            return bitmap;
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
            graphics.DrawLine(new Pen(Color.Black), 40, 24, 29, 24);
            graphics.DrawLine(new Pen(Color.Black), 40, 25, 29, 25);
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
