using System.Drawing;
using System.Windows.Forms;

using CircuitGraphics;

using Core;

namespace RLCCalculator
{
    public partial class CircuitGraphicView : Form
    {
        public CircuitGraphicView(ICircuit circuit)
        {
            InitializeComponent();

            Image image = circuit.GetImage();

            picture.Width = image.Width;
            picture.Height = image.Height;
            picture.Image = image;
        }
    }
}
