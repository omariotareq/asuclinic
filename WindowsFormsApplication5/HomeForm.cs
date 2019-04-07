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
    public partial class HomeForm : Form
    {
       string usrAccess = WindowsFormsApplication5.Properties.Settings.Default.drAccess;
        public HomeForm()
        {
            InitializeComponent();
            String name = WindowsFormsApplication5.Properties.Settings.Default.drName;
           
            //.Text = char.ToUpper(name[0]) + name.Substring(1);

            if (Convert.ToInt16(usrAccess) == 0)
            {
                adminTab.Visible = false;
                adminLbl.Visible = false;
                pictureBox1.Visible = false;
                label1.Visible = false;
            }
            else if (Convert.ToInt16(usrAccess) == 1)
            {
                adminTab.Visible = false;
                adminLbl.Visible = false;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            patients_form pf = new patients_form();
            this.Hide();
            pf.ShowDialog();
            this.Close();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            if ( Convert.ToInt16(usrAccess) < 1)
            {
                adminTab.Visible = false;
                adminLbl.Visible = false;
                pictureBox1.Visible = false;
                label1.Visible = false;
            }
        }

        private void adminTab_Click(object sender, EventArgs e)
        {
            users_control uc = new users_control();
            uc.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Login_Form lf = new Login_Form(); 
            this.Hide();
            lf.ShowDialog();
            this.Close();
        }
    }
}
