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
    public partial class action_form : Form
    {
        int p_id = 0;

        DataTable dt_date = new DataTable();
        DataTable dt = new DataTable();

        BindingSource mainBindingSource = new BindingSource();
        BindingSource dateBindingSource = new BindingSource();


        public action_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            p_id = pa_id;
            patNameLb.Text = name;
            ageLbl.Text = "" + age;

            refreshDateCB();
            clearBindings();
        }

        private void action_form_Load(object sender, EventArgs e)
        {

        }

        private void refreshDateCB()
        {
            dateCB.SelectedIndexChanged -= dateCB_SelectedIndexChanged;


            dt_date = DataSet.getActionDates(p_id);
            dateBindingSource.DataSource = dt_date;
            dateCB.DataSource = dt_date;
            dateCB.DisplayMember = "planDate";

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
                        tb.DataBindings.Clear();
                    }
                }

            }


        }



        private void dateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            actionDate.ValueChanged -= actionDate_ValueChanged;
            fillData();
            actionDate.ValueChanged += actionDate_ValueChanged;
            Cursor.Current = Cursors.Default;
        }


        private void fillData()
        {
            try
            {
                dt = DataSet.getActionall(dateCB.Text, p_id);
                mainBindingSource.DataSource = dt;

                actionDate.DataBindings.Clear();
                nxtDate.DataBindings.Clear();
                clearBindings();

                this.caiCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Clinicalactivityindex", true));
                this.cdaiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "CDAI", true));
                this.twCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "TWID", true));
                this.eaiCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Endoscopicactivity", true));
                this.seseaiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "SESendoscopic", true));
                this.montreal1CB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Monteralactivityindexno", true));
                this.montreal2CB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Monteralindexle", true));
                this.mayoTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Mayoscore", true));
                this.currentStatusCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "currentpatientstatus", true));
                this.currentPlanTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Detailsofcplan", true));
                this.decisionStaffTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Decisionstuff", true));
                this.nxtDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Datenextvisit", true));
                this.fuResidentTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Responsibleresident", true));
                this.actionDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "planDate", true));

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
                DataSet.InsertActionplandata(caiCB.Text, cdaiTB.Text, twCB.Text, eaiCB.Text, seseaiTB.Text, montreal1CB.Text, montreal2CB.Text, mayoTB.Text, currentStatusCB.Text
                    , currentPlanTB.Text, decisionStaffTB.Text, nxtDate.Value.Date, fuResidentTB.Text, actionDate.Value.Date, p_id);

                MessageBox.Show("Saved Successfully");
                refreshDateCB();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2601:
                        MessageBox.Show("This date already contains enterography results registered on the system! \nPlease try a differenet date");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
        }

        private void actionDate_ValueChanged(object sender, EventArgs e)
        {
            clearBindings();
        }

        private void actionDate_Validated(object sender, EventArgs e)
        {
            
        }

    }
}
