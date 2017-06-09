namespace RLCCalculator
{
    partial class CalculatorZForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.circuitsCalculatorGroupBox = new System.Windows.Forms.GroupBox();
            this.circuitViewer = new Controls.CircuitViewer.CircuitViewer();
            this.circuitsCalculatorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // circuitsCalculatorGroupBox
            // 
            this.circuitsCalculatorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circuitsCalculatorGroupBox.Controls.Add(this.circuitViewer);
            this.circuitsCalculatorGroupBox.Location = new System.Drawing.Point(12, 12);
            this.circuitsCalculatorGroupBox.Name = "circuitsCalculatorGroupBox";
            this.circuitsCalculatorGroupBox.Size = new System.Drawing.Size(585, 380);
            this.circuitsCalculatorGroupBox.TabIndex = 0;
            this.circuitsCalculatorGroupBox.TabStop = false;
            this.circuitsCalculatorGroupBox.Text = "Circuits Calculator";
            // 
            // circuitViewer
            // 
            this.circuitViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circuitViewer.Location = new System.Drawing.Point(6, 19);
            this.circuitViewer.Name = "circuitViewer";
            this.circuitViewer.Size = new System.Drawing.Size(573, 355);
            this.circuitViewer.TabIndex = 0;
            // 
            // CalculatorZForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 404);
            this.ControlBox = false;
            this.Controls.Add(this.circuitsCalculatorGroupBox);
            this.Name = "CalculatorZForm";
            this.Text = "Calculator";
            this.circuitsCalculatorGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox circuitsCalculatorGroupBox;
        private Controls.CircuitViewer.CircuitViewer circuitViewer;
    }
}