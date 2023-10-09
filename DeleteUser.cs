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
    public partial class DeleteUser : Form
    {
        DataTable dtuserName;
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            dtuserName = h.myfunDt("SELECT * FROM userName");
            for(int i = 0; i<dtuserName.Rows.Count; i++)
            {
                comboBox1.Items.Add(dtuserName.Rows[i][1].ToString());
               
            }
            comboBox1.Text = dtuserName.Rows[0][1].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int countAdm = 0;
            for(int i = 0; i<dtuserName.Rows.Count; i++)
            {
                if (int.Parse(dtuserName.Rows[i][2].ToString()) == 1)
                {
                    countAdm += 1;
                }
            }
            if(countAdm > 1) 
            {
                string sqlcmd = "DELETE FROM userName " + " WHERE UserName = '" 
                    + comboBox1.Text + "'";
                MySqlConnection con = new MySqlConnection(h.ConStr);
                MySqlCommand cmdAdd = new MySqlCommand(sqlcmd, con);
                con.Open();
                cmdAdd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Користувача '" + comboBox1.Text 
                    + "'\n успішно видалено!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ви не можете видалити користувача '" + comboBox1.Text 
                    + "' !\n Це єдиний адміністратор", "Увага!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
            }
        }
    }
}
