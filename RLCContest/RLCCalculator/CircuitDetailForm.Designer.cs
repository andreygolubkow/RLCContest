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
            this.addComponentButton = new System.Windows.Forms.Button();
            this.addSubcircuitButton = new System.Windows.Forms.Button();
            this.editElementButton = new System.Windows.Forms.Button();
            this.removeElementButton = new System.Windows.Forms.Button();
            this.circuitTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createNewCircuitGroupBox = new System.Windows.Forms.GroupBox();
            this.serialCircuitControl = new Controls.Elements.SingleControls.Circuits.SerialCircuitControl();
            this.createNewCircuitGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addComponentButton
            // 
            this.addComponentButton.Location = new System.Drawing.Point(12, 240);
            this.addComponentButton.Name = "addComponentButton";
            this.addComponentButton.Size = new System.Drawing.Size(93, 23);
            this.addComponentButton.TabIndex = 1;
            this.addComponentButton.Text = "Add component";
            this.addComponentButton.UseVisualStyleBackColor = true;
            this.addComponentButton.Click += new System.EventHandler(this.addComponentButton_Click);
            // 
            // addSubcircuitButton
            // 
            this.addSubcircuitButton.Location = new System.Drawing.Point(12, 269);
            this.addSubcircuitButton.Name = "addSubcircuitButton";
            this.addSubcircuitButton.Size = new System.Drawing.Size(93, 23);
            this.addSubcircuitButton.TabIndex = 2;
            this.addSubcircuitButton.Text = "Add subcircuit";
            this.addSubcircuitButton.UseVisualStyleBackColor = true;
            this.addSubcircuitButton.Click += new System.EventHandler(this.addSubcircuitButton_Click);
            // 
            // editElementButton
            // 
            this.editElementButton.Location = new System.Drawing.Point(111, 240);
            this.editElementButton.Name = "editElementButton";
            this.editElementButton.Size = new System.Drawing.Size(75, 23);
            this.editElementButton.TabIndex = 3;
            this.editElementButton.Text = "Edit element";
            this.editElementButton.UseVisualStyleBackColor = true;
            this.editElementButton.Click += new System.EventHandler(this.editElementButton_Click);
            // 
            // removeElementButton
            // 
            this.removeElementButton.Location = new System.Drawing.Point(192, 240);
            this.removeElementButton.Name = "removeElementButton";
            this.removeElementButton.Size = new System.Drawing.Size(75, 23);
            this.removeElementButton.TabIndex = 4;
            this.removeElementButton.Text = "Remove";
            this.removeElementButton.UseVisualStyleBackColor = true;
            this.removeElementButton.Click += new System.EventHandler(this.removeElementButton_Click);
            // 
            // circuitTypeComboBox
            // 
            this.circuitTypeComboBox.Enabled = false;
            this.circuitTypeComboBox.FormattingEnabled = true;
            this.circuitTypeComboBox.Items.AddRange(new object[] {
            "Serial Circuit"});
            this.circuitTypeComboBox.Location = new System.Drawing.Point(12, 33);
            this.circuitTypeComboBox.Name = "circuitTypeComboBox";
            this.circuitTypeComboBox.Size = new System.Drawing.Size(269, 21);
            this.circuitTypeComboBox.TabIndex = 5;
            this.circuitTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.circuitTypeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Circuit type";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(105, 19);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(141, 23);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(6, 19);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // createNewCircuitGroupBox
            // 
            this.createNewCircuitGroupBox.Controls.Add(this.cancelButton);
            this.createNewCircuitGroupBox.Controls.Add(this.createButton);
            this.createNewCircuitGroupBox.Location = new System.Drawing.Point(15, 298);
            this.createNewCircuitGroupBox.Name = "createNewCircuitGroupBox";
            this.createNewCircuitGroupBox.Size = new System.Drawing.Size(252, 52);
            this.createNewCircuitGroupBox.TabIndex = 9;
            this.createNewCircuitGroupBox.TabStop = false;
            this.createNewCircuitGroupBox.Text = "Create new circuit";
            this.createNewCircuitGroupBox.Visible = false;
            // 
            // serialCircuitControl
            // 
            this.serialCircuitControl.ElementName = "";
            this.serialCircuitControl.Location = new System.Drawing.Point(12, 60);
            this.serialCircuitControl.Name = "serialCircuitControl";
            this.serialCircuitControl.Size = new System.Drawing.Size(275, 174);
            this.serialCircuitControl.TabIndex = 0;
            // 
            // CircuitDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 362);
            this.Controls.Add(this.createNewCircuitGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circuitTypeComboBox);
            this.Controls.Add(this.removeElementButton);
            this.Controls.Add(this.editElementButton);
            this.Controls.Add(this.addSubcircuitButton);
            this.Controls.Add(this.addComponentButton);
            this.Controls.Add(this.serialCircuitControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CircuitDetailForm";
            this.Text = "CircuitDetailForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CircuitDetailForm_FormClosing);
            this.createNewCircuitGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Elements.SingleControls.Circuits.SerialCircuitControl serialCircuitControl;
        private System.Windows.Forms.Button addComponentButton;
        private System.Windows.Forms.Button addSubcircuitButton;
        private System.Windows.Forms.Button editElementButton;
        private System.Windows.Forms.Button removeElementButton;
        private System.Windows.Forms.ComboBox circuitTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox createNewCircuitGroupBox;
    }
}