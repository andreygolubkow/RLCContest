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
    #region Attrubutes
    [Serializable]
    #endregion
    public partial class BaseElementControl : UserControl
    {
        #region Private Fields
        private IElement _element;
        #endregion

        #region Constructors
        protected BaseElementControl()
        {
            InitializeComponent();
            _element = null;
        }

        #endregion

        #region Public Properties
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
        [DefaultValue(null)]
        protected string ElementName
        {
            get => nameTextBox.Text;
            set => nameTextBox.Text = value ?? "";
        }

        [DefaultValue(0)]
        protected double ElementValue
        {
            get => valueTextBox.Text.Length > 0 ? Convert.ToDouble(valueTextBox.Text) : 0;
            set => valueTextBox.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
        }
        #endregion

        #region Public Methods
        public void CleaFields()
        {
            ElementName = "";
            ElementValue = 0;
        }
        #endregion

        #region Private Methods
        private void ValueTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            Validators.DoubleEnterValidate(valueTextBox.Text, e);
        } 
        #endregion
    }
}
