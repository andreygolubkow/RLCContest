#region Using
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using Core;
#endregion

namespace Controls.CircuitViewer
{
    public partial class CircuitViewer : UserControl
    {
        #region Constructors
        public CircuitViewer()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public void ShowZ(ICircuit circuit, double[] freq)
        {
            circuitGridView.Rows.Clear();
            circuitGridView.Columns.Clear();
            BuildStandartRows();
            BuildFreqRows(freq);
            FillCircuitTable(circuit, freq);
        }

        public void ClearTable()
        {
            circuitGridView.Rows.Clear();
            circuitGridView.Columns.Clear();
            BuildStandartRows();
        }

        #endregion

        #region Private Methods
        private void BuildFreqRows(double[] freq)
        {
            foreach (double f in freq)
            {
                var freqColumn = new DataGridViewColumn
                {
                    HeaderText =
                                             Convert.ToString(Math.Round(f, 4),
                                                              CultureInfo.CurrentCulture),
                    CellTemplate = new DataGridViewTextBoxCell()
                };
                circuitGridView.Columns.Add(freqColumn);
            }
        }

        private void BuildStandartRows()
        {
            var nameColumn = new DataGridViewColumn
            {
                HeaderText = @"Name",
                CellTemplate = new DataGridViewTextBoxCell()
            };
            circuitGridView.Columns.Add(nameColumn);
            var elementColumn = new DataGridViewColumn
            {
                HeaderText = @"Element",
                CellTemplate = new DataGridViewTextBoxCell()
            };
            circuitGridView.Columns.Add(elementColumn);
        }

        private void FillCircuitTable(ICircuit circuit, double[] freq)
        {
            for (int elementIndex = -1; elementIndex < circuit.Count; elementIndex++)
            {
                var circuitRow = new DataGridViewRow();
                circuitRow.CreateCells(circuitGridView);
                var cells = new object[freq.Length + 2];
                if (elementIndex == -1)
                {
                    cells[0] = circuit.Name;
                    cells[1] = "";
                    for (var i = 0; i < freq.Length; i++)
                    {
                        cells[i + 2] = circuit.CalculateZ(freq[i]);
                    }
                    circuitRow.DefaultCellStyle.BackColor = Color.Lavender;
                }
                else
                {
                    cells[0] = "";
                    cells[1] = circuit[elementIndex].Name;
                    for (var i = 0; i < freq.Length; i++)
                    {
                        cells[i + 2] = circuit[elementIndex].CalculateZ(freq[i]);
                    }
                    circuitRow.DefaultCellStyle.BackColor = Color.White;
                }
                circuitRow.SetValues(cells);
                circuitGridView.Rows.Add(circuitRow);
            }
        } 
        #endregion
    }
}

