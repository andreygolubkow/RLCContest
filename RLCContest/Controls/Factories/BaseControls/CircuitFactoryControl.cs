using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Controls.SingleControls.BaseControls;

using Core;
using Core.Circuits;

using IComponent = Core.IComponent;

namespace Controls.Factories.BaseControls
{
    public partial class CircuitFactoryControl : BaseFactoryControl
    {
        private BaseCircuitControl _circuitControl;

        public event EventHandler EditComponentButtonClick;
        public event EventHandler AddComponentButtonClick;

        public CircuitFactoryControl()
        {
            InitializeComponent();
            for (var i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is BaseCircuitControl ctrl)
                {
                    ctrl.Location = new Point(7, 58);
                }
            }
            Size = new Size(355, 423);
            circuitTypeComboBox.SelectedIndex = 0;
        }

        public void AddComponent(IComponent component)
        {
            _circuitControl.Add(component);
        }

        public void EndEditComponent(IComponent component)
        {
            int index = _circuitControl.Circuit.IndexOf(_circuitControl.CurrentComponent);
            _circuitControl.Circuit.RemoveAt(index);
            _circuitControl.Circuit.Insert(index, component);
        }

        private void CalculateZButtonClick(object sender, EventArgs e)
        {
            Impedance = _circuitControl.Circuit.CalculateZ(Frequency);
        }

        private void CircuitTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (circuitTypeComboBox.SelectedIndex)
            {
                //Serial
                case 0: _circuitControl = serialCircuitControl;
                    break;
            }
            serialCircuitControl.Visible = circuitTypeComboBox.SelectedIndex == 0;
        }

        private void RemoveElementButtonClick(object sender, EventArgs e)
        {
            _circuitControl.Remove(_circuitControl.CurrentComponent);
        }

        private void CircuitFactoryControlClearButtonClick(object sender, EventArgs e)
        {
            _circuitControl.ElementName = "";
            _circuitControl.Circuit = null;
        }

        private void editElementButton_Click(object sender, EventArgs e)
        {
            EditComponentButtonClick?.Invoke(this,e);
        }

        private void addElementButton_Click(object sender, EventArgs e)
        {
            AddComponentButtonClick?.Invoke(this,e);
        }
    }
}
