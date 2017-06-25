#region Using
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Core;

using Tools;

using Project = Core.Project;

#endregion

namespace RLCCalculator
{

    /// <summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Private Fields

        /// <summary>
        /// Проект.
        /// </summary>
        private Project _project;

        /// <summary>
        /// Форма рассчета Z.
        /// </summary>
        private CalculatorZForm _calculatorZ;

        /// <summary>
        /// Форма редактирования цепи.
        /// </summary>
        private readonly CircuitDetailForm _circuitDetailForm;

        #endregion

        #region Constructors

        /// <summary>
        /// Создает новый экземпляр формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            //// var test = new TestForm();
            // test.ShowDialog();
#endif

            _project = new Project
            {
                Circuits = new List<IComponent>(),
                Frequencies = new List<double>()
            };
            iComponentBindingSource.DataSource = _project.Circuits;
            _calculatorZ = new CalculatorZForm();
            _circuitDetailForm = new CircuitDetailForm(FormOpenMode.LiveEdit);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Нажатие на пункт меню "Частоты"
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void FrequenciesMenuItemClick(object sender, EventArgs e)
        {
            var freqEditorForm = new FrequencyEditorForm(_project.Frequencies);
            freqEditorForm.ShowDialog();
            _project.Frequencies = freqEditorForm.Frequencies;
            _calculatorZ.Frequencies = _project.Frequencies;
        }

        /// <summary>
        /// Нажатие на пукн меню "Z Calculator"
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void ZCalculatorToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_calculatorZ == null)
            {
                _calculatorZ = new CalculatorZForm
                {
                    Frequencies = _project.Frequencies
                };
            }
            _calculatorZ.Visible = true;
        }

        /// <summary>
        /// Изменение текущего списка компонентов.
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void IComponentBindingSourceCurrentChanged(object sender, EventArgs e)
        {
            if (_calculatorZ == null)
            {
                _calculatorZ = new CalculatorZForm
                {
                    Frequencies = _project.Frequencies
                };
            }
            _calculatorZ.Circuit = (ICircuit)iComponentBindingSource.Current;
            _circuitDetailForm.Circuit = (ICircuit)iComponentBindingSource.Current;
        }

        /// <summary>
        /// Нажатие на пукн меню редактирования цепи.
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void CircuitEditorToolStripMenuItemClick(object sender, EventArgs e)
        {
            _circuitDetailForm.Visible = true;
        }

        /// <summary>
        /// Нажатие на пукн меню Обновить.
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void RefreshListToolStripMenuItemClick(object sender, EventArgs e)
        {
            iComponentBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Нажатие на пункт меню Новый проект.
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void NewProjectToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show(@"Do you want to create a new project? All data will be lost!",
                                          @"Create new project",
                                          MessageBoxButtons.YesNo);
            if (message == DialogResult.Yes)
            {
                _project = new Project
                {
                    Frequencies = new List<double>(),
                    Circuits = new List<IComponent>()
                };
                iComponentBindingSource.DataSource = _project.Circuits;
                _calculatorZ.Frequencies = _project.Frequencies;
                _calculatorZ.Circuit = null;
            }
        }

        /// <summary>
        /// Нажатие на пункт меню Отрыть проект.
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void OpenProjectToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataSerializer.DeserializeBin(openFileDialog.FileName, ref _project);

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    _project = new Project
                    {
                        Circuits = new List<IComponent>(),
                        Frequencies = new List<double>()
                    };
                }
                iComponentBindingSource.DataSource = _project.Circuits;
                _calculatorZ.Frequencies = _project.Frequencies;
                _calculatorZ.Circuit = null;

            }
        }

        /// <summary>
        /// Нажатие на пункт меню Сохарнить.
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void SaveProjectToolStripMenuItemClick(object sender, EventArgs e)
        {
            object saveProject = _project.Clone();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataSerializer.SerializeBin(saveFileDialog.FileName, saveProject);
            }
        }

        /// <summary>
        /// Нажатие на пункт меню Новая цепь.
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void NewCircuitToolStripMenuItemClick1(object sender, EventArgs e)
        {
            var circuitForm = new CircuitDetailForm(FormOpenMode.Create);
            if (circuitForm.ShowDialog() == DialogResult.OK)
            {
                iComponentBindingSource.Add(circuitForm.Circuit);
            }
        }

        /// <summary>
        /// Нажатие на пукнт меню Удалить цепь.
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void RemoveCircuitToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (iComponentBindingSource.Current == null)
            {
                MessageBox.Show(@"You must select an element to delete");
                return;
            }
            if (iComponentBindingSource.Current != null)
            {
                iComponentBindingSource.RemoveCurrent();
            }
        }

        /// <summary>
        /// Нажатие на пункт меню Отрисовки цепи.
        /// </summary>
        /// <param name="sender">Истончик события.</param>
        /// <param name="e">Параметры события.</param>
        private void CircuitDesignerToolStripMenuItemClick(object sender, EventArgs e)
        {
            var circuit = iComponentBindingSource.Current as ICircuit;
            if (circuit == null)
            {
                MessageBox.Show(@"You must select an element to delete");
                return;
            }
            {
                var designForm = new CircuitGraphicView(circuit);
                designForm.ShowDialog();
            }
        } 
        #endregion
    }
}
