namespace ParserAvito
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
            this.startButton = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.logText = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.OpenSettings = new System.Windows.Forms.Button();
            this.PictureBoxZXC = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZXC)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.startButton.Location = new System.Drawing.Point(40, 289);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(156, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Парсить";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(263, 27);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(525, 423);
            this.Log.TabIndex = 1;
            this.Log.Text = "";
            this.Log.TextChanged += new System.EventHandler(this.Log_TextChanged);
            // 
            // logText
            // 
            this.logText.AutoSize = true;
            this.logText.Location = new System.Drawing.Point(272, 9);
            this.logText.Name = "logText";
            this.logText.Size = new System.Drawing.Size(43, 13);
            this.logText.TabIndex = 13;
            this.logText.Text = "Log [...]";
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Snap ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.ForeColor = System.Drawing.Color.Brown;
            this.buttonStop.Location = new System.Drawing.Point(40, 341);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(156, 23);
            this.buttonStop.TabIndex = 22;
            this.buttonStop.Text = "Остановить";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(40, 53);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(156, 23);
            this.buttonAdd.TabIndex = 23;
            this.buttonAdd.Text = "Добавить  фильтр";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // OpenSettings
            // 
            this.OpenSettings.Location = new System.Drawing.Point(40, 112);
            this.OpenSettings.Name = "OpenSettings";
            this.OpenSettings.Size = new System.Drawing.Size(156, 23);
            this.OpenSettings.TabIndex = 24;
            this.OpenSettings.Text = "Посмотреть фильтры";
            this.OpenSettings.UseVisualStyleBackColor = true;
            this.OpenSettings.Click += new System.EventHandler(this.OpenSettings_Click);
            // 
            // PictureBoxZXC
            // 
            this.PictureBoxZXC.Enabled = false;
            this.PictureBoxZXC.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxZXC.Image")));
            this.PictureBoxZXC.Location = new System.Drawing.Point(40, 141);
            this.PictureBoxZXC.Name = "PictureBoxZXC";
            this.PictureBoxZXC.Size = new System.Drawing.Size(156, 132);
            this.PictureBoxZXC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxZXC.TabIndex = 25;
            this.PictureBoxZXC.TabStop = false;
            this.PictureBoxZXC.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PictureBoxZXC);
            this.Controls.Add(this.OpenSettings);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.startButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Жеский парсер 0.06";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxZXC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox Log;
        private System.Windows.Forms.Label logText;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button OpenSettings;
        private System.Windows.Forms.PictureBox PictureBoxZXC;
    }
}

