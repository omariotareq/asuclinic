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
	public partial class surgery_form : Form
	{
		int p_id = 0;
		public surgery_form(int pa_id,string name ,int age)
		{
			InitializeComponent();
			patNameLb.Text = name;
			ageLbl.Text = "" + age;
			//hkjhk/
			p_id = pa_id;
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}