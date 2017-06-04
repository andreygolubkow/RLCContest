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
            this.SuspendLayout();
            // 
            // containerControl
            // 
            this.containerControl.Size = new System.Drawing.Size(520, 266);
            // 
            // zValue
            // 
            this.zValue.Location = new System.Drawing.Point(364, 27);
            // 
            // calculateZButton
            // 
            this.calculateZButton.Location = new System.Drawing.Point(260, 22);
            // 
            // frequencyValueTextBox
            // 
            this.frequencyValueTextBox.Location = new System.Drawing.Point(158, 24);
            // 
            // ElementFactoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ElementFactoryControl";
            this.Size = new System.Drawing.Size(526, 397);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
