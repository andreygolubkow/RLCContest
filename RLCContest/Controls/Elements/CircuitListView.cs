#region Using
using System;
using System.ComponentModel;
using System.Windows.Forms;

using Core;

using IComponent = Core.IComponent;

#endregion

namespace Controls.Elements
{
    /// <summary>
    /// Элемент управления для просмотра информации о эл. цепи.
    /// </summary>
    public partial class CircuitListView : UserControl
    {
        #region Private Members

        /// <summary>
        /// Эл. цепь.
        /// </summary>
        private ICircuit _circuit;

        #endregion

        #region Constructors

        /// <summary>
        /// Создает новый экземпляр элемента управления.
        /// </summary>
        public CircuitListView()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Электрическая цепь.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public ICircuit Circuit
        {
            set
            {
                if (_circuit != null)
                {
                    _circuit.CircuitChanged -= CircuitChanged;
                }

                _circuit = value;
                if (value != null)
                {
                    _circuit.CircuitChanged += CircuitChanged;
                    FillList(_circuit);
                }
            }
            get
            {
                return _circuit;

            }
        }

        /// <summary>
        /// Текущий выбранный компонент эл. цепи.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public IComponent Current
        {
            get
            {
                if (_circuit == null)
                {
                    return null;
                }
                if (listBox.SelectedIndex == -1)
                {
                    return null;
                }
                return _circuit[listBox.SelectedIndex];
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Заполняет список элементами.
        /// </summary>
        /// <param name="circuit"></param>
        private void FillList(ICircuit circuit)
        {
            listBox.Items.Clear();
            foreach (IComponent e in circuit)
            {
                listBox.Items.Add(e.Name);
            }
        }

        /// <summary>
        /// Метод срабатывает при изменени эл. цепью своих параметров.
        /// </summary>
        /// <param name="sender">Эл. цепь.</param>
        /// <param name="e">Аргументы события.</param>
        private void CircuitChanged(object sender, EventArgs e)
        {
            FillList(_circuit);
        } 
        #endregion
    }
}
