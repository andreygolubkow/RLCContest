using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Elements;

namespace Controls
{
    public partial class CapacitorElementControl : BaseElementControl
    {
        private IElement _element;

        public CapacitorElementControl()
        {
            InitializeComponent();
        }

        #region Overrides of BaseElementControl

        public override IElement Element
        {
            get
            {
                _element = new Capacitor(ElementName, ElementValue);
                return _element;
            }
            set
            {
                if ( value is Capacitor capacitor )
                {
                    _element = capacitor;
                    ElementName = capacitor.Name;
                    ElementValue = capacitor.Value;
                    return;
                }
                if ( value != null )
                {
                    throw new ArgumentException("Данные объект не допустим, для этого элемента.");
                }
                ElementName = "";
                ElementValue = 0;
            }
        }

        #endregion
    }
}
