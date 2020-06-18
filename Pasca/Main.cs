using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SessionLib;
using System.Runtime.Serialization.Formatters.Binary;


namespace Pasca
{
    public partial class Main : Form
    {
        public static Main MainPage;
        public Main()
        {
            InitializeComponent();
            MainPage = this;
        }

        private void But_CreateNew(object sender, EventArgs e)
        {
            bool key = false;
            try
            {
                if (File.Exists("current_session.txt"))
                {
                    key = true; //значит, восстанавливаем объект из памяти
                }
            }
            catch
            {
                MessageBox.Show("Файл программы сейчас используется. Закройте его и повторите попытку позже.");
                return;
            }
            NowSession newSession = null;
            try
            {
                newSession = new NowSession(this, key);
            }
            catch (IOException)
            {
                MessageBox.Show("При создании сессии возникла ошибка! Закройте файлы программы и повторите попытку.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("При открытии сессии произошла ошибка!\nПовторите попытку позже!");
                return;
            }
            newSession.Location = this.Location;
            this.Visible = false;
            newSession.Show();
        }

        private void But_OpenPrevSes_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(@"prev_sessions.txt"))
                {
                    MessageBox.Show("Нет завершенных сессий для отображения результатов!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Файл программы сейчас используется. Закройте его и повторите попытку позже.");
                return;
            }
            List<Session> sess = null;
            BinaryFormatter bin = new BinaryFormatter();
            Previous_Sessions prev = null;
            try
            {
                using (FileStream f = new FileStream(@"prev_sessions.txt", FileMode.Open))
                {
                    sess = (List<Session>)bin.Deserialize(f);
                }
                prev = new Previous_Sessions(this, sess);
            }
            catch
            {
                MessageBox.Show("При открытии результатов произошла ошибка.\nПовторите попытку позже.");
                return;
            }
            prev.Location = this.Location;
            this.Visible = false;
            prev.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }
    }
}
