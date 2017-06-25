#region Using
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Tools;

#endregion

namespace RLCCalculator
{

    /// <summary>
    /// Форма редактирования списка частот.
    /// </summary>
    public partial class FrequencyEditorForm : Form
    {
        #region Private Fields

        /// <summary>
        /// Список частот.
        /// </summary>
        private List<double> _freqDoubles;

        #endregion

        #region Constructors

        /// <summary>
        /// Создает новый экземпляр формы.
        /// </summary>
        /// <param name="frequencies">Список частот.</param>
        public FrequencyEditorForm(List<double> frequencies)
        {
            InitializeComponent();
            _freqDoubles = frequencies;
            doubleBindingSource.DataSource = _freqDoubles;

        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Список частот.
        /// </summary>
        public List<double> Frequencies => _freqDoubles;

        #endregion

        #region Private Methods

        /// <summary>
        /// Добавление частоты.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void AddButtonClick(object sender, EventArgs e)
        {
            if (frequencyTextBox.Text.Length == 0)
            {
                MessageBox.Show(@"You must enter the frequency");
                return;
            }
            try
            {
                doubleBindingSource.Add(Convert.ToDouble(frequencyTextBox.Text.Trim()));
                frequencyTextBox.Text = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"You did not enter a number");
#if DEBUG
                MessageBox.Show(exception.Message);
#endif

            }

        }

        /// <summary>
        /// Нажатие на кнопку удаления частоты.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void RemoveButtonClick(object sender, EventArgs e)
        {
            if (frequenciesListBox.SelectedIndex == -1)
            {
                MessageBox.Show(@"You must select an item");
                return;
            }
            doubleBindingSource.RemoveCurrent();
        }

        /// <summary>
        /// Нажатие клавишы в текст боксе для ввода частоты.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы.</param>
        private void FrequencyTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            Validators.DoubleEnterValidate(frequencyTextBox.Text, e);
        } 
        #endregion
    }
}
