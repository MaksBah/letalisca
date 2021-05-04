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
    public partial class uredi : Form
    {
        int id;
        public uredi(int idd)
        {
            InitializeComponent();
            id = idd;
        }
        public void kraj()
        {
            
        }
        public void druzba()
        {
            
        }

        private void uredi_Load(object sender, EventArgs e)
        {
            List<string> druzbaizp = Baza.druzba();
            foreach (string x in druzbaizp)
            {
                DruzbacomboBox.Items.Add(x);
            }
            List<string> krajizp = Baza.kraji();
            foreach (string x in krajizp)
            {
                krajcombo.Items.Add(x);
            }

            List<string> neki = new List<string>();
            neki = Baza.Uredi(id);
            foreach(string i in neki)
            {
                
            }
            string naslov = neki[0];
            string kraj = neki[1];
            string druzba = neki[2];
            string opis = neki[3];
            naslovtext.Text = naslov;
            
        }
    }
}
