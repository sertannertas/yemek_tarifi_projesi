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

namespace yemek_tarifi_projesi
{
    public partial class yemek_kayit : Form
    {
        SqlConnection baglanti;
        SqlDataAdapter da;
        SqlCommand komut;
        DataTable dt;

        public yemek_kayit()
        {
            InitializeComponent();
        }

        void Tablo_listele()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-VA00J7V;Initial Catalog=yemek_tarifi;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("Select * from yemek",baglanti);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void yemek_kayit_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void yemek_kayit_Load(object sender, EventArgs e)
        {
            Tablo_listele();
        }

        private void sec_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            textBox4.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void button2_Click(object sender, EventArgs e)//Kaydet
        {
            string kaydet = "Insert into yemek(yemek_ad,malzemeler,tarif,resim)values(@yemek_ad,@malzemeler,@tarif,@resim)";
            komut = new SqlCommand(kaydet,baglanti);
            komut.Parameters.AddWithValue("@yemek_ad",textBox1.Text);
            komut.Parameters.AddWithValue("@malzemeler",textBox2.Text);
            komut.Parameters.AddWithValue("@tarif", textBox3.Text);
            komut.Parameters.AddWithValue("@resim", textBox4.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Tablo_listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kaydet = "Update yemek Set yemek_ad=@yemek_ad,malzemeler=@malzemeler,tarif=@tarif,resim=@resim Where yemek_id=@yemek_id";
            komut = new SqlCommand(kaydet, baglanti);
            komut.Parameters.AddWithValue("@yemek_ad", textBox1.Text);
            komut.Parameters.AddWithValue("@malzemeler", textBox2.Text);
            komut.Parameters.AddWithValue("@tarif", textBox3.Text);
            komut.Parameters.AddWithValue("@resim", textBox4.Text);
            komut.Parameters.AddWithValue("@yemek_id", textBox5.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Tablo_listele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From yemek Where yemek_id=@yemek_id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemek_id", (dataGridView1.CurrentRow.Cells[0].Value));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Tablo_listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text =textBox5.Text= "";
            pictureBox1.ImageLocation = @"C:\Users\Oresta\Documents\Visual Studio 2015\Projects\yemek_tarifi_projesi\yemek_tarifi_projesi\bin\Debug\Adsız.png";
        }

        
    }
}
