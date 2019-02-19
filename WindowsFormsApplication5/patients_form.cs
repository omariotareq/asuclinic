using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class patients_form : Form
    {
        BindingSource dataGridView1BindingSource = new BindingSource();
        bool isRowAdded = false;
        public patients_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patient_name = "%" + textBox1.Text + "%";
            fillGV(patient_name);

        }

        private void fillGV(String patName)
        {
            isRowAdded = false;
            DataTable dt = DataSet.getAllpatientinfo(patName);
            dataGridView1BindingSource.DataSource = dt;

            dataGridView1.Columns["id"].DataPropertyName = "id";
            dataGridView1.Columns["FirstName"].DataPropertyName = "fname";
            dataGridView1.Columns["LastName"].DataPropertyName = "lname";
            dataGridView1.Columns["MiddleName"].DataPropertyName = "mname";
            dataGridView1.Columns["Age"].DataPropertyName = "age";
            dataGridView1.Columns["Telephone"].DataPropertyName = "tele";


            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = dataGridView1BindingSource;

        }

        private void patHistoryBtn_Click(object sender, EventArgs e)
        {
            int ri = dataGridView1.SelectedCells[0].RowIndex;
            int p_id =Convert.ToInt16( dataGridView1.Rows[ri].Cells[0].Value );
            string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value)+" " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
            int age = Convert.ToInt16( dataGridView1.Rows[ri].Cells[4].Value );
            patient_history ph = new patient_history(p_id,name,age);
            ph.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ri = dataGridView1.SelectedCells[0].RowIndex;
            int p_id =Convert.ToInt16( dataGridView1.Rows[ri].Cells[0].Value );
            string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value)+" " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
            int age = Convert.ToInt16( dataGridView1.Rows[ri].Cells[4].Value );
            examination_form ef = new examination_form(p_id, name, age);
            ef.ShowDialog();
        }
    }
}
