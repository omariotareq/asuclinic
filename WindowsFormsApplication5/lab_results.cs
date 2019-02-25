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
        BindingSource resultsBindingSource = new BindingSource();
        DataTable dt = new DataTable();
        DataTable dt_date = new DataTable();
        int mode = 0;
        public lab_results(int pa_id, string name, int age)
        {
            InitializeComponent();
            patNameLb.Text = name;
            ageLbl.Text = "" + age;
            p_id = pa_id;

            refreshDateCB();
            
        }

        private void refreshDateCB()
        {
            dateCB.SelectedIndexChanged -= dateCB_SelectedIndexChanged_1;


            dt_date = DataSet.getPatientLabDates(p_id);
            dateBindingSource.DataSource = dt_date;
            dateCB.DataSource = dt_date;
            dateCB.DisplayMember = "labdate";

            dateCB.SelectedIndexChanged += dateCB_SelectedIndexChanged_1;
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
                DataSet.InsertlabenteryInfo(labDate.Value.Date, Convert.ToInt16(hbTB.Text), Convert.ToInt16(hematoTB.Text), Convert.ToInt16(mcvTB.Text), Convert.ToInt16(rdwTB.Text), Convert.ToInt16(platltsTB.Text), Convert.ToInt16(tlcTB.Text), Convert.ToInt16(neutroTB.Text), Convert.ToInt16(lymphoTB.Text), Convert.ToInt16(eosinoTB.Text), Convert.ToInt16(serumIronTB.Text), Convert.ToInt16(tibcTB.Text), Convert.ToInt16(serumFerrTB.Text), Convert.ToInt16(esrTB.Text), Convert.ToInt16(crpTB.Text), Convert.ToInt16(pancaTB.Text), Convert.ToInt16(ascaTB.Text),Convert.ToInt16(fecalTB.Text), Convert.ToInt16(ttgTB.Text), Convert.ToInt16(rbcTB.Text), Convert.ToInt16(puscellsTB.Text), Convert.ToInt16(closdeficileTB.Text), paraCheck, Convert.ToInt16(stoolcsTB.Text), parasiteTB.Text, stoolothernotesTB.Text, Convert.ToInt16(tuberculinTB.Text), tuberculosisCheck, comboBox1.Text, hbcCheck, hbvCheck, hcvCheck, hivCheck, Convert.ToInt16(amylaseTB.Text), Convert.ToInt16(lipaseTB.Text), Convert.ToInt16(naTB.Text), Convert.ToInt16(kTB.Text), Convert.ToInt16(caTB.Text), Convert.ToInt16(mgTB.Text), Convert.ToInt16(phosTB.Text), Convert.ToInt16(altTB.Text), Convert.ToInt16(astTB.Text), Convert.ToInt16(tproteinTB.Text), Convert.ToInt16(albuminTB.Text), Convert.ToInt16(dbilirubinTB.Text), Convert.ToInt16(tbilirubinTB.Text), Convert.ToInt16(alpTB.Text), Convert.ToInt16(ggtTB.Text), Convert.ToInt16(inrTB.Text), Convert.ToInt16(screatTB.Text), Convert.ToInt16(bunTB.Text), otherlabdataTB.Text, p_id, Convert.ToInt16(ibilirubinTB.Text));
                MessageBox.Show("Saved Successfully");

                refreshDateCB();
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

        private void dateCB_SelectedIndexChanged(object sender, EventArgs e)
        {

            DateTime asDate = DateTime.Parse(dateCB.Text);

      
        }

        private void loadLabResults()
        {
            tuberChkbx.Checked = false;
            hbcChkbx.Checked = false;
            hbvChkbx.Checked = false;
            hcvChkbx.Checked = false;
            hivChkbx.Checked = false;
            parasitesChkbx.Checked = false;
            comboBox1.DataBindings.Clear();
            otherlabdataTB.DataBindings.Clear();
            labDate.DataBindings.Clear();
            foreach (Control gb in groupBox1.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is TextBox)
                        {
                            tb.DataBindings.Clear();
                        }
                    }
                }
            }
            
            if (dt.Rows.Count > 0)
            {
                this.labDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "labdate", true));
                

                this.hbTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "cbchb", true));
                this.mcvTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "cbcmcv", true));
                this.hematoTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "cbchema", true));
                this.platltsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "cbcplatlets", true));
                this.tlcTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "cbctlc", true));
                this.neutroTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "cbcneuro", true));
                this.rdwTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "cbcrdw", true));
                this.lymphoTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "cbclym", true));
                this.eosinoTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "cbceos", true));
                this.serumIronTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "ironstudyseriron", true));
                this.serumFerrTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "ironstudyserumfe", true));
                this.tibcTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "ironstudytibc", true));
                this.altTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFALT", true));
                this.astTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFAST", true));
                this.tproteinTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFTp", true));
                this.albuminTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFAlb", true));
                this.dbilirubinTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFdb", true));
                this.tbilirubinTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFtb", true));
                this.ibilirubinTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFib", true));
                this.alpTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFALP", true));
                this.ggtTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFGGT", true));
                this.inrTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFINR", true));
                this.screatTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFScreat", true));
                this.bunTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "LARFBUN", true));
                this.tuberculinTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "INFtt", true));
                this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "INQua", true));


                if (Convert.ToInt32(dt.Rows[0]["INFtp"]) == 1)
                {
                    tuberChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["INHB"]) == 1)
                {
                    hbcChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["INHBV"]) == 1)
                {
                    hbvChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["INHC"]) == 1)
                {
                    hcvChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["INHIV"]) == 1)
                {
                    hivChkbx.Checked = true;
                }

                this.esrTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "iaimESR", true));
                this.crpTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "iaimCRP", true));
                this.pancaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "iaimpANCA", true));
                this.ascaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "iaimASCA", true));
                this.fecalTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "iaimfecacal", true));
                this.ttgTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "iaimAntiTTG", true));
                this.amylaseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "BCAm", true));
                this.lipaseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "BCLI", true));
                this.naTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "BCNA", true));
                this.kTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "BCK", true));
                this.caTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "BCCa", true));
                this.mgTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "BCMg", true));
                this.phosTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "BCph", true));
                this.rbcTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "SARBCs", true));
                this.puscellsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "SApuscells", true));
                this.stoolcsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "SAstoolcs", true));
                this.closdeficileTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "SAclodef", true));
                this.parasiteTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "SAparanotes", true));
                this.stoolothernotesTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "SAothernotes", true));

                if (Convert.ToInt32(dt.Rows[0]["SApara"]) == 1)
                {
                    parasitesChkbx.Checked = true;
                }

                this.otherlabdataTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.resultsBindingSource, "otherlabdetails", true));
            }
        }

        private void dateCB_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mode = 1;
            if (dateCB.Text != "")
            {
                try
                {
                    //resultsBindingSource.DataSource = null;
                    dt.Clear();
                    dt = DataSet.getLabDetails(dateCB.Text, p_id);
                    resultsBindingSource.DataSource = dt;
                    loadLabResults();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void labDate_ValueChanged(object sender, EventArgs e)
        {
            mode = 0;
            foreach (Control gb in groupBox1.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is TextBox)
                        {
                            tb.Text = "";
                        }
                    }
                }
            }
        }




    }
}
