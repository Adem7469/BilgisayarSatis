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
    public partial class Form1 : Form
    {
       
        static string sqlcon = veritabani.sqlcon;

        public int denemesayisi;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (veritabani.loginkontrol(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Giriş Başarılı");
                this.Hide();
                
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                denemesayisi++;
                if (denemesayisi == 3)
                {
                    MessageBox.Show("3 defa hatalı giriş yaptınız");
                    Application.Exit();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (veritabani.loginkontrolyönetici(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Giriş Başarılı");
                this.Hide();
               Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                denemesayisi++;
                if (denemesayisi == 3)
                {
                    MessageBox.Show("3 defa hatalı giriş yaptınız");
                    Application.Exit();
                }
            }
        }

        private void sifreYenilemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sifreyenileme s=new Sifreyenileme();
            s.Show();
        }

        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Yenikayıt kayıt=new Yenikayıt();
            kayıt.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
 }
