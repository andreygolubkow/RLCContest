#region

using System;

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

        public override IElement Element
        {
            get
            {
                _inductor = new Inductor(ElementName, ElementValue);
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
