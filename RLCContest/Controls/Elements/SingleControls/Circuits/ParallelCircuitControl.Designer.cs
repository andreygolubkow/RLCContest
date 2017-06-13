namespace Controls.Elements.SingleControls.Circuits
{
    partial class ParallelCircuitControl
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
            // circuitGroupBox
            // 
            this.circuitGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.circuitGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circuitGroupBox.Location = new System.Drawing.Point(0, 0);
            this.circuitGroupBox.Size = new System.Drawing.Size(271, 164);
            this.circuitGroupBox.Text = "Parallel Circuit";
            // 
            // ParallelCircuitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ParallelCircuitControl";
            this.Size = new System.Drawing.Size(271, 164);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
