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
    public partial class Sparislerim : Form
    {


        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        static string sqlcon = veritabani.sqlcon;
        string sqlsorgu;
        
        public Sparislerim()
        {
            InitializeComponent();
        }
       

        
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

        private void Sparislerim_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (veritabani.loginkontrol(textBox5.Text, textBox6.Text))
            {
                sqlsorgu = "select * from tbl_sparisler where MüsteriAdi like '%" + textBox5.Text + "%'";
                griddoldur(sqlsorgu);
                
            }
            else
            {
                MessageBox.Show("Şifre veya Kulanıcı adı yanlış");
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "delete from tbl_sparisler where Siparisi=@kodu and SiparisAdeti=@adet and SiparisTutarı=@tutar";
            cmd.Parameters.AddWithValue("@kodu", textBox1.Text);
            cmd.Parameters.AddWithValue("@tarih", textBox2.Text);
            cmd.Parameters.AddWithValue("@adet", textBox3.Text);
            cmd.Parameters.AddWithValue("@tutar", textBox4.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("SİPARİŞİNİZ İPTAL EDİLDİ");
            sqlsorgu = "select * from tbl_sparisler where MüsteriAdi like '%" + textBox5.Text + "%'";
            griddoldur(sqlsorgu);
           
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "update  tbl_sparisler set SiparisAdeti=@adet,SiparisTutarı=@tutar where Siparisi=@ad";
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@tarih", textBox2.Text);
            cmd.Parameters.AddWithValue("@adet", textBox3.Text);
             textBox4.Text = (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(textBox4.Text)).ToString();
           
           
            cmd.Parameters.AddWithValue("@tutar", textBox4.Text);
           

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ÜRÜN GÜNCELENDİ");
            sqlsorgu = "select * from tbl_sparisler where MüsteriAdi like '%" + textBox5.Text + "%'";
            griddoldur(sqlsorgu);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

           

        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
