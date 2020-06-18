using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SessionLib;

namespace Pasca
{
    public partial class NowSession : Form
    {
        Session session;
        Main main_form;
        bool save_key;
        public NowSession(Main form, bool key)
        {
            InitializeComponent();
            main_form = form;
            But_Results.Visible = false;
                if (File.Exists("current_session.txt"))
                {
                    RestoreSession();
                    if (!key) //если не надо восстанавливать сессию, удаляем файл и восстанавливаемый объект
                    {
                        DeleteSession();
                        CreateBeginningofSession();
                    }
                }
                else
                {
                    CreateBeginningofSession();
                }
        }
        private void NowSession_Load(object sender, EventArgs e)
        {
        }
        //восстанаввливаем объект из памяти
        public void RestoreSession()
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (FileStream f = new FileStream("current_session.txt", FileMode.Open))
            {
                session = (Session)bin.Deserialize(f);
            }
        }
        //сохранение объекта в памяти
        //создание сессии с начальными параметрами
        public void CreateBeginningofSession()
        {
            DateTime date = DateTime.Today;
            string path = $@"{date.ToString("ddMMyyyy")}session.xlsm";
            File.Copy(@"шаблон.xlsm", path);
            session = new Session(path, "сессия от"+ date.ToString("dd.MM.yyyy"));
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("current_session.txt", FileMode.Create))
            {
                formatter.Serialize(f, session);
            }
        }
        //удалять файл авторов и обнулять ссылку на объект
        public void DeleteSession()
        {
            try
            {
                if (File.Exists(session.Authors_File))
                    File.Delete(session.Authors_File);
                if (File.Exists("current_session.txt"))
                    File.Delete("current_session.txt");
                session = null;
            }
            catch
            {
                MessageBox.Show("Не удалось удалить старую сессию. Закройте файлы программы.");
                return;
            }
        }
        
        private void But_CreateList_Click(object sender, EventArgs e)
        {
            CreatingAuthors form;
            if (checkedListBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите режим проведения сессии!");
                return;
            }
            if (session.status != Session.Status.creating)
            {
                MessageBox.Show("Вы не можете изменять информацию об авторах после начала сессии!");
                return;
            }
            try
            {
                if (!File.Exists(session.Authors_File) || !File.Exists(session.path_to_pasca))
                {
                    MessageBox.Show("Файл с авторами был перемещён или удалён!\nТекущая сессия будет удалена, приложение будет закрыто.");
                    DeleteSession();
                    main_form.Close();
                }
                else
                {
                    form = new CreatingAuthors(session, false);
                    form.Show();
                }
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить действие. Закройте файлы программы и повторите попытку позже.");
                return;
            }
        }
        private void But_BackToMain(object sender, EventArgs e)
        {
            save_key = true;
            this.Close();
        }
        private void NowSession_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (session.status == Session.Status.creating)
            {
                var result = MessageBox.Show("Хотите ли Вы сохранить текущую сессию?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        session.SaveSession();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось сохранить сессию!");
                    }
                }
                if (result == DialogResult.No)
                {
                    DeleteSession();
                }
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            else if (session.status == Session.Status.send_result)
                DeleteSession();
            else
                session.SaveSession();
            if (save_key)
            {
                main_form.Visible = true;
            }
            if (!save_key)
                main_form.Close();
        }
        
        private void But_SendTaskFile_Click(object sender, EventArgs e)
        {
            if (!session.IsListFilled)
             {
                 MessageBox.Show("Перед отправкой задания Вы должны заполнить список авторов");
                 return;
             }
             if (!session.IsParametersFilled)
             {
                 MessageBox.Show("Перед отправкой задания Вы должны заполнить параметры сессии");
                 return;
             }
             if (session.status != Session.Status.creating)
             {
                 MessageBox.Show("Вы уже отправили задание!");
                 return;
             }
            var result = MessageBox.Show("Вы уверены, что хотите отправить файл с заданием?", "", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.No || result == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                if (!File.Exists(session.path_to_pasca) || !File.Exists(session.Authors_File))
                {
                    MessageBox.Show("Файлы, необходимые для работы приложения, были перемещены или удалены!\nОтправка задания невозможна!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить действие! Закройте файлы программы и повторите попытку.");
                return;
            }
            try
            {
                if (!File.Exists(session.Task_File))
                {
                    MessageBox.Show("Файл с заданием был перемещен или удален!\nВыберите повторно необходимый файл в параметрах и повторите попытку!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить действие! Закройте файл с заданием и повторите попытку.");
                return;
            }
            try
            {
                Run_SendTask();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("В стороннем приложении произошла ошибка! Повторите попытку позже.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("В приложении произошла ошибка! Повторите попытку позже");
                return;
            }
            session.status = Session.Status.sending_task;
            MessageBox.Show("Файл с заданием был успешно отправлен!");
        }
        private void But_SetupParameters_Click(object sender, EventArgs e)
        {
            if (session.status != Session.Status.creating)
            {
                MessageBox.Show("Вы не можете изменять параметры после начала сессии!");
                return;
            }
            if (checkedListBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите режим проведения сессии!");
                return;
            }
            Parameteres params_form;
            try
            {
                params_form = new Parameteres(session);
            }
            catch
            {
                MessageBox.Show("При открытии окна параметров произошла ошибка! Повторите попытку позже.");
                return;
            }
            params_form.Show();
        }
        //запускаем рандомизацию и предшествующие макросы
        void Run_SendTask()
        {
            Run_Macros("But_PrepareAutFile");
            Run_Macros("But_AutFileNormalizeNames");
            //здесь метод для адаптивной рандомизации и внесения изменений в лист рандомизации
            Run_Macros("But_RandomizeAutFile");
            Run_Macros("But_SenTaskMessage");
        }

        private void But_Dow_Subs_Click(object sender, EventArgs e)
        {
            if (session.status == Session.Status.creating)
            {
                MessageBox.Show("Вы не отправили задание!");
                return;
            }
            if (session.status != Session.Status.sending_task)
            {
                MessageBox.Show("Вы уже загрузили решения!");
                return;
            }
            try
            {
                Run_Macros("But_DownloadSubmissions");
                Run_Macros("But_MapSubmissions");
                Run_Macros("But_AnonymizeArtifacts");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("В работе файла приложения произошла ошибка!\nПовторите попытку позже.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("В работе приложения произошла ошибка!\nПовторите попытку позже.");
                return;
            }
            session.status = Session.Status.receiving_subs;
            try
            {
                GetEmptyGuids();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("В стороннем приложении произошла ошибка! Повторите попытку позже.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("В приложении произошла ошибка! Повторите попытку позже.");
                return;
            }
            MessageBox.Show("Файлы успешны загружены!");
        }
        //собираем пустые гиды
        void GetEmptyGuids()
        {
            Excel.Application excel_app = new Excel.Application();
            Excel.Workbook excel_workbook = excel_app.Workbooks.Open(session.Authors_File);
            Excel.Worksheet SubsSheet = excel_workbook.Sheets[6];
            Excel.Worksheet GuidsSheet = excel_workbook.Sheets[3];
            Excel.Worksheet RevSheet = excel_workbook.Sheets["Reviews"];
            session.empty_guids_subs = new List<string>();
            try
            {
                for (int i = 0; i < session.Authors_Count; i++)
                {
                    if (SubsSheet.Cells[i + 2, 3].Value == null)
                    {
                        for (int j = 0; j < session.Authors_Count * session.OneAuthor_Count; j++)
                        {
                            if (RevSheet.Cells[j + 2, 4].Value.ToString() == SubsSheet.Cells[i + 2, 2].Value.ToString())
                            {
                                GuidsSheet.Cells[j + 2, 5].Value = "0";
                                session.empty_guids_subs.Add(GuidsSheet.Cells[j + 2, 4].Value.ToString());
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("При выполнении действия возникла ошибка. Повторите попытку позже.");
                return;
            }
            finally
            {
                excel_workbook.Close(true);
                excel_app.Quit();
                excel_app = null;
                excel_workbook = null;
                SubsSheet = null;
            }
        }
        void Run_Macros(string macros)
        {
            Excel.Application excel_app = new Excel.Application();
            Excel.Workbook excel_workbook = excel_app.Workbooks.Open(session.path_to_pasca);
            Excel.Worksheet MainBook = excel_workbook.Sheets[1];
            excel_app.Run(macros);
            excel_workbook.Close(true);
            excel_app.Quit();
            excel_app = null;
            excel_workbook = null;
            MainBook = null;
        }

        private void But_SendPRForms_Click(object sender, EventArgs e)
        {
            if (session.status == Session.Status.creating)
             {
                 MessageBox.Show("Сессия ещё не начата!");
                 return;
             }
             if (session.status == Session.Status.sending_task)
             {
                 MessageBox.Show("Сперва загрузите решения!");
                 return;
             }
             if (session.status != Session.Status.receiving_subs)
             {
                 MessageBox.Show("Вы уже отправляли оценочные формы!");
                 return;
             }
            try
            {
                Run_Macros("But_SendReviewForms");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            session.status = Session.Status.sending_prforms;
            MessageBox.Show("Оценочные формы были успешно отправлены!");
        }

        private void But_Down_PRForms_Click(object sender, EventArgs e)
        {
             if (session.status == Session.Status.creating)
             {
                 MessageBox.Show("Действие в даннный момент недоступно: Вы не начали сессию!");
                 return;
             }
             if (session.status == Session.Status.sending_task)
             {
                 MessageBox.Show("Действие в даннный момент недоступно: Вы не загрузили решения!");
                 return;
             }
             if (session.status != Session.Status.sending_prforms)
             {
                 MessageBox.Show("Действие в даннный момент недоступно: Вы уже загрузили оценочные формы!");
                 return;
             }
            try
            {
                Run_Macros("But_DownloadReviews");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Оценочные формы были успешно загружены! ");
            session.status = Session.Status.receiving_prforms;
            AddMailing add;
            try
            {
                add = new AddMailing(session);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("В стороннем приложении произошла ошибка! Повторите попытку позже.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("В приложении произошла ошибка! Повторите попытку позже.");
                return;
            }
            string s = "";
            if (add.IsthereEmptySubs())
            {
                s = "При формировании результатов были обнаружены непроверенные работы!";
                if (add.IsthereRightPeers())
                {
                    s += "\nХотите ли вы осуществить дополнительную рассылку?\nДаты сбора оценочных форм и отправки результатов будут сдвинуты на соответствующий срок.";
                    var result = MessageBox.Show(s, "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TimeSpan delta = session.Review_End - session.Review_Begin;
                        session.Review_End = session.Review_End + delta;
                        session.ResultMessage = session.ResultMessage + delta;
                        try
                        {
                            session.SetupParams();
                            add.DoAddMail();
                        }
                        catch
                        {
                            MessageBox.Show("При дополнительной рассылке произошла ошибка!");
                            return;
                        }
                        MessageBox.Show("Дополнительная рассылка оценочных форм произошла успешно!");
                        session.status = Session.Status.sending_prforms;
                    }
                }
                else
                {
                    s += "Никто из участников сессии не принял участие в оценивании.";
                    MessageBox.Show(s);
                }
            MessageBox.Show("Дополнительная рассылка оценочных форм произошла успешно!");

        }
        }

        private void Gen_Report_Click(object sender, EventArgs e)
        {
            if (session.status == Session.Status.creating)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы не начали сессию!");
                return;
            }
            if (session.status == Session.Status.sending_task)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы не загрузили решения!");
                return;
            }
            if (session.status == Session.Status.receiving_subs)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы не отправили оценочные формы!");
                return;
            }
            if (session.status == Session.Status.sending_prforms)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы не загрузили оценочные формы!");
                return;
            }
            if (session.status != Session.Status.receiving_prforms)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы уже сгенерировали отчёт!");
                return;
            }
            try
            {
                Run_Macros("But_ReportFinalMarks");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("При генерации отчёта возникла ошибка в excel!\nПовторите попытку позже!");
                return;
            }
            catch (Exception)
            { 
                MessageBox.Show("При генерации отчёта возникла непредвиденная ошибка!\nПовторите попытку позже!");
                return;
            }
            System.IO.DirectoryInfo folder;
            try
            {
                folder = new DirectoryInfo(session.Folder_path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Папка с сессионными файлами была удалена!");
                return;
            }
            foreach (FileInfo file in folder.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch
                {
                }
            }
            foreach (DirectoryInfo fold in folder.GetDirectories())
            {
                try
                {
                    fold.Delete(true);
                }
                catch
                {
                }
            }
            But_Results.Visible = true;
            session.mas_results = new string[session.Authors_Count, 2];
            try
            {
                Excel.Application excel_app = new Excel.Application();
                Excel.Workbook excel_workbook = excel_app.Workbooks.Open(session.Authors_File);
                Excel.Worksheet MainBook = excel_workbook.Sheets["Report_Marks"];
                for (int i = 0; i < session.mas_results.GetLength(0); i++)
                {
                    for (int j = 0; j < session.mas_results.GetLength(1); j++)
                    {
                        session.mas_results[i, j] = MainBook.Cells[i + 2, j + 2].Value.ToString();
                    }
                }
                excel_workbook.Close(true);
                excel_app.Quit();
                excel_app = null;
                excel_workbook = null;
                MainBook = null;
            }
            catch
            {
                MessageBox.Show("При генерации отчета произошла ошибка! Повторите попытку позже.");
                return;
            }
            session.status = Session.Status.generate_res;
            MessageBox.Show("Отчёт был успешно сгенерирован!");
        }

        private void But_SendResults_Click(object sender, EventArgs e)
        {
            if (session.status == Session.Status.creating)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы не начали сессию!");
                return;
            }
            if (session.status == Session.Status.sending_task)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы не загрузили решения!");
                return;
            }
            if (session.status == Session.Status.receiving_subs)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы не отправили оценочные формы!");
                return;
            }
            if (session.status == Session.Status.sending_prforms)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы не загрузили оценочные формы!");
                return;
            }
            if (session.status != Session.Status.generate_res)
            {
                MessageBox.Show("Действие в даннный момент недоступно: Вы не сгенерировали отчёт!");
                return;
            }
            try
            {
                Run_Macros("But_SendReviewResult");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            session.status = Session.Status.send_result;
            MessageBox.Show("Результаты успешно отправлены!\nСессия проведена успешно!");
            //добавляем объект в файл с объектами
            BinaryFormatter bin = new BinaryFormatter();
            List<Session> sess = new List<Session>();
            try
            {
                if (File.Exists(@"prev_sessions.txt"))
                {
                    using (FileStream f = new FileStream(@"prev_sessions.txt", FileMode.Open))
                    {
                        sess = (List<Session>)bin.Deserialize(f);
                    }
                }
            }
            catch
            {
                MessageBox.Show("При активации предыдущих сессиий произошла ошибка!");
                return;
            }
            sess.Add(session);
            try
            {
                using (FileStream f = new FileStream(@"prev_sessions.txt", FileMode.Create))
                {
                    bin.Serialize(f, sess);
                }
            }
            catch
            {
                MessageBox.Show("При добавлении сессии в архив произошла ошибка!");
                return;
            }
        }

        private void But_Results_Click(object sender, EventArgs e)
        {
            Results form_res = null;
            try
            {
                form_res = new Results(session);
            }
            catch (Exception)
            {
                MessageBox.Show("При попытке открытия результатов произошла ошибка!\nПовторите попытку позже.");
                return;
            }
            form_res.Show();
        }

        private void but_CreatePeers_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex != 0)
            {
                MessageBox.Show("Недоступно при текущем режиме сессии!");
                return;
            }
            if (session.status != Session.Status.creating)
            {
                MessageBox.Show("Вы не можете изменять информацию об авторах после начала сессии!");
                return;
            }
            session.mode = Session.Mode.newpeers;
            CreatingAuthors form;
            try
            {
                if (!File.Exists(session.Authors_File) || !File.Exists(session.path_to_pasca))
                {
                    MessageBox.Show("Файл с авторами был перемещён или удалён!\nТекущая сессия будет удалена, приложение будет закрыто.");
                    DeleteSession();
                    main_form.Close();
                }
                else
                {
                    form = new CreatingAuthors(session, true);
                    form.Show();
                }
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить действие. Закройте файлы программы и повторите попытку позже.");
                return;
            }
        }
    }
    
}
