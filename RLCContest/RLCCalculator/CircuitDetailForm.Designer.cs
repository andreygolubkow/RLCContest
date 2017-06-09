namespace RLCCalculator
{
    partial class CircuitDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CircuitDetailForm));
            this.circuitFactoryControl = new Controls.Factories.BaseControls.CircuitFactoryControl();
            this.SuspendLayout();
            // 
            // circuitFactoryControl
            // 
            this.circuitFactoryControl.Frequency = 0D;
            this.circuitFactoryControl.Impedance = ((System.Numerics.Complex)(resources.GetObject("circuitFactoryControl.Impedance")));
            this.circuitFactoryControl.Location = new System.Drawing.Point(12, 12);
            this.circuitFactoryControl.MinimumSize = new System.Drawing.Size(341, 224);
            this.circuitFactoryControl.Name = "circuitFactoryControl";
            this.circuitFactoryControl.Size = new System.Drawing.Size(355, 423);
            this.circuitFactoryControl.TabIndex = 0;
            // 
            // CircuitDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 437);
            this.Controls.Add(this.circuitFactoryControl);
            this.Name = "CircuitDetailForm";
            this.Text = "CircuitDetailForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CircuitDetailForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Factories.BaseControls.CircuitFactoryControl circuitFactoryControl;
    }
}