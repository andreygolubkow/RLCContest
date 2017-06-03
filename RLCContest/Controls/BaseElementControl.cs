using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Elements;

namespace Controls
{
    public partial class BaseElementControl : UserControl
    {
        private IElement _element;

        public BaseElementControl()
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
