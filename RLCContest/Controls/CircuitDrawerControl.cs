using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Circuits;
using Core.Elements;

using IComponent = Core.IComponent;

namespace Controls
{
    public partial class CircuitDrawerControl : UserControl
    {
        public CircuitDrawerControl()
        {
            InitializeComponent();
        }

        public void DrawCircuit(ICircuit circuit)
        {
            Draw(circuit);
        }

        private void Draw(ICircuit circuit)
        {
            var upLine = SectionsCounter(circuit).upLine;
            var vertLine = SectionsCounter(circuit).vertLine;
            var downLine = SectionsCounter(circuit).downLine;
            
            //+1 - Добавляем место под поворотный компонент в горизонтальном выводе
            //+2 - Добавляем место под поворотные компоненты в вертикальном выводе
            BuildArea(upLine+1, vertLine+2);

            var upStack = new Queue<IComponent>();
            var vertStack = new Queue<IComponent>();
            var downStack = new Queue<IComponent>();

            for (int i = 0; i < circuit.Count; i++)
            {
                if ( i < upLine )
                {
                    upStack.Enqueue(circuit[i]);
                    continue;
                }

                if (i < vertLine+upLine)
                {
                    vertStack.Enqueue(circuit[i]);
                    continue;
                }

                {
                    downStack.Enqueue(circuit[i]);
                }      
            }

            int x = 0;
            int y = 0;



            while ( upStack.Count>0 )
            {
                DrawComponent(x,y,upStack.Dequeue());
                x++;
                
            }
            DrawTurnDown(x,y);
            y++;
            while (vertStack.Count > 0)
            {
                DrawComponent(x, y, vertStack.Dequeue(),ConnectionType.Vertical);
                y++;

            }
            DrawTurnUp(x,y);
            x--;
            while (downStack.Count > 0)
            {
                DrawComponent(x, y, downStack.Dequeue());
                x--;
            }


        }

        private static (int upLine,int vertLine,int downLine)  SectionsCounter(ICircuit circuit)
        {
            var upLine = circuit.Count / 3 < 1 ? 1 : circuit.Count / 3;
            var downLine = upLine*2 > circuit.Count ? upLine-1 : upLine;
            var vertLine = circuit.Count - downLine - upLine;
            return (upLine, vertLine, downLine);
        }

        private void BuildArea(int columnsCount, int rowsCount)
        {
            gridView.Columns.Clear();
            gridView.Rows.Clear();
            
            for (int i = 0; i < columnsCount; i++)
            {
                gridView.Columns.Add(new DataGridViewImageColumn(false)
                                     {
                                         Width = 50,
                                         Image = CircuitImages.WhiteBlock
                                     });
            }
            gridView.RowCount = rowsCount;
        }

        private void DrawComponent(int x, int y, Core.IComponent component, ConnectionType connectionType = ConnectionType.Horizontal)
        {
            var cell = (DataGridViewImageCell)gridView.Rows[y].Cells[x];
            Image componentImage = CircuitImages.WhiteBlock;
            componentImage = component is Resistor ? CircuitImages.Resistor : componentImage;
            componentImage = component is Capacitor ? CircuitImages.Capasitor : componentImage;
            componentImage = component is Inductor ? CircuitImages.Inductor : componentImage;
            componentImage = component is ICircuit ? CircuitImages.IC : componentImage;

            //Рисуем обозначения
            var graphics = Graphics.FromImage(componentImage);
            var font = new System.Drawing.Font(FontFamily.GenericMonospace,14);
            graphics.DrawString(component.Name,font,new SolidBrush(Color.Black), new Point(0,0));
            
            if ( connectionType == ConnectionType.Vertical )
            {
                componentImage?.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            cell.Value = componentImage;
        }

        private void DrawTurnUp(int x, int y)
        {
            var cell = (DataGridViewImageCell)gridView.Rows[y].Cells[x];
            Image componentImage = CircuitImages.TurnUp;
            cell.Value = componentImage;
        }

        private void DrawTurnDown(int x, int y)
        {
            var cell = (DataGridViewImageCell)gridView.Rows[y].Cells[x];
            Image componentImage = CircuitImages.TurnDown;
            cell.Value = componentImage;
        }
    }
}
