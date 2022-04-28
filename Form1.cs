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

namespace veritabani_bag_ile_mesajlasma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = (local); Initial Catalog = vt_mesajlasma; Integrated Security = True");
        private void button1_Click(object sender, EventArgs e)
        {
           baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl1 where NUMARA=@P1 and SIFRE=@P2", baglanti);
            komut.Parameters.AddWithValue("@P1", msktxtnum.Text);
            komut.Parameters.AddWithValue("@P2",txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm2 = new Form2();
                frm2.numara = msktxtnum.Text;
                frm2.Show();

            }
            else
            {
                MessageBox.Show("hatali giris yaptiniz");
            }
            baglanti.Close();
        }
    }
}
