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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show("Hi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }

        private void genderCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (genderCB.Text == "Female")
            {
                mensLbl.Visible = true;
                mensTB.Visible = true;
            }
            else
            {
                mensLbl.Visible = false;
                mensTB.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ///

        }




    }
}
