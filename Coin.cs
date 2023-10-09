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
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using excel =  Microsoft.Office.Interop.Excel;

namespace NUMISMATICA
{
    
    public partial class Coin : Form
    {
        string path = @"C:\2.2nltu\ОБДЗ\NUMISMATICA\bin\Debug";
        DataTable dt;
        public Coin()
        {
            InitializeComponent();
        }

        private void Coin_Load(object sender, EventArgs e)
        {
            //if (int.Parse(h.typeUser) == 3)
            //{
            //    addnew.Visible = false;
            //    Delete.Visible = false;
            //    change.Visible = false;
            //    dataGridView1.ReadOnly = true;
            //}
            addnew.Visible = false;
            Delete.Visible = false;
            change.Visible = false;
            dataGridView1.ReadOnly = true;
            this.Height = 260;
                panel1.Visible= false;
                textBox1.Visible = false;
                label1.Visible = false;
                h.bs1 = new BindingSource();
                h.bs1.DataSource = h.myfunDt("SELECT * FROM coin");
                bindingNavigator1.BindingSource= h.bs1;
                dataGridView1.DataSource = h.bs1;
                dataGridView1.Columns[0].Width = 85;
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].Width = 60;
                dataGridView1.Columns[4].Width = 60;
                dataGridView1.Columns[5].Width = 60;
                dataGridView1.Columns[6].Width = 60;
                dataGridView1.Columns[7].Width = 60;
                dataGridView1.Columns[8].Width = 60;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

                h.bs1.Sort = "idCoin";
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;

