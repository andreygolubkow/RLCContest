#region Using
using System.Drawing;
using System.Windows.Forms;

using CircuitDrawer;

using Core;
using Core.Circuits;

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
        public CircuitGraphicView(CircuitBase circuit)
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
