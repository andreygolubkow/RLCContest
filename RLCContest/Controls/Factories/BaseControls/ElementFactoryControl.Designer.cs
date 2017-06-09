namespace Controls.Factories.Elements
{
    partial class ElementFactoryControl
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
            this.elementTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.elementTypeComboBox = new System.Windows.Forms.ComboBox();
            this.capacitorElementControl = new Controls.SingleControls.Elements.CapacitorElementControl();
            this.inductorElementControl = new Controls.SingleControls.Elements.InductorElementControl();
            this.resistorElementControl = new Controls.SingleControls.Elements.ResistorElementControl();
            this.calculateGroupBox.SuspendLayout();
            this.elementTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculateZButton
            // 
            this.calculateZButton.Click += new System.EventHandler(this.CalculateZButtonClick);
            // 
            // manageGroupBox
            // 
            this.manageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.manageGroupBox.Location = new System.Drawing.Point(3, 141);
            this.manageGroupBox.Size = new System.Drawing.Size(341, 51);
            // 
            // calculateGroupBox
            // 
            this.calculateGroupBox.Location = new System.Drawing.Point(3, 198);
            this.calculateGroupBox.Size = new System.Drawing.Size(341, 62);
            // 
            // elementTypeGroupBox
            // 
            this.elementTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementTypeGroupBox.Controls.Add(this.elementTypeComboBox);
            this.elementTypeGroupBox.Location = new System.Drawing.Point(3, 11);
            this.elementTypeGroupBox.Name = "elementTypeGroupBox";
            this.elementTypeGroupBox.Size = new System.Drawing.Size(752, 48);
            this.elementTypeGroupBox.TabIndex = 0;
            this.elementTypeGroupBox.TabStop = false;
            this.elementTypeGroupBox.Text = "Element Type";
            // 
            // elementTypeComboBox
            // 
            this.elementTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementTypeComboBox.FormattingEnabled = true;
            this.elementTypeComboBox.Items.AddRange(new object[] {
            "Capacitor",
            "Inductor",
            "Resistor"});
            this.elementTypeComboBox.Location = new System.Drawing.Point(6, 19);
            this.elementTypeComboBox.Name = "elementTypeComboBox";
            this.elementTypeComboBox.Size = new System.Drawing.Size(740, 21);
            this.elementTypeComboBox.TabIndex = 0;
            this.elementTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ElementTypeComboBoxSelectedIndexChanged);
            // 
            // capacitorElementControl
            // 
            this.capacitorElementControl.Location = new System.Drawing.Point(0, 65);
            this.capacitorElementControl.Name = "capacitorElementControl";
            this.capacitorElementControl.Size = new System.Drawing.Size(251, 70);
            this.capacitorElementControl.TabIndex = 1;
            // 
            // inductorElementControl
            // 
            this.inductorElementControl.Location = new System.Drawing.Point(254, 65);
            this.inductorElementControl.Name = "inductorElementControl";
            this.inductorElementControl.Size = new System.Drawing.Size(251, 70);
            this.inductorElementControl.TabIndex = 2;
            // 
            // resistorElementControl
            // 
            this.resistorElementControl.Location = new System.Drawing.Point(505, 65);
            this.resistorElementControl.Name = "resistorElementControl";
            this.resistorElementControl.Size = new System.Drawing.Size(251, 70);
            this.resistorElementControl.TabIndex = 3;
            // 
            // ElementFactoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.resistorElementControl);
            this.Controls.Add(this.inductorElementControl);
            this.Controls.Add(this.capacitorElementControl);
            this.Controls.Add(this.elementTypeGroupBox);
            this.Name = "ElementFactoryControl";
            this.Size = new System.Drawing.Size(758, 269);
            this.ClearButtonClick += new System.EventHandler(this.ElementFactoryControlClearButtonClick);
            this.Controls.SetChildIndex(this.elementTypeGroupBox, 0);
            this.Controls.SetChildIndex(this.capacitorElementControl, 0);
            this.Controls.SetChildIndex(this.inductorElementControl, 0);
            this.Controls.SetChildIndex(this.resistorElementControl, 0);
            this.Controls.SetChildIndex(this.manageGroupBox, 0);
            this.Controls.SetChildIndex(this.calculateGroupBox, 0);
            this.calculateGroupBox.ResumeLayout(false);
            this.calculateGroupBox.PerformLayout();
            this.elementTypeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SingleControls.Elements.ResistorElementControl resistorElementControl;
        private SingleControls.Elements.InductorElementControl inductorElementControl;
        private SingleControls.Elements.CapacitorElementControl capacitorElementControl;
        private System.Windows.Forms.GroupBox elementTypeGroupBox;
        private System.Windows.Forms.ComboBox elementTypeComboBox;
    }
}
