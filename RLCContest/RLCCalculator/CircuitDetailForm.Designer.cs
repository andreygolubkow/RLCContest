﻿namespace RLCCalculator
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
            this.addComponentButton = new System.Windows.Forms.Button();
            this.addSubcircuitButton = new System.Windows.Forms.Button();
            this.editElementButton = new System.Windows.Forms.Button();
            this.removeElementButton = new System.Windows.Forms.Button();
            this.circuitTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.serialCircuitControl = new Controls.Elements.SingleControls.Circuits.SerialCircuitControl();
            this.parallelCircuitControl = new Controls.Elements.SingleControls.Circuits.ParallelCircuitControl();
            this.SuspendLayout();
            // 
            // addComponentButton
            // 
            this.addComponentButton.Location = new System.Drawing.Point(12, 240);
            this.addComponentButton.Name = "addComponentButton";
            this.addComponentButton.Size = new System.Drawing.Size(93, 23);
            this.addComponentButton.TabIndex = 3;
            this.addComponentButton.Text = "Add component";
            this.addComponentButton.UseVisualStyleBackColor = true;
            this.addComponentButton.Click += new System.EventHandler(this.AddComponentButtonClick);
            // 
            // addSubcircuitButton
            // 
            this.addSubcircuitButton.Location = new System.Drawing.Point(12, 269);
            this.addSubcircuitButton.Name = "addSubcircuitButton";
            this.addSubcircuitButton.Size = new System.Drawing.Size(93, 23);
            this.addSubcircuitButton.TabIndex = 6;
            this.addSubcircuitButton.Text = "Add subcircuit";
            this.addSubcircuitButton.UseVisualStyleBackColor = true;
            this.addSubcircuitButton.Click += new System.EventHandler(this.AddSubcircuitButtonClick);
            // 
            // editElementButton
            // 
            this.editElementButton.Location = new System.Drawing.Point(111, 240);
            this.editElementButton.Name = "editElementButton";
            this.editElementButton.Size = new System.Drawing.Size(75, 23);
            this.editElementButton.TabIndex = 4;
            this.editElementButton.Text = "Edit element";
            this.editElementButton.UseVisualStyleBackColor = true;
            this.editElementButton.Click += new System.EventHandler(this.EditElementButtonClick);
            // 
            // removeElementButton
            // 
            this.removeElementButton.Location = new System.Drawing.Point(192, 240);
            this.removeElementButton.Name = "removeElementButton";
            this.removeElementButton.Size = new System.Drawing.Size(75, 23);
            this.removeElementButton.TabIndex = 5;
            this.removeElementButton.Text = "Remove";
            this.removeElementButton.UseVisualStyleBackColor = true;
            this.removeElementButton.Click += new System.EventHandler(this.RemoveElementButtonClick);
            // 
            // circuitTypeComboBox
            // 
            this.circuitTypeComboBox.Enabled = false;
            this.circuitTypeComboBox.FormattingEnabled = true;
            this.circuitTypeComboBox.Items.AddRange(new object[] {
            "Serial Circuit",
            "Parallel Circuit"});
            this.circuitTypeComboBox.Location = new System.Drawing.Point(12, 33);
            this.circuitTypeComboBox.Name = "circuitTypeComboBox";
            this.circuitTypeComboBox.Size = new System.Drawing.Size(269, 21);
            this.circuitTypeComboBox.TabIndex = 1;
            this.circuitTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitTypeComboBoxSelectedIndexChanged);
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
            this.createButton.Location = new System.Drawing.Point(111, 292);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(156, 23);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Visible = false;
            this.createButton.Click += new System.EventHandler(this.CreateButtonClick);
            // 
            // serialCircuitControl
            // 
            this.serialCircuitControl.ElementName = "";
            this.serialCircuitControl.Location = new System.Drawing.Point(12, 60);
            this.serialCircuitControl.Name = "serialCircuitControl";
            this.serialCircuitControl.Size = new System.Drawing.Size(275, 174);
            this.serialCircuitControl.TabIndex = 2;
            this.serialCircuitControl.Visible = false;
            // 
            // parallelCircuitControl
            // 
            this.parallelCircuitControl.ElementName = "";
            this.parallelCircuitControl.Location = new System.Drawing.Point(293, 60);
            this.parallelCircuitControl.Name = "parallelCircuitControl";
            this.parallelCircuitControl.Size = new System.Drawing.Size(275, 174);
            this.parallelCircuitControl.TabIndex = 2;
            this.parallelCircuitControl.Visible = false;
            // 
            // CircuitDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 323);
            this.Controls.Add(this.parallelCircuitControl);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circuitTypeComboBox);
            this.Controls.Add(this.removeElementButton);
            this.Controls.Add(this.editElementButton);
            this.Controls.Add(this.addSubcircuitButton);
            this.Controls.Add(this.addComponentButton);
            this.Controls.Add(this.serialCircuitControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CircuitDetailForm";
            this.Text = "Circuit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CircuitDetailFormFormClosing);
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
        private Controls.Elements.SingleControls.Circuits.ParallelCircuitControl parallelCircuitControl;
    }
}