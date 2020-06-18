using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SessionLib
{
    [Serializable]
    public class Session
    {
        public DateTime Submission_Begin;
        public DateTime Submission_End;
        public DateTime Review_Begin;
        public DateTime Review_End;
        public DateTime ResultMessage;
        public List<Peer> peers; //теккщие оценщики
        public List<Peer> peers_archive; //архив рецензентов
        public string Name;
        public Status status;
        public string Authors_File;
        public string Reports_Path;
        public string Task_File { get; set; }
        public string PRForm_File;
        public string path_to_pasca;
        public string Folder_path;
        public bool IsListFilled;
        public bool IsParametersFilled;
        public int Authors_Count;
        public int OneAuthor_Count;
        public int Peers_Count;
        public string TaskTitle;
        public string OutlookAccount;
        public string[,] mas_results;
        public Mode mode;
        public List<string> empty_guids_subs;
        //лист с параметрами из книги с авторами
        public Session(string path, string name)
        {
            status = Status.creating;
            path_to_pasca = Path.GetFullPath(@"PASCA2_0.79.xlsm");
            //Creating_List_File = @"../../../AuthorsList.xlsm";
            Authors_File = Path.GetFullPath(path);
            SetupAuthorsFile();
            TaskTitle = "MyPASession";
            OutlookAccount = "PeerReviewRobot@outlook.com";
            Name = name;
            empty_guids_subs = new List<string>();
            peers_archive = new List<Peer>();
        }
        public enum Status
        {
            creating=1,
            sending_task,
            receiving_subs,
            sending_prforms,
            receiving_prforms,
            generate_res,
            send_result
        }
        public enum Mode
        {
            newpeers = 1,
            oldpeers
        }
        //НУЖЕН МЕТОД ДЛЯ УСТАНОВКИ ВСЕХ ПАРАМЕТРОВ
        public void SetupAuthorsFile()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet MainBook = null;
            xlWorkBook = xlApp.Workbooks.Open(path_to_pasca);
            MainBook = xlWorkBook.Sheets[1];
            MainBook.Cells[5, 5] = Authors_File;
            xlWorkBook.Close(true);
            xlApp.Quit();
            xlApp = null;
            xlWorkBook = null;
            MainBook = null;
        }
        //ИЗМЕНИТЬ ПРИ НАСТРОЙКАХ РАНДОМИЗАЦИИ
        public void SetupAuthorsCount(int count)
        {
            Authors_Count = count;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook Book = null;
            Excel.Worksheet  Sheet= null;
            Book = xlApp.Workbooks.Open(Authors_File);
            Sheet = Book.Sheets["Params"];
            Sheet.Cells[15, 3] = Authors_Count;
            Sheet.Cells[16, 3] = Authors_Count;
            Book.Close(true);
            xlApp.Quit();
            xlApp = null;
            Book = null;
            Sheet = null;
        }
        public void SetupAuthorsCount(int count, Mode mode)
        {
            Peers_Count = count;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook Book = null;
            Excel.Worksheet Sheet = null;
            Book = xlApp.Workbooks.Open(Authors_File);
            Sheet = Book.Sheets["Params"];
            Sheet.Cells[16, 3] = Peers_Count;
            Book.Close(true);
            xlApp.Quit();
            xlApp = null;
            Book = null;
            Sheet = null;
        }
        public int GetRowsCount()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook Book = xlApp.Workbooks.Open(PRForm_File);
            Excel.Worksheet Sheet = Book.Sheets[1];
            int k = Sheet.UsedRange.Rows.Count - 2;
            Book.Close(true);
            xlApp.Quit();
            xlApp = null;
            Book = null;
            Sheet = null;
            return k;
        }
        public void SetupParams()
        {
            int RowsCount = GetRowsCount();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook Book = xlApp.Workbooks.Open(Authors_File); 
            Excel.Worksheet Sheet = Book.Sheets["Params"];
            Sheet.Cells[6, 3] = Submission_Begin.ToString("dd.MM.yyyy hh:mm");
            Sheet.Cells[7, 3] = Submission_End.ToString("dd.MM.yyyy hh:mm");
            Sheet.Cells[8, 3] = Review_Begin.ToString("dd.MM.yyyy hh:mm");
            Sheet.Cells[9, 3] = Review_End.ToString("dd.MM.yyyy hh:mm");
            Sheet.Cells[10, 3] = ResultMessage.ToString("dd.MM.yyyy hh:mm");
            Sheet.Cells[12, 3] = Task_File;
            Sheet.Cells[13, 3] = PRForm_File;
            Sheet.Cells[14, 3] = RowsCount;
            Sheet.Cells[18, 3] = OneAuthor_Count;
            Sheet.Cells[19, 3] = Folder_path;
            Book.Close(true);
            xlApp.Quit();
            xlApp = null;
            Book = null;
            Sheet = null;
        }
        public void SaveSession()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("current_session.txt", FileMode.Create))
            {
                formatter.Serialize(f, this);
            }
        }
    }
}
