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
    public partial class edit_user_form : Form
    {
        private int u_id = 0;
        public edit_user_form(int id)
        {
            InitializeComponent();
            u_id = id;
            populateCB();
            fillData(u_id);
            
        }

        public void fillData(int id)
        {
            try
            {

                DataTable dt = new DataTable();
                BindingSource usrBindingSource = new BindingSource();
                dt = DataSet.getUserData(id);
                usrBindingSource.DataSource = dt;

                this.usrTb.DataBindings.Add(
                    new System.Windows.Forms.Binding("Text", usrBindingSource, "username", true));
                this.pwTb.DataBindings.Add(
                    new System.Windows.Forms.Binding("Text", usrBindingSource, "password", true));
                this.comboBox1.DataBindings.Add(
                    new System.Windows.Forms.Binding("Text", usrBindingSource, "access", true));


            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error, Please try again");
            }
        }

        public class cbItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        public void populateCB()
        {
            var dataSource = new List<cbItem>();
            dataSource.Add(new cbItem() { Name = "Admin", Value = "2" });
            dataSource.Add(new cbItem() { Name = "View and Edit", Value = "1" });
            dataSource.Add(new cbItem() { Name = "View Only", Value = "0" });

            //Setup data binding
            this.comboBox1.DataSource = dataSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Value";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (usrTb.Text != "" && pwTb.Text != "" && comboBox1.Text != "")
                {
                    DataSet.ModifyAccess(Convert.ToString(comboBox1.SelectedValue),usrTb.Text,pwTb.Text,u_id);
                    MessageBox.Show("New user created successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please fill boxes correctly");
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number )
                {
                    case 2601:
                        MessageBox.Show("Username already exists");
                        break;
                    default:
                        MessageBox.Show("Unsuccessful operation, please try again");
                        break;
                        
                }
            }
        }
    }
}
