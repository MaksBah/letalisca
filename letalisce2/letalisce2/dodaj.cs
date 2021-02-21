using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace letalisce2
{
    public partial class dodaj : Form
    {
        public dodaj()
        {
            InitializeComponent();
        }

        private void konbutton_Click(object sender, EventArgs e)
        {
            string imel = imelektext.Text;
            string tel = teltext.Text;


            string naslov = naslovtext.Text;
            string[] k = krajcombo.SelectedItem.ToString().Split('|');
            string kraj = k[0];
            string slika = slikabutton.Text;
            string opis = opistext.Text;
            //bool ok = Baza.vnosletal(imel, naslov, druzba, slika, opis);
            //if (ok == true)
            //{
                MessageBox.Show("Vnos je bil uspešen");
                this.Close();
            //}
            //else
            {
                MessageBox.Show("Vnos ni bil uspešen");
                imelektext.Text = "";
                teltext.Text = "";
                naslovtext.Text = "";
                krajcombo.SelectedIndex = 0;
                slikabutton.Text = "Dodaj sliko";
                opistext.Text = "";
            }
        }
    }
}
