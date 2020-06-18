namespace Pasca
{
    partial class NowSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NowSession));
            this.But_SendTaskFile = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.But_Gen_Report = new System.Windows.Forms.Button();
            this.Down_Subs = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.But_CreateList = new System.Windows.Forms.Button();
            this.But_SetupParameters = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.But_Results = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.but_CreatePeers = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // But_SendTaskFile
            // 
            this.But_SendTaskFile.AutoSize = true;
            this.But_SendTaskFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.But_SendTaskFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.But_SendTaskFile.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.But_SendTaskFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.But_SendTaskFile.Location = new System.Drawing.Point(252, 96);
            this.But_SendTaskFile.Name = "But_SendTaskFile";
            this.But_SendTaskFile.Size = new System.Drawing.Size(233, 75);
            this.But_SendTaskFile.TabIndex = 3;
            this.But_SendTaskFile.Text = "Отправить задание";
            this.But_SendTaskFile.UseVisualStyleBackColor = false;
            this.But_SendTaskFile.Click += new System.EventHandler(this.But_SendTaskFile_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.button5.Location = new System.Drawing.Point(568, 96);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(236, 75);
            this.button5.TabIndex = 4;
            this.button5.Text = "Загрузить решения";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.But_Dow_Subs_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(252, 220);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(233, 75);
            this.button7.TabIndex = 6;
            this.button7.Text = "Отправить оценочные формы";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.But_SendPRForms_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(568, 216);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(236, 79);
            this.button8.TabIndex = 7;
            this.button8.Text = "Загрузить оценочные формы";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.But_Down_PRForms_Click);
            // 
            // But_Gen_Report
            // 
            this.But_Gen_Report.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.But_Gen_Report.BackColor = System.Drawing.Color.WhiteSmoke;
            this.But_Gen_Report.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.But_Gen_Report.Location = new System.Drawing.Point(252, 345);
            this.But_Gen_Report.Name = "But_Gen_Report";
            this.But_Gen_Report.Size = new System.Drawing.Size(233, 79);
            this.But_Gen_Report.TabIndex = 8;
            this.But_Gen_Report.Text = "Сгенерировать отчёт";
            this.But_Gen_Report.UseVisualStyleBackColor = false;
            this.But_Gen_Report.Click += new System.EventHandler(this.Gen_Report_Click);
            // 
            // Down_Subs
            // 
            this.Down_Subs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Down_Subs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Down_Subs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Down_Subs.Location = new System.Drawing.Point(568, 345);
            this.Down_Subs.Name = "Down_Subs";
            this.Down_Subs.Size = new System.Drawing.Size(236, 79);
            this.Down_Subs.TabIndex = 9;
            this.Down_Subs.Text = "Отправить результаты";
            this.Down_Subs.UseVisualStyleBackColor = false;
            this.Down_Subs.Click += new System.EventHandler(this.But_SendResults_Click);
            // 
            // button13
            // 
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button13.Location = new System.Drawing.Point(12, 12);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(91, 30);
            this.button13.TabIndex = 17;
            this.button13.Text = "Назад";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.But_BackToMain);
            // 
            // But_CreateList
            // 
            this.But_CreateList.FlatAppearance.BorderSize = 0;
            this.But_CreateList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.But_CreateList.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.But_CreateList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.But_CreateList.Location = new System.Drawing.Point(0, 83);
            this.But_CreateList.Name = "But_CreateList";
            this.But_CreateList.Size = new System.Drawing.Size(170, 37);
            this.But_CreateList.TabIndex = 18;
            this.But_CreateList.Text = "Авторы";
            this.But_CreateList.UseVisualStyleBackColor = true;
            this.But_CreateList.Click += new System.EventHandler(this.But_CreateList_Click);
            // 
            // But_SetupParameters
            // 
            this.But_SetupParameters.FlatAppearance.BorderSize = 0;
            this.But_SetupParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.But_SetupParameters.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.But_SetupParameters.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.But_SetupParameters.Location = new System.Drawing.Point(3, 191);
            this.But_SetupParameters.Name = "But_SetupParameters";
            this.But_SetupParameters.Size = new System.Drawing.Size(170, 38);
            this.But_SetupParameters.TabIndex = 19;
            this.But_SetupParameters.Text = "Параметры";
            this.But_SetupParameters.UseVisualStyleBackColor = true;
            this.But_SetupParameters.Click += new System.EventHandler(this.But_SetupParameters_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.but_CreatePeers);
            this.panel1.Controls.Add(this.But_Results);
            this.panel1.Controls.Add(this.But_CreateList);
            this.panel1.Controls.Add(this.But_SetupParameters);
            this.panel1.Controls.Add(this.button13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 515);
            this.panel1.TabIndex = 20;
            // 
            // But_Results
            // 
            this.But_Results.FlatAppearance.BorderSize = 0;
            this.But_Results.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.But_Results.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.But_Results.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.But_Results.Location = new System.Drawing.Point(0, 238);
            this.But_Results.Name = "But_Results";
            this.But_Results.Size = new System.Drawing.Size(170, 38);
            this.But_Results.TabIndex = 20;
            this.But_Results.Text = "Результаты";
            this.But_Results.UseVisualStyleBackColor = true;
            this.But_Results.Click += new System.EventHandler(this.But_Results_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 56);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(280, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 44);
            this.label2.TabIndex = 23;
            this.label2.Text = "PAS";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel3.Location = new System.Drawing.Point(245, 191);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(559, 3);
            this.panel3.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(252, 320);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(559, 3);
            this.panel4.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Использовать сторонних рецензентов",
            "Использовать авторов в качестве рецензентов"});
            this.checkedListBox1.Location = new System.Drawing.Point(298, 430);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(462, 73);
            this.checkedListBox1.TabIndex = 1;
            // 
            // but_CreatePeers
            // 
            this.but_CreatePeers.FlatAppearance.BorderSize = 0;
            this.but_CreatePeers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_CreatePeers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.but_CreatePeers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.but_CreatePeers.Location = new System.Drawing.Point(0, 134);
            this.but_CreatePeers.Name = "but_CreatePeers";
            this.but_CreatePeers.Size = new System.Drawing.Size(170, 37);
            this.but_CreatePeers.TabIndex = 21;
            this.but_CreatePeers.Text = "Рецензенты";
            this.but_CreatePeers.UseVisualStyleBackColor = true;
            this.but_CreatePeers.Click += new System.EventHandler(this.but_CreatePeers_Click);
            // 
            // NowSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(884, 515);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Down_Subs);
            this.Controls.Add(this.But_Gen_Report);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.But_SendTaskFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NowSession";
            this.Text = "Current Session";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NowSession_FormClosing);
            this.Load += new System.EventHandler(this.NowSession_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button But_SendTaskFile;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button But_Gen_Report;
        private System.Windows.Forms.Button Down_Subs;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button But_CreateList;
        private System.Windows.Forms.Button But_SetupParameters;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button But_Results;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button but_CreatePeers;
    }
}

