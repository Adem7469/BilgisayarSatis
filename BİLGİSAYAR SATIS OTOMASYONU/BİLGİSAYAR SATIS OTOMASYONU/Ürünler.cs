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
    public partial class Ürünler : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        static string sqlcon = veritabani.sqlcon;
        public Ürünler()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }
        
        private void Ürünler_Load(object sender, EventArgs e)
        {
            veritabani.gridtumunudoldur(dataGridView1, "tbl_islemler");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            
           

        }

        private void button6_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox7.Text = openFileDialog1.FileName;

            
                
        }
        void griddoldur()
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("Select*from tbl_islemler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "select*from tbl_islemmler");
            dataGridView1.DataSource = ds.Tables["select*from tbl_islemler"];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "insert into tbl_islemler(ÜrünAdı, ÜrünKodu, ÜrünFiyatı, ÜrünAdeti, ÜrünMarkası, ÜrünTürü, ÜrrünResmi) values (@adı,@kodu,@fiyatı,@adeti,@markası,@türü,@resmi)";
            cmd.Parameters.AddWithValue("@adı", textBox1.Text);
            cmd.Parameters.AddWithValue("@kodu", textBox2.Text);
            cmd.Parameters.AddWithValue("@fiyatı", textBox3.Text);
            cmd.Parameters.AddWithValue("@adeti", textBox4.Text);
            cmd.Parameters.AddWithValue("@markası", textBox5.Text);
            cmd.Parameters.AddWithValue("@türü", textBox6.Text);
            cmd.Parameters.AddWithValue("@resmi", textBox7.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            veritabani.gridtumunudoldur(dataGridView1, "tbl_islemler");
            MessageBox.Show("ÜRÜN EKLENDİ");
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "delete from tbl_islemler where ÜrünAdı=@adı and ÜrünKodu=@kodu and ÜrünFiyatı=@fiyatı and ÜrünAdeti=@adeti and ÜrünMarkası=@markası and ÜrünTürü=@türü and ÜrrünResmi=@resmi";
            cmd.Parameters.AddWithValue("@adı", textBox1.Text);
            cmd.Parameters.AddWithValue("@kodu", textBox2.Text);
            cmd.Parameters.AddWithValue("@fiyatı", textBox3.Text);
            cmd.Parameters.AddWithValue("@adeti", textBox4.Text);
            cmd.Parameters.AddWithValue("@markası", textBox5.Text);
            cmd.Parameters.AddWithValue("@türü", textBox6.Text);
            cmd.Parameters.AddWithValue("@resmi", textBox7.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            veritabani.gridtumunudoldur(dataGridView1, "tbl_islemler");
            MessageBox.Show("ÜRÜN SİLİNDİ");
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "update tbl_islemler set ÜrünFiyatı=@fiyatı,ÜrünAdeti=@adeti where ÜrünAdı=@adı and ÜrünKodu=@kodu";
            cmd.Parameters.AddWithValue("@adı", textBox1.Text);
            cmd.Parameters.AddWithValue("@kodu", textBox2.Text);
            cmd.Parameters.AddWithValue("@fiyatı", textBox3.Text);
            cmd.Parameters.AddWithValue("@adeti", textBox4.Text);
            cmd.Parameters.AddWithValue("@resmi", textBox7.Text);

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ÜRÜN GÜNCELENDİ");
            veritabani.gridtumunudoldur(dataGridView1, "tbl_islemler");
            
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f2=new Form2();
            f2.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void raporToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sparisler sp = new Sparisler();
            sp.Show();
        }
    }
}
