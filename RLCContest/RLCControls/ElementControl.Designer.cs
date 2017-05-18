namespace RLCControls
{
    partial class ElementControl
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
            this.resistorName = new System.Windows.Forms.Label();
            this.resistorValue = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // resistorName
            // 
            this.resistorName.AutoSize = true;
            this.resistorName.Location = new System.Drawing.Point(28, 33);
            this.resistorName.Name = "resistorName";
            this.resistorName.Size = new System.Drawing.Size(35, 13);
            this.resistorName.TabIndex = 1;
            this.resistorName.Text = "Name";
            // 
            // resistorValue
            // 
            this.resistorValue.AutoSize = true;
            this.resistorValue.Location = new System.Drawing.Point(28, 46);
            this.resistorValue.Name = "resistorValue";
            this.resistorValue.Size = new System.Drawing.Size(32, 13);
            this.resistorValue.TabIndex = 2;
            this.resistorValue.Text = "1 Ом";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RLCControls.Properties.Resources.Resistor;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ResistorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resistorValue);
            this.Controls.Add(this.resistorName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ResistorControl";
            this.Size = new System.Drawing.Size(86, 64);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label resistorName;
        private System.Windows.Forms.Label resistorValue;
    }
}
