using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace SessionLib
{
    public class AddMailing
    {
        public List<Peer> peers; //правильные оценщики
        public List<string> guids;//гиды непроверенных работ
        static Random rand = new Random();
        Session session;
        public AddMailing(Session ses)
        {
            session = ses;
            GetRightPeers(session.Authors_File);
            GetGuids(session.Authors_File);
        }
        //собираем людей, которые проверили хотя бы одну работу
        public bool IsthereEmptySubs()
        {
            if (guids == null || guids.Count == 0)
                return false;
            return true;
        }
        public bool IsthereRightPeers()
        {
            if (guids == null || guids.Count == 0)
                return false;
            return true;
        }
        public void GetRightPeers(string file)
        {
            peers = new List<Peer>();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook Book = null;
            Excel.Worksheet SheetRes = null;
            Book = xlApp.Workbooks.Open(file);
            int cur_ind = 0;
            Excel.Worksheet SheetRevs = null;
            Excel.Worksheet SheetPeers = null;
            SheetRes = Book.Sheets["Results"];
            SheetRevs = Book.Sheets["Reviews"];
            SheetPeers = Book.Sheets["Peers"];
            int index;
            for (int i = 0; i < SheetRevs.UsedRange.Rows.Count; i++)
            {
                if (SheetRes.Cells[i + 2, 2].Value != null)
                {
                    index = IsInList(SheetRes.Cells[i + 2, 3].Value.ToString());
                    if (index == -1)
                    {
                        peers.Add(new Peer(SheetRes.Cells[i + 2, 3].Value.ToString(), SheetRevs.Cells[i + 2, 4].Value.ToString()));
                        //метод, добавляющий собственный индентификатор
                        for (int j = 0; j < session.Authors_Count * session.OneAuthor_Count - 1; j++)
                        {
                            if (SheetRevs.Cells[j + 2, 3].Value.ToString() == peers[cur_ind].Peer_id)
                            {
                                peers[cur_ind].old_guids.Add(SheetRevs.Cells[j + 2, 4].Value.ToString());
                                break;
                            }
                        }
                        //email
                        for (int k = 2; k <= xlApp.WorksheetFunction.Count(SheetPeers.Columns[2]) + 1; k++)
                        {
                            if (SheetPeers.Cells[k, 2].Value.ToString() == peers[cur_ind].Peer_id)
                                peers[cur_ind].email = SheetPeers.Cells[k, 8].Value.ToString();
                        }
                        cur_ind++;
                    }
                    else
                    {
                        peers[index].old_guids.Add(SheetRevs.Cells[i + 2, 4].Value.ToString());
                    }
                }
            }
            Book.Close(true);
            xlApp.Quit();
            Book = null;
            SheetRes = null;
        }
        //для проверки, не было ли такого оценщика ранее, если был, то возвращаем индекс его места,  иначе -1
        int IsInList(string s)
        {
            if (peers.Count == 0)
                return -1;
            for (int i = 0; i < peers.Count; i++)
            {
                if (s == peers[i].Peer_id)
                    return i;
            }
            return -1;
        }
        //метод сбора неоцененных работ(их гидов)
        public void GetGuids(string file)
        {
            guids = new List<string>();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook Book = null;
            Excel.Worksheet SheetRes = null;
            Excel.Worksheet SheetRevs = null;
            Book = xlApp.Workbooks.Open(file);
            SheetRes = Book.Sheets["Results"];
            SheetRevs = Book.Sheets["Reviews"];
            for (int i = 0; i < SheetRevs.UsedRange.Rows.Count - 1; i++)
            {
                if (SheetRes.Cells[i + 2, 2].Value == null)
                {
                    guids.Add(SheetRevs.Cells[i + 2, 4].Value.ToString());
                }
            }
            Book.Close(true);
            xlApp.Quit();
            Book = null;
            SheetRes = null;
            SheetRevs = null;
            for (int i = 0; i < session.empty_guids_subs.Count; i++)
            {
                guids.RemoveAll(k => k == session.empty_guids_subs[i]);
            }
        }

        public void DoAddMail()
        {
            GetMappedPeers();//распределили работы по проверяющим
            ChangeReviewList();//заносим данные в эксель
            SendEmails();
        }
        //отправляем каждому необходимые работы
        void SendEmails()
        {
            string prform_path;
            for (int i = 0; i < peers.Count; i++)
            {
                for (int j = 0; j < peers[i].new_guids.Count; j++)
                {
                    prform_path = session.Folder_path + @"\Review " + peers[i].guids_ID[j] + ".xlsm";
                    File.Copy(@"..\..\..\PATemplate_Example.xlsm", prform_path);
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook Book = xlApp.Workbooks.Open(prform_path);
                    Excel.Worksheet Sheet = Book.Sheets[1];
                    Sheet.Cells[1, 2] = peers[i].prform_IDs[j];
                    Book.Close(true);
                    xlApp.Quit();
                    Book = null;
                    Sheet = null;
                    Microsoft.Office.Interop.Outlook._Application _app = new Microsoft.Office.Interop.Outlook.Application();
                    Microsoft.Office.Interop.Outlook.MailItem mail = (Microsoft.Office.Interop.Outlook.MailItem)_app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                    mail.To = peers[i].email;
                    mail.Subject = peers[i].prform_IDs[j] + " review for " + session.TaskTitle + peers[i].new_guids[j];
                    mail.Body = "Hello!"
       + "\n" + "\t" + "Please see attached files." + "\n" + "Reply to this message with attached complete PR form (" + peers[i].prform_IDs[j] + ".xlsm) only."
       + "\n" + "Deadline for reviews is " + session.Review_End + "."
       + "\n\t" + "Truly yours, Peer Review Robot.";
                    mail.Attachments.Add(prform_path);
                    mail.Attachments.Add(Directory.GetFiles(session.Folder_path, $"{peers[i].new_guids[j]}*")[0]);
                    mail.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceNormal;
                    Outlook.Account account = GetOutlookAccount(_app, session.OutlookAccount);
                    mail.SendUsingAccount = account;
                    mail.Send();
                    _app.Quit();
                    _app = null;
                    mail = null;
                    File.Delete(prform_path);
                }
            }
        }
        public static Outlook.Account GetOutlookAccount(Outlook._Application application, string email)
        {
            Outlook.Accounts accounts = application.Session.Accounts;
            foreach (Outlook.Account account in accounts)
            {
                if (account.SmtpAddress == email)
                {
                    return account;
                }
            }
            return null;
        }
        //метод, находящий по гиду проверяющего
        //проверяем также, что мы берем следующего проверяющего этой работы
        Peer FindPeer(string s, List<string> list)
        {
            for (int i = 0; i < peers.Count; i++)
            {
                if (peers[i].new_guids.Contains(s) && !list.Contains(peers[i].Peer_id))
                    return peers[i];
            }
            return null;
        }

        //метод, меняющий в экселе в листе Reviews проверяющих
        void ChangeReviewList()
        {
            string guid;
            Peer peer;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook Book = xlApp.Workbooks.Open(session.Authors_File);
            Excel.Worksheet SheetRes = Book.Sheets["Results"];
            Excel.Worksheet SheetRevs = Book.Sheets["Reviews"];
            Excel.Worksheet SheetGuids = Book.Sheets["GUIDS"];
            for (int i = 2; i <= SheetRevs.UsedRange.Rows.Count; i++)
            {
                if (SheetRes.Cells[i, 2].Value == null)
                {
                    guid = SheetRevs.Cells[i, 4].Value.ToString();
                    List<string> oneguid_peers = new List<string>();//массив проверяющих одного гида
                    for (int j = 2; j < i; j++)
                    {
                        if (SheetRevs.Cells[j, 4].Value.ToString() == guid)
                            oneguid_peers.Add(SheetRevs.Cells[j, 2].Value.ToString());
                    }
                    peer = FindPeer(guid, oneguid_peers);
                    SheetRevs.Cells[i, 2].Value = peer.Peer_id;
                    peer.prform_IDs[peer.new_guids.IndexOf(guid)] = SheetRevs.Cells[i, 1].Value.ToString();
                    peer.guids_ID[peer.new_guids.IndexOf(guid)] = SheetGuids.Cells[i, 4].Value.ToString();
                }
            }
            Book.Close(true);
            xlApp.Quit();
            Book = null;
            SheetRes = null;
            SheetRevs = null;
        }
        void GetMappedPeers()
        {
            for (int i = 0; i < peers.Count; i++)
            {
                peers[i].new_guids = new List<string>(peers[i].new_guids.Count);
            }
            int count = guids.Count / peers.Count;
            for (int i = 1; i <= count; i++)
            {
                MixGuids();//перемешали гиды
                MapPeerwithGuid();//добавили проверяющим по одной работе
            }
            //здесь случай, когда гидов меньше чем проверяющих
            //нужно выбрать из проверяющих необходимое кол-во человек
            if (guids.Count % peers.Count != 0)
            {
                int[] index_mas = GetIndexs(guids.Count);
                MapPeerwithGuid(index_mas);
            }
            for (int i = 0; i < peers.Count; i++)
            {
                peers[i].InitIDs();
            }
        }
        //метод, возвращающий массив индексов необходимого размера
        int[] GetIndexs(int n)
        {
            int ind;
            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                do
                {
                    ind = rand.Next(peers.Count);
                }
                while (mas.Contains(ind));
                mas[i] = ind;
            }
            return mas;
        }
        //для последней партии определяем работы
        void MapPeerwithGuid(int[] mas)
        {
            int count;
            for (int i = 0; i < mas.Length; i++)
            {
                count = 0;
                while ((peers[mas[i]].old_guids.Contains(guids[0]) || peers[mas[i]].new_guids.Contains(guids[0])) && count < 6)
                {
                    MixGuids();
                }
                peers[mas[i]].new_guids.Add(guids[0]);
                guids.RemoveAt(0);
            }
        }
        //метод, сопоставляющий проверяющего с работой
        void MapPeerwithGuid()
        {
            int count;
            for (int i = 0; i < peers.Count; i++)
            {
                count = 0;
                while ((peers[i].old_guids.Contains(guids[0]) || peers[i].new_guids.Contains(guids[0])) && count < 6)
                {
                    MixGuids();
                    count++;
                }
                peers[i].new_guids.Add(guids[0]);
                guids.RemoveAt(0);
            }
        }
        //метод, перемешивающий массив оценщиков
        void MixGuids()
        {
            for (int i = guids.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i);
                var temp = guids[j];
                guids[j] = guids[i];
                guids[i] = temp;
            }
        }
    }
}
