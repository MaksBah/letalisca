﻿using System;
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
            kraj();
            druzba();
        }
        public void kraj()
        {
            List<string> krajizp = Baza.kraji();
            foreach (string x in krajizp)
            {
                krajcombo.Items.Add(x);
            }
        }
        public void druzba()
        {
            List<string> druzbaizp = Baza.druzba();
            foreach (string x in druzbaizp)
            {
                DruzbacomboBox.Items.Add(x);
            }
        }

        private void konbutton_Click(object sender, EventArgs e)
        {
            string imel = textBox1.Text;
            string naslov = naslovtext.Text;
            string druzba = DruzbacomboBox.SelectedItem.ToString();
            string kraj = krajcombo.SelectedItem.ToString();
            string slika = slikabutton.Text;
            string opis = opistext.Text;
            bool ok = Baza.Vnosletal(imel, naslov, druzba,  opis, kraj, slika);
            if (ok == true)
            {
                MessageBox.Show("Vnos je bil uspešen");
                this.Close();
            }
            else
            {
                MessageBox.Show("Vnos ni bil uspešen");
                textBox1.Text = "";
                naslovtext.Text = "";
                krajcombo.SelectedIndex = 0;
                slikabutton.Text = "Dodaj sliko";
                opistext.Text = "";
            }
            this.Hide();
            
        }

        private void dodaj_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void slikabutton_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileend = @"C:\Users\tilen\Pictures\maks";
                    string filepath = openFileDialog1.FileName;
                    string[] lol = filepath.Split('\\');
                    int fin = lol.Length - 1;
                    string filename = lol[fin];
                    fileend = fileend + "\\" + filename;
                    System.IO.File.Copy(filepath, fileend, true);
                    slikabutton.Text = fileend;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dodaj_Load(object sender, EventArgs e)
        {

        }
    }
}
