using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMISMATICA
{
    public partial class AddNewUser : Form
    {
        System.Data.DataTable dtuserName;
        bool nuser;
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            dtuserName = h.myfunDt("SELECT * FROM userName");

        }

        private void txtNameUser_Leave(object sender, EventArgs e)
        {
            nuser = true;
            if (button2.Focused)
            {
                this.Close();
            }
            else
            {
                for (int i = 0; i < dtuserName.Rows.Count; i++)
                {

                    if (String.Equals(txtNameUser.Text.Trim(), dtuserName.Rows[i][1].ToString())
                        || (String.Equals(txtNameUser.Text, "")))
                    {
                        nuser = false;
                        break;

                    }
                }
            }

            if (!nuser)
            {
                MessageBox.Show("Ім'я користувача не заповнено або вже існує!", "Увага!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameUser.Focus();
            }
        }

        private void txtTypeUser_Leave(object sender, EventArgs e)
        {
            int g;
            nuser = true;
            if (button2.Focused)
            {
                this.Close();
            }
            else
            {
                if (!int.TryParse(txtTypeUser.Text, out g))
                {
                    nuser = false;
                }
                else if (((int.Parse(txtTypeUser.Text)) < 0) || (int.Parse(txtTypeUser.Text) > 3))
                {
                    nuser = false;
                }
            }
            if (!nuser)
            {
                MessageBox.Show("Не вірний тип користувача!", "Увага!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTypeUser.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNameUser.Text != "")
            {

                if (txtTypeUser.Text != "") //Пone тwn коpистуsavа нe поpoke
                {
                    if (String.Equals(txtPassword1User.Text, txtPassword2User.Text))
                    {


                        string sqlcmd = "INSERT INTO userName (UserName, Type, Password)" + " VALUES(@P1, @P2, @P3)";
                        MySqlConnection con = new MySqlConnection(h.ConStr);
                        MySqlCommand cmdAdd = new MySqlCommand(sqlcmd, con);
                        cmdAdd.Parameters.AddWithValue("@P1", txtNameUser.Text);
                        cmdAdd.Parameters.AddWithValue("@P2", txtTypeUser.Text);
                        cmdAdd.Parameters.AddWithValue("@P3", h.EncriptedPassword_MD5(txtPassword1User.Text));

                        con.Open();
                        cmdAdd.ExecuteNonQuery();

                        con.Close();

                        MessageBox.Show("Нового користувача '" + txtNameUser.Text + "'\n успішно додано");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Паролі не співпадають! \nВиправте паролі",
                            "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Тип доступу не заповнено! \nВиправте тип доступу", "Помила!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
            }
        }
    }
}