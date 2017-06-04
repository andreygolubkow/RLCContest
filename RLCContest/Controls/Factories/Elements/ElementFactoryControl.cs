using System.Drawing;
using System.Windows.Forms;

using Controls.Factories.BaseControls;

namespace Controls.Factories.Elements
{
    public partial class ElementFactoryControl : BaseFactoryControl
    {
        public ElementFactoryControl()
        {
            InitializeComponent();
            inductorElementControl.Location = new Point(6, 73);
            capacitorElementControl.Location = new Point(6, 73);
            resistorElementControl.Location = new Point(6, 73);
        }
    }
}
