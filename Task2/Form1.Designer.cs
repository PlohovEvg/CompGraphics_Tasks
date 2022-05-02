namespace Task2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CreateISOBtn = new System.Windows.Forms.Button();
            this.IsoImagePicBox = new System.Windows.Forms.PictureBox();
            this.DefaultImagePicBox = new System.Windows.Forms.PictureBox();
            this.ClearCanvasBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IsoImagePicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultImagePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateISOBtn
            // 
            this.CreateISOBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CreateISOBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateISOBtn.Location = new System.Drawing.Point(1097, 782);
            this.CreateISOBtn.Name = "CreateISOBtn";
            this.CreateISOBtn.Size = new System.Drawing.Size(200, 61);
            this.CreateISOBtn.TabIndex = 0;
            this.CreateISOBtn.Text = "Построить изометрию";
            this.CreateISOBtn.UseVisualStyleBackColor = false;
            this.CreateISOBtn.Click += new System.EventHandler(this.CreateISOBtn_Click);
            // 
            // IsoImagePicBox
            // 
            this.IsoImagePicBox.Location = new System.Drawing.Point(489, 12);
            this.IsoImagePicBox.Name = "IsoImagePicBox";
            this.IsoImagePicBox.Size = new System.Drawing.Size(602, 831);
            this.IsoImagePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IsoImagePicBox.TabIndex = 2;
            this.IsoImagePicBox.TabStop = false;
            // 
            // DefaultImagePicBox
            // 
            this.DefaultImagePicBox.Image = global::Task2.Properties.Resources.Виды;
            this.DefaultImagePicBox.Location = new System.Drawing.Point(12, 12);
            this.DefaultImagePicBox.Name = "DefaultImagePicBox";
            this.DefaultImagePicBox.Size = new System.Drawing.Size(462, 831);
            this.DefaultImagePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.DefaultImagePicBox.TabIndex = 1;
            this.DefaultImagePicBox.TabStop = false;
            // 
            // ClearCanvasBtn
            // 
            this.ClearCanvasBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClearCanvasBtn.Enabled = false;
            this.ClearCanvasBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearCanvasBtn.Location = new System.Drawing.Point(1097, 715);
            this.ClearCanvasBtn.Name = "ClearCanvasBtn";
            this.ClearCanvasBtn.Size = new System.Drawing.Size(200, 61);
            this.ClearCanvasBtn.TabIndex = 3;
            this.ClearCanvasBtn.Text = "Очистить полотно";
            this.ClearCanvasBtn.UseVisualStyleBackColor = false;
            this.ClearCanvasBtn.Click += new System.EventHandler(this.ClearCanvasBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1309, 860);
            this.Controls.Add(this.ClearCanvasBtn);
            this.Controls.Add(this.IsoImagePicBox);
            this.Controls.Add(this.DefaultImagePicBox);
            this.Controls.Add(this.CreateISOBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Построение изометрической проекции";
            ((System.ComponentModel.ISupportInitialize)(this.IsoImagePicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultImagePicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateISOBtn;
        private System.Windows.Forms.PictureBox DefaultImagePicBox;
        private System.Windows.Forms.PictureBox IsoImagePicBox;
        private System.Windows.Forms.Button ClearCanvasBtn;
    }
}

