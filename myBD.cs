using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace NUMISMATICA
{
    public partial class myBD : Form
    {
        public myBD()
        {
            InitializeComponent();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About f1 = new About();
            f1.ShowDialog();
        }

        private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator C1 = new Calculator();
            C1.ShowDialog();
        }

        private void myBD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void монетиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Coin f1 = new Coin();
            f1.ShowDialog();

        }

        private void нумізматиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Numismat f2 = new Numismat();
            f2.ShowDialog();
        }

        private void колекціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collection f3 = new Collection();
            f3.ShowDialog();
        }

        private void myBD_Load(object sender, EventArgs e)
        {

            
            //if (int.Parse(h.typeUser) > 1)
            //{
            //    admToolStripMenuItem.Visible = false;
            //}
            //else { admToolStripMenuItem.Visible = true; }
        }

        private void резервнеКопіюванняБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(h.ConStr);
            MySqlCommand cmd = new MySqlCommand("copyTablesBD", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Немає з'єднання з сервером!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            MessageBox.Show("Резервне копіювання успішно завершено!");
        }

        private void додатиКористувачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUser ad = new AddNewUser();
            ad.ShowDialog();
        }

        private void видалитиКористувачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUser du = new DeleteUser();
            du.ShowDialog();
        }

        private void змінитиПарольКористувачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUserPassword edu = new EditUserPassword();
            edu.ShowDialog();
        }
    }
}
