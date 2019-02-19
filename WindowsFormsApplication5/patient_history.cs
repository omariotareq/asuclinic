using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class patient_history : Form
    {
        long p_id = 0;
        BindingSource patBindingSource = new BindingSource();
        DataTable dt = new DataTable();
        public patient_history(long pa_id,string name,int age)
        {
            InitializeComponent();
            p_id = pa_id;

            dt = DataSet.getPatientHistory(pa_id);
            patBindingSource.DataSource = dt;
            loadHistory();
            patNameLb.Text = name;
            ageLbl.Text =""+ age;
        }

        private void loadHistory()
        {
            this.patDiagnosisCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "statusofdiagnosis", true));
            this.dateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "currentdate", true));
            //assigning date time picker to value
            //dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0]["cd"]); 
            this.abdPainCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "statusofdiagnosis", true));
            this.complainTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "currentcomplain", true));
            this.feverCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "fever", true));
            this.motionsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "noofmotions", true));
            this.mucusCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "muscs", true));
            this.bleedingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "bleeding", true));
            this.wlossKgTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "weightlossinkg", true));
            this.historyTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "historydetails", true));
            this.extraTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.patBindingSource, "mainfestations", true));


            if (Convert.ToInt32(dt.Rows[0]["Tesnismus"] )==1)
            {
                teniChkbx.Checked = true;
            }
            else
            {
                teniChkbx.Checked = false;
            }

            if (Convert.ToInt32(dt.Rows[0]["Diarrhea"]) == 1)
            {
                diaChkbx.Checked = true;
            }
            else
            {
                diaChkbx.Checked = false;
            }

            if (Convert.ToInt32(dt.Rows[0]["perianaldischarge"]) == 1)
            {
                periChkbx.Checked = true;
            }
            else
            {
                periChkbx.Checked = false;
            }

            if (Convert.ToInt32(dt.Rows[0]["weightloss"]) == 1)
            {
                wlossChkbx.Checked = true;
            }
            else
            {
                wlossChkbx.Checked = false;
            }




        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int teniCheck = 0;
                int diaCheck = 0;
                int periCheck = 0;
                int weightCheck = 0;

                if (teniChkbx.Checked == true)
                {
                    teniCheck = 1;
                }
                if (diaChkbx.Checked == true)
                {
                    diaCheck = 1;
                }
                if (periChkbx.Checked == true)
                {
                    periCheck = 1;
                }
                if (wlossChkbx.Checked == true)
                {
                    weightCheck = 1;
                }
               
                DataSet.InsertHistoryInfo(dateTimePicker1.Value.Date,patDiagnosisCB.Text, abdPainCB.Text, complainTB.Text, feverCB.Text, teniCheck, diaCheck, Convert.ToInt16(string.IsNullOrEmpty(motionsTB.Text) ? "0" : motionsTB.Text), mucusCB.Text, bleedingCB.Text, periCheck, weightCheck, Convert.ToInt16(string.IsNullOrEmpty(wlossKgTb.Text) ? "0" : wlossKgTb.Text), historyTB.Text, extraTB.Text, p_id);
                MessageBox.Show("Saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void patient_history_Load(object sender, EventArgs e)
        {

        }
        

    }
}
