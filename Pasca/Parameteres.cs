using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SessionLib;
using Excel = Microsoft.Office.Interop.Excel;


namespace Pasca
{
    public partial class Parameteres : Form
    {
        Session session;
        public Parameteres(Session session)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            this.session = session;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm";
            dateTimePicker3.CustomFormat = "dd/MM/yyyy hh:mm";
            dateTimePicker4.CustomFormat = "dd/MM/yyyy hh:mm";
            dateTimePicker5.CustomFormat = "dd/MM/yyyy hh:mm";
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
            dateTimePicker3.MinDate = dateTimePicker2.Value.AddDays(1);
            dateTimePicker4.MinDate = dateTimePicker3.Value.AddDays(1);
            dateTimePicker5.MinDate = dateTimePicker4.Value.AddDays(1);
            ShowParams();
        }
        
        private void Parameteres_Load(object sender, EventArgs e)
        {
        }

        void ShowParams()
        {
            if (!session.IsParametersFilled)
                return;
            dateTimePicker1.Value = session.Submission_Begin;
            dateTimePicker2.Value = session.Submission_End;
            dateTimePicker3.Value = session.Review_Begin;
            dateTimePicker4.Value = session.Review_End;
            dateTimePicker4.Value = session.ResultMessage;
            comboBox1.SelectedItem = session.OneAuthor_Count.ToString();
            textBox1.Text = session.Task_File;
            textBox2.Text = session.PRForm_File;
            textBox3.Text = session.Folder_path;
        }

        private void But_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.pdf;*.docx)|*.pdf;*.docx";
            try
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = openFileDialog.FileName;     
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при выборе файла!\nПовторите попытку позже");
                return;
            }
        }

        private void select_PRForm_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.xlsm";
            try
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox2.Text = openFileDialog.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при выборе файла!\nПовторите попытку позже");
                return;
            }
        }

        private void But_SaveParams_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Выберите файл с заданием!");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Выберите файл с оценочной формой!");
                return;
            }
            try
            {
                session.Submission_Begin = dateTimePicker1.Value;
                session.Submission_End = dateTimePicker2.Value;
                session.Review_Begin = dateTimePicker3.Value;
                session.Review_End = dateTimePicker4.Value;
                session.ResultMessage = dateTimePicker5.Value;
                session.OneAuthor_Count = int.Parse(comboBox1.SelectedItem.ToString());
                session.Task_File = textBox1.Text;
                session.PRForm_File = textBox2.Text;
                session.Folder_path = textBox3.Text;
                session.SetupParams();
                session.IsParametersFilled = true;
                MessageBox.Show("Параметры успешно установлены!");
            }
            catch 
            {
                MessageBox.Show("Произошла ошибка при установке параметров! Повторите попытку позже.");
                return;
            }
        }

        private void But_ChooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            try
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox3.Text = dialog.SelectedPath;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при выборе файла!\nПовторите попытку позже");
                return;
            }
        }

        private void Parameteres_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы хотите сохранить изменения в параметрах?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                But_SaveParams_Click(this, new EventArgs());
        }
    }
}
