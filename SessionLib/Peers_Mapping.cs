using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SessionLib
{
    class Peers_Mapping
    {
        List<Peer> peers;
        List<string> authors  = new List<string>();
        Session session;
        static Random rand = new Random();
        public Peers_Mapping(List<Peer> peer, Session ses)
        {
            peers = peer;
            session = ses;
        }
        //весь процесс
        public void DoAllMapping()
        {
            GetIds();
        }
        //метод, присваивающий идентификаторы проверяющим
        //также формирующий айди авторов и устанавливающий их в эксель
        void GetIds()
        {
            List<string> ids = new List<string>();
            string s;
            for (int i = 0; i < peers.Count; i++)
            {
                do
                {
                    s = ((int)(100000 + 899999 * rand.NextDouble())).ToString();
                }
                while (ids.Contains(s));
                peers[i].Peer_id = s;
                ids.Add(s);
            }
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook Book = null;
            Excel.Worksheet SheetAut = null;
            Book = xlApp.Workbooks.Open(session.Authors_File);
            SheetAut = Book.Sheets["List"];
            for (int i = 0; i < session.Authors_Count; i++)
            {
                do
                {
                    s = ((int)(100000 + 899999 * rand.NextDouble())).ToString();
                }
                while (ids.Contains(s));
                SheetAut.Cells[i + 2, 2] = s;
                ids.Add(s);
                authors.Add(s);
            }
            Book.Close(true);
            xlApp.Quit();
            Book = null;
            SheetAut = null;
        }
        //метод, строящий соотношение
        void GetMapping()
        {
            int iter = session.Authors_Count * session.OneAuthor_Count / peers.Count;

        }
    }
}
