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
        long user_id = 0;
        public Login_Form()
        {
            InitializeComponent();
        }
        
        private void lgnBtn_Click(object sender, EventArgs e)
        {
            user_id = DataSet.getUserID(loginTB.Text, passwordTB.Text);
            if(user_id != 0){
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();
                this.Close();
            }
            else{
                MessageBox.Show("failure bitch");
            }
        }
    }
}
