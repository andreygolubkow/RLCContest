#region

using System;
using System.ComponentModel;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Elements;

#endregion

namespace Controls.Elements.SingleControls.Elements
{
    public partial class InductorElementControl : BaseElementControl
    {
        #region Fields

        private Inductor _inductor;

        #endregion

        public InductorElementControl()
        {
            InitializeComponent();
        }

        [DefaultValue(null)]
        public override IElement Element
        {
            get
            {
                if (_inductor == null)
                {
                    _inductor = ElementName.Length > 0 ? new Inductor(ElementName, ElementValue) : new Inductor("Inductor" + Convert.ToString(DateTime.Now.Millisecond), ElementValue);
                }
                else
                {
                    _inductor.Name = ElementName;
                    _inductor.Value = ElementValue;
                }
                return _inductor;
            }
            set
            {
                if ( value is Inductor inductor )
                {
                    _inductor = inductor;
                    ElementName = inductor.Name;
                    ElementValue = inductor.Value;
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
    }
}
