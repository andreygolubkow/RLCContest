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
            this.componentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.capacitorElementControl = new Controls.Elements.SingleControls.Elements.CapacitorElementControl();
            this.inductorElementControl = new Controls.Elements.SingleControls.Elements.InductorElementControl();
            this.resistorElementControl = new Controls.Elements.SingleControls.Elements.ResistorElementControl();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // componentTypeComboBox
            // 
            this.componentTypeComboBox.FormattingEnabled = true;
            this.componentTypeComboBox.Items.AddRange(new object[] {
            "Capasitor",
            "Inductor",
            "Resistor"});
            this.componentTypeComboBox.Location = new System.Drawing.Point(12, 25);
            this.componentTypeComboBox.Name = "componentTypeComboBox";
            this.componentTypeComboBox.Size = new System.Drawing.Size(251, 21);
            this.componentTypeComboBox.TabIndex = 0;
            this.componentTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.componentTypeComboBox_SelectedIndexChanged);
            // 
            // capacitorElementControl
            // 
            this.capacitorElementControl.Location = new System.Drawing.Point(12, 52);
            this.capacitorElementControl.Name = "capacitorElementControl";
            this.capacitorElementControl.Size = new System.Drawing.Size(251, 70);
            this.capacitorElementControl.TabIndex = 2;
            this.capacitorElementControl.Visible = false;
            // 
            // inductorElementControl
            // 
            this.inductorElementControl.Location = new System.Drawing.Point(269, 52);
            this.inductorElementControl.Name = "inductorElementControl";
            this.inductorElementControl.Size = new System.Drawing.Size(251, 70);
            this.inductorElementControl.TabIndex = 3;
            this.inductorElementControl.Visible = false;
            // 
            // resistorElementControl
            // 
            this.resistorElementControl.Location = new System.Drawing.Point(526, 52);
            this.resistorElementControl.Name = "resistorElementControl";
            this.resistorElementControl.Size = new System.Drawing.Size(251, 70);
            this.resistorElementControl.TabIndex = 4;
            this.resistorElementControl.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Component type";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(188, 128);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(15, 128);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ComponentDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 159);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resistorElementControl);
            this.Controls.Add(this.inductorElementControl);
            this.Controls.Add(this.capacitorElementControl);
            this.Controls.Add(this.componentTypeComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ElementDetailForm";
            this.Text = "ComponentDetailFormcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox componentTypeComboBox;
        private Controls.Elements.SingleControls.Elements.CapacitorElementControl capacitorElementControl;
        private Controls.Elements.SingleControls.Elements.InductorElementControl inductorElementControl;
        private Controls.Elements.SingleControls.Elements.ResistorElementControl resistorElementControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}