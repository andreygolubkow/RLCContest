using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLCGui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void createElementButton_Click(object sender, EventArgs e)
        {
            var element = elementFactory.Element;
            element.Location = new System.Drawing.Point(20,20);
            Controls.Add(element);
        }
    }
}
