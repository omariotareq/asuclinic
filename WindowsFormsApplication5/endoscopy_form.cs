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
    public partial class endoscopy_form : Form
    {
        int p_id = 0;
        string segment="";
        string muc_ero = "";
        string muc_fri = "";

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
                segment = "";
                muc_fri = "";
                muc_ero = "";

                gatherSegment();
                gatherMucEro();
                gatherMucFri();

                DataSet.Insertendoscopydata(endscopyDate.Value.Date, binToInt(segment), rectumEyrthemaCB.Text, sigmoidEyrthemaCB.Text, ltColonEyrthemaCB.Text, trColonEyrthemaCB.Text,
                    rtColonEyrthemaCB.Text, tileumEyrthemaCB.Text, neotEyrthemaCB.Text, rectumVasPattCB.Text, sigmoidVasPattCB.Text, ltColonVasPattCB.Text, trColonVasPattCB.Text,
                    rtColonVasPattCB.Text, tileumVasPattCB.Text, neotVasPattCB.Text, rectumUlcCB.Text, sigmoidUlcCB.Text, ltColonUlcCB.Text, trColonUlcCB.Text, rtColonUlcCB.Text, tileumUlcCB.Text,
                    neotUlcCB.Text, rectumUlcerSizeCB.Text, sigmoidUlcerSizeCB.Text, ltColonUlcerSizeCB.Text, trColonUlcerSizeCB.Text, rtColonUlcerSizeCB.Text, tileumUlcerSizeCB.Text, neotUlcerSizeCB.Text,
                    rectumUlcerAreaCB.Text, sigmoidUlcerAreaCB.Text, ltColonUlcerAreaCB.Text, trColonUlcerAreaCB.Text, rtColonUlcerAreaCB.Text, tileumUlcerAreaCB.Text, neotUlcerAreaCB.Text,
                    binToInt(muc_ero), binToInt(muc_fri), rectumNarrowingCB.Text, sigmoidNarrowingCB.Text, ltColonNarrowingCB.Text, trColonNarrowingCB.Text, rtColonNarrowingCB.Text, tileumNarrowingCB.Text,
                    neotNarrowingCB.Text, Convert.ToInt16(pancolitisChkbx.Checked), p_id);

                MessageBox.Show("Saved successfully");
                refreshDateCB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int temp = 0;
                char[] temp_char = new char[7];

                dt = DataSet.getEndoall(dateCB.Text, p_id);
                mainBindingSource.DataSource = dt;

                clearBindings();
                endscopyDate.DataBindings.Clear();

                this.endscopyDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Endodate", true));

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
            clearBindings();
        }


    }
}
