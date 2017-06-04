﻿namespace Controls.Factories.BaseControls
{
    partial class BaseFactoryControl
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
            this.containerControl = new System.Windows.Forms.GroupBox();
            this.manageGroupBox = new System.Windows.Forms.GroupBox();
            this.createNewButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.calculateGroupBox = new System.Windows.Forms.GroupBox();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.frequencyValueTextBox = new System.Windows.Forms.TextBox();
            this.calculateZButton = new System.Windows.Forms.Button();
            this.zLabel = new System.Windows.Forms.Label();
            this.zValue = new System.Windows.Forms.Label();
            this.manageGroupBox.SuspendLayout();
            this.calculateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // containerControl
            // 
            this.containerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerControl.Location = new System.Drawing.Point(3, 3);
            this.containerControl.Name = "containerControl";
            this.containerControl.Size = new System.Drawing.Size(330, 261);
            this.containerControl.TabIndex = 0;
            this.containerControl.TabStop = false;
            this.containerControl.Text = "Factory";
            // 
            // manageGroupBox
            // 
            this.manageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manageGroupBox.Controls.Add(this.clearButton);
            this.manageGroupBox.Controls.Add(this.removeButton);
            this.manageGroupBox.Controls.Add(this.modifyButton);
            this.manageGroupBox.Controls.Add(this.createNewButton);
            this.manageGroupBox.Location = new System.Drawing.Point(3, 270);
            this.manageGroupBox.Name = "manageGroupBox";
            this.manageGroupBox.Size = new System.Drawing.Size(330, 51);
            this.manageGroupBox.TabIndex = 1;
            this.manageGroupBox.TabStop = false;
            this.manageGroupBox.Text = "Manage";
            // 
            // createNewButton
            // 
            this.createNewButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createNewButton.Location = new System.Drawing.Point(5, 19);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(75, 23);
            this.createNewButton.TabIndex = 0;
            this.createNewButton.Text = "Create new";
            this.createNewButton.UseVisualStyleBackColor = true;
            this.createNewButton.Click += new System.EventHandler(this.createNewButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modifyButton.Location = new System.Drawing.Point(86, 19);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 1;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.removeButton.Location = new System.Drawing.Point(167, 19);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = " Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clearButton.Location = new System.Drawing.Point(250, 19);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // calculateGroupBox
            // 
            this.calculateGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calculateGroupBox.Controls.Add(this.zValue);
            this.calculateGroupBox.Controls.Add(this.zLabel);
            this.calculateGroupBox.Controls.Add(this.calculateZButton);
            this.calculateGroupBox.Controls.Add(this.frequencyValueTextBox);
            this.calculateGroupBox.Controls.Add(this.frequencyLabel);
            this.calculateGroupBox.Location = new System.Drawing.Point(3, 327);
            this.calculateGroupBox.Name = "calculateGroupBox";
            this.calculateGroupBox.Size = new System.Drawing.Size(330, 62);
            this.calculateGroupBox.TabIndex = 2;
            this.calculateGroupBox.TabStop = false;
            this.calculateGroupBox.Text = "Calculate";
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(3, 27);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(57, 13);
            this.frequencyLabel.TabIndex = 0;
            this.frequencyLabel.Text = "Frequency";
            // 
            // frequencyValueTextBox
            // 
            this.frequencyValueTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.frequencyValueTextBox.Location = new System.Drawing.Point(63, 24);
            this.frequencyValueTextBox.Name = "frequencyValueTextBox";
            this.frequencyValueTextBox.Size = new System.Drawing.Size(96, 20);
            this.frequencyValueTextBox.TabIndex = 1;
            // 
            // calculateZButton
            // 
            this.calculateZButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calculateZButton.Location = new System.Drawing.Point(165, 22);
            this.calculateZButton.Name = "calculateZButton";
            this.calculateZButton.Size = new System.Drawing.Size(75, 23);
            this.calculateZButton.TabIndex = 2;
            this.calculateZButton.Text = "Calculate Z";
            this.calculateZButton.UseVisualStyleBackColor = true;
            this.calculateZButton.Click += new System.EventHandler(this.calculateZButton_Click);
            // 
            // zLabel
            // 
            this.zLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(246, 27);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(17, 13);
            this.zLabel.TabIndex = 3;
            this.zLabel.Text = "Z:";
            // 
            // zValue
            // 
            this.zValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.zValue.AutoSize = true;
            this.zValue.Location = new System.Drawing.Point(269, 27);
            this.zValue.Name = "zValue";
            this.zValue.Size = new System.Drawing.Size(13, 13);
            this.zValue.TabIndex = 4;
            this.zValue.Text = "0";
            // 
            // BaseFactoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calculateGroupBox);
            this.Controls.Add(this.manageGroupBox);
            this.Controls.Add(this.containerControl);
            this.Name = "BaseFactoryControl";
            this.Size = new System.Drawing.Size(336, 392);
            this.manageGroupBox.ResumeLayout(false);
            this.calculateGroupBox.ResumeLayout(false);
            this.calculateGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox containerControl;
        private System.Windows.Forms.GroupBox manageGroupBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button createNewButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox calculateGroupBox;
        protected System.Windows.Forms.Label zValue;
        private System.Windows.Forms.Label zLabel;
        protected System.Windows.Forms.Button calculateZButton;
        protected System.Windows.Forms.TextBox frequencyValueTextBox;
        private System.Windows.Forms.Label frequencyLabel;
    }
}
