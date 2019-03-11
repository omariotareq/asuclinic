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
    public partial class pathology_form : Form
    {
        int p_id = 0;
        int mode = 0;
        int entry_id = 0;

        DataTable dt_date = new DataTable();
        BindingSource dateBindingSource = new BindingSource();

        DataTable dt = new DataTable();
        BindingSource pathBindingSource = new BindingSource();
        public pathology_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            patNameLb.Text = name;
            ageLbl.Text = "" + age;
            p_id = pa_id;

            refreshDateCB();
            dateCB.Text = "";
        }

        private void refreshDateCB()
        {
            dateCB.SelectedIndexChanged -= dateCB_SelectedIndexChanged;


            dt_date = DataSet.getPatholgyDates(p_id);
            dateBindingSource.DataSource = dt_date;
            dateCB.DataSource = dt_date;
            dateCB.DisplayMember = "patholgydate";

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
                        tb.Text = "";
                    }
                    if (tb is CheckBox)
                    {
                        ((CheckBox)tb).Checked = false;
                    }
                }

            }


        }


        private void fillData(string date)
        {
            try
            {

                clearBindings();
                dt = DataSet.getpathologydata(date, p_id);
                pathBindingSource.DataSource = dt;

                pathDate.DataBindings.Clear();

                entry_id = Convert.ToInt32(dt.Rows[0]["id"]);

                pathDate.ValueChanged -= pathDate_ValueChanged;
                this.pathDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.pathBindingSource, "patholgydate", true));
                pathDate.ValueChanged += pathDate_ValueChanged;

                this.ileumInfReaction.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "ileir", true));
                this.archDist.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "ilad", true));
                this.infCells.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "ilic", true));
                this.neutInf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Niil", true));
                this.erosionTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "ilER", true));
                this.colonInfReaction.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "irco", true));
                this.cryptDist.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "cradco", true));
                this.basalLymph.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "balco", true));
                this.cryptAbc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "crycco", true));
                this.laminaEosino.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "lamineosco", true));
                this.otherIlealFindingsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "otherileal", true));
                this.colonOtherFindingsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "otherfindings", true));
                this.finalReportTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "finalreport", true));

                if (Convert.ToInt32(dt.Rows[0]["ucil"]) == 1)
                {
                    UlcChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["grail"]) == 1)
                {
                    granChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["lamneutroco"]) == 1)
                {
                    laminaNeutroChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["ulceco"]) == 1)
                {
                    colonUlcChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["granilco"]) == 1)
                {
                    colonGranChkbx.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mode = 1;
            fillData(dateCB.Text);
            Cursor.Current = Cursors.Default;
        }

        private void pathology_form_Load(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int ulc=0;
                int gran =0;
                int lam = 0;
                int colon_ulc =0;
                int colon_gran=0;
                if(UlcChkbx.Checked){
                    ulc =1 ;
                }
                if(granChkbx.Checked){
                    gran = 1;
                }
                if(laminaNeutroChkbx.Checked){
                    lam = 1;
                }
                if(colonUlcChkbx.Checked){
                    colon_ulc = 1;
                }
                if(colonGranChkbx.Checked){
                    colon_gran =1;
                }

                if (mode == 0)
                {
                    DataSet.Insertpatholgydata(pathDate.Value.Date, ileumInfReaction.Text, archDist.Text, infCells.Text, neutInf.Text, erosionTB.Text, Convert.ToInt16(UlcChkbx.Checked), Convert.ToInt16(granChkbx.Checked),
                        otherIlealFindingsTB.Text, colonInfReaction.Text, cryptDist.Text, basalLymph.Text, cryptAbc.Text, laminaEosino.Text, Convert.ToInt16(laminaNeutroChkbx.Checked), Convert.ToInt16(colonUlcChkbx.Checked),
                        Convert.ToInt16(colonGranChkbx.Checked), colonOtherFindingsTB.Text, finalReportTB.Text, p_id);
                }
                else if (mode == 1)
                {
                    DataSet.Updatepatholgydata(pathDate.Value.Date, ileumInfReaction.Text, archDist.Text, infCells.Text, neutInf.Text, erosionTB.Text, Convert.ToInt16(UlcChkbx.Checked), Convert.ToInt16(granChkbx.Checked),
                        otherIlealFindingsTB.Text, colonInfReaction.Text, cryptDist.Text, basalLymph.Text, cryptAbc.Text, laminaEosino.Text, Convert.ToInt16(laminaNeutroChkbx.Checked), Convert.ToInt16(colonUlcChkbx.Checked),
                        Convert.ToInt16(colonGranChkbx.Checked), colonOtherFindingsTB.Text, finalReportTB.Text, p_id, entry_id);
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
                                        pathDate.ValueChanged -= pathDate_ValueChanged;
                                        fillData(pathDate.Value.Date.ToString());
                                        pathDate.ValueChanged += pathDate_ValueChanged;
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

        private void pathDate_ValueChanged(object sender, EventArgs e)
        {
            mode = 0;
            clearBindings();
        }


    }
}
