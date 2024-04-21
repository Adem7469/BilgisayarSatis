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
    public partial class Sparisler : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        static string sqlcon = veritabani.sqlcon;
        public Sparisler()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        void gridbirlestir(String sql)
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();

            da.Fill(ds, "tbl_sparisler");
            dataGridView1.DataSource = ds.Tables["tbl_sparisler"];
            con.Close();
        }
        private void Sparisler_Load(object sender, EventArgs e)
        {
            veritabani.gridtumunudoldur(dataGridView1, "tbl_sparisler");
            string sqlsorgu = "select tbl_islemler.*, tbl_sparisler.* from tbl_islemler INNER JOIN tbl_sparisler ON tbl_islemler.ÜrünKodu = tbl_sparisler.Siparisi";
            gridbirlestir(sqlsorgu);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
           
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        private void raporGösterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            kulanıcırapor r = new kulanıcırapor();
            r.Show();
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Ürünler ür = new Ürünler();
            ür.Show();
        }

        private void kapaatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
