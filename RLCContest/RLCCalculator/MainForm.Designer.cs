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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.circuitsGroupBox = new System.Windows.Forms.GroupBox();
            this.circuitsListBox = new System.Windows.Forms.ListBox();
            this.iComponentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCircuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCircuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.circuitDesignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequenciesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuitEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.circuitsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iComponentBindingSource)).BeginInit();
            this.mainMenu.SuspendLayout();
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
            this.circuitsGroupBox.Size = new System.Drawing.Size(342, 345);
            this.circuitsGroupBox.TabIndex = 0;
            this.circuitsGroupBox.TabStop = false;
            this.circuitsGroupBox.Text = "Circuits List";
            // 
            // circuitsListBox
            // 
            this.circuitsListBox.DataSource = this.iComponentBindingSource;
            this.circuitsListBox.DisplayMember = "Name";
            this.circuitsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circuitsListBox.FormattingEnabled = true;
            this.circuitsListBox.Location = new System.Drawing.Point(3, 16);
            this.circuitsListBox.Name = "circuitsListBox";
            this.circuitsListBox.Size = new System.Drawing.Size(336, 326);
            this.circuitsListBox.TabIndex = 0;
            // 
            // iComponentBindingSource
            // 
            this.iComponentBindingSource.DataSource = typeof(Core.IComponent);
            this.iComponentBindingSource.CurrentChanged += new System.EventHandler(this.IComponentBindingSourceCurrentChanged);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.circuitToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.refreshListToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(366, 24);
            this.mainMenu.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.toolStripSeparator1,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.N)));
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.newProjectToolStripMenuItem.Text = "New project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.NewProjectToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.openProjectToolStripMenuItem.Text = "Open project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.OpenProjectToolStripMenuItemClick);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveProjectToolStripMenuItem.Text = "Save project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItemClick);
            // 
            // circuitToolStripMenuItem
            // 
            this.circuitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCircuitToolStripMenuItem,
            this.removeCircuitToolStripMenuItem,
            this.toolStripSeparator2,
            this.circuitDesignerToolStripMenuItem});
            this.circuitToolStripMenuItem.Name = "circuitToolStripMenuItem";
            this.circuitToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.circuitToolStripMenuItem.Text = "Circuit";
            // 
            // newCircuitToolStripMenuItem
            // 
            this.newCircuitToolStripMenuItem.Name = "newCircuitToolStripMenuItem";
            this.newCircuitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newCircuitToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.newCircuitToolStripMenuItem.Text = "New circuit";
            this.newCircuitToolStripMenuItem.Click += new System.EventHandler(this.NewCircuitToolStripMenuItemClick1);
            // 
            // removeCircuitToolStripMenuItem
            // 
            this.removeCircuitToolStripMenuItem.Name = "removeCircuitToolStripMenuItem";
            this.removeCircuitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.X)));
            this.removeCircuitToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.removeCircuitToolStripMenuItem.Text = "Remove circuit";
            this.removeCircuitToolStripMenuItem.Click += new System.EventHandler(this.RemoveCircuitToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(214, 6);
            // 
            // circuitDesignerToolStripMenuItem
            // 
            this.circuitDesignerToolStripMenuItem.Name = "circuitDesignerToolStripMenuItem";
            this.circuitDesignerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.circuitDesignerToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.circuitDesignerToolStripMenuItem.Text = "Circuit Designer";
            this.circuitDesignerToolStripMenuItem.Click += new System.EventHandler(this.CircuitDesignerToolStripMenuItemClick);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frequenciesMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // frequenciesMenuItem
            // 
            this.frequenciesMenuItem.Name = "frequenciesMenuItem";
            this.frequenciesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.frequenciesMenuItem.Size = new System.Drawing.Size(177, 22);
            this.frequenciesMenuItem.Text = "Frequencies";
            this.frequenciesMenuItem.Click += new System.EventHandler(this.FrequenciesMenuItemClick);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zCalculatorToolStripMenuItem,
            this.circuitEditorToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // zCalculatorToolStripMenuItem
            // 
            this.zCalculatorToolStripMenuItem.Name = "zCalculatorToolStripMenuItem";
            this.zCalculatorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.zCalculatorToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.zCalculatorToolStripMenuItem.Text = "Z Calculator";
            this.zCalculatorToolStripMenuItem.Click += new System.EventHandler(this.ZCalculatorToolStripMenuItemClick);
            // 
            // circuitEditorToolStripMenuItem
            // 
            this.circuitEditorToolStripMenuItem.Name = "circuitEditorToolStripMenuItem";
            this.circuitEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.circuitEditorToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.circuitEditorToolStripMenuItem.Text = "Circuit Editor";
            this.circuitEditorToolStripMenuItem.Click += new System.EventHandler(this.CircuitEditorToolStripMenuItemClick);
            // 
            // refreshListToolStripMenuItem
            // 
            this.refreshListToolStripMenuItem.Name = "refreshListToolStripMenuItem";
            this.refreshListToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshListToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.refreshListToolStripMenuItem.Text = "Refresh List";
            this.refreshListToolStripMenuItem.Click += new System.EventHandler(this.RefreshListToolStripMenuItemClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "cr";
            this.openFileDialog.Filter = "Circuit library|*.cr";
            this.openFileDialog.Title = "Open circuit project";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "cr";
            this.saveFileDialog.Filter = "Circuit library|*.cr";
            this.saveFileDialog.Title = "Save circuit project";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 414);
            this.Controls.Add(this.circuitsGroupBox);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Circuit Viewer ";
            this.circuitsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iComponentBindingSource)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox circuitsGroupBox;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ListBox circuitsListBox;
        private System.Windows.Forms.BindingSource iComponentBindingSource;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequenciesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circuitEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem circuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCircuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCircuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem circuitDesignerToolStripMenuItem;
    }
}

