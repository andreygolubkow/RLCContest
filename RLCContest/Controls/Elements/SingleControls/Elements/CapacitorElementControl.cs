#region Using

using System;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Elements;

#endregion

namespace Controls.Elements.SingleControls.Elements
{
    public partial class CapacitorElementControl : BaseElementControl
    {
        #region Private Fields

        private Capacitor _capacitor;

        #endregion

        #region Constructors
        public CapacitorElementControl()
        {
            InitializeComponent();

        } 
        #endregion

        #region Overrides of BaseElementControl


        public override IElement Element
        {
            get
            {
                if ( _capacitor == null )
                {
                    _capacitor = ElementName.Length > 0 ? new Capacitor(ElementName, ElementValue) : new Capacitor("Element" + Convert.ToString(DateTime.Now.Millisecond), ElementValue);
                }
                else
                {
                    _capacitor.Name = ElementName;
                    _capacitor.Value = ElementValue;
                }
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
