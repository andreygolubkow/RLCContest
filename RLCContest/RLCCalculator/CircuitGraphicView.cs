#region Using
using System.Drawing;
using System.Windows.Forms;

using CircuitDrawer;

using Core;

#endregion

namespace RLCCalculator
{
    /// <summary>
    /// Форма просмотра грифического представления схемы.
    /// </summary>
    public partial class CircuitGraphicView : Form
    {
        #region Constructors

        /// <summary>
        /// Создает новый экземпляр формы.
        /// </summary>
        /// <param name="circuit">Эл. цепь для просмотра.</param>
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
