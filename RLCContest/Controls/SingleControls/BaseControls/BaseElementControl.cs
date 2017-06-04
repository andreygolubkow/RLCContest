using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

using Core;

namespace Controls.SingleControls.BaseControls
{
    public partial class BaseElementControl : UserControl
    {
        private IElement _element;

        protected BaseElementControl()
        {
            InitializeComponent();
            _element = null;
        }

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
                if ( value == null )
                {
                    nameTextBox.Clear();
                    valueTextBox.Clear();
                    return;
                }
                _element = value;
            }
        }

        protected string ElementName
        {
            get => nameTextBox.Text;
            set => nameTextBox.Text = value;
        }

        protected double ElementValue
        {
            get => Convert.ToDouble(valueTextBox.Text);
            set => valueTextBox.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
        }
    }
}
