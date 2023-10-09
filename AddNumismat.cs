using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMISMATICA
{
    public partial class AddNumismat : Form
    {
        public AddNumismat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(h.ConStr))
            {
                string t1 = textBox1.Text;
                string t2 = textBox2.Text;
                string t3 = textBox3.Text;
                string sql = "INSERT INTO numismat " +
                   "(idN, fullname, yearbirth)" +
                   "VALUES (@tk1, @tk2, @tk3)";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@tk1", t1);
                cmd.Parameters.AddWithValue("@tk2", t2);
                cmd.Parameters.AddWithValue("@tk3", t3);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Запис успішно додано!");

            }
        }
    }
}
