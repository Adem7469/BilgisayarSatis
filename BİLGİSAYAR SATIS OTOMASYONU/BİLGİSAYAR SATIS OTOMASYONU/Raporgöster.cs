using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BİLGİSAYAR_SATIS_OTOMASYONU
{
    public partial class Raporgöster : Form
    {
       
       public DataSet ds=new DataSet();
        public string kulanıcı;
        static string sqlcon = veritabani.sqlcon;
        public Raporgöster()
        {
            InitializeComponent();
        }
        public void rapordoldur()
        {
           

            raporsparis1.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = raporsparis1;
            

            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Raporgöster_Load(object sender, EventArgs e)
        {
            raporsparis1.SetDataSource(ds.Tables[0]);
            raporsparis1.SetParameterValue("KulanıcıAd", kulanıcı);
            crystalReportViewer1.ReportSource = raporsparis1;
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            kulanıcırapor k = new kulanıcırapor();
            k.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
