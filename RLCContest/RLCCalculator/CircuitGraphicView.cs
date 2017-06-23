#region Using
using System.Drawing;
using System.Windows.Forms;

using CircuitDrawer;

using Core;

#endregion

namespace RLCCalculator
{
    public partial class CircuitGraphicView : Form
    {
        #region Constructors
        public CircuitGraphicView(ICircuit circuit)
        {
            InitializeComponent();

            Image image = circuit.GetImage();

            picture.Width = image.Width;
            picture.Height = image.Height;
            picture.Image = image;
        } 
        #endregion
    }
}
