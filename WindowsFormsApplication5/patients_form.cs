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
    public partial class patients_form : Form
    {
        BindingSource dataGridView1BindingSource = new BindingSource();
        bool isRowAdded = false;
        public patients_form()
        {
            InitializeComponent();
            fillAllGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patient_name = "%" + textBox1.Text + "%";
            fillGV(patient_name);

        }

        private void fillAllGV()
        {
            isRowAdded = false;
            DataTable dt = DataSet.selectAllPatients();
            dataGridView1BindingSource.DataSource = dt;

            dataGridView1.Columns["id"].DataPropertyName = "id";
            dataGridView1.Columns["FirstName"].DataPropertyName = "fname";
            dataGridView1.Columns["LastName"].DataPropertyName = "lname";
            dataGridView1.Columns["MiddleName"].DataPropertyName = "mname";
            dataGridView1.Columns["Age"].DataPropertyName = "age";
            dataGridView1.Columns["Telephone"].DataPropertyName = "tele";


            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = dataGridView1BindingSource;

        }
        private void fillGV(String patName)
        {
            isRowAdded = false;
            DataTable dt = DataSet.getAllpatientinfo(patName);
            dataGridView1BindingSource.DataSource = dt;

            dataGridView1.Columns["id"].DataPropertyName = "id";
            dataGridView1.Columns["FirstName"].DataPropertyName = "fname";
            dataGridView1.Columns["LastName"].DataPropertyName = "lname";
            dataGridView1.Columns["MiddleName"].DataPropertyName = "mname";
            dataGridView1.Columns["Age"].DataPropertyName = "age";
            dataGridView1.Columns["Telephone"].DataPropertyName = "tele";


            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = dataGridView1BindingSource;

        }

        private void patHistoryBtn_Click(object sender, EventArgs e)
        {
            int ri = dataGridView1.SelectedCells[0].RowIndex;
            int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
            string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
            int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);
            patient_history ph = new patient_history(p_id, name, age);
            ph.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ri = dataGridView1.SelectedCells[0].RowIndex;
            int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
            string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
            int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);
            examination_form ef = new examination_form(p_id, name, age);
            ef.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ri = dataGridView1.SelectedCells[0].RowIndex;
            int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
            string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
            int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);
            lab_results lr = new lab_results(p_id, name, age);
            lr.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ri = dataGridView1.SelectedCells[0].RowIndex;
            int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
            string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
            int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);
           
            
            enterography_form ef = new enterography_form(p_id, name, age);
            ef.ShowDialog();
        }

private void button5_Click(object sender, EventArgs e)
        {
            int ri = dataGridView1.SelectedCells[0].RowIndex;
            int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
            string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
            int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);


            pathology_form ef = new pathology_form(p_id, name, age);
            ef.ShowDialog();
        }

private void button5_Click_1(object sender, EventArgs e)
{
    int ri = dataGridView1.SelectedCells[0].RowIndex;
    int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
    string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
    int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);


    Surgery_form ef = new Surgery_form(p_id, name, age);
    ef.ShowDialog();
}

private void button6_Click(object sender, EventArgs e)
{
    int ri = dataGridView1.SelectedCells[0].RowIndex;
    int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
    string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
    int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);


    ultrasound_form ef = new ultrasound_form(p_id, name, age);
    ef.ShowDialog();
}

private void button7_Click(object sender, EventArgs e)
{
    int ri = dataGridView1.SelectedCells[0].RowIndex;
    int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
    string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
    int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);


    endoscopy_form ef = new endoscopy_form(p_id, name, age);
    ef.ShowDialog();
}

private void button8_Click(object sender, EventArgs e)
{
    int ri = dataGridView1.SelectedCells[0].RowIndex;
    int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
    string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
    int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);


    durg_form ef = new durg_form(p_id, name, age);
    ef.ShowDialog();
}

private void button9_Click(object sender, EventArgs e)
{
    int ri = dataGridView1.SelectedCells[0].RowIndex;
    int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
    string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
    int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);


    action_form ef = new action_form(p_id, name, age);
    ef.ShowDialog();
}

private void button11_Click(object sender, EventArgs e)
{
    int ri = dataGridView1.SelectedCells[0].RowIndex;
    int p_id = Convert.ToInt16(dataGridView1.Rows[ri].Cells[0].Value);
    string name = Convert.ToString(dataGridView1.Rows[ri].Cells[1].Value) + Convert.ToString(dataGridView1.Rows[ri].Cells[2].Value) + " " + Convert.ToString(dataGridView1.Rows[ri].Cells[3].Value);
    int age = Convert.ToInt16(dataGridView1.Rows[ri].Cells[4].Value);


    patient_info_form ef = new patient_info_form(p_id);
    ef.ShowDialog();
}

private void button12_Click(object sender, EventArgs e)
{
    HomeForm hf = new HomeForm();
    this.Hide();
    hf.ShowDialog();
    this.Close();
}
    }        
}
