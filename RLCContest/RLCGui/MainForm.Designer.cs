namespace RLCGui
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.createElementButton = new System.Windows.Forms.Button();
            this.elementFactory = new RLCControls.ElementFactory();
            this.circuitControl = new RLCControls.CircuitControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.createElementButton);
            this.panel1.Controls.Add(this.elementFactory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(397, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 407);
            this.panel1.TabIndex = 0;
            // 
            // createElementButton
            // 
            this.createElementButton.Location = new System.Drawing.Point(3, 133);
            this.createElementButton.Name = "createElementButton";
            this.createElementButton.Size = new System.Drawing.Size(197, 23);
            this.createElementButton.TabIndex = 1;
            this.createElementButton.Text = "Создать";
            this.createElementButton.UseVisualStyleBackColor = true;
            this.createElementButton.Click += new System.EventHandler(this.CreateElementButtonClick);
            this.createElementButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CreateElementButtonMouseMove);
            // 
            // elementFactory
            // 
            this.elementFactory.Location = new System.Drawing.Point(3, 3);
            this.elementFactory.Name = "elementFactory";
            this.elementFactory.Size = new System.Drawing.Size(197, 124);
            this.elementFactory.TabIndex = 0;
            // 
            // circuitControl
            // 
            this.circuitControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circuitControl.Location = new System.Drawing.Point(-3, 0);
            this.circuitControl.Name = "circuitControl";
            this.circuitControl.Size = new System.Drawing.Size(397, 407);
            this.circuitControl.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 407);
            this.Controls.Add(this.circuitControl);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RLCControls.ElementFactory elementFactory;
        private System.Windows.Forms.Button createElementButton;
        private RLCControls.CircuitControl circuitControl;
    }
}

