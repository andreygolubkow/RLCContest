namespace RLCCalculator
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OpenFreqListForTestButton = new System.Windows.Forms.Button();
            this.openWithTestListButton = new System.Windows.Forms.Button();
            this.openFreqList = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OpenFreqListForTestButton);
            this.groupBox1.Controls.Add(this.openWithTestListButton);
            this.groupBox1.Controls.Add(this.openFreqList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frequencies Editor";
            // 
            // OpenFreqListForTestButton
            // 
            this.OpenFreqListForTestButton.Location = new System.Drawing.Point(6, 48);
            this.OpenFreqListForTestButton.Name = "OpenFreqListForTestButton";
            this.OpenFreqListForTestButton.Size = new System.Drawing.Size(203, 23);
            this.OpenFreqListForTestButton.TabIndex = 2;
            this.OpenFreqListForTestButton.Text = "Open for test list";
            this.OpenFreqListForTestButton.UseVisualStyleBackColor = true;
            this.OpenFreqListForTestButton.Click += new System.EventHandler(this.OpenFreqListForTestButton_Click);
            // 
            // openWithTestListButton
            // 
            this.openWithTestListButton.Location = new System.Drawing.Point(106, 19);
            this.openWithTestListButton.Name = "openWithTestListButton";
            this.openWithTestListButton.Size = new System.Drawing.Size(103, 23);
            this.openWithTestListButton.TabIndex = 1;
            this.openWithTestListButton.Text = "Open with test list";
            this.openWithTestListButton.UseVisualStyleBackColor = true;
            this.openWithTestListButton.Click += new System.EventHandler(this.openWithTestListButton_Click);
            // 
            // openFreqList
            // 
            this.openFreqList.Location = new System.Drawing.Point(6, 19);
            this.openFreqList.Name = "openFreqList";
            this.openFreqList.Size = new System.Drawing.Size(94, 23);
            this.openFreqList.TabIndex = 0;
            this.openFreqList.Text = "Open empty list";
            this.openFreqList.UseVisualStyleBackColor = true;
            this.openFreqList.Click += new System.EventHandler(this.openFreqListEditor_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 379);
            this.Controls.Add(this.groupBox1);
            this.Name = "TestForm";
            this.Text = "DEBUG Form";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button openFreqList;
        private System.Windows.Forms.Button OpenFreqListForTestButton;
        private System.Windows.Forms.Button openWithTestListButton;
    }
}