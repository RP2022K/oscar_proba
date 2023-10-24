using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.IO;

namespace Sikidomok2
{
    public partial class Form1 : Form
    {
        private int kattintas = 0;
        private string csucsok = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void Csucspont(object sender, MouseEventArgs e)
        {
            Graphics rajzlap = ((Panel)sender).CreateGraphics();
            rajzlap.FillRectangle(new SolidBrush(Color.Yellow), e.X, e.Y, 7, 7);
            kattintas++;
            csucsok += ("(" + e.X + "," + e.Y + ")");
            if (kattintas >= 3)
            {
                this.textBox1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mk = null;
            SQLiteConnection sk = null;

            try
            {
                mk = new MySqlConnection("SERVER=127.0.0.1;USERNAME=root;PASSWORD=;DATABASE=sikidomok;");
                bool kell = false;
                if (File.Exists("sikidomok.db"))
                {
                    kell = false;
                }
                else
                {
                    kell = true;
                }
                sk = new SQLiteConnection("Data Source=sikidomok.db;");
                sk.Open();
                if (kell)
                {
                    SQLiteCommand p = new SQLiteCommand("CREATE TABLE sikidomok(megnevezes VARCHAR(20), koordinatak VARCHAR(20));",sk);
                    p.ExecuteNonQuery();
                }

                SQLiteCommand u = new SQLiteCommand("INSERT INTO sikidomok VALUES(@megnevezes,@koordinatak);",sk);
                u.Parameters.AddWithValue("@megnevezes",this.textBox1.Text);
                u.Parameters.AddWithValue("@koordinatak", csucsok);
                u.ExecuteNonQuery();
            }
            catch { }
            mk.Close();
            sk.Close();
            (this.panel1.CreateGraphics()).Clear(Color.Green);
            this.textBox1.Text = "";
            this.textBox1.Enabled = false;
            this.button1.Enabled = false;
        }
        

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
