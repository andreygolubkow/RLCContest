#region Using
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Core;

#endregion

namespace RLCCalculator
{
    public partial class CalculatorZForm : Form
    {
        #region Private Fields
        private ICircuit _circuit;
        private List<double> _frequencies;

        #endregion

        #region Constructors
        public CalculatorZForm()
        {
            InitializeComponent();
            _frequencies = new List<double>();
        }
        #endregion

        #region Public Properties
        public ICircuit Circuit
        {
            set
            {

                if (value == null)
                {
                    circuitViewer.ClearTable();
                    return;
                }
                if (_circuit != null)
                {
                    _circuit.CircuitChanged -= CircuitChanged;
                }
                _circuit = value;
                _circuit.CircuitChanged += CircuitChanged;
                circuitViewer.ShowZ(_circuit, _frequencies.ToArray());
            }
        }

        public List<double> Frequencies
        {
            set
            {
                if (value != null)
                {
                    _frequencies = value;
                    CircuitChanged(this, new EventArgs());
                }
            }
        }
        #endregion

        #region Private Methods
        private void CircuitChanged(object sender, EventArgs e)
        {
            if (_circuit != null)
            {
                circuitViewer.ShowZ(_circuit, _frequencies.ToArray());
            }
        }

        private void CalculatorZFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        } 
        #endregion
    }
}
