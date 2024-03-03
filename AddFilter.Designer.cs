namespace ParserAvito
{
    partial class AddFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFilter));
            this.label5 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MaxPageTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxPriceTextBox = new System.Windows.Forms.TextBox();
            this.MinPriceTexBox = new System.Windows.Forms.TextBox();
            this.buttonAddFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LinkTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Название товара";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(5, 224);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(354, 20);
            this.NameTextBox.TabIndex = 28;
            this.NameTextBox.Text = "Не важно";
            this.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Макс. кол-во страниц";
            // 
            // MaxPageTextBox
            // 
            this.MaxPageTextBox.Location = new System.Drawing.Point(161, 110);
            this.MaxPageTextBox.Name = "MaxPageTextBox";
            this.MaxPageTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaxPageTextBox.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Цена до";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Цена от";
            // 
            // MaxPriceTextBox
            // 
            this.MaxPriceTextBox.Location = new System.Drawing.Point(5, 167);
            this.MaxPriceTextBox.Name = "MaxPriceTextBox";
            this.MaxPriceTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaxPriceTextBox.TabIndex = 23;
            // 
            // MinPriceTexBox
            // 
            this.MinPriceTexBox.Location = new System.Drawing.Point(5, 110);
            this.MinPriceTexBox.Name = "MinPriceTexBox";
            this.MinPriceTexBox.Size = new System.Drawing.Size(100, 20);
            this.MinPriceTexBox.TabIndex = 22;
            // 
            // buttonAddFilter
            // 
            this.buttonAddFilter.Location = new System.Drawing.Point(144, 296);
            this.buttonAddFilter.Name = "buttonAddFilter";
            this.buttonAddFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFilter.TabIndex = 30;
            this.buttonAddFilter.Text = "Добавить";
            this.buttonAddFilter.UseVisualStyleBackColor = true;
            this.buttonAddFilter.Click += new System.EventHandler(this.buttonAddFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Ссылка";
            // 
            // LinkTextBox
            // 
            this.LinkTextBox.Location = new System.Drawing.Point(5, 33);
            this.LinkTextBox.Name = "LinkTextBox";
            this.LinkTextBox.Size = new System.Drawing.Size(354, 20);
            this.LinkTextBox.TabIndex = 31;
            // 
            // AddFilter
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 382);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LinkTextBox);
            this.Controls.Add(this.buttonAddFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MaxPageTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaxPriceTextBox);
            this.Controls.Add(this.MinPriceTexBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MaxPageTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MaxPriceTextBox;
        private System.Windows.Forms.TextBox MinPriceTexBox;
        private System.Windows.Forms.Button buttonAddFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LinkTextBox;
    }
}