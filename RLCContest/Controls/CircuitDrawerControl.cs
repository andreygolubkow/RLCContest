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

            var list = GenerateImages(circuit);

            var upMax = SectionsCounter(list).upLine;
            var vertMax = SectionsCounter(list).vertLine;
            var downMax = SectionsCounter(list).downLine;


            //+1 - Добавляем место под поворотный компонент в горизонтальном выводе
            //+2 - Добавляем место под поворотные компоненты в вертикальном выводе
            BuildArea(upMax + 1, vertMax + 2);

            int x = 0;
            int y = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if ( i < upMax )
                {
                    DrawComponent(x,y,list[i],DrawType.Horizontal);
                    x++;
                    continue;
                }
                if ( i == upMax )
                {
                    DrawTurnDown(x,y);
                    y++;
                }
                if ( i < upMax + vertMax )
                {
                    DrawComponent(x,y,list[i],DrawType.Vertical);
                    y++;
                    continue;
                }
                if (i == upMax + vertMax)
                {
                    DrawTurnUp(x, y);
                    x--;
                }
                if (i < upMax + vertMax+downMax)
                {
                    DrawComponent(x, y, list[i], DrawType.Horizontal);
                    x--;
                }
            }


        }

        private List<Image> GenerateImages(ICircuit circuit)
        {
            var list = new List<Image>();

            if ( circuit is SerialCircuit )
            {
                foreach (var component in circuit)
                {
                    Image componentImage = CircuitImages.WhiteBlock;
                    componentImage = component is Resistor ? CircuitImages.SerialResistor : CircuitImages.SerialIC;
                    componentImage = component is Capacitor ? CircuitImages.SerialCapasitor : componentImage;
                    componentImage = component is Inductor ? CircuitImages.SerialInductor : componentImage;
                    var graphics = Graphics.FromImage(componentImage);
                    var font = new System.Drawing.Font(FontFamily.GenericMonospace, 14);
                    graphics.DrawString(component.Name, font, new SolidBrush(Color.Black), new Point(0, 0));
                    list.Add(componentImage);
                }
            }
            return list;
        }

        private static (int upLine,int vertLine,int downLine)  SectionsCounter<T>(IList<T>  list)
        {
            var upLine = list.Count / 3 < 1 ? 1 : list.Count / 3;
            var downLine = upLine*2 > list.Count ? upLine-1 : upLine;
            var vertLine = list.Count - downLine - upLine;
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
        
        private void DrawComponent(int x, int y, Image component, DrawType connectionType = DrawType.Horizontal)
        {
            var cell = (DataGridViewImageCell)gridView.Rows[y].Cells[x];
            
            if ( connectionType == DrawType.Vertical )
            {
                component?.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            cell.Value = component;
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
