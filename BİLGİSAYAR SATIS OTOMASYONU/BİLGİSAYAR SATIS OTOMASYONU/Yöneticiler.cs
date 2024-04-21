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
    public partial class Yöneticiler : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        static string sqlcon = veritabani.sqlcon;
        public Yöneticiler()
        {
            InitializeComponent();
        }
        void griddoldur()
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("Select*from tbl_yöneticilogin", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "select*from tbl_yöneticilogin");
            dataGridView1.DataSource = ds.Tables["select*from tbl_yöneticilogin"];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           dateTimePicker1.Value=DateTime.Now;


        }

        private void Yöneticiler_Load(object sender, EventArgs e)
        {
            veritabani.gridtumunudoldur(dataGridView1, "tbl_yöneticilogin");
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Yönetici Adı";
            dataGridView1.Columns[3].HeaderText = "Songiris Tarihi";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "insert into tbl_yöneticilogin(Yönetici, Sifre, Tarih) values (@user,@pass,@tarih)";
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", veritabani.Md5sifreleme(textBox3.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            MessageBox.Show("Yönetici Eklendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            string sql = "delete from tbl_yöneticilogin where Yönetici=@user and Sifre=@pass";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", textBox3.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            MessageBox.Show("Yönetici Silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "update tbl_yöneticilogin set Sifre=@pass where Yönetici=@user";
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", veritabani.Md5sifreleme(textBox3.Text));

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            MessageBox.Show("Yönetici Güncelendi");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
