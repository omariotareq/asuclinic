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
    public partial class examination_form : Form
    {
        long p_id = 0;
        public examination_form(long pa_id, string name, int age)
        {
            InitializeComponent();
            patNameLb.Text = name;
            ageLbl.Text = "" + age;
        }
    }
}
