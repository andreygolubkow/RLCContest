#region

using System;
using System.ComponentModel;

using Controls.SingleControls.BaseControls;

using Core;
using Core.Elements;

#endregion

namespace Controls.SingleControls.Elements
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
                _inductor = ElementName.Length > 0 ? new Inductor(ElementName, ElementValue) : null;
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
