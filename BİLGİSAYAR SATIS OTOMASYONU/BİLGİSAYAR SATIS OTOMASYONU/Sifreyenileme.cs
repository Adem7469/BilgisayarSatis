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
    public partial class Sifreyenileme : Form
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;

        static string sqlcon = veritabani.sqlcon;
        public int sonuc = 0;
        public Sifreyenileme()
        {
            InitializeComponent();
        }
        public void sifredegistir()
        {
           string sorgu = "select SİFRE from tbl_login where SİFRE=@pass and KULANİCİ=@user";
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu,con);
            
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", veritabani.Md5sifreleme(textBox2.Text));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con = new SqlConnection(sqlcon);
                cmd = new SqlCommand();
                string sql = "update tbl_login set SİFRE=@pass where KULANİCİ=@user";
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", veritabani.Md5sifreleme(textBox3.Text));
               
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Şifreniz Deşiştirildi");
                label6.Text = "";
            }
            else
            {
                label6.Text = "Eski Şifreniz Hatalıdır...";
                kapcaolustur();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == sonuc.ToString())
            {
                if (textBox3.Text == textBox4.Text)
                {
                    if (textBox1.Text != "")
                    {
                        sifredegistir();
                       

                    }
                    else
                    {
                        label6.Text = "Lütfen Kulanıcı Adını Giriniz";
                        kapcaolustur();
                    }
                }
                else
                {
                    label6.Text = "Yeni şifre ve tekrarı aynı değil";
                    kapcaolustur();
                }

            }
            else
            {
                label6.Text = "Captcha Hatalı Girildi";
                kapcaolustur();
            }
        }
        public void kapcaolustur()
        {
            Random R = new Random();
            R.Next();
            int ilk = R.Next(0, 50);
            int ikinci = R.Next(0, 50);
            sonuc = ilk + ikinci;
            label5.Text = ilk.ToString() + " + " + ikinci.ToString() + " =";
        }

        private void Sifreyenileme_Load(object sender, EventArgs e)
        {
            kapcaolustur();
            label6.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
