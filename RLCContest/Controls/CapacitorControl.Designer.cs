namespace Controls
{
    partial class CapacitorControl
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
            this.capacitorGroubBox = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.calculateZButton = new System.Windows.Forms.Button();
            this.zLabel = new System.Windows.Forms.Label();
            this.zValueLabel = new System.Windows.Forms.Label();
            this.capacitorGroubBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // capacitorGroubBox
            // 
            this.capacitorGroubBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.capacitorGroubBox.Controls.Add(this.zValueLabel);
            this.capacitorGroubBox.Controls.Add(this.zLabel);
            this.capacitorGroubBox.Controls.Add(this.calculateZButton);
            this.capacitorGroubBox.Controls.Add(this.valueLabel);
            this.capacitorGroubBox.Controls.Add(this.nameLabel);
            this.capacitorGroubBox.Controls.Add(this.valueTextBox);
            this.capacitorGroubBox.Controls.Add(this.nameTextBox);
            this.capacitorGroubBox.Location = new System.Drawing.Point(3, 0);
            this.capacitorGroubBox.Name = "capacitorGroubBox";
            this.capacitorGroubBox.Size = new System.Drawing.Size(229, 92);
            this.capacitorGroubBox.TabIndex = 0;
            this.capacitorGroubBox.TabStop = false;
            this.capacitorGroubBox.Text = "Capacitor";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(47, 13);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(175, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTextBox.Location = new System.Drawing.Point(47, 39);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(98, 20);
            this.valueTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 16);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // valueLabel
            // 
            this.valueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(6, 42);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(34, 13);
            this.valueLabel.TabIndex = 3;
            this.valueLabel.Text = "Value";
            // 
            // calculateZButton
            // 
            this.calculateZButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.calculateZButton.Location = new System.Drawing.Point(148, 62);
            this.calculateZButton.Name = "calculateZButton";
            this.calculateZButton.Size = new System.Drawing.Size(75, 23);
            this.calculateZButton.TabIndex = 4;
            this.calculateZButton.Text = "Calculate";
            this.calculateZButton.UseVisualStyleBackColor = true;
            // 
            // zLabel
            // 
            this.zLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(6, 67);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(14, 13);
            this.zLabel.TabIndex = 5;
            this.zLabel.Text = "Z";
            // 
            // zValueLabel
            // 
            this.zValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zValueLabel.AutoSize = true;
            this.zValueLabel.Location = new System.Drawing.Point(44, 67);
            this.zValueLabel.Name = "zValueLabel";
            this.zValueLabel.Size = new System.Drawing.Size(58, 13);
            this.zValueLabel.TabIndex = 6;
            this.zValueLabel.Text = "0 [Z value]";
            // 
            // CapacitorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.capacitorGroubBox);
            this.Name = "CapacitorControl";
            this.Size = new System.Drawing.Size(238, 96);
            this.capacitorGroubBox.ResumeLayout(false);
            this.capacitorGroubBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox capacitorGroubBox;
        private System.Windows.Forms.Label zValueLabel;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.Button calculateZButton;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}
