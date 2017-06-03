using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core.Elements;

namespace Controls
{
    public partial class CapacitorControl : UserControl
    {
        private Capacitor _element;

        public CapacitorControl()
        {
            InitializeComponent();
            _element = null;
#if !DEBUG
            zValueLabel.Text = "";
#endif
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public Capacitor Element
        {
            get
            {
                _element = new Capacitor(nameTextBox.Text,Convert.ToDouble(valueTextBox.Text));
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

    }
}
