namespace Controls.CircuitViewer
{
    partial class CircuitViewer
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
            this.circuitGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.circuitGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // circuitGridView
            // 
            this.circuitGridView.AllowUserToAddRows = false;
            this.circuitGridView.AllowUserToDeleteRows = false;
            this.circuitGridView.AllowUserToResizeRows = false;
            this.circuitGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.circuitGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circuitGridView.Location = new System.Drawing.Point(0, 0);
            this.circuitGridView.Name = "circuitGridView";
            this.circuitGridView.RowHeadersVisible = false;
            this.circuitGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.circuitGridView.Size = new System.Drawing.Size(631, 346);
            this.circuitGridView.TabIndex = 0;
            // 
            // CircuitViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.circuitGridView);
            this.Name = "CircuitViewer";
            this.Size = new System.Drawing.Size(631, 346);
            ((System.ComponentModel.ISupportInitialize)(this.circuitGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView circuitGridView;
    }
}
