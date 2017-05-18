using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RLCControls;

namespace RLCGui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateElementButtonClick(object sender, EventArgs e)
        {
            var element = elementFactory.GetElementControl();
            circuitControl.AddControl(element);

        }

        

        private void CreateElementButtonMouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
