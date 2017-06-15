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

            var list = GetComponentsList(circuit);

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


        /// <summary>
        /// Получаем рекурсивно список компонентов
        /// </summary>
        /// <param name="circuit"></param>
        /// <returns></returns>
        private List<ElementWithConnectionAdapter> GetComponentsList(ICircuit circuit)
        {
            var list = new List<ElementWithConnectionAdapter>();

            foreach (IComponent c in circuit)
            {
                if ( c is ICircuit icirc )
                {
                    //Переход Serial => Parallel
                    if ( circuit is SerialCircuit && icirc is ParallelCircuit )
                    {
                        var connector = new SerialToParralelAdapter();
                        connector.Image = CircuitImages.HorizontalSerialToParralelAdapter;
                        var elementAdapter = new ElementWithConnectionAdapter(connector,ConnectionType.Adapter);
                        list.Add(elementAdapter);
                    }
                    //Переход Parallel => Serial
                    else if (circuit is ParallelCircuit && icirc is SerialCircuit)
                    {
                        var connector = new SerialToParralelAdapter();
                        connector.Image = CircuitImages.HorizontalSerialToParralelAdapter;
                        connector.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        var elementAdapter = new ElementWithConnectionAdapter(connector, ConnectionType.Adapter);
                        list.Add(elementAdapter);
                    }
                    list.AddRange(GetComponentsList(icirc));
                    //Переход Serial => Parallel
                    if (circuit is SerialCircuit && icirc is ParallelCircuit)
                    {
                        var connector = new SerialToParralelAdapter();
                        connector.Image = CircuitImages.HorizontalSerialToParralelAdapter;
                        connector.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        var elementAdapter = new ElementWithConnectionAdapter(connector, ConnectionType.Adapter);
                        list.Add(elementAdapter);
                    }
                    //Переход Parallel => Serial
                    else if (circuit is ParallelCircuit && icirc is SerialCircuit)
                    {
                        var connector = new SerialToParralelAdapter();
                        connector.Image = CircuitImages.HorizontalSerialToParralelAdapter;
                        var elementAdapter = new ElementWithConnectionAdapter(connector, ConnectionType.Adapter);
                        list.Add(elementAdapter);
                    }
                }
                else if (c is IElement element)
                {
                    var connectionType = circuit is SerialCircuit ? ConnectionType.Serial : ConnectionType.Parallel;
                    list.Add(new ElementWithConnectionAdapter(element, connectionType));
                }
            }
            return list;
        }

        private static (int upLine,int vertLine,int downLine)  SectionsCounter(IList<ElementWithConnectionAdapter>  list)
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

        private void DrawComponent(int x, int y, ElementWithConnectionAdapter component, DrawType connectionType = DrawType.Horizontal)
        {
            var cell = (DataGridViewImageCell)gridView.Rows[y].Cells[x];
            Image componentImage = CircuitImages.WhiteBlock;
            if ( component.ConnectionType == ConnectionType.Parallel )
            {
                componentImage = component.Element is Resistor ? CircuitImages.ParallelResistor : componentImage;
                componentImage = component.Element is Capacitor ? CircuitImages.ParallelCapasitor : componentImage;
                componentImage = component.Element is Inductor ? CircuitImages.ParallelInductor : componentImage;
                componentImage?.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (component.ConnectionType == ConnectionType.Serial)
            {
                componentImage = component.Element is Resistor ? CircuitImages.SerialResistor : componentImage;
                componentImage = component.Element is Capacitor ? CircuitImages.SerialCapasitor : componentImage;
                componentImage = component.Element is Inductor ? CircuitImages.SerialInductor : componentImage;
            }
            else
            {
                var adapter = (SerialToParralelAdapter)component.Element;
                componentImage = adapter.Image;
            }

            //Рисуем обозначения
            var graphics = Graphics.FromImage(componentImage);
            var font = new System.Drawing.Font(FontFamily.GenericMonospace,14);
            graphics.DrawString(component.Element.Name,font,new SolidBrush(Color.Black), new Point(0,0));
            
            if ( connectionType == DrawType.Vertical )
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
