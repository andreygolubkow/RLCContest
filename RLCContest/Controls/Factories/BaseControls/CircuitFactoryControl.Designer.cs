using Controls.Elements.SingleControls.Circuits;

namespace Controls.Factories.BaseControls
{
    partial class CircuitFactoryControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.circuitTypeComboBox = new System.Windows.Forms.ComboBox();
            this.circuitTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.serialCircuitControl = new SerialCircuitControl();
            this.elementManager = new System.Windows.Forms.GroupBox();
            this.removeElementButton = new System.Windows.Forms.Button();
            this.editElementButton = new System.Windows.Forms.Button();
            this.addElementButton = new System.Windows.Forms.Button();
            this.calculateGroupBox.SuspendLayout();
            this.circuitTypeGroupBox.SuspendLayout();
            this.elementManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculateZButton
            // 
            this.calculateZButton.Click += new System.EventHandler(this.CalculateZButtonClick);
            // 
            // manageGroupBox
            // 
            this.manageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.manageGroupBox.Location = new System.Drawing.Point(7, 294);
            this.manageGroupBox.Text = "Circuit";
            // 
            // calculateGroupBox
            // 
            this.calculateGroupBox.Location = new System.Drawing.Point(7, 351);
            // 
            // circuitTypeComboBox
            // 
            this.circuitTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circuitTypeComboBox.FormattingEnabled = true;
            this.circuitTypeComboBox.Items.AddRange(new object[] {
            "Serial"});
            this.circuitTypeComboBox.Location = new System.Drawing.Point(6, 19);
            this.circuitTypeComboBox.Name = "circuitTypeComboBox";
            this.circuitTypeComboBox.Size = new System.Drawing.Size(333, 21);
            this.circuitTypeComboBox.TabIndex = 3;
            this.circuitTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitTypeComboBoxSelectedIndexChanged);
            // 
            // circuitTypeGroupBox
            // 
            this.circuitTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circuitTypeGroupBox.Controls.Add(this.circuitTypeComboBox);
            this.circuitTypeGroupBox.Location = new System.Drawing.Point(7, 3);
            this.circuitTypeGroupBox.Name = "circuitTypeGroupBox";
            this.circuitTypeGroupBox.Size = new System.Drawing.Size(345, 49);
            this.circuitTypeGroupBox.TabIndex = 4;
            this.circuitTypeGroupBox.TabStop = false;
            this.circuitTypeGroupBox.Text = "Circuit Type";
            // 
            // serialCircuitControl
            // 
            this.serialCircuitControl.ElementName = "";
            this.serialCircuitControl.Location = new System.Drawing.Point(7, 58);
            this.serialCircuitControl.Name = "serialCircuitControl";
            this.serialCircuitControl.Size = new System.Drawing.Size(275, 174);
            this.serialCircuitControl.TabIndex = 5;
            // 
            // elementManager
            // 
            this.elementManager.Controls.Add(this.removeElementButton);
            this.elementManager.Controls.Add(this.editElementButton);
            this.elementManager.Controls.Add(this.addElementButton);
            this.elementManager.Location = new System.Drawing.Point(7, 238);
            this.elementManager.Name = "elementManager";
            this.elementManager.Size = new System.Drawing.Size(284, 50);
            this.elementManager.TabIndex = 6;
            this.elementManager.TabStop = false;
            this.elementManager.Text = "Components";
            // 
            // removeElementButton
            // 
            this.removeElementButton.Location = new System.Drawing.Point(207, 19);
            this.removeElementButton.Name = "removeElementButton";
            this.removeElementButton.Size = new System.Drawing.Size(74, 23);
            this.removeElementButton.TabIndex = 2;
            this.removeElementButton.Text = "Remove element";
            this.removeElementButton.UseVisualStyleBackColor = true;
            this.removeElementButton.Click += new System.EventHandler(this.RemoveElementButtonClick);
            // 
            // editElementButton
            // 
            this.editElementButton.Location = new System.Drawing.Point(108, 19);
            this.editElementButton.Name = "editElementButton";
            this.editElementButton.Size = new System.Drawing.Size(93, 23);
            this.editElementButton.TabIndex = 1;
            this.editElementButton.Text = "Edit component";
            this.editElementButton.UseVisualStyleBackColor = true;
            this.editElementButton.Click += new System.EventHandler(this.editElementButton_Click);
            // 
            // addElementButton
            // 
            this.addElementButton.Location = new System.Drawing.Point(8, 19);
            this.addElementButton.Name = "addElementButton";
            this.addElementButton.Size = new System.Drawing.Size(94, 23);
            this.addElementButton.TabIndex = 0;
            this.addElementButton.Text = "Add component";
            this.addElementButton.UseVisualStyleBackColor = true;
            this.addElementButton.Click += new System.EventHandler(this.addElementButton_Click);
            // 
            // CircuitFactoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementManager);
            this.Controls.Add(this.serialCircuitControl);
            this.Controls.Add(this.circuitTypeGroupBox);
            this.Name = "CircuitFactoryControl";
            this.Size = new System.Drawing.Size(355, 423);
            this.ClearButtonClick += new System.EventHandler(this.CircuitFactoryControlClearButtonClick);
            this.Controls.SetChildIndex(this.manageGroupBox, 0);
            this.Controls.SetChildIndex(this.calculateGroupBox, 0);
            this.Controls.SetChildIndex(this.circuitTypeGroupBox, 0);
            this.Controls.SetChildIndex(this.serialCircuitControl, 0);
            this.Controls.SetChildIndex(this.elementManager, 0);
            this.calculateGroupBox.ResumeLayout(false);
            this.calculateGroupBox.PerformLayout();
            this.circuitTypeGroupBox.ResumeLayout(false);
            this.elementManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox circuitTypeComboBox;
        private System.Windows.Forms.GroupBox circuitTypeGroupBox;
        private SerialCircuitControl serialCircuitControl;
        private System.Windows.Forms.GroupBox elementManager;
        private System.Windows.Forms.Button removeElementButton;
        private System.Windows.Forms.Button editElementButton;
        private System.Windows.Forms.Button addElementButton;
    }
}
