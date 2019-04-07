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
    public partial class Login_Form : Form
    {
       
        public Login_Form()
        {
            InitializeComponent();
        }
        
        private void lgnBtn_Click(object sender, EventArgs e)
        {
            DataSet.ReturnValues rv = new DataSet.ReturnValues();
            
            rv  = DataSet.getUserID(loginTB.Text, passwordTB.Text);
            if(rv.usrId != 0){
                Cursor.Current = Cursors.WaitCursor;
                WindowsFormsApplication5.Properties.Settings.Default.drId = rv.usrId;
                WindowsFormsApplication5.Properties.Settings.Default.drAccess = rv.usrAccess;
                WindowsFormsApplication5.Properties.Settings.Default.drName = loginTB.Text;
                HomeForm f1 = new HomeForm();
                this.Hide();
                f1.ShowDialog();
                Cursor.Current = Cursors.Default;
                this.Close();
            }
            else{
                MessageBox.Show("Wrong Username or Password");
            }
        }
    }
}
