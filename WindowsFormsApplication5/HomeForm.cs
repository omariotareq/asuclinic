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
        public HomeForm()
        {
            InitializeComponent();
            String name = WindowsFormsApplication5.Properties.Settings.Default.drName;
           
            drNameLbl.Text = char.ToUpper(name[0]) + name.Substring(1);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            patients_form pf = new patients_form();
            pf.ShowDialog();
        }
    }
}
