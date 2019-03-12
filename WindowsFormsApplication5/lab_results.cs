using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        int mode = 0;
        int entry_id = 0;

        BindingSource dateBindingSource = new BindingSource();
        BindingSource resultsBindingSource = new BindingSource();
        DataTable dt = new DataTable();
        DataTable dt_date = new DataTable();
        
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
                Cursor.Current = Cursors.WaitCursor;
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

                if (mode == 0)
                {
                    DataSet.InsertlabenteryInfo(labDate.Value.Date, hbTB.Text, (hematoTB.Text), (mcvTB.Text), (rdwTB.Text), (platltsTB.Text), (tlcTB.Text), (neutroTB.Text), (lymphoTB.Text), (eosinoTB.Text), (serumIronTB.Text), (tibcTB.Text), 
                        (serumFerrTB.Text), (esrTB.Text), (crpTB.Text), (pancaTB.Text), (ascaTB.Text), (fecalTB.Text), (ttgTB.Text), (rbcTB.Text), (puscellsTB.Text), (closdeficileTB.Text), paraCheck, (stoolcsTB.Text), parasiteTB.Text, 
                        stoolothernotesTB.Text, (tuberculinTB.Text), tuberculosisCheck, comboBox1.Text, hbcCheck, hbvCheck, hcvCheck, hivCheck, (amylaseTB.Text), (lipaseTB.Text), (naTB.Text), (kTB.Text), (caTB.Text), (mgTB.Text), (phosTB.Text), 
                        (altTB.Text), (astTB.Text), (tproteinTB.Text), (albuminTB.Text), (dbilirubinTB.Text), (tbilirubinTB.Text), (alpTB.Text), (ggtTB.Text), (inrTB.Text), (screatTB.Text), (bunTB.Text), otherlabdataTB.Text, p_id, (ibilirubinTB.Text));
                }
                else if (mode == 1) 
                {
                    DataSet.Updatelabentery(labDate.Value.Date, hbTB.Text, (hematoTB.Text), (mcvTB.Text), (rdwTB.Text), (platltsTB.Text), (tlcTB.Text), (neutroTB.Text), (lymphoTB.Text), (eosinoTB.Text), (serumIronTB.Text), (tibcTB.Text),
                        (serumFerrTB.Text), (esrTB.Text), (crpTB.Text), (pancaTB.Text), (ascaTB.Text), (fecalTB.Text), (ttgTB.Text), (rbcTB.Text), (puscellsTB.Text), (closdeficileTB.Text), paraCheck, (stoolcsTB.Text), parasiteTB.Text,
                        stoolothernotesTB.Text, (tuberculinTB.Text), tuberculosisCheck, comboBox1.Text, hbcCheck, hbvCheck, hcvCheck, hivCheck, (amylaseTB.Text), (lipaseTB.Text), (naTB.Text), (kTB.Text), (caTB.Text), (mgTB.Text), (phosTB.Text),
                        (altTB.Text), (astTB.Text), (tproteinTB.Text), (albuminTB.Text), (dbilirubinTB.Text), (tbilirubinTB.Text), (alpTB.Text), (ggtTB.Text), (inrTB.Text), (screatTB.Text), (bunTB.Text), otherlabdataTB.Text, p_id,entry_id, (ibilirubinTB.Text));
                }

                MessageBox.Show("Saved Successfully");

                refreshDateCB();
                Cursor.Current = Cursors.Default;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2601:
                       MouseEventArgs me = (MouseEventArgs)e;
                        DialogResult dr = MessageBox.Show("This date already data registered on the system! \nWould you like to edit the current entry?\nIf no please choose a different date.", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                                    if (dr == DialogResult.Yes)
                                    {
                                        mode = 1;
                                        Cursor.Current = Cursors.WaitCursor;
                                        labDate.ValueChanged -= labDate_ValueChanged;
                                        fillData(labDate.Value.Date.ToString());
                                        labDate.ValueChanged += labDate_ValueChanged;
                                        Cursor.Current = Cursors.Default;
                                    }
                                    if (dr == DialogResult.No)
                                    {
                                        mode = 0;
                                    }
                                
                        
                        break;
                    default:
                        throw;
                }
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
                entry_id = Convert.ToInt32(dt.Rows[0]["id"]);

                labDate.ValueChanged -= labDate_ValueChanged;
                this.labDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.resultsBindingSource, "labdate", true));
                labDate.ValueChanged += labDate_ValueChanged;

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
            Cursor.Current = Cursors.WaitCursor;
            
            fillData(dateCB.Text);
            mode = 1;

            Cursor.Current = Cursors.Default;
        }

        private void fillData(string date)
        {
            
            if (dateCB.Text != "")
            {
                try
                {
                    //resultsBindingSource.DataSource = null;
                    dt.Clear();
                    dt = DataSet.getLabDetails(date, p_id);
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
