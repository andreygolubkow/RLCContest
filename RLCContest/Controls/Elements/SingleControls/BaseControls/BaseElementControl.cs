#region Using
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

using Core;

using Tools;

#endregion

namespace Controls.Elements.SingleControls.BaseControls
{

    /// <summary>
    /// Базовый элемент управления для элемента эл. цепи. 
    /// </summary>
    #region Attrubutes
    [Serializable]
    #endregion
    public partial class BaseElementControl : UserControl
    {
        #region Private Fields

        /// <summary>
        /// Элемент эл. цепи.
        /// </summary>
        private IElement _element;
        #endregion

        #region Constructors

        /// <summary>
        /// Создает экземпляр класса.
        /// </summary>
        protected BaseElementControl()
        {
            InitializeComponent();
            _element = null;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Элемент  эл. цепи.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public virtual IElement Element
        {
            get
            {
                return _element;
            }
            set
            {
                if (value == null)
                {
                    nameTextBox.Clear();
                    valueTextBox.Clear();
                    return;
                }
                _element = value;
            }
        }
        #endregion

        #region Protected Properies

        /// <summary>
        /// Наименование элемента.
        /// </summary>
        [DefaultValue(null)]
        protected string ElementName
        {
            get => nameTextBox.Text;
            set => nameTextBox.Text = value ?? "";
        }

        /// <summary>
        /// Номинал элемента.
        /// </summary>
        [DefaultValue(0)]
        protected double ElementValue
        {
            get => valueTextBox.Text.Length > 0 ? Convert.ToDouble(valueTextBox.Text) : 0;
            set => valueTextBox.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Очищает поля для ввода.
        /// </summary>
        public void CleaFields()
        {
            ElementName = "";
            ElementValue = 0;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Нажатие клавиши в поле для ввода номинала.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ValueTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            Validators.DoubleEnterValidate(valueTextBox.Text, e);
        } 
        #endregion
    }
}
