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
	public partial class Surgery_form : Form
	{
        int p_id = 0;
        int mode = 0;
        int entry_id = 0;

        DataTable dt_date = new DataTable();
        DataTable dt = new DataTable();

        BindingSource b_d = new BindingSource();
        BindingSource b_dd = new BindingSource();

		public Surgery_form(int pa_id, string name, int age)
		{
            
				InitializeComponent();
				patNameLb.Text = name;
				ageLbl.Text = "" + age;
				p_id = pa_id;

                refreshDateCB();
                
		}

		private void label18_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (mode == 0)
                {
                    DataSet.InsertSurgeryInfo(surgDate.Value.Date, surgicaInd.Text, operDetails.Text, surgicalComp.Text, p_id);
                }
                else if (mode == 1)
                {
                    DataSet.UpdateSurgeryInfo(surgDate.Value.Date, surgicaInd.Text, operDetails.Text, surgicalComp.Text, p_id, entry_id);
                }
                MessageBox.Show("Saved successfully");
            }
            catch(SqlException ex)
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
                                        surgDate.ValueChanged -= surgDate_ValueChanged;
                                        fillData(surgDate.Value.Date.ToString());
                                        surgDate.ValueChanged += surgDate_ValueChanged;
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

            refreshDateCB();
            
        }

        private void surgDatesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            surgDate.ValueChanged -= surgDate_ValueChanged;
            mode = 1;
            fillData(surgDatesCB.Text);
            surgDate.ValueChanged += surgDate_ValueChanged;
            Cursor.Current = Cursors.Default;
        }

        private void fillData(string date)
        {
            try
            {
                dt = DataSet.getSurgery(date, p_id);
                b_d.DataSource = dt;

                surgDate.DataBindings.Clear();
                surgicaInd.DataBindings.Clear();
                operDetails.DataBindings.Clear();
                surgicalComp.DataBindings.Clear();

                entry_id = Convert.ToInt32(dt.Rows[0]["id"]);
                this.surgDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.b_d, "Dateofsurgery", true));
                this.surgicaInd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.b_d, "surgicalindication", true));
                this.operDetails.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.b_d, "operativedetails", true));
                this.surgicalComp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.b_d, "surgicalcomplication", true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshDateCB()
        {
            surgDatesCB.SelectedIndexChanged -= surgDatesCB_SelectedIndexChanged;


            dt_date = DataSet.getSurgeryDates(p_id);
            b_dd.DataSource = dt_date;
            surgDatesCB.DataSource = dt_date;
            surgDatesCB.DisplayMember = "Dateofsurgery";

            surgDatesCB.SelectedIndexChanged += surgDatesCB_SelectedIndexChanged;
        }

        private void surgDate_ValueChanged(object sender, EventArgs e)
        {
            clearBindings();
            mode = 0;
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
                    }
                }

            }


        }
	}
}
