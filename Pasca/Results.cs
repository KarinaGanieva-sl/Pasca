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

namespace Pasca
{
    public partial class Results : Form
    {
        Session session;
        public Results(Session ses)
        {
            InitializeComponent();
            session = ses;
            FillResults();
        }
        void FillResults()
        {
            for (int i = 0; i < session.mas_results.GetLength(0); i++)
            {
                for (int j = 0; j < session.mas_results.GetLength(1); j++)
                {
                   list.Rows[i].Cells[j].Value = session.mas_results[i, j];
                }
            }
        }

        private void Results_Load(object sender, EventArgs e)
        {

        }
    }
}
