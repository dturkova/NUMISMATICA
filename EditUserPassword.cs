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
    public partial class EditUserPassword : Form
    {
        public EditUserPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.Equals(textBox1.Text, textBox2.Text) &&
                textBox1.Text != "")
            {
                string sqlcmd = "UPDATE userName SET Password = '"
                + h.EncriptedPassword_MD5(textBox1.Text) + "' WHERE UserName ='" + comboBox1.Text 
                + "'";
                MySqlConnection con = new MySqlConnection(h.ConStr);
                MySqlCommand cmdAdd = new MySqlCommand(sqlcmd, con);
                con.Open();
                cmdAdd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Пароль користувача '" + comboBox1.Text + "'\n успішно змінена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else {
                MessageBox.Show("Паролі не співпадають \n або не введені!", "Помилка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    };
            textBox1.Focus();

        }
    }
}
