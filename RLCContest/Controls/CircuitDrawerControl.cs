using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
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
            var c = new SerialCircuit();
            c.Add(new Capacitor("c1",5));
            c.Add(new Resistor("r1", 1));
            c.Add(new Inductor("i1", 2));
            c.Add(new SerialCircuit());

            DrawCircuit(c);
        }

        private void DrawCircuit(ICircuit circuit)
        {
            var upLine = SectionsCounter(circuit).upLine;
            var vertLine = SectionsCounter(circuit).vertLine;
            var downLine = SectionsCounter(circuit).downLine;

            BuildArea(10, 10);

            int x = 1;
            int y = 1;
            int upCounter = 0;
            int vertCounter = 0;
            int downCounter = 0;

            foreach (IComponent component in circuit)
            {
                if ( upCounter < upLine )
                {
                    DrawComponent(x,y,component);
                    x++;
                    upCounter++;
                    continue;
                }
                if ( vertCounter < vertLine )
                {
                    if ( vertCounter == 0 )
                    {
                        y++;
                    }
                    DrawComponent(x,y,component);
                    vertCounter++;
                    y++;
                    continue;
                }
                if (downCounter < downLine)
                {
                    x--;
                    DrawComponent(x, y, component);
                    downCounter++;
                }
            }  

        }

        private static (int upLine,int vertLine,int downLine)  SectionsCounter(ICircuit circuit)
        {
            int upLine = circuit.Count % 3;
            int downLine = upLine;
            int vertLine = circuit.Count - upLine - downLine;
            return (upLine, vertLine, downLine);
        }

        private void BuildArea(int columnsCount, int rowsCount)
        {
            gridView.RowCount = rowsCount;
            for (int i = 0; i < columnsCount; i++)
            {
                gridView.Columns.Add(new DataGridViewImageColumn(false)
                                     {
                                         Width = 50
                                     });
            }
        }

        private void DrawComponent(int x, int y, Core.IComponent component)
        {
            var cell = (DataGridViewImageCell)gridView.Rows[y].Cells[x];
            Image componentImage = null;
            componentImage = component is Resistor ? CircuitImages.Resistor : componentImage;
            componentImage = component is Capacitor ? CircuitImages.Capasitor : componentImage;
            componentImage = component is Inductor ? CircuitImages.Inductor : componentImage;
            componentImage = component is ICircuit ? CircuitImages.IC : componentImage;
            cell.Value = componentImage;


        }
    }
}
