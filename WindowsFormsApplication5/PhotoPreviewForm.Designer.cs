namespace WindowsFormsApplication5
{
    partial class PhotoPreviewForm
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
            this.previewPb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewPb)).BeginInit();
            this.SuspendLayout();
            // 
            // previewPb
            // 
            this.previewPb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPb.Location = new System.Drawing.Point(0, 0);
            this.previewPb.Margin = new System.Windows.Forms.Padding(2);
            this.previewPb.Name = "previewPb";
            this.previewPb.Size = new System.Drawing.Size(634, 556);
            this.previewPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPb.TabIndex = 1;
            this.previewPb.TabStop = false;
            // 
            // PhotoPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 556);
            this.Controls.Add(this.previewPb);
            this.Name = "PhotoPreviewForm";
            this.Text = "PhotoPreviewForm";
            ((System.ComponentModel.ISupportInitialize)(this.previewPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox previewPb;
    }
}