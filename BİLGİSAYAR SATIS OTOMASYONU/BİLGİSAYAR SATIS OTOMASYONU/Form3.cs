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
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        static string sqlcon = veritabani.sqlcon;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            string sql = "insert into tbl_sparisler(MüsteriAdi, MüsteriSoyadi, TelefonNO, MüsteriAdresi,Siparisi, SiparisTarihi, SiparisAdeti, SiparisTutarı) values (@ad,@soyad,@no,@adres,@siparis,@tarih,@adet,@tutar)";
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@adres", textBox4.Text);
            cmd.Parameters.AddWithValue("@no", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@siparis", textBox5.Text);
            cmd.Parameters.AddWithValue("@adet", textBox3.Text);
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            cmd.Parameters.AddWithValue("@tutar", label10.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Siparisiniz Alinmistir");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            veritabani.gridtumunudoldur(dataGridView1, "tbl_islemler");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                label10.Text = (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(label10.Text)).ToString();
            }
        }
        void griddoldur(String sql)
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();

            da.Fill(ds, "tbl_islemler");
            dataGridView1.DataSource = ds.Tables["tbl_islemler"];
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                string sqlsorgu = "select * from tbl_islemler where ÜrünTürü like '%" + textBox6.Text + "%' order by ÜrünTürü ASC";
                griddoldur(sqlsorgu);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
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

        private void siparişlerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Sparislerim form = new Sparislerim();
            form.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
