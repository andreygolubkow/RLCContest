using Controls.CircuitDrawer;

namespace RLCCalculator
{
    partial class CircuitGraphicView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CircuitGraphicView));
            this.circuitDrawerControl = new CircuitDrawerControl();
            this.SuspendLayout();
            // 
            // circuitDrawerControl
            // 
            this.circuitDrawerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circuitDrawerControl.Location = new System.Drawing.Point(0, 0);
            this.circuitDrawerControl.Name = "circuitDrawerControl";
            this.circuitDrawerControl.Size = new System.Drawing.Size(284, 261);
            this.circuitDrawerControl.TabIndex = 0;
            // 
            // CircuitGraphicView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.circuitDrawerControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CircuitGraphicView";
            this.Text = "Circuit Design";
            this.ResumeLayout(false);

        }

        #endregion

        private CircuitDrawerControl circuitDrawerControl;
    }
}