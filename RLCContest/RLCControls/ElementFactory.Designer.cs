namespace RLCControls
{
    partial class ElementFactory
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
            this.elementsComboBox = new System.Windows.Forms.ComboBox();
            this.elementName = new System.Windows.Forms.TextBox();
            this.elementValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // elementsComboBox
            // 
            this.elementsComboBox.FormattingEnabled = true;
            this.elementsComboBox.Items.AddRange(new object[] {
            "Резистор",
            "Катушка",
            "Конденсатор"});
            this.elementsComboBox.Location = new System.Drawing.Point(3, 13);
            this.elementsComboBox.Name = "elementsComboBox";
            this.elementsComboBox.Size = new System.Drawing.Size(186, 21);
            this.elementsComboBox.TabIndex = 0;
            // 
            // elementName
            // 
            this.elementName.Location = new System.Drawing.Point(3, 58);
            this.elementName.Name = "elementName";
            this.elementName.Size = new System.Drawing.Size(186, 20);
            this.elementName.TabIndex = 1;
            // 
            // elementValue
            // 
            this.elementValue.Location = new System.Drawing.Point(3, 97);
            this.elementValue.Name = "elementValue";
            this.elementValue.Size = new System.Drawing.Size(186, 20);
            this.elementValue.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номинал";
            // 
            // ElementFactory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elementValue);
            this.Controls.Add(this.elementName);
            this.Controls.Add(this.elementsComboBox);
            this.Name = "ElementFactory";
            this.Size = new System.Drawing.Size(197, 124);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox elementsComboBox;
        private System.Windows.Forms.TextBox elementName;
        private System.Windows.Forms.TextBox elementValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
