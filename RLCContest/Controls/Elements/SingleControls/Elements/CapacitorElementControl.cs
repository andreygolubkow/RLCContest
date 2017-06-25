#region Using

using System;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Elements;

#endregion

namespace Controls.Elements.SingleControls.Elements
{

    /// <summary>
    /// Элемент управления для конденсатора.
    /// </summary>
    public partial class CapacitorElementControl : BaseElementControl
    {
        #region Private Fields

        /// <summary>
        /// Конденсатор.
        /// </summary>
        private Capacitor _capacitor;

        #endregion

        #region Constructors
        //TODO убрать пустую строку
        /// <summary>
        /// Создает новый экземпляр элемента управления.
        /// </summary>
        public CapacitorElementControl()
        {
            InitializeComponent();

        } 
        #endregion

        #region Overrides of BaseElementControl

        /// <summary>
        /// Элемент эл. цепи.
        /// </summary>
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
