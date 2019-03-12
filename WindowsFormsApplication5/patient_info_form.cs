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
    public partial class patient_info_form : Form
    {
        DataTable dt = new DataTable();
        BindingSource mainBindingSource = new BindingSource();
        int p_id = 0;
        public patient_info_form(int id)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            p_id = id;
            fillData(id);
        }

        private void fillData(int id)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dt = DataSet.getPatientInfo(id);
                mainBindingSource.DataSource = dt;

                this.firstNameTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "fname", true));
                this.middleNameTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mname", true));
                this.lastNameTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "lname", true));
                this.telephoneTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "tele", true));
                this.genderCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "gender", true));
                this.ageTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "age", true));
                this.addressTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "adress", true));
                this.cityTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "city", true));
                this.govTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "governorate", true));
                this.occupTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "occupation", true));
                this.maritalstatusCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "maritialstatus", true));
                this.mensTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mensturalhistory", true));
                this.firstvisitDP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mainBindingSource, "firstvisit", true));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;

        }

        private void saveData()
        {
            try
            {
                DataSet.UpdateUserInfo(firstNameTB.Text, middleNameTB.Text, lastNameTB.Text, telephoneTB.Text, genderCB.Text, Convert.ToInt16(ageTB.Text), addressTB.Text,
                cityTB.Text, govTB.Text, occupTB.Text, maritalstatusCB.Text, mensTB.Text, firstvisitDP.Value.Date,p_id);
                MessageBox.Show("Saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            saveData();
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
