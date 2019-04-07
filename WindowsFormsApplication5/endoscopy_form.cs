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
    public partial class endoscopy_form : Form
    {
        int p_id = 0;
        string segment="";
        string muc_ero = "";
        string muc_fri = "";
        int mode = 0;
        int entry_id = 0;

        DataTable dt_date = new DataTable();
        DataTable dt = new DataTable();

        BindingSource mainBindingSource = new BindingSource();
        BindingSource dateBindingSource = new BindingSource();

        public endoscopy_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            p_id = pa_id;
            patNameLb.Text = name;
            ageLbl.Text = "" + age;

            refreshDateCB();
            clearBindings();
        }

        public static char[] intToBinary(int number)
        {


            var array = Convert.ToString(number, 2).PadLeft(7, '0').ToArray();

            return array;
        }

        private void gatherSegment()
        {
            segment = "";

            if (rectumSegmentChkbx.Checked)
            {
                segment = segment + "1";
            }
            else
            {
                segment = segment + "0";
            }

            if (sigmoidSegmentChkbx.Checked)
            {
                segment = segment + "1";
            }
            else
            {
                segment = segment + "0";
            }

            if (ltColonSegmentChkbx.Checked)
            {
                segment = segment + "1";
            }
            else
            {
                segment = segment + "0";
            }
            if (trColonSegmentChkbx.Checked)
            {
                segment = segment + "1";
            }
            else
            {
                segment = segment + "0";
            }
            if (rtColonSegmentChkbx.Checked)
            {
                segment = segment + "1";
            }
            else
            {
                segment = segment + "0";
            }
            if (tileumSegmentChkbx.Checked)
            {
                segment = segment + "1";
            }
            else
            {
                segment = segment + "0";
            }
            if (neotSegmentChkbx.Checked)
            {
                segment = segment + "1";
            }
            else
            {
                segment = segment + "0";
            }

        }

        private void gatherMucEro()
        {
            muc_ero = "";

            if (rectumMucEroChkbx.Checked)
            {
                muc_ero = muc_ero + "1";
            }
            else
            {
                muc_ero = muc_ero + "0";
            }

            if (sigmoidMucEroChkbx.Checked)
            {
                muc_ero = muc_ero + "1";
            }
            else
            {
                muc_ero = muc_ero + "0";
            }

            if (ltColonMucEroChkbx.Checked)
            {
                muc_ero = muc_ero + "1";
            }
            else
            {
                muc_ero = muc_ero + "0";
            }
            if (trColonMucEroChkbx.Checked)
            {
                muc_ero = muc_ero + "1";
            }
            else
            {
                muc_ero = muc_ero + "0";
            }
            if (rtColonMucEroChkbx.Checked)
            {
                muc_ero = muc_ero + "1";
            }
            else
            {
                muc_ero = muc_ero + "0";
            }
            if (tileumMucEroChkbx.Checked)
            {
                muc_ero = muc_ero + "1";
            }
            else
            {
                muc_ero = muc_ero + "0";
            }
            if (neotMucEroChkbx.Checked)
            {
                muc_ero = muc_ero + "1";
            }
            else
            {
                muc_ero = muc_ero + "0";
            }

        }

        private void gatherMucFri()
        {
            muc_fri = "";

            if (rectumMucFriaChkbx.Checked)
            {
                muc_fri = muc_fri + "1";
            }
            else
            {
                muc_fri = muc_fri + "0";
            }

            if (sigmoidMucFriaChkbx.Checked)
            {
                muc_fri = muc_fri + "1";
            }
            else
            {
                muc_fri = muc_fri + "0";
            }

            if (ltColonMucFriaChkbx.Checked)
            {
                muc_fri = muc_fri + "1";
            }
            else
            {
                muc_fri = muc_fri + "0";
            }
            if (trColonMucFriaChkbx.Checked)
            {
                muc_fri = muc_fri + "1";
            }
            else
            {
                muc_fri = muc_fri + "0";
            }
            if (rtColonMucFriaChkbx.Checked)
            {
                muc_fri = muc_fri + "1";
            }
            else
            {
                muc_fri = muc_fri + "0";
            }
            if (tileumMucFriaChkbx.Checked)
            {
                muc_fri = muc_fri + "1";
            }
            else
            {
                muc_fri = muc_fri + "0";
            }
            if (neotMucFriaChkbx.Checked)
            {
                muc_fri = muc_fri + "1";
            }
            else
            {
                muc_fri = muc_fri + "0";
            }

        }

        public static int binToInt(string number)
        {
            int output = Convert.ToInt32(number, 2);


            return output;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                segment = "";
                muc_fri = "";
                muc_ero = "";

                gatherSegment();
                gatherMucEro();
                gatherMucFri();

                if (mode == 0)
                {
                    DataSet.Insertendoscopydata(endscopyDate.Value.Date, binToInt(segment), rectumEyrthemaCB.Text, sigmoidEyrthemaCB.Text, ltColonEyrthemaCB.Text, trColonEyrthemaCB.Text,
                        rtColonEyrthemaCB.Text, tileumEyrthemaCB.Text, neotEyrthemaCB.Text, rectumVasPattCB.Text, sigmoidVasPattCB.Text, ltColonVasPattCB.Text, trColonVasPattCB.Text,
                        rtColonVasPattCB.Text, tileumVasPattCB.Text, neotVasPattCB.Text, rectumUlcCB.Text, sigmoidUlcCB.Text, ltColonUlcCB.Text, trColonUlcCB.Text, rtColonUlcCB.Text, tileumUlcCB.Text,
                        neotUlcCB.Text, rectumUlcerSizeCB.Text, sigmoidUlcerSizeCB.Text, ltColonUlcerSizeCB.Text, trColonUlcerSizeCB.Text, rtColonUlcerSizeCB.Text, tileumUlcerSizeCB.Text, neotUlcerSizeCB.Text,
                        rectumUlcerAreaCB.Text, sigmoidUlcerAreaCB.Text, ltColonUlcerAreaCB.Text, trColonUlcerAreaCB.Text, rtColonUlcerAreaCB.Text, tileumUlcerAreaCB.Text, neotUlcerAreaCB.Text,
                        binToInt(muc_ero), binToInt(muc_fri), rectumNarrowingCB.Text, sigmoidNarrowingCB.Text, ltColonNarrowingCB.Text, trColonNarrowingCB.Text, rtColonNarrowingCB.Text, tileumNarrowingCB.Text,
                        neotNarrowingCB.Text, Convert.ToInt16(pancolitisChkbx.Checked), p_id);
                }
                else if(mode == 1)
                {
                    DataSet.Updateendoscopydata(endscopyDate.Value.Date, binToInt(segment), rectumEyrthemaCB.Text, sigmoidEyrthemaCB.Text, ltColonEyrthemaCB.Text, trColonEyrthemaCB.Text,
                        rtColonEyrthemaCB.Text, tileumEyrthemaCB.Text, neotEyrthemaCB.Text, rectumVasPattCB.Text, sigmoidVasPattCB.Text, ltColonVasPattCB.Text, trColonVasPattCB.Text,
                        rtColonVasPattCB.Text, tileumVasPattCB.Text, neotVasPattCB.Text, rectumUlcCB.Text, sigmoidUlcCB.Text, ltColonUlcCB.Text, trColonUlcCB.Text, rtColonUlcCB.Text, tileumUlcCB.Text,
                        neotUlcCB.Text, rectumUlcerSizeCB.Text, sigmoidUlcerSizeCB.Text, ltColonUlcerSizeCB.Text, trColonUlcerSizeCB.Text, rtColonUlcerSizeCB.Text, tileumUlcerSizeCB.Text, neotUlcerSizeCB.Text,
                        rectumUlcerAreaCB.Text, sigmoidUlcerAreaCB.Text, ltColonUlcerAreaCB.Text, trColonUlcerAreaCB.Text, rtColonUlcerAreaCB.Text, tileumUlcerAreaCB.Text, neotUlcerAreaCB.Text,
                        binToInt(muc_ero), binToInt(muc_fri), rectumNarrowingCB.Text, sigmoidNarrowingCB.Text, ltColonNarrowingCB.Text, trColonNarrowingCB.Text, rtColonNarrowingCB.Text, tileumNarrowingCB.Text,
                        neotNarrowingCB.Text, Convert.ToInt16(pancolitisChkbx.Checked), p_id,entry_id);
                }

                MessageBox.Show("Saved successfully");
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
                            endscopyDate.ValueChanged -= endscopyDate_ValueChanged;
                            fillData(endscopyDate.Value.Date.ToString());
                            endscopyDate.ValueChanged += endscopyDate_ValueChanged;
                            Cursor.Current = Cursors.Default;
                        }
                        if (dr == DialogResult.No)
                        {
                            mode = 0;
                        }


                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
        }

        private void refreshDateCB()
        {
            dateCB.SelectedIndexChanged -= dateCB_SelectedIndexChanged;


            dt_date = DataSet.getEndoDates(p_id);
            dateBindingSource.DataSource = dt_date;
            dateCB.DataSource = dt_date;
            dateCB.DisplayMember = "Endodate";

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
                        tb.DataBindings.Clear();
                    }
                }

            }


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

        private void fillData(string date)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int temp = 0;
                char[] temp_char = new char[7];

                dt = DataSet.getEndoall(date, p_id);
                mainBindingSource.DataSource = dt;

                clearBindings();
                endscopyDate.DataBindings.Clear();

                entry_id = Convert.ToInt32(dt.Rows[0]["id"]);
                endscopyDate.ValueChanged -= endscopyDate_ValueChanged;
                this.endscopyDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mainBindingSource, "Endodate", true));
                endscopyDate.ValueChanged += endscopyDate_ValueChanged;

                #region Segment
                temp = Convert.ToInt32(dt.Rows[0]["Segment"]);
                temp_char = intToBinary(temp);
                if (temp_char[0] == '1')
                {
                    rectumSegmentChkbx.Checked = true;
                }
                if (temp_char[1] == '1')
                {
                    sigmoidSegmentChkbx.Checked = true;
                }
                if (temp_char[2] == '1')
                {
                    ltColonSegmentChkbx.Checked = true;
                }
                if (temp_char[3] == '1')
                {
                    trColonSegmentChkbx.Checked = true;
                }
                if (temp_char[4] == '1')
                {
                    rtColonSegmentChkbx.Checked = true;
                }
                if (temp_char[5] == '1')
                {
                    tileumSegmentChkbx.Checked = true;
                }
                if (temp_char[6] == '1')
                {
                    neotSegmentChkbx.Checked = true;
                }
                #endregion

                this.rectumEyrthemaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "eryr", true));
                this.sigmoidEyrthemaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "erys", true));
                this.ltColonEyrthemaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "eryl", true));
                this.trColonEyrthemaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "erytr", true));
                this.rtColonEyrthemaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "eryrt", true));
                this.tileumEyrthemaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "eryti", true));
                this.neotEyrthemaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "eryn", true));

                this.rectumVasPattCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "vr", true));
                this.sigmoidVasPattCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "vs", true));
                this.ltColonVasPattCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "vl", true));
                this.trColonVasPattCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "vtr", true));
                this.rtColonVasPattCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "vrt", true));
                this.tileumVasPattCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "vti", true));
                this.neotVasPattCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "vn", true));

                this.rectumUlcCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ur", true));
                this.sigmoidUlcCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "us", true));
                this.ltColonUlcCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ul", true));
                this.trColonUlcCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "utr", true));
                this.rtColonUlcCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "urt", true));
                this.tileumUlcCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "uti", true));
                this.neotUlcCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "un", true));

                this.rectumUlcerSizeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "usr", true));
                this.sigmoidUlcerSizeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "uss", true));
                this.ltColonUlcerSizeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "usl", true));
                this.trColonUlcerSizeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ustr", true));
                this.rtColonUlcerSizeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "usrt", true));
                this.tileumUlcerSizeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "usti", true));
                this.neotUlcerSizeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "usn", true));

                this.rectumUlcerAreaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "uar", true));
                this.sigmoidUlcerAreaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "uas", true));
                this.ltColonUlcerAreaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ual", true));
                this.trColonUlcerAreaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "uatr", true));
                this.rtColonUlcerAreaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "uart", true));
                this.tileumUlcerAreaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "uati", true));
                this.neotUlcerAreaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "uan", true));

                #region Musocal Erosions
                temp = Convert.ToInt32(dt.Rows[0]["Muscoalero"]);
                temp_char = intToBinary(temp);
                if (temp_char[0] == '1')
                {
                    rectumMucEroChkbx.Checked = true;
                }
                if (temp_char[1] == '1')
                {
                    sigmoidMucEroChkbx.Checked = true;
                }
                if (temp_char[2] == '1')
                {
                    ltColonMucEroChkbx.Checked = true;
                }
                if (temp_char[3] == '1')
                {
                    trColonMucEroChkbx.Checked = true;
                }
                if (temp_char[4] == '1')
                {
                    rtColonMucEroChkbx.Checked = true;
                }
                if (temp_char[5] == '1')
                {
                    tileumMucEroChkbx.Checked = true;
                }
                if (temp_char[6] == '1')
                {
                    neotMucEroChkbx.Checked = true;
                }
                #endregion

                #region Musocal Fri
                temp = Convert.ToInt32(dt.Rows[0]["Muscoalfria"]);
                temp_char = intToBinary(temp);
                if (temp_char[0] == '1')
                {
                    rectumMucFriaChkbx.Checked = true;
                }
                if (temp_char[1] == '1')
                {
                    sigmoidMucFriaChkbx.Checked = true;
                }
                if (temp_char[2] == '1')
                {
                    ltColonMucFriaChkbx.Checked = true;
                }
                if (temp_char[3] == '1')
                {
                    trColonMucFriaChkbx.Checked = true;
                }
                if (temp_char[4] == '1')
                {
                    rtColonMucFriaChkbx.Checked = true;
                }
                if (temp_char[5] == '1')
                {
                    tileumMucFriaChkbx.Checked = true;
                }
                if (temp_char[6] == '1')
                {
                    neotMucFriaChkbx.Checked = true;
                }
                #endregion

                this.rectumNarrowingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Nr", true));
                this.sigmoidNarrowingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Ns", true));
                this.ltColonNarrowingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Nl", true));
                this.trColonNarrowingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Ntr", true));
                this.rtColonNarrowingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Nrt", true));
                this.tileumNarrowingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Nti", true));
                this.neotNarrowingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Nn", true));

                this.pancolitisChkbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mainBindingSource, "Pancolitis", true));

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void endscopyDate_ValueChanged(object sender, EventArgs e)
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
                                DataSet.parametrizedInsertEndo(Convert.ToInt16(entry_id), PhotoByte);
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
                di = DataSet.selectEndoImages(Convert.ToInt16(entry_id));
                byte[] image_arr = null;
                Image photo = null;

                for (int i = 0; i < di.Rows.Count; i++)
                {
                    try
                    {
                        image_arr = (byte[])di.Rows[i]["endo_image"];

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
                    DataSet.deleteEndoImage(Convert.ToInt32(((PictureBox)sender).Tag), p_id);
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

        private void endoscopy_form_Load(object sender, EventArgs e)
        {
            string usrAccess = WindowsFormsApplication5.Properties.Settings.Default.drAccess;
            if (Convert.ToInt16(usrAccess) < 1)
            {
                saveBtn.Visible = false;
            }
        }
    }
}
