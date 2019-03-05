namespace WindowsFormsApplication5
{
    partial class Surgery_form
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
            this.ageLbl = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.patNameLb = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.surgicaInd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.surgDate = new System.Windows.Forms.DateTimePicker();
            this.surgDatesCB = new System.Windows.Forms.ComboBox();
            this.operDetails = new System.Windows.Forms.TextBox();
            this.surgicalComp = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ageLbl
            // 
            this.ageLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ageLbl.AutoSize = true;
            this.ageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLbl.Location = new System.Drawing.Point(586, 27);
            this.ageLbl.Name = "ageLbl";
            this.ageLbl.Size = new System.Drawing.Size(0, 24);
            this.ageLbl.TabIndex = 46;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(526, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 24);
            this.label20.TabIndex = 45;
            this.label20.Text = "Age:";
            // 
            // patNameLb
            // 
            this.patNameLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patNameLb.AutoSize = true;
            this.patNameLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patNameLb.Location = new System.Drawing.Point(237, 27);
            this.patNameLb.Name = "patNameLb";
            this.patNameLb.Size = new System.Drawing.Size(0, 24);
            this.patNameLb.TabIndex = 44;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(274, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 24);
            this.label18.TabIndex = 43;
            this.label18.Text = "Name:";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 31);
            this.label3.TabIndex = 42;
            this.label3.Text = "Surgery";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 48;
            this.label1.Text = "Date of surgery";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Controls.Add(this.surgicalComp);
            this.groupBox1.Controls.Add(this.operDetails);
            this.groupBox1.Controls.Add(this.surgDatesCB);
            this.groupBox1.Controls.Add(this.surgDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.surgicaInd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 535);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 24);
            this.label5.TabIndex = 53;
            this.label5.Text = "Surgical complications";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 24);
            this.label4.TabIndex = 51;
            this.label4.Text = "Operative details";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 24);
            this.label2.TabIndex = 50;
            this.label2.Text = "Surgical indication";
            // 
            // surgicaInd
            // 
            this.surgicaInd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surgicaInd.Location = new System.Drawing.Point(229, 133);
            this.surgicaInd.Multiline = true;
            this.surgicaInd.Name = "surgicaInd";
            this.surgicaInd.Size = new System.Drawing.Size(745, 104);
            this.surgicaInd.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(325, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 24);
            this.label6.TabIndex = 54;
            this.label6.Text = "Surgeries :";
            // 
            // surgDate
            // 
            this.surgDate.CustomFormat = "dd/MM/yyyy";
            this.surgDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surgDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.surgDate.Location = new System.Drawing.Point(170, 62);
            this.surgDate.Name = "surgDate";
            this.surgDate.Size = new System.Drawing.Size(144, 31);
            this.surgDate.TabIndex = 55;
            this.surgDate.ValueChanged += new System.EventHandler(this.surgDate_ValueChanged);
            // 
            // surgDatesCB
            // 
            this.surgDatesCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surgDatesCB.FormatString = "yyyy-MM-dd";
            this.surgDatesCB.FormattingEnabled = true;
            this.surgDatesCB.Location = new System.Drawing.Point(443, 13);
            this.surgDatesCB.Name = "surgDatesCB";
            this.surgDatesCB.Size = new System.Drawing.Size(213, 32);
            this.surgDatesCB.TabIndex = 221;
            this.surgDatesCB.SelectedIndexChanged += new System.EventHandler(this.surgDatesCB_SelectedIndexChanged);
            // 
            // operDetails
            // 
            this.operDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operDetails.Location = new System.Drawing.Point(229, 260);
            this.operDetails.Multiline = true;
            this.operDetails.Name = "operDetails";
            this.operDetails.Size = new System.Drawing.Size(745, 104);
            this.operDetails.TabIndex = 222;
            // 
            // surgicalComp
            // 
            this.surgicalComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surgicalComp.Location = new System.Drawing.Point(229, 387);
            this.surgicalComp.Multiline = true;
            this.surgicalComp.Name = "surgicalComp";
            this.surgicalComp.Size = new System.Drawing.Size(745, 104);
            this.surgicalComp.TabIndex = 223;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(431, 497);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(143, 32);
            this.saveBtn.TabIndex = 224;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Surgery_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ageLbl);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.patNameLb);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "Surgery_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Surgery_form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label ageLbl;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label patNameLb;
		private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox surgicaInd;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker surgDate;
        private System.Windows.Forms.ComboBox surgDatesCB;
        private System.Windows.Forms.TextBox surgicalComp;
        private System.Windows.Forms.TextBox operDetails;
        private System.Windows.Forms.Button saveBtn;
	}
}