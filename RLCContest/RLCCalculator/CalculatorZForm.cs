#region Using
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Core;
using Core.Circuits;

#endregion

namespace RLCCalculator
{

    /// <summary>
    /// Форма рассчета сопротивления.
    /// </summary>
    public partial class CalculatorZForm : Form
    {
        #region Private Fields

        /// <summary>
        /// Электрическая цепь для рассчета.
        /// </summary>
        private CircuitBase _circuit;

        /// <summary>
        /// Список частот для рассчета.
        /// </summary>
        private List<double> _frequencies;
        #endregion

        #region Constructors

        /// <summary>
        /// Создает экземпляр формы.
        /// </summary>
        public CalculatorZForm()
        {
            InitializeComponent();
            _frequencies = new List<double>();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Электрическая цепь для рассчета.
        /// </summary>
        public CircuitBase Circuit
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

        /// <summary>
        /// Список частот для рассчета.
        /// </summary>
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

        /// <summary>
        /// Метод срабатывается при изменениии параметров цепи.
        /// </summary>
        /// <param name="sender">Цепь изменившая параметр.</param>
        /// <param name="e">Аргументы.</param>
        private void CircuitChanged(object sender, EventArgs e)
        {
            if (_circuit != null)
            {
                circuitViewer.ShowZ(_circuit, _frequencies.ToArray());
            }
        }

        /// <summary>
        /// Не дает закрыть форму.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void CalculatorZFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        } 
        #endregion
    }
}
