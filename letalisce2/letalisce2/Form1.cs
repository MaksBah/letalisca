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
            polnjenje();
            
        }
        string connect = Baza.connect();

        private void Form1_Load(object sender, EventArgs e)
        {
            

        } 
        public void polnjenje()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM izpisletalisca();", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(new object[] { reader.GetString(0), reader.GetString(1), reader.GetString(2) });

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string imel = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            if (e.ColumnIndex == 4)
            {
                Baza.deleteletalisce(imel);
                polnjenje();
            }
            if (e.ColumnIndex == 3)
            {
                Form2 form = new Form2(imel);
                form.Show();
                this.Hide();
            }
            if (e.ColumnIndex == 5)
            {
                Baza.deleteletalisce(imel);
                polnjenje();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
