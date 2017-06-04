#region

using System;

using Core;
using Core.Elements;

#endregion

namespace Controls.Elements
{
    public partial class CapacitorElementControl : BaseElementControl
    {
        #region Fields

        private Capacitor _capacitor;

        #endregion

        public CapacitorElementControl()
        {
            InitializeComponent();
        }

        #region Overrides of BaseElementControl

        public override IElement Element
        {
            get
            {
                _capacitor = new Capacitor(ElementName, ElementValue);
                return _capacitor;
            }
            set
            {
                if ( value is Capacitor capacitor )
                {
                    _capacitor = capacitor;
                    ElementName = capacitor.Name;
                    ElementValue = capacitor.Value;
                    return;
                }
                if ( value != null )
                {
                    throw new ArgumentException("Данный объект не допустим, для этого элемента.");
                }
                ElementName = "";
                ElementValue = 0;
            }
        }

        #endregion
    }
}
