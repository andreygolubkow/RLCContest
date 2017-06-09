using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Circuits;
using Core.Elements;

using IComponent = Core.IComponent;

namespace Controls
{
    public partial class CircuitViewer : UserControl
    {
        private ICircuit _circuit;
        public CircuitViewer()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]

        public void ShowZ(ICircuit circuit, double[] freq)
        {
            circuitGridView.Rows.Clear();
            circuitGridView.Columns.Clear();
            _circuit = circuit;
            BuildStandartRows();
            BuildFreqRows(freq);
            FillTable(freq);
        }

        private void BuildFreqRows(double[] freq)
        {
            foreach (var f in freq)
            {
                var freqColumn = new DataGridViewColumn
                                 {
                                     HeaderText = Convert.ToString(Math.Round(f,5), CultureInfo.InvariantCulture),
                                     CellTemplate = new DataGridViewTextBoxCell()
                };
                circuitGridView.Columns.Add(freqColumn);
            }
        }

        private void BuildStandartRows()
        {
            var nameColumn = new DataGridViewColumn
                             {
                                 HeaderText = "Name",
                                 CellTemplate = new DataGridViewTextBoxCell()
                             };
            circuitGridView.Columns.Add(nameColumn);
            var elementColumn = new DataGridViewColumn
                             {
                                 HeaderText = "Element",
                                 CellTemplate = new DataGridViewTextBoxCell()
                             };
            circuitGridView.Columns.Add(elementColumn);
        }

        private void FillTable(double[] freq)
        {

            for (int elementIndex = -1; elementIndex < _circuit.Count; elementIndex++)
            {
                var circuitRow = new DataGridViewRow();
                circuitRow.CreateCells(circuitGridView);
                var cells = new object[freq.Length + 2];
                if ( elementIndex == -1 )
                {
                    cells[0] = _circuit.Name;
                    cells[1] = "";
                    for (var i = 0; i < freq.Length; i++)
                    {
                        cells[i + 2] = _circuit.CalculateZ(freq[i]);
                    }
                    circuitRow.DefaultCellStyle.BackColor = Color.Lavender;
                }
                else
                {
                    cells[0] = "";
                    cells[1] = _circuit[elementIndex].Name;
                    for (var i = 0; i < freq.Length; i++)
                    {
                        cells[i + 2] = _circuit[elementIndex].CalculateZ(freq[i]);
                    }
                    circuitRow.DefaultCellStyle.BackColor = Color.White;
                }
                circuitRow.SetValues(cells);
                circuitGridView.Rows.Add(circuitRow);
            }

               

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c1 = new SerialCircuit();
            c1.Name = "MyCircuit1";
            c1.Add(new Resistor("res1",5));
            c1.Add(new Inductor("In",12));
            var c2 = new SerialCircuit();
            c2.Name = "MyCircuit2";
            c2.Add(new Resistor("res1", 5));
            c2.Add(new Inductor("In", 12));
            var f = new double[5] { 1, 2, 3, 4, 5 };
            c1.Add(c2);
            ShowZ(c1, f);
        }
    }
}

