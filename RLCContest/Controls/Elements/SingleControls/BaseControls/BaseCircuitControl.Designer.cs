namespace Controls.Elements.SingleControls.BaseControls
{
    partial class BaseCircuitControl
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
            this.components = new System.ComponentModel.Container();
            this.circuitGroupBox = new System.Windows.Forms.GroupBox();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.elementsListGroupBox = new System.Windows.Forms.GroupBox();
            this.elementsListBox = new System.Windows.Forms.ListBox();
            this.iComponentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.circuitGroupBox.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            this.elementsListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iComponentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // circuitGroupBox
            // 
            this.circuitGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circuitGroupBox.Controls.Add(this.nameGroupBox);
            this.circuitGroupBox.Controls.Add(this.elementsListGroupBox);
            this.circuitGroupBox.Location = new System.Drawing.Point(3, 3);
            this.circuitGroupBox.Name = "circuitGroupBox";
            this.circuitGroupBox.Size = new System.Drawing.Size(266, 165);
            this.circuitGroupBox.TabIndex = 0;
            this.circuitGroupBox.TabStop = false;
            this.circuitGroupBox.Text = "Circuit";
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameGroupBox.Controls.Add(this.nameTextBox);
            this.nameGroupBox.Location = new System.Drawing.Point(6, 113);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(254, 46);
            this.nameGroupBox.TabIndex = 4;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(6, 16);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(242, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // elementsListGroupBox
            // 
            this.elementsListGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementsListGroupBox.Controls.Add(this.elementsListBox);
            this.elementsListGroupBox.Location = new System.Drawing.Point(6, 19);
            this.elementsListGroupBox.Name = "elementsListGroupBox";
            this.elementsListGroupBox.Size = new System.Drawing.Size(254, 95);
            this.elementsListGroupBox.TabIndex = 1;
            this.elementsListGroupBox.TabStop = false;
            this.elementsListGroupBox.Text = "Elements list";
            // 
            // elementsListBox
            // 
            this.elementsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementsListBox.DataSource = this.iComponentBindingSource;
            this.elementsListBox.DisplayMember = "Name";
            this.elementsListBox.FormattingEnabled = true;
            this.elementsListBox.Location = new System.Drawing.Point(6, 19);
            this.elementsListBox.Name = "elementsListBox";
            this.elementsListBox.Size = new System.Drawing.Size(242, 56);
            this.elementsListBox.TabIndex = 0;
            // 
            // iComponentBindingSource
            // 
            this.iComponentBindingSource.DataSource = typeof(Core.IComponent);
            this.iComponentBindingSource.CurrentItemChanged += new System.EventHandler(this.IComponentBindingSourceCurrentItemChanged);
            // 
            // BaseCircuitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.circuitGroupBox);
            this.Name = "BaseCircuitControl";
            this.Size = new System.Drawing.Size(275, 174);
            this.circuitGroupBox.ResumeLayout(false);
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.elementsListGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iComponentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox circuitGroupBox;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox elementsListGroupBox;
        private System.Windows.Forms.ListBox elementsListBox;
        private System.Windows.Forms.BindingSource iComponentBindingSource;
    }
}
