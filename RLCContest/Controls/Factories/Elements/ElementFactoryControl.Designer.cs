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
            this.containerControl.SuspendLayout();
            this.elementTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // zValue
            // 
            this.zValue.Location = new System.Drawing.Point(491, 27);
            // 
            // calculateZButton
            // 
            this.calculateZButton.Location = new System.Drawing.Point(387, 22);
            // 
            // frequencyValueTextBox
            // 
            this.frequencyValueTextBox.Location = new System.Drawing.Point(285, 24);
            // 
            // containerControl
            // 
            this.containerControl.Controls.Add(this.resistorElementControl);
            this.containerControl.Controls.Add(this.inductorElementControl);
            this.containerControl.Controls.Add(this.capacitorElementControl);
            this.containerControl.Controls.Add(this.elementTypeGroupBox);
            this.containerControl.Size = new System.Drawing.Size(775, 149);
            // 
            // elementTypeGroupBox
            // 
            this.elementTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementTypeGroupBox.Controls.Add(this.elementTypeComboBox);
            this.elementTypeGroupBox.Location = new System.Drawing.Point(6, 19);
            this.elementTypeGroupBox.Name = "elementTypeGroupBox";
            this.elementTypeGroupBox.Size = new System.Drawing.Size(763, 48);
            this.elementTypeGroupBox.TabIndex = 0;
            this.elementTypeGroupBox.TabStop = false;
            this.elementTypeGroupBox.Text = "Element Type";
            // 
            // elementTypeComboBox
            // 
            this.elementTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementTypeComboBox.FormattingEnabled = true;
            this.elementTypeComboBox.Location = new System.Drawing.Point(6, 19);
            this.elementTypeComboBox.Name = "elementTypeComboBox";
            this.elementTypeComboBox.Size = new System.Drawing.Size(751, 21);
            this.elementTypeComboBox.TabIndex = 0;
            // 
            // capacitorElementControl
            // 
            this.capacitorElementControl.Location = new System.Drawing.Point(6, 73);
            this.capacitorElementControl.Name = "capacitorElementControl";
            this.capacitorElementControl.Size = new System.Drawing.Size(251, 70);
            this.capacitorElementControl.TabIndex = 1;
            // 
            // inductorElementControl
            // 
            this.inductorElementControl.Location = new System.Drawing.Point(263, 73);
            this.inductorElementControl.Name = "inductorElementControl";
            this.inductorElementControl.Size = new System.Drawing.Size(251, 70);
            this.inductorElementControl.TabIndex = 2;
            // 
            // resistorElementControl
            // 
            this.resistorElementControl.Location = new System.Drawing.Point(520, 73);
            this.resistorElementControl.Name = "resistorElementControl";
            this.resistorElementControl.Size = new System.Drawing.Size(251, 70);
            this.resistorElementControl.TabIndex = 3;
            // 
            // ElementFactoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ElementFactoryControl";
            this.Size = new System.Drawing.Size(781, 290);
            this.containerControl.ResumeLayout(false);
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
