using System.Drawing;

using Controls.Factories.BaseControls;

namespace Controls.Factories.Elements
{
    public partial class ElementFactoryControl : BaseFactoryControl
    {
        public ElementFactoryControl()
        {
            InitializeComponent();
            inductorElementControl.Location = new Point(3, 65);
            capacitorElementControl.Location = new Point(3, 65);
            resistorElementControl.Location = new Point(3, 65);
            Size = new Size(352, 269);
        }
    }
}
