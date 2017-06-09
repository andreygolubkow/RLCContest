namespace RLCCalculator
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.circuitsGroupBox = new System.Windows.Forms.GroupBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.iComponentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.circuitsListBox = new System.Windows.Forms.ListBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testCircuitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuitsGroupBox.SuspendLayout();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iComponentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // circuitsGroupBox
            // 
            this.circuitsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circuitsGroupBox.Controls.Add(this.circuitsListBox);
            this.circuitsGroupBox.Location = new System.Drawing.Point(12, 39);
            this.circuitsGroupBox.Name = "circuitsGroupBox";
            this.circuitsGroupBox.Size = new System.Drawing.Size(240, 359);
            this.circuitsGroupBox.TabIndex = 0;
            this.circuitsGroupBox.TabStop = false;
            this.circuitsGroupBox.Text = "Circuits List";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testCircuitsToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(264, 24);
            this.mainMenu.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 406);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(264, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // iComponentBindingSource
            // 
            this.iComponentBindingSource.DataSource = typeof(Core.IComponent);
            // 
            // circuitsListBox
            // 
            this.circuitsListBox.DataSource = this.iComponentBindingSource;
            this.circuitsListBox.DisplayMember = "Name";
            this.circuitsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circuitsListBox.FormattingEnabled = true;
            this.circuitsListBox.Location = new System.Drawing.Point(3, 16);
            this.circuitsListBox.Name = "circuitsListBox";
            this.circuitsListBox.Size = new System.Drawing.Size(234, 340);
            this.circuitsListBox.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // testCircuitsToolStripMenuItem
            // 
            this.testCircuitsToolStripMenuItem.Name = "testCircuitsToolStripMenuItem";
            this.testCircuitsToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.testCircuitsToolStripMenuItem.Text = "Test Circuits";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 428);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.circuitsGroupBox);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Circuit Viewer ";
            this.circuitsGroupBox.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iComponentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox circuitsGroupBox;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ListBox circuitsListBox;
        private System.Windows.Forms.BindingSource iComponentBindingSource;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testCircuitsToolStripMenuItem;
    }
}

