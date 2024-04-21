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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        static string sqlcon = veritabani.sqlcon;
        void griddoldur()
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("Select*from tbl_login", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "select*from tbl_login");
            dataGridView1.DataSource = ds.Tables["select*from tbl_login"];
            con.Close();
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "insert into tbl_login(KULANİCİ, SİFRE, TARİH) values (@user,@pass,@tarih)";
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", veritabani.Md5sifreleme(textBox3.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            MessageBox.Show("Kulanıcı Eklendi");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            veritabani.gridtumunudoldur(dataGridView1, "tbl_login");
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Kulanıcı Adı";
            dataGridView1.Columns[3].HeaderText = "Songiris Tarihi";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            string sql = "delete from tbl_login where KULANİCİ=@user and SİFRE=@pass";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", textBox3.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            MessageBox.Show("Kulanıcı Silindi");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "update tbl_login set SİFRE=@pass where KULANİCİ=@user and KID=@kıd";
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", veritabani.Md5sifreleme(textBox3.Text));
            cmd.Parameters.AddWithValue("@kıd", Convert.ToInt32(textBox1.Text));
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            MessageBox.Show("Kulanıcı güncelendi");
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
            Form1 form = new Form1();
            form.Show(); 
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void yöneticilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Yöneticiler y=new Yöneticiler();
            y.Show();
        }

        private void sparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
          this.Hide();
            Ürünler Ü = new Ürünler();
            Ü.Show();
        }

        private void ürünlerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
