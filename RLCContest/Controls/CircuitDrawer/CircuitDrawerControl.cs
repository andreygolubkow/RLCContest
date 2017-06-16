using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Core;
using Core.Circuits;
using Core.Elements;

namespace Controls.CircuitDrawer
{
    public partial class CircuitDrawerControl : UserControl
    {
        public CircuitDrawerControl()
        {
            InitializeComponent();
        }

        public void DrawCircuit(ICircuit circuit)
        {
            if ( circuit is SerialCircuit )
            {
                DrawSerial(circuit);
            }
            else
            {
                DrawParallel(circuit);
            }
        }

        private void DrawSerial(ICircuit circuit)
        {
            List<Image> list = GenerateImages(circuit);

            (int upMax, int vertMax, int downMax) = SectionsCounter(list);
            //+1 - Добавляем место под поворотный компонент в горизонтальном выводе
            //+2 - Добавляем место под поворотные компоненты в вертикальном выводе
            BuildArea(upMax + 1, vertMax + 2);

            var x = 0;
            var y = 0;

            for (var i = 0; i < list.Count; i++)
            {
                if ( i < upMax )
                {
                    DrawComponent(x, y, list[i], DrawType.Horizontal);
                    x++;
                    continue;
                }
                if ( i == upMax )
                {
                    if ( circuit is SerialCircuit )
                    {
                        DrawUpSCorner(x, y);
                    }

                    y++;
                }
                if ( i < upMax + vertMax )
                {
                    DrawComponent(x, y, list[i], DrawType.Vertical);
                    y++;
                    continue;
                }
                if ( i == upMax + vertMax )
                {
                    if ( circuit is SerialCircuit )
                    {
                        DrawDownSCorner(x, y);
                    }

                    x--;
                }
                if ( i < upMax + vertMax + downMax )
                {
                    DrawComponent(x, y, list[i], DrawType.Horizontal);
                    x--;
                }
            }
        }

        private void DrawParallel(ICircuit circuit)
        {
            List<Image> list = GenerateImages(circuit);

            //+1 - Добавляем место под поворотный компонент в горизонтальном выводе
            //+2 - Добавляем место под поворотные компоненты в вертикальном выводе
            BuildArea(list.Count, 3);

            var x = 0;
            var y = 1;

            foreach (Image image in list)
            {
                DrawComponent(x, y, image, DrawType.Vertical);
                x++;
            }
        }

        private static List<Image> GenerateImages(ICircuit circuit)
        {
            var list = new List<Image>();

            if ( circuit is SerialCircuit )
            {
                foreach (IComponent component in circuit)
                {
                    Image componentImage = component is Resistor ? CircuitImages.SerialResistor : CircuitImages.SerialIC;
                    componentImage = component is Capacitor ? CircuitImages.SerialCapasitor : componentImage;
                    componentImage = component is Inductor ? CircuitImages.SerialInductor : componentImage;
                    Graphics graphics = Graphics.FromImage(componentImage);
                    var font = new Font(FontFamily.GenericMonospace, 14);
                    graphics.DrawString(component.Name, font, new SolidBrush(Color.Black), new Point(0, 0));
                    list.Add(componentImage);
                }
            }
            else if ( circuit is ParallelCircuit )
            {
                foreach (IComponent component in circuit)
                {
                    Image componentImage = component is Resistor ? CircuitImages.ParallelResistor : CircuitImages.ParallelIC;
                    componentImage = component is Capacitor ? CircuitImages.ParallelCapasitor : componentImage;
                    componentImage = component is Inductor ? CircuitImages.ParallelInductor : componentImage;
                    Graphics graphics = Graphics.FromImage(componentImage);
                    var font = new Font(FontFamily.GenericMonospace, 14);
                    graphics.DrawString(component.Name, font, new SolidBrush(Color.Black), new Point(0, 0));
                    list.Add(componentImage);
                }
            }
            return list;
        }

        private static (int upLine, int vertLine, int downLine) SectionsCounter<T>(IList<T> list)
        {
            int upLine = list.Count / 3 < 1 ? 1 : list.Count / 3;
            int downLine = upLine * 2 > list.Count ? upLine - 1 : upLine;
            int vertLine = list.Count - downLine - upLine;
            return (upLine, vertLine, downLine);
        }

        private void BuildArea(int columnsCount, int rowsCount)
        {
            gridView.Columns.Clear();
            gridView.Rows.Clear();

            for (var i = 0; i < columnsCount; i++)
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

        private void DrawUpSCorner(int x, int y)
        {
            var cell = (DataGridViewImageCell)gridView.Rows[y].Cells[x];
            Image componentImage = CircuitImages.TurnDown;
            cell.Value = componentImage;
        }

        private void DrawDownSCorner(int x, int y)
        {
            var cell = (DataGridViewImageCell)gridView.Rows[y].Cells[x];
            Image componentImage = CircuitImages.TurnUp;
            cell.Value = componentImage;
        }
    }
}
