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
    public partial class lab_results : Form
    {
        int p_id = 0;
        BindingSource dateBindingSource = new BindingSource();
        DataTable dt_date = new DataTable();
        public lab_results(int pa_id, string name, int age)
        {
            InitializeComponent();
            patNameLb.Text = name;
            ageLbl.Text = "" + age;
            p_id = pa_id;

            dt_date = DataSet.getPatientLabDates(pa_id);
            dateBindingSource.DataSource = dt_date;
            //this.dateCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dateBindingSource, "labdate", true));
            dateCB.DataSource = dt_date;
            dateCB.DisplayMember = "labdate";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet.InsertLab(labDate.Value.Date, p_id);
                MessageBox.Show("Saved Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void albuminTB_TextChanged(object sender, EventArgs e)
        {

        }




    }
}
