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
    public partial class Yenikayıt : Form
    {
        SqlConnection con;
        SqlCommand cmd;

        static string sqlcon = veritabani.sqlcon;
        public Yenikayıt()
        {
            InitializeComponent();
        }

        private void Yenikayıt_Load(object sender, EventArgs e)
        {

        }
        public void yenikayıt()
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "insert into tbl_login(KULANİCİ, SİFRE, TARİH) values (@user,@pass,@tarih)";
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", veritabani.Md5sifreleme(textBox2.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
               if(textBox2.Text !="")
                {
                    if(textBox2.Text ==textBox3.Text)
                    {
                        yenikayıt();
                        MessageBox.Show("Kaydınız alınmıştır");
                    }
                    else
                    {
                        label4.Text = "Şifre ve şifre tekrarı aynı değil";
                    }
                }
                else
                {
                    label4.Text = "Şifre Boş Geçilemez";
                }
            }
            else
            {
                label4.Text = "Lütfen Kulanıcı Adını Girin";
            }
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
