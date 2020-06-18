using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLib
{
    public class Peer
    {
        public string Peer_id;//собственное id
        public double koef;
        public string[] prform_IDs;
        public string[] guids_ID;
        public List<string> old_guids = new List<string>();//список проверенных работ
        public List<string> new_guids = new List<string>();//список новых работ для проверки
        public string name;
        public string lastname;
        public string email;
        public Peer(string one, string two)
        {
            Peer_id = one;
            old_guids.Add(two);
        }
        public Peer(string last, string nam, string em)
        {
            lastname = last;
            name = nam;
            email = em;
        }
        public static bool operator ==(Peer one, Peer two)
        {
            if (one.name == two.name && one.lastname == two.lastname && one.email == two.email)
                return true;
            return false;
        }
        public static bool operator !=(Peer one, Peer two)
        {
            if (!(one.name == two.name && one.lastname == two.lastname && one.email == two.email))
                return false;
            return true;
        }
        public void InitIDs()
        {
            prform_IDs = new string[new_guids.Count];
            guids_ID = new string[new_guids.Count];
        }
    }
}
