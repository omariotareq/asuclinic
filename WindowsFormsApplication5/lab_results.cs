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
                int paraCheck=0;
                int hbcCheck=0;
                int hbvCheck=0;
                int hivCheck = 0;
                int hcvCheck = 0;
                int tuberculosisCheck = 0;
                if (parasitesChkbx.Checked)
                {
                    paraCheck = 1;
                }
                if (hbcChkbx.Checked)
                {
                    hbcCheck = 1;
                }
                if (hbvChkbx.Checked)
                {
                    hbvCheck = 1;
                }
                if (hivChkbx.Checked)
                {
                    hivCheck = 1;
                }
                if (hcvChkbx.Checked)
                {
                    hcvCheck = 1;
                }
                if (tuberChkbx.Checked)
                {
                    tuberculosisCheck = 1;
                }
                DataSet.InsertlabenteryInfo(labDate.Value.Date, Convert.ToInt16(hbTB.Text), Convert.ToInt16(hematoTB.Text), Convert.ToInt16(mcvTB.Text), Convert.ToInt16(rdwTB.Text), Convert.ToInt16(platltsTB.Text), Convert.ToInt16(tlcTB.Text), Convert.ToInt16(neutroTB.Text), Convert.ToInt16(lymphoTB.Text), Convert.ToInt16(eosinoTB.Text), Convert.ToInt16(serumIronTB.Text), Convert.ToInt16(tibcTB.Text), Convert.ToInt16(serumFerrTB.Text), Convert.ToInt16(esrTB.Text), Convert.ToInt16(crpTB.Text), Convert.ToInt16(pancaTB.Text), Convert.ToInt16(ascaTB.Text), Convert.ToInt16(ttgTB.Text), Convert.ToInt16(rbcTB.Text), Convert.ToInt16(puscellsTB.Text), Convert.ToInt16(closdeficileTB.Text), paraCheck, Convert.ToInt16(stoolcsTB.Text), parasiteTB.Text, stoolothernotesTB.Text, Convert.ToInt16(tuberculinTB.Text), tuberculosisCheck, comboBox1.Text, hbcCheck, hbvCheck, hcvCheck, hivCheck, Convert.ToInt16(amylaseTB.Text), Convert.ToInt16(lipaseTB.Text), Convert.ToInt16(naTB.Text), Convert.ToInt16(kTB.Text), Convert.ToInt16(caTB.Text), Convert.ToInt16(mgTB.Text), Convert.ToInt16(phosTB.Text), Convert.ToInt16(altTB.Text), Convert.ToInt16(astTB.Text), Convert.ToInt16(tproteinTB.Text), Convert.ToInt16(albuminTB.Text), Convert.ToInt16(dbilirubinTB.Text), Convert.ToInt16(tbilirubinTB.Text), Convert.ToInt16(alpTB.Text), Convert.ToInt16(ggtTB.Text), Convert.ToInt16(inrTB.Text), Convert.ToInt16(screatTB.Text), Convert.ToInt16(bunTB.Text), otherlabdataTB.Text, p_id, Convert.ToInt16(ibilirubinTB.Text));
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
