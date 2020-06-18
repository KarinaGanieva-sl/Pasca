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
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;


namespace Pasca
{
    public partial class CreatingAuthors : Form
    {
        Session session;
        DataGridViewRow row;
        bool mode_key;
        public CreatingAuthors(Session session, bool key)
        {
            InitializeComponent();
            this.session = session;
            mode_key = key;
            if (session.status != Session.Status.creating)
                list.AllowUserToAddRows = false;
            FillList();
        }
        //переносить авторов и кол-во авторов и оценщиков
        private void But_Save_Click(object sender, EventArgs e)
        {
           if (CheckInfo())
            {
                /*if (list.RowCount - 1 < 6)
                {
                    MessageBox.Show("Кол-во участников сессии должно быть больше 5!");
                    return;
                }*/
                List<Peer> peers = new List<Peer>();
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet MainBook;
                if (mode_key)
                {
                    session.SetupAuthorsCount(list.RowCount - 1, session.mode);
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(session.Authors_File);
                    MainBook = xlWorkBook.Sheets["Peers"];
                }
                else
                {
                    session.SetupAuthorsCount(list.RowCount - 1);
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(session.Authors_File);
                    MainBook = xlWorkBook.Sheets["List"];
                }
                for (int i = 0; i < list.RowCount-1; i++)
                {
                    peers = new List<Peer>();
                    MainBook.Cells[i+2, 3] = list.Rows[i].Cells[0].Value.ToString();
                    MainBook.Cells[i + 2, 4] = list.Rows[i].Cells[1].Value.ToString();
                    if(list.Rows[i].Cells[2].Value!=null)
                    MainBook.Cells[i + 2, 5] = list.Rows[i].Cells[2].Value.ToString();
                    MainBook.Cells[i + 2, 8] = list.Rows[i].Cells[3].Value.ToString();
                    if (mode_key) peers.Add(new Peer(list.Rows[i].Cells[0].Value.ToString(), list.Rows[i].Cells[1].Value.ToString(), list.Rows[i].Cells[3].Value.ToString()));
                }
                session.IsListFilled = true;
                xlWorkBook.Close(true);
                xlApp.Quit();
                xlWorkBook = null;
                MainBook = null;
                MessageBox.Show("Список успешно создан!");
                //после окончания сессии добавлять в архив рецензентов
                //собрать рецензентов и посмотреть, если кто из них в архиве, если таковы имеются то записывать им коэф

                if(mode_key) FillKoef(peers);
            }
        }
        //найти рецензентов из архива, восстановить их коэф, остальным дать 0.5
        void FillKoef(List<Peer> peers)
        {

            for (int i = 0; i < peers.Count; i++)
            {
               if (session.peers_archive.Count!=0 && session.peers_archive.Contains(peers[i]))
                    peers[i].koef = session.peers_archive[session.peers_archive.IndexOf(peers[i])].koef;
                else peers[i].koef = 0.5;
            }
            session.peers = peers;
        }
        //Проверяем корректность инфо
        bool CheckInfo()
        {
            for(int i=0; i < list.RowCount-1; i++)
            {
                if(list.Rows[i].Cells[0].Value == null|| list.Rows[i].Cells[1].Value ==null|| list.Rows[i].Cells[3].Value == null)
                {
                    MessageBox.Show($"Заполните, пожалуйста, все обязательные поля");
                    return false;
                }
                if (!CheckName(list.Rows[i].Cells[0].Value.ToString()))
                {
                    MessageBox.Show($"Используйте только русскую раскладку. Некорректное значение: "+ list.Rows[i].Cells[0].Value.ToString());
                    return false;
                }
                if (!CheckName(list.Rows[i].Cells[1].Value.ToString()))
                {
                    MessageBox.Show($"Используйте только русскую раскладку. Некорректное значение: " + list.Rows[i].Cells[0].Value.ToString());
                    return false;
                }
                if (!CheckName(list.Rows[i].Cells[1].Value.ToString()))
                {
                    MessageBox.Show($"Используйте только русскую раскладку. Некорректное значение: " + list.Rows[i].Cells[0].Value.ToString());
                    return false;
                }
            }
            return true;
        }
        //проверяет корректность имени
        bool CheckName(string name)
        {
            if (name == null)
                return true;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] > 'я' || name[i] < 'А')
                    return false;
            }
            return true;
        }
        
        //метод для отображение списка участникво, если они есть
        void FillList()
        {
            if (session.IsListFilled)
            {
                Excel.Application xlApp = null;
                Excel.Workbook xlWorkBook = null;
                Excel.Worksheet MainBook;
                try
                {
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(session.Authors_File);
                    if (!mode_key)
                    {
                        MainBook = xlWorkBook.Sheets["List"];
                        for (int i = 0; i < session.Authors_Count; i++)
                        {
                            list.Rows.Add(MainBook.Cells[i + 2, 3].Value, MainBook.Cells[i + 2, 4].Value, MainBook.Cells[i + 2, 5].Value, MainBook.Cells[i + 2, 8].Value);
                        }
                    }
                    else
                    {
                        MainBook = xlWorkBook.Sheets["Peers"];
                        MessageBox.Show("dddddddddd");
                        for (int i = 0; i < session.Peers_Count; i++)
                        {
                            list.Rows.Add(MainBook.Cells[i + 2, 3].Value, MainBook.Cells[i + 2, 4].Value, MainBook.Cells[i + 2, 5].Value, MainBook.Cells[i + 2, 8].Value);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("При создании списка проищошла ошибка!\nПовторите попытку позже");
                }
                finally
                {
                    xlWorkBook.Close(true);
                    xlApp.Quit();
                    xlWorkBook = null;
                    MainBook = null;
                }
            }
        }
        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                row = CloneWithValues(list.SelectedRows[0]);
            }
            catch
            {
                return;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                list.Rows.RemoveAt(list.SelectedRows[0].Index);
            }
            catch
            {
                return;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (row != null)
                {
                    list.Rows.Add(row);
                }
            }
            catch
            {
                return;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloneWithValues(list.SelectedRows[0]);
                list.Rows.RemoveAt(list.SelectedRows[0].Index);
            }
            catch
            {
                return;
            }
        }

        private void CreatingAuthors_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы хотите сохранить изменения в списке авторов?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                But_Save_Click(this, new EventArgs());
        }

        private void CreatingAuthors_Load(object sender, EventArgs e)
        {

        }
    }
}
