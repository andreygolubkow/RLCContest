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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.circuitTypeComboBox = new System.Windows.Forms.GroupBox();
            this.calculateGroupBox.SuspendLayout();
            this.circuitTypeComboBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // manageGroupBox
            // 
            this.manageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.manageGroupBox.Location = new System.Drawing.Point(0, 157);
            // 
            // calculateGroupBox
            // 
            this.calculateGroupBox.Location = new System.Drawing.Point(0, 214);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(540, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // circuitTypeComboBox
            // 
            this.circuitTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circuitTypeComboBox.Controls.Add(this.comboBox1);
            this.circuitTypeComboBox.Location = new System.Drawing.Point(7, 3);
            this.circuitTypeComboBox.Name = "circuitTypeComboBox";
            this.circuitTypeComboBox.Size = new System.Drawing.Size(552, 49);
            this.circuitTypeComboBox.TabIndex = 4;
            this.circuitTypeComboBox.TabStop = false;
            this.circuitTypeComboBox.Text = "Circuit Type";
            // 
            // CircuitFactoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.circuitTypeComboBox);
            this.Name = "CircuitFactoryControl";
            this.Size = new System.Drawing.Size(562, 279);
            this.Controls.SetChildIndex(this.manageGroupBox, 0);
            this.Controls.SetChildIndex(this.calculateGroupBox, 0);
            this.Controls.SetChildIndex(this.circuitTypeComboBox, 0);
            this.calculateGroupBox.ResumeLayout(false);
            this.calculateGroupBox.PerformLayout();
            this.circuitTypeComboBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox circuitTypeComboBox;
    }
}
