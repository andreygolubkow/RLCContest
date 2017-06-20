using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;

namespace Controls.CircuitDrawer
{
    public partial class AdvancedCircuitDrawer : UserControl
    {
        private ICircuit _circuit;

        private List<List<IElement>> _elementsList;

        public AdvancedCircuitDrawer()
        {
            InitializeComponent();
        }

        private void  Draw(ICircuit circuit)
        {


            foreach (var el in circuit)
            {
                
            }


        }



    }
}
