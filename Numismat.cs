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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NUMISMATICA
{
    public partial class Numismat : Form
    {
        public Numismat()
        {
            InitializeComponent();
        }

        private void Numismat_Load(object sender, EventArgs e)
        {
            textBoxK.Visible = false;
            label1.Visible = false;
            h.bs1 = new BindingSource();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM numismat");
            bindingNavigator1.BindingSource = h.bs1;
            dataGridView1.DataSource = h.bs1;
            h.bs1.Sort = dataGridView1.Columns[1].Name;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBoxK.Visible = true;
            label1.Visible = true;
            label1.Text = "Пошук: ";
            textBoxK.Focus();
        }

        private void textBoxK_Leave(object sender, EventArgs e)
        {
            textBoxK.Visible = false;
            label1.Visible = false;
        }

        private void textBoxK_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBoxK.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void addnew_Click(object sender, EventArgs e)
        {
            AddNumismat f2add = new AddNumismat();
            f2add.ShowDialog();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM numismat");
            dataGridView1.DataSource = h.bs1;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridView1.Columns[0].Name;

            DeleteNumismat f2delete = new DeleteNumismat();
            f2delete.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM numismat");
            dataGridView1.DataSource = h.bs1;
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            int curColidx = dataGridView1.CurrentCellAddress.X;
            int curRowidx = dataGridView1.CurrentCellAddress.Y;
            string curColName0 = dataGridView1.Columns[0].Name;
            string curColName = dataGridView1.Columns[curColidx].Name;
            h.curVal0 = dataGridView1[0, curRowidx].Value.ToString();

            string newCurCellVal = e.Value.ToString();
            if (curColName == "fullname" || curColName == "yearbirth")
            {
                newCurCellVal = "'" + newCurCellVal + "'";
            }
            string sqlStr = "UPDATE numismat SET " + curColName + " = " + newCurCellVal + " WHERE "
                + curColName0 + " = " + h.curVal0;

            using (MySqlConnection con = new MySqlConnection(h.ConStr))
            {
                MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridView1.Columns[0].Name;
            ChangeNumismat f5 = new ChangeNumismat();
            f5.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM numismat");
            dataGridView1.DataSource = h.bs1;
        }
    }
}
