﻿#region

using System;
using System.ComponentModel;

using Controls.SingleControls.BaseControls;

using Core;
using Core.Elements;

#endregion

namespace Controls.SingleControls.Elements
{
    public partial class ResistorElementControl : BaseElementControl
    {
        #region Fields

        private Resistor _resistor;

        #endregion

        public ResistorElementControl()
        {
            InitializeComponent();
        }

        [DefaultValue(null)]
        public override IElement Element
        {
            get
            {
                _resistor = ElementName.Length>0 ? new Resistor(ElementName, ElementValue) : new Resistor("Resistor" + Convert.ToString(DateTime.Now.Millisecond),ElementValue);
                return _resistor;
            }
            set
            {
                if ( value is Resistor resistor )
                {
                    _resistor = resistor;
                    ElementName = resistor.Name;
                    ElementValue = resistor.Value;
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