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
    public partial class ChangeCoin : Form
    {
        public ChangeCoin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sqlStr = "UPDATE coin SET " + textBox1.Text + " WHERE " + textBox2.Text;
            //if(MessageBox.Show("Ви впевпені, що хочете замінити дані? ", "Заміна", 
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            //{
            //    using (MySqlConnection con = new MySqlConnection(h.ConStr)) 
            //    {
            //        MySqlCommand cmd = new MySqlCommand(sqlStr, con);
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();

            //    }
            //}

            if ((checkBox1.Checked == false) && (checkBox2.Checked == true))
            {
                int FileSize;
                byte[] masBytes;
                FileStream fs;
                string strFileName;
                strFileName = h.pathToPhoto;
                fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                FileSize = (Int32)fs.Length;
                masBytes = new byte[FileSize];
                fs.Read(masBytes, 0, FileSize);
                fs.Close();

                string sqlStr = "UPDATE coin SET photo = @File WHERE " + textBox2.Text;  
                if(MessageBox.Show("Ви впевнені, що хочете замінити дані? ","Заміна",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                { 
                using(MySqlConnection con = new MySqlConnection(h.ConStr))
                    {
                        MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                        cmd.Parameters.AddWithValue("@File", masBytes);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Редагувння записів пройшло вдало! ");
                    }
                }
            }

            if ((checkBox1.Checked == true) && (checkBox2.Checked == true))
            {
                int FileSize;
                byte[] rawData;
                FileStream fs;
                string strFileName;
                strFileName = h.pathToPhoto;
                fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                FileSize = (Int32)fs.Length;
                rawData = new byte[FileSize];
                fs.Read(rawData, 0, FileSize);
                fs.Close();

                string sqlStr = "UPDATE coin SET " + textBox2.Text +
                    " photo = @File " +
                    "WHERE " + textBox2.Text;
                
                if(MessageBox.Show("Ви впевнені, що хочете замінити дані?", "Заміна",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = new MySqlConnection(h.ConStr))
                    {
                        MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                        cmd.Parameters.AddWithValue("@File", rawData);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Редагувння записів пройшло вдало! ");
                    }
                }
            }

            this.Close();
        }

        private void ChangeCoin_Load(object sender, EventArgs e)
        {
            h.pathToPhoto = Application.StartupPath + @"\" + "libertyhead.jpg";
            pictureBox1.Image=Image.FromFile(h.pathToPhoto);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true) 
            {
                label1.Visible = true;
                textBox1.Visible = true;
                button1.Visible = true;

            }
            else if(checkBox1.Checked==false) 
            {
                label1.Visible = false;
                textBox1.Visible = false;
                if(checkBox2.Checked==false) 
                {
                    button1.Visible = false;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked== true) 
            {
                panel2.Visible = true;
                label3.Visible = true;
                button3.Visible = true;
                pictureBox1.Visible = true;
                button1.Visible = true;

            }
            else if(checkBox2.Checked == false) 
            {
                panel2.Visible = false;
                label3.Visible = false;
                button3.Visible = false;
                pictureBox1.Visible = false;
                if(checkBox1.Checked == false) 
                {
                    button1.Visible = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Виберіть файл ";
            OFD.Filter = "img files (*.jpg)|*.jpg|bmp file (*.bmp)|*.bmp|All files(*.*)|*.*";
            OFD.InitialDirectory = Application.StartupPath;

            if (OFD.ShowDialog() != DialogResult.OK)return;
            { h.pathToPhoto = OFD.FileName;
                pictureBox1.Image = Image.FromFile(h.pathToPhoto);
            }
        }
    }
}
