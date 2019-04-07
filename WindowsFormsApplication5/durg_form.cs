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
    public partial class durg_form : Form
    {
        int p_id = 0;
        int mode = 0;
        int entry_id = 0;

        DataTable dt_date = new DataTable();
        BindingSource dateBindingSource = new BindingSource();

        DataTable dt = new DataTable();
        BindingSource pathBindingSource = new BindingSource();

        public durg_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            patNameLb.Text = name;
            ageLbl.Text = "" + age;
            p_id = pa_id;

            refreshDateCB();
        }


        private void refreshDateCB()
        {
            dateCB.SelectedIndexChanged -= dateCB_SelectedIndexChanged;


            dt_date = DataSet.getDrugDates(p_id);
            dateBindingSource.DataSource = dt_date;
            dateCB.DataSource = dt_date;
            dateCB.DisplayMember = "Recorddate";

            dateCB.SelectedIndexChanged += dateCB_SelectedIndexChanged;
        }
        private void clearBindings()
        {
            foreach (Control gb in this.Controls)
            {

                foreach (Control tb in gb.Controls)
                {
                    if (tb is TextBox)
                    {
                        tb.DataBindings.Clear();
                        tb.Text = "";
                    }
                    if (tb is ComboBox)
                    {
                        tb.DataBindings.Clear();
                    }
                    if (tb is CheckBox)
                    {
                        ((CheckBox)tb).Checked = false;
                        tb.DataBindings.Clear();
                    }
                }

            }


        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (mode == 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DataSet.Insertdruginfo(drugDate.Value.Date, Convert.ToInt16(steroidTreatChkbx.Checked), sterDoseTB.Text, steriodWeekNoTB.Text, steriodNotesTB.Text, Convert.ToInt16(sulphaChkbx.Checked), sulphaDoseTB.Text, sulphaWeekTB.Text,
                        Convert.ToInt16(oralMesaChkbx.Checked), oralMesaDoseTB.Text, oralMesaWeekTB.Text, Convert.ToInt16(rectalMesaChkbx.Checked), rectalMesaDoseTB.Text, rectalMesaWeekTB.Text, Convert.ToInt16(mtxTreatChkbx.Checked), mtxTreatDoseTB.Text,
                        mtxTreatWeekTB.Text, Convert.ToInt16(azaTreatChkbx.Checked), azaTreatDoseTB.Text, azaTreatWeekTB.Text, Convert.ToInt16(ifxTreatChkbx.Checked), ifxTreatDoseTB.Text, ifxTreatWeekTB.Text, Convert.ToInt16(adaTreatChkbx.Checked),
                        adaTreatDoseTB.Text, adaTreatWeekTB.Text, Convert.ToInt16(goliTreatChkbx.Checked), goliTreatDoseTB.Text, goliTreatWeekTB.Text, Convert.ToInt16(ustekinTreatChkbx.Checked), ustekinTreatDoseTB.Text, ustekinTreatWeekTB.Text,
                        bioTherapyNotesTB.Text, Convert.ToInt16(vitDChkbx.Checked), Convert.ToInt16(caChkbx.Checked), Convert.ToInt16(ppiTreatChkbx.Checked), Convert.ToInt16(folicAcidChkbx.Checked), Convert.ToInt16(ironChkbx.Checked), routeCB.Text,
                        suppTherapyDoseTB.Text, Convert.ToInt16(antibioticChkbx.Checked), antibioticDetailsTB.Text, otherMedicationNotesTB.Text, p_id);
                    Cursor.Current = Cursors.Default;
                }
                else if (mode == 1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DataSet.Updatedruginfo(drugDate.Value.Date, Convert.ToInt16(steroidTreatChkbx.Checked), sterDoseTB.Text, steriodWeekNoTB.Text, steriodNotesTB.Text, Convert.ToInt16(sulphaChkbx.Checked), sulphaDoseTB.Text, sulphaWeekTB.Text,
                        Convert.ToInt16(oralMesaChkbx.Checked), oralMesaDoseTB.Text, oralMesaWeekTB.Text, Convert.ToInt16(rectalMesaChkbx.Checked), rectalMesaDoseTB.Text, rectalMesaWeekTB.Text, Convert.ToInt16(mtxTreatChkbx.Checked), mtxTreatDoseTB.Text,
                        mtxTreatWeekTB.Text, Convert.ToInt16(azaTreatChkbx.Checked), azaTreatDoseTB.Text, azaTreatWeekTB.Text, Convert.ToInt16(ifxTreatChkbx.Checked), ifxTreatDoseTB.Text, ifxTreatWeekTB.Text, Convert.ToInt16(adaTreatChkbx.Checked),
                        adaTreatDoseTB.Text, adaTreatWeekTB.Text, Convert.ToInt16(goliTreatChkbx.Checked), goliTreatDoseTB.Text, goliTreatWeekTB.Text, Convert.ToInt16(ustekinTreatChkbx.Checked), ustekinTreatDoseTB.Text, ustekinTreatWeekTB.Text,
                        bioTherapyNotesTB.Text, Convert.ToInt16(vitDChkbx.Checked), Convert.ToInt16(caChkbx.Checked), Convert.ToInt16(ppiTreatChkbx.Checked), Convert.ToInt16(folicAcidChkbx.Checked), Convert.ToInt16(ironChkbx.Checked), routeCB.Text,
                        suppTherapyDoseTB.Text, Convert.ToInt16(antibioticChkbx.Checked), antibioticDetailsTB.Text, otherMedicationNotesTB.Text, p_id,entry_id);
                    Cursor.Current = Cursors.Default;
                }
                MessageBox.Show("Saved successfully");
                refreshDateCB();
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
                                        drugDate.ValueChanged -= drugDate_ValueChanged;
                                        fillData(drugDate.Value.Date.ToString());
                                        drugDate.ValueChanged += drugDate_ValueChanged;
                                        Cursor.Current = Cursors.Default;
                                    }
                                    if (dr == DialogResult.No)
                                    {
                                        mode = 0;
                                    }
                                
                        
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
        }

        private void dateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                mode = 1;
                fillData(dateCB.Text);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillData(string date)
        {
            dt = DataSet.getDrugs(date, p_id);
            pathBindingSource.DataSource = dt;

            clearBindings();
            drugDate.DataBindings.Clear();

            entry_id = Convert.ToInt32(dt.Rows[0]["id"]);

            drugDate.ValueChanged -= drugDate_ValueChanged;
            this.drugDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.pathBindingSource, "Recorddate", true));
            drugDate.ValueChanged += drugDate_ValueChanged;

            this.steroidTreatChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "steroidtreat", true));
            this.sterDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Dose", true));
            this.steriodWeekNoTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Wekkno", true));
            this.steriodNotesTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Steroidsnotes", true));

            this.sulphaChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "Asas", true));
            this.sulphaDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Asad", true));
            this.sulphaWeekTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Asaw", true));
            

            this.oralMesaChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "Asao", true));
            this.oralMesaDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Asaod", true));
            this.oralMesaWeekTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Asaow", true));

            this.rectalMesaChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "Asar", true));
            this.rectalMesaDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Asard", true));
            this.rectalMesaWeekTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Asarw", true));

            this.mtxTreatChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "immmtx", true));
            this.mtxTreatDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "immmd", true));
            this.mtxTreatWeekTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "immmw", true));

            this.azaTreatChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "imma", true));
            this.azaTreatDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "immad", true));
            this.azaTreatWeekTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "immaw", true));

            this.ifxTreatChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "bif", true));
            this.ifxTreatDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "bifd", true));
            this.ifxTreatWeekTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "bifw", true));

            this.adaTreatChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "bad", true));
            this.adaTreatDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "badd", true));
            this.adaTreatWeekTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "badw", true));

            this.goliTreatChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "bgo", true));
            this.goliTreatDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "bgod", true));
            this.goliTreatWeekTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "bgow", true));

            this.ustekinTreatChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "bus", true));
            this.ustekinTreatDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "busd", true));
            this.ustekinTreatWeekTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "busw", true));

            this.bioTherapyNotesTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Biolgnotes", true));

            this.vitDChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "supvit", true));
            this.caChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "supca", true));
            this.ppiTreatChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "supppi", true));
            this.folicAcidChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "suppfa", true));
            this.ironChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "suppiron", true));

            this.routeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "suproute", true));
            this.suppTherapyDoseTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "supdose", true));

            this.antibioticChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pathBindingSource, "antiat", true));
            this.antibioticDetailsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "antidetails", true));

            this.otherMedicationNotesTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "othermedication", true));



        }


        private void drugDate_ValueChanged(object sender, EventArgs e)
        {
            clearBindings();
            mode = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void durg_form_Load(object sender, EventArgs e)
        {
            string usrAccess = WindowsFormsApplication5.Properties.Settings.Default.drAccess;
            if (Convert.ToInt16(usrAccess) < 1)
            {
                saveBtn.Visible = false;
            }
        }
    }
}
