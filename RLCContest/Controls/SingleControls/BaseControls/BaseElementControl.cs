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

        [DefaultValue(null)]
        protected string ElementName
        {
            get => nameTextBox.Text;
            set => nameTextBox.Text = value ?? "";
        }

        [DefaultValue(0)]
        protected double ElementValue
        {
            get => valueTextBox.Text.Length>0 ? Convert.ToDouble(valueTextBox.Text):0;
            set => valueTextBox.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
        }
    }
}
