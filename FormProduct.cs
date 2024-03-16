using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Techno
{
    enum RowState
    {
        DeleteRow
    }
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                {
                    dataGridView1[i, j].Style.BackColor = Color.White;
                    dataGridView1[i, j].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                {
                    if (dataGridView1[i,j].Value.ToString().IndexOf(textBox1.Text)!= - 1)
                    {
                        dataGridView1[i, j].Style.BackColor = Color.AliceBlue;
                        dataGridView1[i, j].Style.ForeColor = Color.Blue;
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                dataGridView1.Sort(reasonDataGridViewTextBoxColumn, System.ComponentModel.ListSortDirection.Ascending);
            else
                dataGridView1.Sort(reasonDataGridViewTextBoxColumn, System.ComponentModel.ListSortDirection.Descending);
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "technoBDDataSet.Report". При необходимости она может быть перемещена или удалена.
            this.reportTableAdapter.Fill(this.technoBDDataSet.Report);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reportBindingSource.Filter = "ABC = '" + comboBox1.Text + "'"; //
        }
        private void DeleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[5].Value = RowState.DeleteRow;
                return;
            }
            dataGridView1.Rows[index].Cells[5].Value = RowState.DeleteRow;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }
    }
}
