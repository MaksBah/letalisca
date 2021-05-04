using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;

namespace letalisce2
{
    class Baza
    {
        public static string connect()
        {
            var uriString = ConfigurationManager.AppSettings["ELEPHANTSQL_URL"] ?? "postgres://bvcpwlka:lrcOYxm8QZLEwrP7qt-qHH9j5xmuzEGL@rogue.db.elephantsql.com:5432/bvcpwlka";
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;

            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);
            return connStr;



        }
        public static List<string> kraji()
        {
            string connection = connect();
            List<string> krajiizpis = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM krajizpis();", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string skp = reader.GetString(0);
                    krajiizpis.Add(skp);

                }
                con.Close();
                return krajiizpis;

            }
        }
        public static List<string> druzba()
        {
            string connection = connect();
            List<string> druzbeizpis = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM druzbe;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string skp = reader.GetString(1);
                    druzbeizpis.Add(skp);

                }
                con.Close();
                return druzbeizpis;

            }
        }




        public static bool Vnosletal(string ime, string naslov, string druzba, string opis, string kraj, string slika)
        {
            bool ok;
            string connection = connect();
            using (NpgsqlConnection con = new NpgsqlConnection(connection))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT vnosletal('" + ime + "','" + naslov + "','" + kraj + "','" + druzba + "','" + opis + "','" + slika + "');", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                reader.Read();
                ok = reader.GetBoolean(0);
                con.Close();
                return ok;
            }


        }
        public static void deleteletalisce(string imel)
        {
            string connection = connect();
            using (NpgsqlConnection con = new NpgsqlConnection(connection))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT deleteletalisce('" + imel + "')", con);
                com.ExecuteNonQuery();


                con.Close();
            }
        }
        public static List<string> Uredi(int id)
        {
            string connection = connect();
            List<string> druzbeizpis = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection(connection))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM druzbe;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string skp = reader.GetString(1);
                    druzbeizpis.Add(skp);

                }
                con.Close();
                return druzbeizpis;

            }
        }

    }
}
