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
    public partial class examination_form : Form
    {
        long p_id = 0;
        BindingSource patBindingSource = new BindingSource();
        DataTable dt = new DataTable();
        public examination_form(long pa_id, string name, int age)
        {
            InitializeComponent();
            patNameLb.Text = name;
            ageLbl.Text = "" + age;
            p_id = pa_id;
            dt = DataSet.getPatientExamInfo(pa_id);
            patBindingSource.DataSource = dt;

            loadHistory();
        }

        private void loadHistory()
        {
            try
            {
                this.systolicTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "Systolic", true));
                this.diastolicTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "diastolic", true));
                this.pulseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "pulse", true));
                this.tempTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "Temp", true));
                this.rrTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "Resp_rate", true));
                this.weightTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "weight", true));
                this.heightTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "Hight", true));
                this.bmiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "BMI", true));
                this.generalTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "General_findings", true));
                this.localTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "Local_findings", true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet.UpdateExamInfo(systolicTB.Text, diastolicTB.Text, pulseTB.Text, tempTB.Text, rrTB.Text, weightTB.Text, heightTB.Text, bmiTB.Text, generalTB.Text, localTB.Text, p_id);
                MessageBox.Show("Saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
