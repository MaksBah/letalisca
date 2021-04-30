using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace letalisce2
{
    public partial class Form2 : Form
    {
        string imel;
        public Form2(string ime)
        {
            InitializeComponent();
            imel = ime;
            polnjenje();
        }
        string connect = Baza.connect();
        public void polnjenje()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM glavniIzpis('" + imel + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    labelIme.Text = reader.GetString(0);
                    labelNaslov.Text = reader.GetString(1);
                    labelDruzba.Text = reader.GetString(3);
                    richTextOpis.Text = reader.GetString(2);
                    pictureBox1.Image = Image.FromFile(reader.GetString(4));
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                con.Close();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
