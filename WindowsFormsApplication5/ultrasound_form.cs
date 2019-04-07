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
    public partial class ultrasound_form : Form
    {
        int p_id = 0;
        string sub_muc = "";
        string fat_creep = "";
        string local_ln_enlarg = "";
        string mur_fib = "";
        string lum_stric = "";
        string pres_dila = "";
        int u_id = 0;
        int mode = 0;
        int entry_id = 0;

        DataTable dt_date = new DataTable();
        DataTable dt = new DataTable();

        BindingSource mainBindingSource = new BindingSource();
        BindingSource dateBindingSource = new BindingSource();
        public ultrasound_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            p_id = pa_id;
            patNameLb.Text = name;
            ageLbl.Text = "" + age;

            refreshDateCB();
        }

        public static int binToInt(string number)
        {
            int output = Convert.ToInt32(number, 2);


            return output;
        }

        public static char[] intToBinary(int number)
        {


            var array = Convert.ToString(number, 2).PadLeft(6, '0').ToArray();

            return array;
        }

        #region gathering
        

        private void gatherSubMuc()
        {
            sub_muc = "";

            if (jejuSubEdeChkbx.Checked)
            {
                sub_muc = sub_muc + "1";
            }
            else
            {
                sub_muc = sub_muc + "0";
            }

            if (ileumSubEdeChkbx.Checked)
            {
                sub_muc = sub_muc + "1";
            }
            else
            {
                sub_muc = sub_muc + "0";
            }

            if (rtColonSubEdeChkbx.Checked)
            {
                sub_muc = sub_muc + "1";
            }
            else
            {
                sub_muc = sub_muc + "0";
            }
            if (trColonSubEdeChkbx.Checked)
            {
                sub_muc = sub_muc + "1";
            }
            else
            {
                sub_muc = sub_muc + "0";
            }
            if (ltColonSubEdeChkbx.Checked)
            {
                sub_muc = sub_muc + "1";
            }
            else
            {
                sub_muc = sub_muc + "0";
            }
            if (sigColonSubEdeChkbx.Checked)
            {
                sub_muc = sub_muc + "1";
            }
            else
            {
                sub_muc = sub_muc + "0";
            }
           

        }

        private void gatherFatCreep()
        {
            fat_creep = "";

            if (jejuFatCreepingSignChkbx.Checked)
            {
                fat_creep = fat_creep + "1";
            }
            else
            {
                fat_creep = fat_creep + "0";
            }

            if (ileumFatCreepingSignChkbx.Checked)
            {
                fat_creep = fat_creep + "1";
            }
            else
            {
                fat_creep = fat_creep + "0";
            }

            if (rtColonFatCreepingSignChkbx.Checked)
            {
                fat_creep = fat_creep + "1";
            }
            else
            {
                fat_creep = fat_creep + "0";
            }
            if (trColonFatCreepingSignChkbx.Checked)
            {
                fat_creep = fat_creep + "1";
            }
            else
            {
                fat_creep = fat_creep + "0";
            }
            if (ltColonFatCreepingSignChkbx.Checked)
            {
                fat_creep = fat_creep + "1";
            }
            else
            {
                fat_creep = fat_creep + "0";
            }
            if (sigColonFatCreepingSignChkbx.Checked)
            {
                fat_creep = fat_creep + "1";
            }
            else
            {
                fat_creep = fat_creep + "0";
            }


        }

        private void gatherLocalLN()
        {
            local_ln_enlarg = "";

            if (jejuLocalLnEnlargChkbx.Checked)
            {
                local_ln_enlarg = local_ln_enlarg + "1";
            }
            else
            {
                local_ln_enlarg = local_ln_enlarg + "0";
            }

            if (ileumLocalLnEnlargChkbx.Checked)
            {
                local_ln_enlarg = local_ln_enlarg + "1";
            }
            else
            {
                local_ln_enlarg = local_ln_enlarg + "0";
            }

            if (rtColonLocalLnEnlargChkbx.Checked)
            {
                local_ln_enlarg = local_ln_enlarg + "1";
            }
            else
            {
                local_ln_enlarg = local_ln_enlarg + "0";
            }
            if (trColonLocalLnEnlargChkbx.Checked)
            {
                local_ln_enlarg = local_ln_enlarg + "1";
            }
            else
            {
                local_ln_enlarg = local_ln_enlarg + "0";
            }
            if (ltColonLocalLnEnlargChkbx.Checked)
            {
                local_ln_enlarg = local_ln_enlarg + "1";
            }
            else
            {
                local_ln_enlarg = local_ln_enlarg + "0";
            }
            if (sigColonLocalLnEnlargChkbx.Checked)
            {
                local_ln_enlarg = local_ln_enlarg + "1";
            }
            else
            {
                local_ln_enlarg = local_ln_enlarg + "0";
            }


        }

        private void gatherMurFib()
        {
            mur_fib = "";

            if (jejuMuralFibChkbx.Checked)
            {
                mur_fib = mur_fib + "1";
            }
            else
            {
                mur_fib = mur_fib + "0";
            }

            if (ileumMuralFibChkbx.Checked)
            {
                mur_fib = mur_fib + "1";
            }
            else
            {
                mur_fib = mur_fib + "0";
            }

            if (rtColonMuralFibChkbx.Checked)
            {
                mur_fib = mur_fib + "1";
            }
            else
            {
                mur_fib = mur_fib + "0";
            }
            if (trColonMuralFibChkbx.Checked)
            {
                mur_fib = mur_fib + "1";
            }
            else
            {
                mur_fib = mur_fib + "0";
            }
            if (ltColonMuralFibChkbx.Checked)
            {
                mur_fib = mur_fib + "1";
            }
            else
            {
                mur_fib = mur_fib + "0";
            }
            if (sigColonMuralFibChkbx.Checked)
            {
                mur_fib = mur_fib + "1";
            }
            else
            {
                mur_fib = mur_fib + "0";
            }


        }

        private void gatherLumStric()
        {
            lum_stric = "";

            if (jejuLumStrChkbx.Checked)
            {
                lum_stric = lum_stric + "1";
            }
            else
            {
                lum_stric = lum_stric + "0";
            }

            if (ileumLumStrChkbx.Checked)
            {
                lum_stric = lum_stric + "1";
            }
            else
            {
                lum_stric = lum_stric + "0";
            }

            if (rtColonLumStrChkbx.Checked)
            {
                lum_stric = lum_stric + "1";
            }
            else
            {
                lum_stric = lum_stric + "0";
            }
            if (trColonLumStrChkbx.Checked)
            {
                lum_stric = lum_stric + "1";
            }
            else
            {
                lum_stric = lum_stric + "0";
            }
            if (ltColonLumStrChkbx.Checked)
            {
                lum_stric = lum_stric + "1";
            }
            else
            {
                lum_stric = lum_stric + "0";
            }
            if (sigColonLumStrChkbx.Checked)
            {
                lum_stric = lum_stric + "1";
            }
            else
            {
                lum_stric = lum_stric + "0";
            }


        }

        private void gatherPresDila()
        {
            pres_dila = "";

            if (jejuPresDilChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }

            if (ileumPresDilChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }

            if (rtColonPresDilChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }
            if (trColonPresDilChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }
            if (ltColonPresDilChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }
            if (sigColonPresDilChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }


        }
        #endregion

        private void ileumMuralFibrosisChkbx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rtColonMuralFibrosisChkbx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void trColonMuralFibrosisChkbx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ltColonMuralFibrosisChkbx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sigColonMuralFibrosisChkbx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int pof = 0;
                int pres_abc=0;

                gatherSubMuc();
                gatherFatCreep();
                gatherLocalLN();
                gatherMurFib();
                gatherLumStric();
                gatherPresDila();

                if(presFistChkbx.Checked){
                    pof =1 ;
                }

                if(presOfAbcChkbx.Checked){
                    pres_abc =1 ;
                }

                if (mode == 0)
                {
                    u_id = DataSet.Insertultrasonicinfo(1, usDate.Value.Date, jejuMucOutTB.Text, ileumMucOutTB.Text, rtColonMucOutTB.Text, trColonMucOutTB.Text, ltColonMucOutTB.Text, sigColonMucOutTB.Text,
                         binToInt(sub_muc), jejuSMthickTB.Text, ileumSMthickTB.Text, rtColonSMthickTB.Text, trColonSMthickTB.Text, ltColonSMthickTB.Text, sigColonSMthickTB.Text, jejuSegmentLenTB.Text,
                         ileumSegmentLenTB.Text, rtColonSegmentLenTB.Text, trColonSegmentLenTB.Text, ltColonSegmentLenTB.Text, sigColonSegmentLenTB.Text, jejuMuralThickTB.Text, ileumMuralThickTB.Text,
                         rtColonMuralThickTB.Text, trColonMuralThickTB.Text, ltColonMuralThickTB.Text, sigColonMuralThickTB.Text, jejuMuralHyperCB.Text, ileumMuralHyperCB.Text, rtColonMuralHyperCB.Text,
                         trColonMuralHyperCB.Text, ltColonMuralHyperCB.Text, sigColonMuralHyperCB.Text, jejuMuralHyperCB.Text, ileumMuralHyperCB.Text, rtColonMuralHyperCB.Text, trColonMuralHyperCB.Text,
                         ltColonMuralHyperCB.Text, sigColonMuralHyperCB.Text, jejuMuralRiTB.Text, ileumMuralRiTB.Text, rtColonMuralRiTB.Text, trColonMuralRiTB.Text, ltColonMuralRiTB.Text,
                         sigColonMuralRiTB.Text, jejuMuralPiTB.Text, ileumMuralPiTB.Text, rtColonMuralPiTB.Text, trColonMuralPiTB.Text, ltColonMuralPiTB.Text, sigColonMuralPiTB.Text, binToInt(fat_creep),
                         binToInt(local_ln_enlarg), jejuLocalLnSizeTB.Text, ileumLocalLnSizeTB.Text, rtColonLocalLnSizeTB.Text, trColonLocalLnSizeTB.Text, ltColonLocalLnSizeTB.Text, sigColonLocalLnSizeTB.Text,
                         jejuLocalLnVasCB.Text, ileumLocalLnVasCB.Text, rtColonLocalLnVasCB.Text, trColonLocalLnVasCB.Text, ltColonLocalLnVasCB.Text, sigColonLocalLnVasCB.Text, binToInt(mur_fib),
                         binToInt(lum_stric), binToInt(pres_dila), jejuPresDiaTB.Text, ileumPresDiaTB.Text, rtColonPresDiaTB.Text, trColonPresDiaTB.Text, ltColonPresDiaTB.Text, sigColonPresDiaTB.Text,
                         totalActiveLengthTB.Text, pof, fistulaLengthTB.Text, fistulaDiamTB.Text, fistTypeCB.Text, otherFisTypeTB.Text, pres_abc, abcDiaTB.Text, abcVolumeTB.Text, locationAbcCB.Text, otherTypeAbcTB.Text, otherFindingsTB.Text, usReportTB.Text, p_id);
                }
                else if(mode==1)
                {
                    DataSet.Updateultrasonicinfo(1, usDate.Value.Date, jejuMucOutTB.Text, ileumMucOutTB.Text, rtColonMucOutTB.Text, trColonMucOutTB.Text, ltColonMucOutTB.Text, sigColonMucOutTB.Text,
                         binToInt(sub_muc), jejuSMthickTB.Text, ileumSMthickTB.Text, rtColonSMthickTB.Text, trColonSMthickTB.Text, ltColonSMthickTB.Text, sigColonSMthickTB.Text, jejuSegmentLenTB.Text,
                         ileumSegmentLenTB.Text, rtColonSegmentLenTB.Text, trColonSegmentLenTB.Text, ltColonSegmentLenTB.Text, sigColonSegmentLenTB.Text, jejuMuralThickTB.Text, ileumMuralThickTB.Text,
                         rtColonMuralThickTB.Text, trColonMuralThickTB.Text, ltColonMuralThickTB.Text, sigColonMuralThickTB.Text, jejuMuralHyperCB.Text, ileumMuralHyperCB.Text, rtColonMuralHyperCB.Text,
                         trColonMuralHyperCB.Text, ltColonMuralHyperCB.Text, sigColonMuralHyperCB.Text, jejuMuralHyperCB.Text, ileumMuralHyperCB.Text, rtColonMuralHyperCB.Text, trColonMuralHyperCB.Text,
                         ltColonMuralHyperCB.Text, sigColonMuralHyperCB.Text, jejuMuralRiTB.Text, ileumMuralRiTB.Text, rtColonMuralRiTB.Text, trColonMuralRiTB.Text, ltColonMuralRiTB.Text,
                         sigColonMuralRiTB.Text, jejuMuralPiTB.Text, ileumMuralPiTB.Text, rtColonMuralPiTB.Text, trColonMuralPiTB.Text, ltColonMuralPiTB.Text, sigColonMuralPiTB.Text, binToInt(fat_creep),
                         binToInt(local_ln_enlarg), jejuLocalLnSizeTB.Text, ileumLocalLnSizeTB.Text, rtColonLocalLnSizeTB.Text, trColonLocalLnSizeTB.Text, ltColonLocalLnSizeTB.Text, sigColonLocalLnSizeTB.Text,
                         jejuLocalLnVasCB.Text, ileumLocalLnVasCB.Text, rtColonLocalLnVasCB.Text, trColonLocalLnVasCB.Text, ltColonLocalLnVasCB.Text, sigColonLocalLnVasCB.Text, binToInt(mur_fib),
                         binToInt(lum_stric), binToInt(pres_dila), jejuPresDiaTB.Text, ileumPresDiaTB.Text, rtColonPresDiaTB.Text, trColonPresDiaTB.Text, ltColonPresDiaTB.Text, sigColonPresDiaTB.Text,
                         totalActiveLengthTB.Text, pof, fistulaLengthTB.Text, fistulaDiamTB.Text, fistTypeCB.Text, otherFisTypeTB.Text, pres_abc, abcDiaTB.Text, abcVolumeTB.Text, locationAbcCB.Text, otherTypeAbcTB.Text, otherFindingsTB.Text, usReportTB.Text, p_id, u_id);
                }
                MessageBox.Show("Saved successfully");
                refreshDateCB();

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
                                        usDate.ValueChanged -= usDate_ValueChanged;
                                        fillData(usDate.Value.Date.ToString());
                                        fillImages(u_id);
                                        usDate.ValueChanged += usDate_ValueChanged;
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


        private void fillData(string date)
        {
            try
            {
                int temp = 0;
                char[] temp_char = new char[6];

                clearBindings();
                dt = DataSet.getUltrasonics(date, p_id);
                mainBindingSource.DataSource = dt;

                usDate.DataBindings.Clear();

                u_id = Convert.ToInt32(dt.Rows[0]["id"]);

                usDate.ValueChanged -= usDate_ValueChanged;
                this.usDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mainBindingSource, "Dateofus", true));
                usDate.ValueChanged += usDate_ValueChanged;

                this.jejuMucOutTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "moje", true));
                this.ileumMucOutTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "moil", true));
                this.rtColonMucOutTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "morc", true));
                this.trColonMucOutTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "motc", true));
                this.ltColonMucOutTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "molc", true));
                this.sigColonMucOutTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mosi", true));

                this.jejuSMthickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "smtje", true));
                this.ileumSMthickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "smtil", true));
                this.rtColonSMthickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "smtrc", true));
                this.trColonSMthickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "smttc", true));
                this.ltColonSMthickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "smtlc", true));
                this.sigColonSMthickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "smtsi", true));

                this.jejuSegmentLenTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "slje", true));
                this.ileumSegmentLenTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "slil", true));
                this.rtColonSegmentLenTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "slrc", true));
                this.trColonSegmentLenTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "sltc", true));
                this.ltColonSegmentLenTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "sllc", true));
                this.sigColonSegmentLenTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "slsi", true));

                this.jejuMuralThickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mtje", true));
                this.ileumMuralThickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mtil", true));
                this.rtColonMuralThickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mtrc", true));
                this.trColonMuralThickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mttc", true));
                this.ltColonMuralThickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mtlc", true));
                this.sigColonMuralThickTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mtsi", true));

                this.jejuMuralHyperCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mhje", true));
                this.ileumMuralHyperCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mhil", true));
                this.rtColonMuralHyperCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mhrc", true));
                this.trColonMuralHyperCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mhtc", true));
                this.ltColonMuralHyperCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mhlc", true));
                this.sigColonMuralHyperCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mhsi", true));

                this.jejuMuralPsvTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mpje", true));
                this.ileumMuralPsvTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mpil", true));
                this.rtColonMuralPsvTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mprc", true));
                this.trColonMuralPsvTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mptc", true));
                this.ltColonMuralPsvTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mplc", true));
                this.sigColonMuralPsvTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mpsi", true));

                this.jejuMuralRiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mrje", true));
                this.ileumMuralRiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mril", true));
                this.rtColonMuralRiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mrrc", true));
                this.trColonMuralRiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mrtc", true));
                this.ltColonMuralRiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mrlc", true));
                this.sigColonMuralRiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mrsi", true));

                this.jejuMuralPiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mpije", true));
                this.ileumMuralPiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mpiil", true));
                this.rtColonMuralPiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mpirc", true));
                this.trColonMuralPiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mpitc", true));
                this.ltColonMuralPiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mpilc", true));
                this.sigColonMuralPiTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "mpisi", true));

                this.jejuLocalLnSizeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llsje", true));
                this.ileumLocalLnSizeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llsil", true));
                this.rtColonLocalLnSizeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llsrc", true));
                this.trColonLocalLnSizeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llstc", true));
                this.ltColonLocalLnSizeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llslc", true));
                this.sigColonLocalLnSizeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llssi", true));

                this.jejuLocalLnVasCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llvje", true));
                this.ileumLocalLnVasCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llvil", true));
                this.rtColonLocalLnVasCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llvrc", true));
                this.trColonLocalLnVasCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llvtc", true));
                this.ltColonLocalLnVasCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llvlc", true));
                this.sigColonLocalLnVasCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "llvsi", true));

                this.jejuPresDiaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "jejuPresDiam", true));
                this.ileumPresDiaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ileumPresDiam", true));
                this.rtColonPresDiaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "rtColonPresDiam", true));
                this.trColonPresDiaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "trColonPresDiam", true));
                this.ltColonPresDiaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ltColonPresDiam", true));
                this.sigColonPresDiaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "sigColonPresDiam", true));

                this.totalActiveLengthTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "tcl", true));
                this.fistulaLengthTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "length", true));
                this.fistulaDiamTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "fis_diameter", true));
                this.fistTypeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "typeoffis", true));
                this.otherFisTypeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "othertypefis", true));
                this.abcDiaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Diam", true));
                this.abcVolumeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "volume", true));
                this.locationAbcCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "loa", true));
                this.otherTypeAbcTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "otherlloac", true));
                this.otherFindingsTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "otherfinding", true));
                this.usReportTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ultrasoundreport", true));

                #region subMucosal edema
                temp = Convert.ToInt32(dt.Rows[0]["subedema"]);
                temp_char = intToBinary(temp);
                if (temp_char[0] == '1')
                {
                    jejuSubEdeChkbx.Checked = true;
                }
                if (temp_char[1] == '1')
                {
                    ileumSubEdeChkbx.Checked = true;
                }
                if (temp_char[2] == '1')
                {
                    rtColonSubEdeChkbx.Checked = true;
                }
                if (temp_char[3] == '1')
                {
                    trColonSubEdeChkbx.Checked = true;
                }
                if (temp_char[4] == '1')
                {
                    ltColonSubEdeChkbx.Checked = true;
                }
                if (temp_char[5] == '1')
                {
                    sigColonSubEdeChkbx.Checked = true;
                }
               
                #endregion

                #region fat creeping
                temp = Convert.ToInt32(dt.Rows[0]["fatcreepsign"]);
                temp_char = intToBinary(temp);
                if (temp_char[0] == '1')
                {
                    jejuFatCreepingSignChkbx.Checked = true;
                }
                if (temp_char[1] == '1')
                {
                    ileumFatCreepingSignChkbx.Checked = true;
                }
                if (temp_char[2] == '1')
                {
                    rtColonFatCreepingSignChkbx.Checked = true;
                }
                if (temp_char[3] == '1')
                {
                    trColonFatCreepingSignChkbx.Checked = true;
                }
                if (temp_char[4] == '1')
                {
                    ltColonFatCreepingSignChkbx.Checked = true;
                }
                if (temp_char[5] == '1')
                {
                    sigColonFatCreepingSignChkbx.Checked = true;
                }

                #endregion

                #region local ln enlargment
                temp = Convert.ToInt32(dt.Rows[0]["locallnenla"]);
                temp_char = intToBinary(temp);
                if (temp_char[0] == '1')
                {
                    jejuLocalLnEnlargChkbx.Checked = true;
                }
                if (temp_char[1] == '1')
                {
                    ileumLocalLnEnlargChkbx.Checked = true;
                }
                if (temp_char[2] == '1')
                {
                    rtColonLocalLnEnlargChkbx.Checked = true;
                }
                if (temp_char[3] == '1')
                {
                    trColonLocalLnEnlargChkbx.Checked = true;
                }
                if (temp_char[4] == '1')
                {
                    ltColonLocalLnEnlargChkbx.Checked = true;
                }
                if (temp_char[5] == '1')
                {
                    sigColonLocalLnEnlargChkbx.Checked = true;
                }

                #endregion

                #region MuralFibrosis
                temp = Convert.ToInt32(dt.Rows[0]["muralfib"]);
                temp_char = intToBinary(temp);
                if (temp_char[0] == '1')
                {
                    jejuMuralFibChkbx.Checked = true;
                }
                if (temp_char[1] == '1')
                {
                    ileumMuralFibChkbx.Checked = true;
                }
                if (temp_char[2] == '1')
                {
                    rtColonMuralFibChkbx.Checked = true;
                }
                if (temp_char[3] == '1')
                {
                    trColonMuralFibChkbx.Checked = true;
                }
                if (temp_char[4] == '1')
                {
                    ltColonMuralFibChkbx.Checked = true;
                }
                if (temp_char[5] == '1')
                {
                    sigColonMuralFibChkbx.Checked = true;
                }

                #endregion

                #region Luminal stricture
                temp = Convert.ToInt32(dt.Rows[0]["luminalstric"]);
                temp_char = intToBinary(temp);
                if (temp_char[0] == '1')
                {
                    jejuLumStrChkbx.Checked = true;
                }
                if (temp_char[1] == '1')
                {
                    ileumLumStrChkbx.Checked = true;
                }
                if (temp_char[2] == '1')
                {
                    rtColonLumStrChkbx.Checked = true;
                }
                if (temp_char[3] == '1')
                {
                    trColonLumStrChkbx.Checked = true;
                }
                if (temp_char[4] == '1')
                {
                    ltColonLumStrChkbx.Checked = true;
                }
                if (temp_char[5] == '1')
                {
                    sigColonLumStrChkbx.Checked = true;
                }

                #endregion

                #region Pres dilation
                temp = Convert.ToInt32(dt.Rows[0]["presdialation"]);
                temp_char = intToBinary(temp);
                if (temp_char[0] == '1')
                {
                    jejuPresDilChkbx.Checked = true;
                }
                if (temp_char[1] == '1')
                {
                    ileumPresDilChkbx.Checked = true;
                }
                if (temp_char[2] == '1')
                {
                    rtColonPresDilChkbx.Checked = true;
                }
                if (temp_char[3] == '1')
                {
                    trColonPresDilChkbx.Checked = true;
                }
                if (temp_char[4] == '1')
                {
                    ltColonPresDilChkbx.Checked = true;
                }
                if (temp_char[5] == '1')
                {
                    sigColonPresDilChkbx.Checked = true;
                }

                #endregion

                if (Convert.ToInt32(dt.Rows[0]["pof"]) == 1)
                {
                    presFistChkbx.Checked = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["pa"]) == 1)
                {
                    presOfAbcChkbx.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    }
                    if (tb is CheckBox)
                    {
                        ((CheckBox)tb).Checked = false;
                    }
                }

            }


        }
        private void refreshDateCB()
        {
            dateCB.SelectedIndexChanged -= dateCB_SelectedIndexChanged;


            dt_date = DataSet.getultrasonicDates(p_id);
            dateBindingSource.DataSource = dt_date;
            dateCB.DataSource = dt_date;
            dateCB.DisplayMember = "Dateofus";

            dateCB.SelectedIndexChanged += dateCB_SelectedIndexChanged;
        }

        private void dateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mode = 1;
            fillData(dateCB.Text);
            fillImages(u_id);
            button1.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void usDate_ValueChanged(object sender, EventArgs e)
        {
            mode = 0;
            clearBindings();
            flowLayoutPanel1.Controls.Clear();
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

        private void fillImages(int id)
        {


            try
            {
                flowLayoutPanel1.Controls.Clear();
                DataTable di = new DataTable();
                di = DataSet.getUltrasonicImages(Convert.ToInt16(id));
                byte[] image_arr = null;
                Image photo = null;

                for (int i = 0; i < di.Rows.Count; i++)
                {
                    try
                    {
                        image_arr = (byte[])di.Rows[i]["u_image"];

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
                         DataSet.deleteuimages(Convert.ToInt32(((PictureBox)sender).Tag), p_id);
                         flowLayoutPanel1.Controls.Clear();
                         fillImages(p_id);
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



        private void clearPb()
        {
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                                DataSet.parametrizedInsertUltra(Convert.ToInt16(u_id), PhotoByte);
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
                fillImages(u_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("please select a valid date");
                MessageBox.Show(ex.Message);
            }
        }

        private void ultrasound_form_Load(object sender, EventArgs e)
        {
            string usrAccess = WindowsFormsApplication5.Properties.Settings.Default.drAccess;
            if (Convert.ToInt16(usrAccess) < 1)
            {
                saveBtn.Visible = false;
            }
        }
    }


}
