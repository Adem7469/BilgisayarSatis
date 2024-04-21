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
    public partial class kulanıcırapor : Form
    {
        SqlConnection con;
        
        SqlDataAdapter da;
        DataSet ds;
        static string sqlcon = veritabani.sqlcon;
        string sqlsorgu;
        void griddoldur(string sql)
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public kulanıcırapor()
        {
            InitializeComponent();
        }

        private void kulanıcırapor_Load(object sender, EventArgs e)
        {
            sqlsorgu = "select tbl_islemler.*, tbl_sparisler.* from tbl_islemler INNER JOIN tbl_sparisler ON tbl_islemler.ÜrünKodu = tbl_sparisler.Siparisi";
            griddoldur(sqlsorgu);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                 sqlsorgu = "select tbl_islemler.ÜrünAdı, tbl_islemler.ÜrünFiyatı, tbl_islemler.ÜrünAdeti, tbl_islemler.ÜrünMarkası, tbl_islemler.ÜrünTürü, tbl_sparisler.* from tbl_islemler INNER JOIN tbl_sparisler ON tbl_islemler.ÜrünKodu = tbl_sparisler.Siparisi where tbl_sparisler.MüsteriAdi like '%" + textBox1.Text + "%'" ;
                griddoldur(sqlsorgu);
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Raporgöster a = new Raporgöster();
            a.kulanıcı=textBox1.Text;
            a.ds = ds;
            a.Show();
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Ürünler Ü = new Ürünler();
            Ü.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
