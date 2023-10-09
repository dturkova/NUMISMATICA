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
    public partial class Collection : Form
    {
        public Collection()
        {
            InitializeComponent();
        }

        private void Collection_Load(object sender, EventArgs e)
        {
            textBoxC.Visible = false;
            label1.Visible = false;
            h.bs1 = new BindingSource();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM collection");
            bindingNavigator1.BindingSource = h.bs1;
            dataGridViewC.DataSource = h.bs1;
            
            dataGridViewC.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridViewC.DefaultCellStyle.SelectionForeColor = Color.Black;

            h.bs1.Sort = dataGridViewC.Columns[2].Name;
            dataGridViewC.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewC.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBoxC.Visible = true;
            label1.Visible = true;
            label1.Text = "Пошук: ";
            textBoxC.Focus();
        }

        private void textBoxC_Leave(object sender, EventArgs e)
        {
            textBoxC.Visible = false;
            label1.Visible = false;
        }

        private void textBoxC_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewC.RowCount; i++)
            {
                dataGridViewC.Rows[i].Selected = false;
                for (int j = 0; j < dataGridViewC.ColumnCount; j++)
                {
                    if (dataGridViewC.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridViewC.Rows[i].Cells[j].Value.ToString().Contains(textBoxC.Text))
                        {
                            dataGridViewC.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void addnew_Click(object sender, EventArgs e)
        {
            AddCollection f3add = new AddCollection();
            f3add.ShowDialog();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM collection");
            dataGridViewC.DataSource = h.bs1;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridViewC[0, dataGridViewC.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridViewC.Columns[0].Name;

            DeleteCollection f3delete = new DeleteCollection();
            f3delete.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM collection");
            dataGridViewC.DataSource = h.bs1;
        }

        private void Change_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridViewC[0, dataGridViewC.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridViewC.Columns[0].Name;
            ChangeCollection f5 = new ChangeCollection();
            f5.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM collection");
            dataGridViewC.DataSource = h.bs1;
        }

        private void dataGridViewC_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            int curColidx = dataGridViewC.CurrentCellAddress.X;
            int curRowidx = dataGridViewC.CurrentCellAddress.Y;
            string curColName0 = dataGridViewC.Columns[0].Name;
            string curColName = dataGridViewC.Columns[curColidx].Name;
            h.curVal0 = dataGridViewC[0, curRowidx].Value.ToString();

            string newCurCellVal = e.Value.ToString();
            if (curColName == "storage" || curColName == "purpose" )
            {
                newCurCellVal = "'" + newCurCellVal + "'";
            }
            string sqlStr = "UPDATE collection SET " + curColName + " = " + newCurCellVal + " WHERE "
                + curColName0 + " = " + h.curVal0;

            using (MySqlConnection con = new MySqlConnection(h.ConStr))
            {
                MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
