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
    public partial class users_control : Form
    {
        bool isRowAdded = false;
        BindingSource dataGridView1BindingSource = new BindingSource();
        public users_control()
        {
            InitializeComponent();

            fillAllGV();
        }

        private void fillAllGV()
        {
            isRowAdded = false;
            DataTable dt = DataSet.SelectAllUsers();
            dataGridView1BindingSource.DataSource = dt;

            for (int i = 0;  i < dt.Rows.Count;i++ ) {
                if ((string)dt.Rows[i]["access"] == "2")
                {
                    dt.Rows[i]["access"] = "Admin";
                }
                else if ((string) dt.Rows[i]["access"] == "1")
                {
                    dt.Rows[i]["access"] = "View and Edit";
                }
                else if ((string)dt.Rows[i]["access"] == "0")
                {
                    dt.Rows[i]["access"] = "View Only";
                }
            }
            dataGridView1.Columns["id"].DataPropertyName = "id";
            dataGridView1.Columns["usr"].DataPropertyName = "username";
            dataGridView1.Columns["pw"].DataPropertyName = "password";
            dataGridView1.Columns["acc"].DataPropertyName = "access";
            


            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = dataGridView1BindingSource;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            new_user_form nwf = new new_user_form();
            nwf.ShowDialog();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int ri = dataGridView1.SelectedCells[0].RowIndex;
                int id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);


                edit_user_form ef = new edit_user_form(id);
                ef.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, contact developer");
            }
        }

        private void users_control_Activated(object sender, EventArgs e)
        {
            fillAllGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ri = dataGridView1.SelectedCells[0].RowIndex;
                int id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);

                DataSet.deleteUser(id);
                MessageBox.Show("deleted successfully");
                fillAllGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, please check your connection");
            }
        }


    }
}
