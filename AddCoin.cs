using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMISMATICA
{
    public partial class AddCoin : Form
    {
        public AddCoin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(MySqlConnection con = new MySqlConnection(h.ConStr))
            {
                string t1 = textBox1.Text;
                string t2 = textBox2.Text;
                string t3 = textBox3.Text;
                string t4 = textBox4.Text;
                string t5 = textBox5.Text;
                string t6 = textBox6.Text;
                string t7 = textBox7.Text;
                string t8 = textBox8.Text;
                string t9 = textBox9.Text;

                string strFileName = h.pathToPhoto;
                FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                int FileSize = (Int32)fs.Length;
                byte[] rawData = new byte[FileSize];
                fs.Read(rawData,0,FileSize);
                fs.Close();
                string sql = "INSERT INTO root.coin " +
                             "(idCoin, name, feature, year, price, nominal, coin.condition, metal, theme, photo, photopath)" +
                        " VALUES (@tk1, @tk2, @tk3, @tk4, @tk5, @tk6, @tk7, @tk8, @tk9, @File, @FIleName)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tk1", t1);
                cmd.Parameters.AddWithValue("@tk2", t2);
                cmd.Parameters.AddWithValue("@tk3", t3);
                cmd.Parameters.AddWithValue("@tk4", t4);
                cmd.Parameters.AddWithValue("@tk5", t5);
                cmd.Parameters.AddWithValue("@tk6", t6);
                cmd.Parameters.AddWithValue("@tk7", t7);
                cmd.Parameters.AddWithValue("@tk8", t8);
                cmd.Parameters.AddWithValue("@tk9", t9);

                cmd.Parameters.AddWithValue("@FileName", strFileName);
                cmd.Parameters.AddWithValue("@File", rawData);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Запис успішно додано! ");

            }
            this.Close();
        }

        private void AddCoin_Load(object sender, EventArgs e)
        {
            h.pathToPhoto ="@\"C:\\2.2nltu\\ОБДЗ\\NUMISMATICA\\noimage.jpg";
            pictureBox1.Image = Image.FromFile(@"C:\2.2nltu\ОБДЗ\NUMISMATICA\noimage.jpg");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Виберіть файл";
            openFileDialog1.Filter = "img files (*.jpg) |*.jpg|bmp file (*.bmp)|*.bmp|ALL files (*.*)|*.*";
            openFileDialog1.InitialDirectory = Application.StartupPath;
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            {
                h.pathToPhoto=openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(h.pathToPhoto);
            }
        }
    }
}
