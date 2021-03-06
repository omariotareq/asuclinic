﻿namespace WindowsFormsApplication5
{
    partial class patient_history
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(patient_history));
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.patDiagnosisCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.abdPainCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.complainTB = new System.Windows.Forms.TextBox();
            this.feverCB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.teniChkbx = new System.Windows.Forms.CheckBox();
            this.diaChkbx = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.motionsTB = new System.Windows.Forms.TextBox();
            this.mucusCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bleedingCB = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.periChkbx = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.wlossChkbx = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.wlossKgTb = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.historyTB = new System.Windows.Forms.TextBox();
            this.extraTB = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.patNameLb = new System.Windows.Forms.Label();
            this.ageLbl = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Record Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "MMM/dd/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(215, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(149, 29);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(472, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status of patient\'s diagnosis";
            // 
            // patDiagnosisCB
            // 
            this.patDiagnosisCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patDiagnosisCB.AutoCompleteCustomSource.AddRange(new string[] {
            "Not Known IBD",
            "Known Crohn\'s",
            "Known UC",
            "Unspecified IBD type"});
            this.patDiagnosisCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patDiagnosisCB.FormattingEnabled = true;
            this.patDiagnosisCB.Items.AddRange(new object[] {
            "Not Known IBD",
            "Known Crohns",
            "Known UC",
            "Unspecified IBD type"});
            this.patDiagnosisCB.Location = new System.Drawing.Point(755, 28);
            this.patDiagnosisCB.Name = "patDiagnosisCB";
            this.patDiagnosisCB.Size = new System.Drawing.Size(194, 32);
            this.patDiagnosisCB.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "History";
            // 
            // abdPainCB
            // 
            this.abdPainCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.abdPainCB.AutoCompleteCustomSource.AddRange(new string[] {
            "Not Known IBD",
            "Known Crohn\'s",
            "Known UC",
            "Unspecified IBD type"});
            this.abdPainCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abdPainCB.FormattingEnabled = true;
            this.abdPainCB.Items.AddRange(new object[] {
            "None",
            "Mild",
            "Moderate",
            "Severe"});
            this.abdPainCB.Location = new System.Drawing.Point(201, 89);
            this.abdPainCB.Name = "abdPainCB";
            this.abdPainCB.Size = new System.Drawing.Size(177, 32);
            this.abdPainCB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Abdonimal pain";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Current complain";
            // 
            // complainTB
            // 
            this.complainTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complainTB.Location = new System.Drawing.Point(201, 131);
            this.complainTB.Multiline = true;
            this.complainTB.Name = "complainTB";
            this.complainTB.Size = new System.Drawing.Size(344, 142);
            this.complainTB.TabIndex = 8;
            // 
            // feverCB
            // 
            this.feverCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.feverCB.AutoCompleteCustomSource.AddRange(new string[] {
            "Not Known IBD",
            "Known Crohn\'s",
            "Known UC",
            "Unspecified IBD type"});
            this.feverCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feverCB.FormattingEnabled = true;
            this.feverCB.Items.AddRange(new object[] {
            "None",
            "Low",
            "High"});
            this.feverCB.Location = new System.Drawing.Point(703, 86);
            this.feverCB.Name = "feverCB";
            this.feverCB.Size = new System.Drawing.Size(161, 32);
            this.feverCB.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(635, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fever";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(633, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tenismus";
            // 
            // teniChkbx
            // 
            this.teniChkbx.AutoSize = true;
            this.teniChkbx.Location = new System.Drawing.Point(739, 143);
            this.teniChkbx.Name = "teniChkbx";
            this.teniChkbx.Size = new System.Drawing.Size(15, 14);
            this.teniChkbx.TabIndex = 12;
            this.teniChkbx.UseVisualStyleBackColor = true;
            // 
            // diaChkbx
            // 
            this.diaChkbx.AutoSize = true;
            this.diaChkbx.Location = new System.Drawing.Point(890, 143);
            this.diaChkbx.Name = "diaChkbx";
            this.diaChkbx.Size = new System.Drawing.Size(15, 14);
            this.diaChkbx.TabIndex = 14;
            this.diaChkbx.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(795, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = "Diarrhea";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(635, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 24);
            this.label9.TabIndex = 15;
            this.label9.Text = "Number of motions";
            // 
            // motionsTB
            // 
            this.motionsTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motionsTB.Location = new System.Drawing.Point(828, 178);
            this.motionsTB.Multiline = true;
            this.motionsTB.Name = "motionsTB";
            this.motionsTB.Size = new System.Drawing.Size(50, 28);
            this.motionsTB.TabIndex = 16;
            // 
            // mucusCB
            // 
            this.mucusCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mucusCB.AutoCompleteCustomSource.AddRange(new string[] {
            "Not Known IBD",
            "Known Crohn\'s",
            "Known UC",
            "Unspecified IBD type"});
            this.mucusCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mucusCB.FormattingEnabled = true;
            this.mucusCB.Items.AddRange(new object[] {
            "Sometimes",
            "Yes",
            "No"});
            this.mucusCB.Location = new System.Drawing.Point(713, 217);
            this.mucusCB.Name = "mucusCB";
            this.mucusCB.Size = new System.Drawing.Size(80, 32);
            this.mucusCB.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(635, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 24);
            this.label10.TabIndex = 17;
            this.label10.Text = "Mucus ";
            // 
            // bleedingCB
            // 
            this.bleedingCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bleedingCB.AutoCompleteCustomSource.AddRange(new string[] {
            "Not Known IBD",
            "Known Crohn\'s",
            "Known UC",
            "Unspecified IBD type"});
            this.bleedingCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bleedingCB.FormattingEnabled = true;
            this.bleedingCB.Items.AddRange(new object[] {
            "Always",
            "Sometimes",
            "Few Times",
            "No"});
            this.bleedingCB.Location = new System.Drawing.Point(177, 300);
            this.bleedingCB.Name = "bleedingCB";
            this.bleedingCB.Size = new System.Drawing.Size(117, 32);
            this.bleedingCB.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 24);
            this.label11.TabIndex = 19;
            this.label11.Text = "Bleeding rectum";
            // 
            // periChkbx
            // 
            this.periChkbx.AutoSize = true;
            this.periChkbx.Location = new System.Drawing.Point(511, 310);
            this.periChkbx.Name = "periChkbx";
            this.periChkbx.Size = new System.Drawing.Size(15, 14);
            this.periChkbx.TabIndex = 22;
            this.periChkbx.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(333, 303);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 24);
            this.label12.TabIndex = 21;
            this.label12.Text = "Perinal discharge";
            // 
            // wlossChkbx
            // 
            this.wlossChkbx.AutoSize = true;
            this.wlossChkbx.Location = new System.Drawing.Point(676, 309);
            this.wlossChkbx.Name = "wlossChkbx";
            this.wlossChkbx.Size = new System.Drawing.Size(15, 14);
            this.wlossChkbx.TabIndex = 24;
            this.wlossChkbx.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(553, 303);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 24);
            this.label13.TabIndex = 23;
            this.label13.Text = "Weight loss";
            // 
            // wlossKgTb
            // 
            this.wlossKgTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wlossKgTb.Location = new System.Drawing.Point(906, 299);
            this.wlossKgTb.Multiline = true;
            this.wlossKgTb.Name = "wlossKgTb";
            this.wlossKgTb.Size = new System.Drawing.Size(50, 28);
            this.wlossKgTb.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(728, 302);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(172, 24);
            this.label14.TabIndex = 25;
            this.label14.Text = "Weight loss in Kg";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 354);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 24);
            this.label15.TabIndex = 27;
            this.label15.Text = "History details";
            // 
            // historyTB
            // 
            this.historyTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyTB.Location = new System.Drawing.Point(149, 354);
            this.historyTB.Multiline = true;
            this.historyTB.Name = "historyTB";
            this.historyTB.Size = new System.Drawing.Size(318, 102);
            this.historyTB.TabIndex = 28;
            // 
            // extraTB
            // 
            this.extraTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extraTB.Location = new System.Drawing.Point(642, 357);
            this.extraTB.Multiline = true;
            this.extraTB.Name = "extraTB";
            this.extraTB.Size = new System.Drawing.Size(318, 102);
            this.extraTB.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(490, 354);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(146, 24);
            this.label16.TabIndex = 29;
            this.label16.Text = "Extraintestinal ";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(490, 378);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(137, 24);
            this.label17.TabIndex = 31;
            this.label17.Text = "manifestaions";
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Location = new System.Drawing.Point(421, 489);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(148, 36);
            this.saveBtn.TabIndex = 32;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(145, 86);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 24);
            this.label18.TabIndex = 33;
            this.label18.Text = "Name:";
            // 
            // patNameLb
            // 
            this.patNameLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patNameLb.AutoSize = true;
            this.patNameLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patNameLb.Location = new System.Drawing.Point(222, 86);
            this.patNameLb.Name = "patNameLb";
            this.patNameLb.Size = new System.Drawing.Size(0, 24);
            this.patNameLb.TabIndex = 34;
            // 
            // ageLbl
            // 
            this.ageLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ageLbl.AutoSize = true;
            this.ageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLbl.Location = new System.Drawing.Point(571, 86);
            this.ageLbl.Name = "ageLbl";
            this.ageLbl.Size = new System.Drawing.Size(0, 24);
            this.ageLbl.TabIndex = 36;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(511, 86);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 24);
            this.label20.TabIndex = 35;
            this.label20.Text = "Age:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.complainTB);
            this.groupBox1.Controls.Add(this.feverCB);
            this.groupBox1.Controls.Add(this.abdPainCB);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.patDiagnosisCB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.teniChkbx);
            this.groupBox1.Controls.Add(this.extraTB);
            this.groupBox1.Controls.Add(this.diaChkbx);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.historyTB);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.motionsTB);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.wlossKgTb);
            this.groupBox1.Controls.Add(this.mucusCB);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.wlossChkbx);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.bleedingCB);
            this.groupBox1.Controls.Add(this.periChkbx);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(2, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(995, 559);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::WindowsFormsApplication5.Properties.Resources.ain_shams_university;
            this.pictureBox3.Location = new System.Drawing.Point(9, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(67, 74);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 67;
            this.pictureBox3.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkRed;
            this.label19.Location = new System.Drawing.Point(77, 55);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 19);
            this.label19.TabIndex = 66;
            this.label19.Text = "IBD TEAM";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkRed;
            this.label21.Location = new System.Drawing.Point(77, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(347, 19);
            this.label21.TabIndex = 65;
            this.label21.Text = "GASTROENTROLOGY AND HEPATOLOGY UNIT";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.DarkRed;
            this.label22.Location = new System.Drawing.Point(77, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(270, 19);
            this.label22.TabIndex = 64;
            this.label22.Text = "INTERNAL MEDICINE DEPARTMENT";
            // 
            // patient_history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.ageLbl);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.patNameLb);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "patient_history";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.patient_history_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox patDiagnosisCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox abdPainCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox complainTB;
        private System.Windows.Forms.ComboBox feverCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox teniChkbx;
        private System.Windows.Forms.CheckBox diaChkbx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox motionsTB;
        private System.Windows.Forms.ComboBox mucusCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox periChkbx;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox wlossChkbx;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox wlossKgTb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox historyTB;
        private System.Windows.Forms.TextBox extraTB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox bleedingCB;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label patNameLb;
        private System.Windows.Forms.Label ageLbl;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
    }
}