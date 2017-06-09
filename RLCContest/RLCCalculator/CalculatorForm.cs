﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;

namespace RLCCalculator
{
    public partial class CalculatorZForm : Form
    {
        private ICircuit _circuit;
        private List<double> _frequencies;

        public CalculatorZForm()
        {
            InitializeComponent();
            _frequencies = new List<double>();
        }

        public ICircuit Circuit
        {
            set
            {
                
                if ( value == null )
                {
                    circuitViewer.ClearTable();
                    return;
                }
                if ( _circuit != null )
                {
                    _circuit.CircuitChanged -= CircuitChanged;
                }
                _circuit = value;
                _circuit.CircuitChanged += CircuitChanged;

            }
        }

        public List<double> Frequencies
        {
            set
            {
                if ( value != null )
                {
                    _frequencies = value;
                    CircuitChanged(this, new EventArgs());
                }
            }
        }

        private void CircuitChanged(object sender, EventArgs e)
        {
            if ( _circuit != null )
            {
                   circuitViewer.ShowZ(_circuit, _frequencies.ToArray());
            }
        }


    }
}