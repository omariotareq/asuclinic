namespace WindowsFormsApplication5
{
    partial class patients_form
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.patHistoryBtn = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(340, 51);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(327, 38);
			this.textBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button1.Location = new System.Drawing.Point(695, 60);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "SEARCH";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.FirstName,
            this.MiddleName,
            this.LastName,
            this.Age,
            this.Telephone});
			this.dataGridView1.Location = new System.Drawing.Point(208, 116);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(603, 329);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.Visible = false;
			// 
			// FirstName
			// 
			this.FirstName.HeaderText = "First Name";
			this.FirstName.Name = "FirstName";
			// 
			// MiddleName
			// 
			this.MiddleName.HeaderText = "Middle Name";
			this.MiddleName.Name = "MiddleName";
			// 
			// LastName
			// 
			this.LastName.HeaderText = "Last Name";
			this.LastName.Name = "LastName";
			// 
			// Age
			// 
			this.Age.HeaderText = "Age";
			this.Age.Name = "Age";
			// 
			// Telephone
			// 
			this.Telephone.HeaderText = "Telephone";
			this.Telephone.Name = "Telephone";
			// 
			// patHistoryBtn
			// 
			this.patHistoryBtn.BackColor = System.Drawing.Color.PowderBlue;
			this.patHistoryBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.patHistoryBtn.Location = new System.Drawing.Point(12, 482);
			this.patHistoryBtn.Name = "patHistoryBtn";
			this.patHistoryBtn.Size = new System.Drawing.Size(145, 33);
			this.patHistoryBtn.TabIndex = 3;
			this.patHistoryBtn.Text = "History";
			this.patHistoryBtn.UseVisualStyleBackColor = false;
			this.patHistoryBtn.Click += new System.EventHandler(this.patHistoryBtn_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.PowderBlue;
			this.button2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(196, 482);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(145, 33);
			this.button2.TabIndex = 4;
			this.button2.Text = "First Examination";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.PowderBlue;
			this.button3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(377, 482);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(145, 33);
			this.button3.TabIndex = 5;
			this.button3.Text = "Lab Results";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.PowderBlue;
			this.button4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.Location = new System.Drawing.Point(554, 482);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(145, 33);
			this.button4.TabIndex = 6;
			this.button4.Text = "Enterography";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.PowderBlue;
			this.button5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button5.Location = new System.Drawing.Point(721, 482);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(145, 33);
			this.button5.TabIndex = 7;
			this.button5.Text = "Surgery";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// patients_form
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1028, 616);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.patHistoryBtn);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.MaximizeBox = false;
			this.Name = "patients_form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "patients_form";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.Button patHistoryBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
	}
}