namespace PhoneBookConfigurator
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panelss = new System.Windows.Forms.TabControl();
            this.DescriptPole = new System.Windows.Forms.TabPage();
            this.ContentAD = new System.Windows.Forms.Panel();
            this.HeadPanel1 = new System.Windows.Forms.Panel();
            this.GroupPole = new System.Windows.Forms.TabPage();
            this.FiltrsPole = new System.Windows.Forms.TabPage();
            this.SystemParams = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Panelss.SuspendLayout();
            this.DescriptPole.SuspendLayout();
            this.SystemParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = ".";
            this.openFileDialog1.Title = "Выбор Файла";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 727);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 49);
            this.panel1.TabIndex = 4;
            // 
            // Panelss
            // 
            this.Panelss.Controls.Add(this.DescriptPole);
            this.Panelss.Controls.Add(this.GroupPole);
            this.Panelss.Controls.Add(this.FiltrsPole);
            this.Panelss.Controls.Add(this.SystemParams);
            this.Panelss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panelss.Location = new System.Drawing.Point(0, 0);
            this.Panelss.Name = "Panelss";
            this.Panelss.SelectedIndex = 0;
            this.Panelss.Size = new System.Drawing.Size(834, 727);
            this.Panelss.TabIndex = 5;
            this.Panelss.SelectedIndexChanged += new System.EventHandler(this.Panelss_SelectedIndexChanged_1);
            // 
            // DescriptPole
            // 
            this.DescriptPole.AutoScroll = true;
            this.DescriptPole.BackColor = System.Drawing.Color.SkyBlue;
            this.DescriptPole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DescriptPole.Controls.Add(this.ContentAD);
            this.DescriptPole.Controls.Add(this.HeadPanel1);
            this.DescriptPole.Location = new System.Drawing.Point(4, 22);
            this.DescriptPole.Name = "DescriptPole";
            this.DescriptPole.Padding = new System.Windows.Forms.Padding(3);
            this.DescriptPole.Size = new System.Drawing.Size(826, 701);
            this.DescriptPole.TabIndex = 0;
            this.DescriptPole.Text = "Расшифровка и полей";
            // 
            // ContentAD
            // 
            this.ContentAD.AutoScroll = true;
            this.ContentAD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContentAD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentAD.Location = new System.Drawing.Point(3, 33);
            this.ContentAD.Name = "ContentAD";
            this.ContentAD.Size = new System.Drawing.Size(816, 661);
            this.ContentAD.TabIndex = 2;
            // 
            // HeadPanel1
            // 
            this.HeadPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.HeadPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadPanel1.Location = new System.Drawing.Point(3, 3);
            this.HeadPanel1.Name = "HeadPanel1";
            this.HeadPanel1.Size = new System.Drawing.Size(816, 30);
            this.HeadPanel1.TabIndex = 1;
            // 
            // GroupPole
            // 
            this.GroupPole.AutoScroll = true;
            this.GroupPole.BackColor = System.Drawing.Color.Khaki;
            this.GroupPole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GroupPole.Location = new System.Drawing.Point(4, 22);
            this.GroupPole.Name = "GroupPole";
            this.GroupPole.Size = new System.Drawing.Size(826, 701);
            this.GroupPole.TabIndex = 2;
            this.GroupPole.Text = "Групировка справочника";
            // 
            // FiltrsPole
            // 
            this.FiltrsPole.AutoScroll = true;
            this.FiltrsPole.BackColor = System.Drawing.Color.Pink;
            this.FiltrsPole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FiltrsPole.Location = new System.Drawing.Point(4, 22);
            this.FiltrsPole.Name = "FiltrsPole";
            this.FiltrsPole.Size = new System.Drawing.Size(826, 701);
            this.FiltrsPole.TabIndex = 3;
            this.FiltrsPole.Text = "Фильтр отображения";
            // 
            // SystemParams
            // 
            this.SystemParams.BackColor = System.Drawing.Color.Silver;
            this.SystemParams.Controls.Add(this.button2);
            this.SystemParams.Controls.Add(this.textBox2);
            this.SystemParams.Controls.Add(this.textBox1);
            this.SystemParams.Controls.Add(this.label2);
            this.SystemParams.Controls.Add(this.button1);
            this.SystemParams.Controls.Add(this.label1);
            this.SystemParams.Location = new System.Drawing.Point(4, 22);
            this.SystemParams.Name = "SystemParams";
            this.SystemParams.Size = new System.Drawing.Size(826, 701);
            this.SystemParams.TabIndex = 4;
            this.SystemParams.Text = "Системные настройки";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(599, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Выбрать";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(166, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(418, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(418, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Путь к файлу дампа АД";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(599, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь файу настроек";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 776);
            this.Controls.Add(this.Panelss);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление телефонным справочником";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panelss.ResumeLayout(false);
            this.DescriptPole.ResumeLayout(false);
            this.SystemParams.ResumeLayout(false);
            this.SystemParams.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl Panelss;
        private System.Windows.Forms.TabPage DescriptPole;
        private System.Windows.Forms.Panel ContentAD;
        private System.Windows.Forms.Panel HeadPanel1;
        private System.Windows.Forms.TabPage GroupPole;
        private System.Windows.Forms.TabPage FiltrsPole;
        private System.Windows.Forms.TabPage SystemParams;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

