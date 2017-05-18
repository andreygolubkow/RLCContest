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
            this.elementName = new System.Windows.Forms.Label();
            this.elementValue = new System.Windows.Forms.Label();
            this.elementPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.elementPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // elementName
            // 
            this.elementName.AutoSize = true;
            this.elementName.Location = new System.Drawing.Point(28, 33);
            this.elementName.Name = "elementName";
            this.elementName.Size = new System.Drawing.Size(35, 13);
            this.elementName.TabIndex = 1;
            this.elementName.Text = "Name";
            // 
            // elementValue
            // 
            this.elementValue.AutoSize = true;
            this.elementValue.Location = new System.Drawing.Point(28, 46);
            this.elementValue.Name = "elementValue";
            this.elementValue.Size = new System.Drawing.Size(32, 13);
            this.elementValue.TabIndex = 2;
            this.elementValue.Text = "1 Ом";
            // 
            // elementPicture
            // 
            this.elementPicture.Image = global::RLCControls.Properties.Resources.Resistor;
            this.elementPicture.Location = new System.Drawing.Point(3, 3);
            this.elementPicture.Name = "elementPicture";
            this.elementPicture.Size = new System.Drawing.Size(80, 27);
            this.elementPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.elementPicture.TabIndex = 0;
            this.elementPicture.TabStop = false;
            // 
            // ElementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementValue);
            this.Controls.Add(this.elementName);
            this.Controls.Add(this.elementPicture);
            this.Name = "ElementControl";
            this.Size = new System.Drawing.Size(86, 64);
            ((System.ComponentModel.ISupportInitialize)(this.elementPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox elementPicture;
        private System.Windows.Forms.Label elementName;
        private System.Windows.Forms.Label elementValue;
    }
}
