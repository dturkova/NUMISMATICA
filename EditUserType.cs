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
    public partial class EditUserType : Form
    {
        DataTable dtuserName;
        public EditUserType()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int countAdm = 0;
            for(int i = 0; i<dtuserName.Rows.Count; i++)
            {
                countAdm +=1;
            }
            if(countAdm> 1) 
            {
                string sqlcmd = "UPDATE userNAme SET Type = '" + comboBox1.Text + "' WHERE UserName = '" + comboBox2.Text + "'";
                MySqlConnection con = new MySqlConnection(h.ConStr);
                con.Open();
                MessageBox.Show("Тип користувача '" + comboBox2.Text + "'\n успішно змінено");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ви не можете змінити тип користувача '" +
                    comboBox2.Text + "' !\n Це єдиний адміністратор!", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
            }
        }

    }
}
