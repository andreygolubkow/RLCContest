using System.Windows.Forms;

using Core;

using Tools;

namespace RLCCalculator
{
    public partial class MainForm : Form
    {
        private Project _project;

        private CalculatorZForm _calculatorZ;
        
        public MainForm()
        {
            InitializeComponent();
            _project = new Project();
            _calculatorZ = new CalculatorZForm();
#if DEBUG
            var testForm = new TestForm();
            testForm.Show();
#endif
        }

        private void frequenciesMenuItem_Click(object sender, System.EventArgs e)
        {
            var freqEditorForm = new FrequencyEditorForm(_project.Frequencies);
            freqEditorForm.ShowDialog();
            _project.Frequencies = freqEditorForm.Frequencies;
            _calculatorZ.Frequencies = _project.Frequencies;
        }

        private void zCalculatorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if ( _calculatorZ == null )
            {
                _calculatorZ = new CalculatorZForm();
                _calculatorZ.Frequencies = _project.Frequencies;
            }
            _calculatorZ.Visible = zCalculatorToolStripMenuItem.Checked;
        }

        private void iComponentBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if ( _calculatorZ == null )
            {
                _calculatorZ = new CalculatorZForm();
                _calculatorZ.Frequencies = _project.Frequencies;
            }
            _calculatorZ.Circuit = (ICircuit)iComponentBindingSource.Current;
        }
    }
}
