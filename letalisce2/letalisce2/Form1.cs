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
    public partial class Form1 : Form
    {

        public Form1()

        {
            InitializeComponent();

            
        }
        string connect = Baza.connect();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM izpis;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(new object[] { reader.GetString(1), reader.GetString(2), reader.GetString(3), "Klikni", reader.GetInt32(0) });

                }
                con.Close();
            }

        }

        private void Dodaj_Click(object sender, EventArgs e)
        {
            this.Hide();
            dodaj d = new dodaj();
            d.Show();
           
        }
    }
}
