#region Using
using System;
using System.Drawing;
using System.Windows.Forms;

using Controls.Elements.SingleControls.BaseControls;

using Core;
using Core.Circuits;

using Tools;

#endregion

namespace RLCCalculator
{

    /// <summary>
    /// Класс редактирования эл. цепи.
    /// </summary>
    public partial class CircuitDetailForm : Form
    {
        #region Private Fields

        /// <summary>
        /// Контрол для редактирования цепи.
        /// </summary>
        private BaseCircuitControl _circuitControl;

        /// <summary>
        /// Тип открытия формы.
        /// </summary>
        private readonly FormOpenModeEnum _modeEnum;
        #endregion

        #region Constructors

        /// <summary>
        /// Создает новый экземпляр формы.
        /// </summary>
        /// <param name="modeEnum">Тип открытия формы.</param>
        public CircuitDetailForm(FormOpenModeEnum modeEnum = FormOpenModeEnum.Create)
        {
            InitializeComponent();

            Size = new Size(304, 362);
            serialCircuitControl.Location = new Point(12, 60);
            parallelCircuitControl.Location = new Point(12, 60);

            _modeEnum = modeEnum;
            switch (modeEnum)
            {
                case FormOpenModeEnum.Create:

                    circuitTypeComboBox.Enabled = true;
                    createButton.Visible = true;

                    break;
                case FormOpenModeEnum.Edit:

                    circuitTypeComboBox.Enabled = false;

                    break;
                case FormOpenModeEnum.LiveEdit:

                    circuitTypeComboBox.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(modeEnum), modeEnum, null);
            }

        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Электрическая цепь.
        /// </summary>
        public CircuitBase CircuitBase
        {
            set
            {
                if (value is SerialCircuit)
                {
                    circuitTypeComboBox.SelectedIndex = 0;
                    _circuitControl.Circuit = value;
                }
                if (value is ParallelCircuit)
                {
                    circuitTypeComboBox.SelectedIndex = 1;
                    _circuitControl.Circuit = value;
                }
            }
            get => _circuitControl.Circuit;
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Предотвращает закрытие формы в лайв режиме.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void CircuitDetailFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modeEnum == FormOpenModeEnum.LiveEdit)
            {
                e.Cancel = true;
                Visible = false;
            }

        }

        /// <summary>
        /// Нажатие на кнопку удаления элемента.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void RemoveElementButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You must create circuit  to delete items");
                return;
            }
            if (_circuitControl.CurrentComponent == null)
            {
                MessageBox.Show(@"You must select an item to delete");
                return;
            }
            _circuitControl.Remove(_circuitControl.CurrentComponent);
        }

        /// <summary>
        /// Нажатие на кнопку добавления элемента.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void AddComponentButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You need to select an electrical circuit to add elements");
                return;
            }
            var componentForm = new ElementDetailForm(null);
            if (componentForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _circuitControl.Add(componentForm.Element);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
        }

        /// <summary>
        /// Изменение элемента в комбо боксе. Показывает нужный контрол для элемента.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void CircuitTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {

            if (circuitTypeComboBox.SelectedIndex == 0)
            {
                _circuitControl = serialCircuitControl;
            }
            if (circuitTypeComboBox.SelectedIndex == 1)
            {
                _circuitControl = parallelCircuitControl;
            }

            serialCircuitControl.Visible = circuitTypeComboBox.SelectedIndex == 0;
            parallelCircuitControl.Visible = circuitTypeComboBox.SelectedIndex == 1;

            if (_modeEnum == FormOpenModeEnum.Create)
            {
                _circuitControl.Circuit = null;
            }
        }

        /// <summary>
        /// Нажатие на кнопку создания элемента.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void CreateButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You need to select an electrical circuit to create circuit");
                return;
            }
            try
            {
                if (_circuitControl.Circuit.Name.Length == 0)
                {
                    throw new Exception("You must enter a valid name");
                }
                CircuitBase circuitBase = _circuitControl.Circuit;
                if (circuitBase == null)
                {
                    throw new ArgumentNullException(nameof(circuitBase));
                }
                circuitBase.TryLoad();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Нажатие на кнопку добавления эл.цепи.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void AddSubcircuitButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You need to select an electrical circuit to add elements");
                return;
            }
            var circuitForm = new CircuitDetailForm(FormOpenModeEnum.Create);
            if (circuitForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _circuitControl.Add(circuitForm.CircuitBase);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        /// <summary>
        /// Нажатие на кнопку редактирования элемента.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void EditElementButtonClick(object sender, EventArgs e)
        {
            if (_circuitControl == null)
            {
                MessageBox.Show(@"You must create circuit to edit");
                return;
            }
            if (_circuitControl.CurrentComponent == null)
            {
                MessageBox.Show(@"You must select an item to edit");
                return;
            }
            if (_circuitControl.CurrentComponent is IElement element)
            {
                var elementForm = new ElementDetailForm(element);
                if (elementForm.ShowDialog() == DialogResult.OK)
                {
                }
            }
            else if (_circuitControl.CurrentComponent is CircuitBase circuit)
            {
                var circuitForm = new CircuitDetailForm(FormOpenModeEnum.Edit)
                {
                    CircuitBase = circuit
                };
                circuitForm.ShowDialog();
            }
        } 
        #endregion
    }
}
