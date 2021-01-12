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

            using (NpgsqlConnection letalisce = new NpgsqlConnection("Server=rogue.db.elephantsql.com; User Id=bvcpwlka; Password=lrcOYxm8QZLEwrP7qt-qHH9j5xmuzEGL; Database=bvcpwlka"))
            {
                letalisce.Open();

                using (NpgsqlCommand sql = new NpgsqlCommand("SELECT id FROM Kraj", letalisce))
                {
                    NpgsqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        label1.Text += Convert.ToString(reader[1])+" ";
                    }
                }

                letalisce.Close();

                    
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
