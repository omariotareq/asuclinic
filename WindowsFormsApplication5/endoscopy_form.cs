﻿using System;
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
    public partial class endoscopy_form : Form
    {
        int p_id = 0;
        public endoscopy_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            p_id = pa_id;
            patNameLb.Text = name;
            ageLbl.Text = "" + age;
        }
    }
}