#region Using
using System;
using System.ComponentModel;
using System.Windows.Forms;

using Core;

#endregion

namespace Controls.Elements.SingleControls.BaseControls
{

    /// <summary>
    /// Базовый элемент управления для эл. цепей.
    /// </summary>
    #region Attributes
    [Serializable]
    #endregion
    public partial class BaseCircuitControl : UserControl
    {

        #region Protected Fields

        /// <summary>
        /// Электрическая цепь.
        /// </summary>
        protected ICircuit _circuit;
        #endregion

        #region Constructors

        /// <summary>
        /// Создает новый экземпляр элемента управлений.
        /// </summary>
        protected BaseCircuitControl()
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
        public virtual ICircuit Circuit
        {
            get => _circuit;
            set
            {
                _circuit = value;
                ElementName = value.Name;
                circuitListView.Circuit = _circuit;
            }
        }

        /// <summary>
        /// Текущий выбранный компонент.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public Core.IComponent CurrentComponent => circuitListView.Current;

        /// <summary>
        /// Наименование цепи.
        /// </summary>
        public string ElementName
        {
            get
            {
                return nameTextBox.Text;
            }
            set
            {
                nameTextBox.Text = value;
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Добавление эл. элемента в цепь.
        /// </summary>
        /// <param name="component">Элемент эл. цепи.</param>
        public void Add(Core.IComponent component)
        {
            _circuit.Add(component);
        }

        /// <summary>
        /// Удаляет элемент из эл. цепи.
        /// </summary>
        /// <param name="component">Компонент эл.цепи.</param>
        public void Remove(Core.IComponent component)
        {
            _circuit.Remove(component);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Изменение имени в текстовом поле.
        /// </summary>
        /// <param name="sender">Текстовое поле.</param>
        /// <param name="e">Аргументы.</param>
        private void NameTextBoxTextChanged(object sender, EventArgs e)
        {
            if (_circuit != null)
            {
                if (nameTextBox.Text.Length > 0)
                {
                    _circuit.Name = nameTextBox.Text;
                }
            }
        } 
        #endregion
    }
}
