namespace Pasca
{
    partial class Previous_Sessions
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Previous_Sessions));
            this.panel2 = new System.Windows.Forms.Panel();
            this.But_Back = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Data2 = new System.Windows.Forms.DataGridView();
            this.Data1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьСессиюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Data2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Controls.Add(this.But_Back);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(-4, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 67);
            this.panel2.TabIndex = 21;
            // 
            // But_Back
            // 
            this.But_Back.FlatAppearance.BorderSize = 0;
            this.But_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.But_Back.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.But_Back.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.But_Back.Location = new System.Drawing.Point(10, 14);
            this.But_Back.Name = "But_Back";
            this.But_Back.Size = new System.Drawing.Size(91, 30);
            this.But_Back.TabIndex = 24;
            this.But_Back.Text = "Назад";
            this.But_Back.UseVisualStyleBackColor = true;
            this.But_Back.Click += new System.EventHandler(this.But_Back_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Perpetua Titling MT", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(352, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 44);
            this.label7.TabIndex = 23;
            this.label7.Text = "PAS";
            // 
            // Data2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.Data2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Data2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data2.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Data2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Data2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Data2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Names,
            this.FatherName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Data2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Data2.EnableHeadersVisualStyles = false;
            this.Data2.Location = new System.Drawing.Point(214, 71);
            this.Data2.Name = "Data2";
            this.Data2.ShowRowErrors = false;
            this.Data2.Size = new System.Drawing.Size(628, 324);
            this.Data2.TabIndex = 22;
            // 
            // Data1
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.Data1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Data1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Data1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Data1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Data1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.Data1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Data1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Data1.EnableHeadersVisualStyles = false;
            this.Data1.Location = new System.Drawing.Point(6, 71);
            this.Data1.Name = "Data1";
            this.Data1.ShowRowErrors = false;
            this.Data1.Size = new System.Drawing.Size(202, 324);
            this.Data1.TabIndex = 23;
            this.Data1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Data1_CellMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 154.3147F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Сессия";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьСессиюToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 28);
            // 
            // удалитьСессиюToolStripMenuItem
            // 
            this.удалитьСессиюToolStripMenuItem.Name = "удалитьСессиюToolStripMenuItem";
            this.удалитьСессиюToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.удалитьСессиюToolStripMenuItem.Text = "Удалить сессию";
            this.удалитьСессиюToolStripMenuItem.Click += new System.EventHandler(this.DeleteSessionToolStripMenuItem_Click);
            // 
            // Names
            // 
            this.Names.FillWeight = 154.3147F;
            this.Names.HeaderText = "Имя";
            this.Names.Name = "Names";
            // 
            // FatherName
            // 
            this.FatherName.FillWeight = 45.68528F;
            this.FatherName.HeaderText = "Результат";
            this.FatherName.Name = "FatherName";
            // 
            // Previous_Sessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(854, 509);
            this.Controls.Add(this.Data1);
            this.Controls.Add(this.Data2);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Previous_Sessions";
            this.Text = "Предыдущие сессии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Previous_Sessions_FormClosing);
            this.Load += new System.EventHandler(this.Previous_Sessions_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Data2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView Data2;
        private System.Windows.Forms.DataGridView Data1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьСессиюToolStripMenuItem;
        private System.Windows.Forms.Button But_Back;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatherName;
    }
}