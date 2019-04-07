using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class pathology_form : Form
    {
        int p_id = 0;
        int mode = 0;
        int entry_id = 0;

        DataTable dt_date = new DataTable();
        BindingSource dateBindingSource = new BindingSource();

        DataTable dt = new DataTable();
        BindingSource pathBindingSource = new BindingSource();
        public pathology_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            patNameLb.Text = name;
            ageLbl.Text = "" + age;
            p_id = pa_id;

            refreshDateCB();
            dateCB.Text = "";
        }

        private void refreshDateCB()
        {
            dateCB.SelectedIndexChanged -= dateCB_SelectedIndexChanged;


            dt_date = DataSet.getPatholgyDates(p_id);
            dateBindingSource.DataSource = dt_date;
            dateCB.DataSource = dt_date;
            dateCB.DisplayMember = "patholgydate";

            dateCB.SelectedIndexChanged += dateCB_SelectedIndexChanged;
        }

        private void clearBindings()
        {
            foreach (Control gb in this.Controls)
            {

                foreach (Control tb in gb.Controls)
                {
                    if (tb is TextBox)
                    {
                        tb.DataBindings.Clear();
                        tb.Text = "";
                    }
                    if (tb is ComboBox)
                    {
                        tb.DataBindings.Clear();
                        tb.Text = "";
                    }
                    if (tb is CheckBox)
                    {
                        ((CheckBox)tb).Checked = false;
                    }
                }

            }


        }


        private void fillData(string date)
        {
            try
            {

                clearBindings();
                dt = DataSet.getpathologydata(date, p_id);
                pathBindingSource.DataSource = dt;

                pathDate.DataBindings.Clear();

                entry_id = Convert.ToInt32(dt.Rows[0]["id"]);

                pathDate.ValueChanged -= pathDate_ValueChanged;
                this.pathDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.pathBindingSource, "patholgydate", true));
                pathDate.ValueChanged += pathDate_ValueChanged;

                this.ileumInfReaction.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "ileir", true));
                this.archDist.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "ilad", true));
                this.infCells.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "ilic", true));
                this.neutInf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "Niil", true));
                this.erosionTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "ilER", true));
                this.colonInfReaction.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "irco", true));
                this.cryptDist.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "cradco", true));
                this.basalLymph.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "balco", true));
                this.cryptAbc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "crycco", true));
                this.laminaEosino.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "lamineosco", true));
                this.otherIlealFindingsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "otherileal", true));
                this.colonOtherFindingsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "otherfindings", true));
                this.finalReportTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pathBindingSource, "finalreport", true));

                if (Convert.ToInt32(dt.Rows[0]["ucil"]) == 1)
                {
                    UlcChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["grail"]) == 1)
                {
                    granChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["lamneutroco"]) == 1)
                {
                    laminaNeutroChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["ulceco"]) == 1)
                {
                    colonUlcChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["granilco"]) == 1)
                {
                    colonGranChkbx.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            button1.Enabled = true;
            mode = 1;
            fillData(dateCB.Text);
            fillImages();
            Cursor.Current = Cursors.Default;
        }

        private void pathology_form_Load(object sender, EventArgs e)
        {
            string usrAccess = WindowsFormsApplication5.Properties.Settings.Default.drAccess;
            if (Convert.ToInt16(usrAccess) < 1)
            {
                saveBtn.Visible = false;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int ulc=0;
                int gran =0;
                int lam = 0;
                int colon_ulc =0;
                int colon_gran=0;
                if(UlcChkbx.Checked){
                    ulc =1 ;
                }
                if(granChkbx.Checked){
                    gran = 1;
                }
                if(laminaNeutroChkbx.Checked){
                    lam = 1;
                }
                if(colonUlcChkbx.Checked){
                    colon_ulc = 1;
                }
                if(colonGranChkbx.Checked){
                    colon_gran =1;
                }

                if (mode == 0)
                {
                    DataSet.Insertpatholgydata(pathDate.Value.Date, ileumInfReaction.Text, archDist.Text, infCells.Text, neutInf.Text, erosionTB.Text, Convert.ToInt16(UlcChkbx.Checked), Convert.ToInt16(granChkbx.Checked),
                        otherIlealFindingsTB.Text, colonInfReaction.Text, cryptDist.Text, basalLymph.Text, cryptAbc.Text, laminaEosino.Text, Convert.ToInt16(laminaNeutroChkbx.Checked), Convert.ToInt16(colonUlcChkbx.Checked),
                        Convert.ToInt16(colonGranChkbx.Checked), colonOtherFindingsTB.Text, finalReportTB.Text, p_id);
                }
                else if (mode == 1)
                {
                    DataSet.Updatepatholgydata(pathDate.Value.Date, ileumInfReaction.Text, archDist.Text, infCells.Text, neutInf.Text, erosionTB.Text, Convert.ToInt16(UlcChkbx.Checked), Convert.ToInt16(granChkbx.Checked),
                        otherIlealFindingsTB.Text, colonInfReaction.Text, cryptDist.Text, basalLymph.Text, cryptAbc.Text, laminaEosino.Text, Convert.ToInt16(laminaNeutroChkbx.Checked), Convert.ToInt16(colonUlcChkbx.Checked),
                        Convert.ToInt16(colonGranChkbx.Checked), colonOtherFindingsTB.Text, finalReportTB.Text, p_id, entry_id);
                }
                    MessageBox.Show("Saved Successfully");
                refreshDateCB();
                Cursor.Current = Cursors.Default;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2601:
                       MouseEventArgs me = (MouseEventArgs)e;
                        DialogResult dr = MessageBox.Show("This date already data registered on the system! \nWould you like to edit the current entry?\nIf no please choose a different date.", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                                    if (dr == DialogResult.Yes)
                                    {
                                        mode = 1;
                                        Cursor.Current = Cursors.WaitCursor;
                                        pathDate.ValueChanged -= pathDate_ValueChanged;
                                        fillData(pathDate.Value.Date.ToString());
                                        pathDate.ValueChanged += pathDate_ValueChanged;
                                        Cursor.Current = Cursors.Default;
                                    }
                                    if (dr == DialogResult.No)
                                    {
                                        mode = 0;
                                    }
                                
                        
                        break;
                    default:
                        throw;
                }
            }
        }

        private void pathDate_ValueChanged(object sender, EventArgs e)
        {
            mode = 0;
            clearBindings();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (PictureBox item in attachmentFlowPanel.Controls)
                {
                    bool isNullOrEmpty = (item == null) || (item.Image == null);
                    if (!isNullOrEmpty)
                    {
                        MemoryStream ms = new MemoryStream();
                        byte[] PhotoByte = null;
                        item.Image.Save(ms, ImageFormat.Jpeg);
                        PhotoByte = ms.ToArray();

                        /*Image img = item.Image;
                        ImageConverter converter = new ImageConverter();
                        arr_upload_image = (byte[])converter.ConvertTo(img, typeof(byte[]));*/


                        if (p_id != 0)
                        {

                            try
                            {
                                DataSet.parametrizedInsertPath(Convert.ToInt16(entry_id), PhotoByte);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a date");
                        }
                    }

                }
                MessageBox.Show("upload complete");
                clearPb();
                flowLayoutPanel1.Controls.Clear();
                fillImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show("please select a valid date");
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void clearPb()
        {
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
        }

        private void fillImages()
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                flowLayoutPanel1.Controls.Clear();
                DataTable di = new DataTable();
                di = DataSet.selectPathImages(Convert.ToInt16(entry_id));
                byte[] image_arr = null;
                Image photo = null;

                for (int i = 0; i < di.Rows.Count; i++)
                {
                    try
                    {
                        image_arr = (byte[])di.Rows[i]["path_image"];

                        //photo = (Bitmap)((new ImageConverter()).ConvertFrom(image_arr));


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                    PictureBox pb = new PictureBox();
                    MemoryStream stream = new MemoryStream(image_arr, 0, image_arr.Length);
                    pb.Image = Image.FromStream(stream);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.BackColor = Color.Transparent;
                    pb.Height = 100;
                    pb.Width = 100;
                    pb.Tag = di.Rows[i]["id"];
                    pb.Click += new EventHandler(pb_click);
                    flowLayoutPanel1.Controls.Add(pb);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;

        }

        private void chooseImage()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image File";
            openFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png, *.ico, *.jpeg)|*.bmp;*.jpg;*.png;*.ico;*.jpeg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(openFileDialog.FileName);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image File";
            openFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png, *.ico, *.jpeg)|*.bmp;*.jpg;*.png;*.ico;*.jpeg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image File";
            openFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png, *.ico, *.jpeg)|*.bmp;*.jpg;*.png;*.ico;*.jpeg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image File";
            openFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png, *.ico, *.jpeg)|*.bmp;*.jpg;*.png;*.ico;*.jpeg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image File";
            openFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png, *.ico, *.jpeg)|*.bmp;*.jpg;*.png;*.ico;*.jpeg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void pb_click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this photo ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    // Do something
                    Cursor.Current = Cursors.WaitCursor;
                    DataSet.deletePathImage(Convert.ToInt32(((PictureBox)sender).Tag), p_id);
                    flowLayoutPanel1.Controls.Clear();
                    fillImages();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Deleted successfullyy");
                }
            }
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PhotoPreviewForm ppf = new PhotoPreviewForm(((PictureBox)sender).Image);
                ppf.ShowDialog();
            }
        }


    }
}
