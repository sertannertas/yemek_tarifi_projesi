using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemek_tarifi_projesi
{
    public partial class ana_menu : Form
    {
        public ana_menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yemek_kayit yeni = new yemek_kayit();
            yeni.Show();   
        }

      

        private void ana_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