            DataTable minmaxValue = h.myfunDt("SELECT MIN(price), MAX(price), " + "MIN(year), MAX(YEAR) FROM root.coin");
            txtCin.Text = minmaxValue.Rows[0][0].ToString();
            txtCout.Text = minmaxValue.Rows[0][1].ToString();
            txtYearin.Text = minmaxValue.Rows[0][2].ToString();
            txtYearout.Text = minmaxValue.Rows[0][3].ToString();
            minmaxValue = h.myfunDt("SELECT DISTINCT coin.condition FROM root.coin");
            cmbStan.Items.Add("");
            for(int i=0; i<minmaxValue.Rows.Count; i++) 
            {
                cmbStan.Items.Add(minmaxValue.Rows[i][0].ToString());   
            }
            cmbStan.Text = "";
            cmbMetal.DropDownStyle= ComboBoxStyle.DropDownList;
            cmbMetal.Items.Add("");
            cmbMetal.Items.Add("silver");
            cmbMetal.Items.Add("gold");
            cmbMetal.Items.Add("copper nickel");
            cmbMetal.Text = "";
            path += @"\Report";
            dt = (DataTable)h.bs1.DataSource;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label1.Visible = true;
            label1.Text = "Пошук: ";
            textBox1.Focus();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Visible=false;
            label1.Visible=false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for(int i = 0; i<dataGridView1.RowCount; i++) 
            {
                dataGridView1.Rows[i].Selected = false;
                for(int j = 0; j<dataGridView1.ColumnCount; j++) 
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null) 
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text)) 
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (btnFilter.Checked) 
            {
                this.Height = 450;
                panel1.Visible = true;
            }
            else 
            {
            panel1.Visible=false;
                h.bs1.Filter = "";
                this.Height = 260;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strFilter = "idCoin >= 0";

            ////Ціна
            if ((txtCin.Text != "") && (txtCout.Text != ""))
            {
                strFilter += " AND (price >= '" + int.Parse(txtCin.Text) + "' AND price <= '" + int.Parse(txtCout.Text) + "') ";
            }
            else if ((txtCin.Text == "") && (txtCin.Text != ""))
            {
                strFilter += " AND (price <= '" + int.Parse(txtCout.Text) + "') ";
            }
            else if ((txtCin.Text != "") && (txtCout.Text == ""))
            {
                strFilter += " AND (price >= '" + int.Parse(txtCin.Text) + "') ";
            }
            /////Рік
            if ((txtYearin.Text != "") && (txtYearout.Text != ""))
            {
                strFilter += " AND (year >= '" + int.Parse(txtYearin.Text) + "' AND year <= '" + int.Parse(txtYearout.Text) + "') ";
            }
            else if ((txtYearin.Text == "") && (txtYearout.Text != ""))
            {
                strFilter += " AND (year <= '" + int.Parse(txtYearout.Text) + "') ";
            }
            else if ((txtYearin.Text != "") && (txtYearout.Text == ""))
            {
                strFilter += " AND (year >= '" + int.Parse(txtYearin.Text) + "') ";
            }
            ////Стан
            if (cmbStan.Text != "")
            { strFilter += " AND (condition LIKE '%" + cmbStan.Text + "%') "; }
            ////Метал
            if (cmbMetal.Text != "")
            { strFilter += " AND (metal LIKE '%" + cmbMetal.Text + "%') "; }
            ////Назва
            if (txtName.Text != "")
            { strFilter += " AND (name LIKE '%" + txtName.Text + "%') "; }

            //MessageBox.Show(strFilter);
            h.bs1.Filter = strFilter;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            h.bs1.Filter = "";
        }

        private void addnew_Click(object sender, EventArgs e)
        {
            AddCoin f1add = new AddCoin();
            f1add.ShowDialog();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM coin");
            dataGridView1.DataSource = h.bs1;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridView1.Columns[0].Name;
            DeleteCoin f1delete = new DeleteCoin();
            f1delete.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM coin");
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
            if (curColName == "name" || curColName == "feature" || curColName == "year")
            {
                newCurCellVal = "'" + newCurCellVal + "'";
            }
            string sqlStr="UPDATE coin SET "+curColName+" = "+newCurCellVal+" WHERE "
                +curColName0 +" = "+h.curVal0;

            using(MySqlConnection con = new MySqlConnection(h.ConStr))
            {
                MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void change_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridView1[0,dataGridView1.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridView1.Columns[0].Name;
            ChangeCoin f4 = new ChangeCoin();
            f4.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM coin");
            dataGridView1.DataSource = h.bs1;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rIndx = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[rIndx].Cells[9].Value.ToString().Length>0) 
            {
                byte[] a = (byte[])dataGridView1.Rows[rIndx].Cells[9].Value;
                MemoryStream memImage = new MemoryStream(a);
                pictureBox1.Image = Image.FromStream(memImage);
                memImage.Close();

            }
            else 
            {
                pictureBox1.Image = Image.FromFile(@"C:\2.2nltu\ОБДЗ\NUMISMATICA\noimage.jpg"); //при виході за межі записів
            }
        }

        private void btnStream_Click(object sender, EventArgs e)
        {
            var srcEncoding = Encoding.GetEncoding(1251);
            string extend;
            if (radioButtontsv.Checked)
                extend = "tsv";
            else if (radioButtondoc.Checked)
                extend = "doc";
            else if (radioButtonxls.Checked)
                extend = "xls";
            else
                extend = "txt";
            string filename;
            filename = path + @"\Coin_Stream." + extend;
            if (File.Exists(filename)) File.Delete(filename);
            StreamWriter wr = new StreamWriter(filename, false, encoding: srcEncoding);

            try
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                    wr.Write(dt.Columns[i] + "\t");
                wr.WriteLine();
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            if (dt.Columns[j].DataType.ToString() == "System.Byte[]")
                                wr.Write("ФОТО" + "\t");
                            else if (dt.Columns[j].DataType.ToString() == "System.DateTime")
                                wr.Write(Convert.ToDateTime(dt.Rows[i][j]).ToString("dd/MM/yyyy") + "\t");
                            else if (dt.Columns[j].DataType.ToString() == "System.Double")
                                wr.Write(Convert.ToDouble(dt.Rows[i][j]).ToString() + "\t");
                            else
                                wr.Write(Convert.ToString(dt.Rows[i][j])+"\t");
                        }
                        else
                            wr.Write("\t");
                         
                    }
                    wr.WriteLine();
                }
                wr.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            MessageBox.Show("Export in STream is ok");
        }

        private void btmOLEDB_Click(object sender, EventArgs e)
        {
            string fileName = path + @"\C_OLEDB.xls";
            if (File.Exists(fileName)) File.Delete(fileName);

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName +
                ";Mode=ReaderWrite;Extended Properties=\"Excel 8.0; HDR=NO\"";
            string commandCreateoledb = "CREATE TABLE [MySheet] ([" + dt.Columns[0].ColumnName + "] int";
            for (int i = 1; i < (dt.Columns.Count); i++)
                commandCreateoledb += ", [" + dt.Columns[i].ColumnName + "] string";
            commandCreateoledb += ")";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(commandCreateoledb, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cmd.CommandText = "insert into [MySheet$] values(" + Convert.ToString(dt.Rows[i][0]);
                            for (int j = 1; j < (dt.Columns.Count); j++)
                            {
                                if (dt.Columns[j].DataType.ToString() == "System.String")
                                    cmd.CommandText += ", '" + Convert.ToString(dt.Rows[i][j]) + "'";
                                else if (dt.Columns[j].DataType.ToString() == "System.Int32")
                                    cmd.CommandText += ", '" + Convert.ToInt32(dt.Rows[i][j]) + "'";
                                else if (dt.Columns[j].DataType.ToString() == "System.Decimal")
                                    cmd.CommandText += ", '" + Convert.ToDecimal(dt.Rows[i][j]) + "'";
                                else if (dt.Columns[j].DataType.ToString() == "System.DateTime")
                                    cmd.CommandText += ", '" + Convert.ToDateTime(dt.Rows[i][j]).ToString("dd/MM/yyyy") + "'";
                                else
                                    cmd.CommandText += ", 'не конвертовано'";
                            }
                            cmd.CommandText += ")";
                            cmd.ExecuteNonQuery();
                        }
                       
                    }
                    catch
                    {
                       MessageBox.Show("Таблиця MySheet уже існує або відкрита");
                    }
                }
                conn.Close();
            }
            MessageBox.Show("Export dt to file as OLEDB - OK");

        }

        private void btnComObject_Click(object sender, EventArgs e)
        {
            string fileName = path + @"\Coin_COM.xls";
            if (File.Exists(fileName)) File.Delete(fileName);
            Excel.Application excel = new Excel.Application();
            excel.Workbooks.Add(Type.Missing);
            Excel.Workbook workbook = excel.Workbooks[1];

            Excel.Worksheet sheet = workbook.Worksheets.get_Item(1);
            sheet.Name = "Монети";

            for(int j = 0; j<dt.Columns.Count; j++)
            {
                sheet.Cells[1, j + 1].Value = dt.Columns[j].ColumnName;

            }
            for(int i = 0; i<dt.Rows.Count; i++) 
            { 
            for(int j =0; j<dt.Columns.Count; i++)
                {
                    if (dt.Columns[j].DataType.ToString() == "System.Byte[]")
                    {
                        sheet.Cells[i + 2, j + 1].Value = "ФОТО";

                    }
                    else
                    {
                        sheet.Cells[i + 2, j + 1].Value = dt.Rows[i][j];
                    }
                }
            }

            excel.Application.ActiveWorkbook.SaveAs(fileName, Excel.XlSaveAsAccessMode.xlNoChange);
            workbook.Close(false);
            excel.Quit();
            MessageBox.Show("File xls створено за допомогою com-об'єктів Excel");
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            string fileName = path + @"\Coin_XML.xls";
            dt.WriteXml(fileName);
            MessageBox.Show("File xls створено за допомогою розмітки XML");
        }
    }  
    
}    

