using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BİLGİSAYAR_SATIS_OTOMASYONU
{
    internal class veritabani
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;
        static SqlDataAdapter da;
        static DataSet ds;

        public static string sqlcon = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        public static DataGridView gridtumunudoldur(DataGridView gridim, string sqlsorgu)
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("Select * from " + sqlsorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sqlsorgu);
            gridim.DataSource = ds.Tables[sqlsorgu];
            con.Close();
            return gridim;
        }


        public static bool loginkontrol(string kulanıcıadı, string sifre)
        {
            string sorgu = "select * from tbl_login where KULANİCİ=@user and SİFRE=@pass";
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", kulanıcıadı);
            cmd.Parameters.AddWithValue("@pass", veritabani.Md5sifreleme(sifre));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;

            }

        }

        public static bool loginkontrolyönetici(string kulanıcıadı, string sifre)
        {
            string sorgu = "select * from tbl_yöneticilogin where Yönetici=@user and Sifre=@pass";
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", kulanıcıadı);
            cmd.Parameters.AddWithValue("@pass",  veritabani.Md5sifreleme(sifre));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;

            }

        }
        public static string Md5sifreleme(string sifrelenicekmetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenicekmetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in dizi)
                sb.Append(b.ToString("x2").ToLower());
            return sb.ToString();
        }

    }
}
