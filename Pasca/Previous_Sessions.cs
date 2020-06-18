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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Pasca
{
    public partial class Previous_Sessions : Form
    {
        List<Session> sessions;
        Main Main_Form;
        bool save_key;
        public Previous_Sessions(Main form,List<Session> ses)
        {
            InitializeComponent();
            sessions = ses;
            Main_Form = form;
            AddSessToTable();
        }
        void AddSessToTable()
        {
            for (int i = 0; i < sessions.Count; i++)
            {
                Data1.Rows.Add(sessions[i].Name);
            }
        }
        private void Previous_Sessions_Load(object sender, EventArgs e)
        {

        }

        private void DeleteSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Data1.SelectedCells[0] != null)
            {
                contextMenuStrip1.Close();
                return;
            }
            if (Data1.SelectedRows == null)
            {
                return;
            }
            try
            {
                Data1.Rows.RemoveAt(Data1.SelectedRows[0].Index);
                sessions.RemoveAt(Data1.SelectedRows[0].Index);
            }
            catch
            {
                MessageBox.Show("При удалении сессии произошла ошибка!\nПовторите попытку позже.");
                return;
            }
        }

        private void Data1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {//индекс нужной сессии
                    Data2.Rows.Clear();
                    int index = GetIndexOfSession(Data1.SelectedCells[0].Value.ToString());
                    for (int i = 0; i < sessions[index].mas_results.GetLength(0); i++)
                    {
                        Data2.Rows.Add(sessions[index].mas_results[i, 0], sessions[index].mas_results[i, 1]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("При отображении произошла ошибка!\nПовторите попытку позже.");
                return;
            }
        }
        int GetIndexOfSession(string name)
        {
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }
        private void But_Back_Click(object sender, EventArgs e)
        {
            save_key = true;
            this.Close();
        }

        private void Previous_Sessions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                using (FileStream f = new FileStream(@"prev_sessions.txt", FileMode.Create))
                {
                    bin.Serialize(f, sessions);
                }
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить сохранение сессий");
            }
            if (save_key)
            {
                Main_Form.Visible = true;
            }
            if (!save_key)
                Main_Form.Close();
        }
    }
}
