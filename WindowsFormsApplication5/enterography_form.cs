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
    public partial class enterography_form : Form
    {
        int p_id = 0;
        public enterography_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            patNameLb.Text = name;
            ageLbl.Text = "" + age;
            p_id = pa_id;
        }

        public static char[] intToBinary(int number)
        {
            

            var array = Convert.ToString(number, 2).PadLeft(7, '0').ToArray();

            return array;
        }

        public static int binToInt(string number)
        {
            int output = Convert.ToInt32(number, 2);

            return output;
        }

       
    }
}
