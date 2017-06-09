namespace RLCCalculator
{
    partial class ElementDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementDetailForm));
            this.elementFactoryControl1 = new Controls.Factories.BaseControls.ElementFactoryControl();
            this.SuspendLayout();
            // 
            // elementFactoryControl1
            // 
            this.elementFactoryControl1.Frequency = 0D;
            this.elementFactoryControl1.Impedance = ((System.Numerics.Complex)(resources.GetObject("elementFactoryControl1.Impedance")));
            this.elementFactoryControl1.Location = new System.Drawing.Point(12, 12);
            this.elementFactoryControl1.MinimumSize = new System.Drawing.Size(341, 224);
            this.elementFactoryControl1.Name = "elementFactoryControl1";
            this.elementFactoryControl1.Size = new System.Drawing.Size(352, 269);
            this.elementFactoryControl1.TabIndex = 0;
            // 
            // ElementDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 292);
            this.Controls.Add(this.elementFactoryControl1);
            this.Name = "ElementDetailForm";
            this.Text = "ElementDetailForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Factories.BaseControls.ElementFactoryControl elementFactoryControl1;
    }
}