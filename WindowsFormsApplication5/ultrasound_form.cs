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
    public partial class ultrasound_form : Form
    {
        int p_id = 0;
        string sub_muc = "";
        string fat_creep = "";
        string local_ln_enlarg = "";
        string mur_fib = "";
        string lum_stric = "";
        string pres_dila = "";

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
        }

        public static int binToInt(string number)
        {
            int output = Convert.ToInt32(number, 2);


            return output;
        }

        public static char[] intToBinary(int number)
        {


            var array = Convert.ToString(number, 2).PadLeft(7, '0').ToArray();

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

                DataSet.Insertultrasonicinfo(1, usDate.Value.Date, jejuMucOutTB.Text, ileumMucOutTB.Text, rtColonMucOutTB.Text, trColonMucOutTB.Text, ltColonMucOutTB.Text, sigColonMucOutTB.Text,
                    binToInt(sub_muc), jejuSMthickTB.Text, ileumSMthickTB.Text, rtColonSMthickTB.Text, trColonSMthickTB.Text, ltColonSMthickTB.Text, sigColonSMthickTB.Text, jejuSegmentLenTB.Text,
                    ileumSegmentLenTB.Text, rtColonSegmentLenTB.Text, trColonSegmentLenTB.Text, ltColonSegmentLenTB.Text, sigColonSegmentLenTB.Text, jejuMuralThickTB.Text, ileumMuralThickTB.Text,
                    rtColonMuralThickTB.Text, trColonMuralThickTB.Text, ltColonMuralThickTB.Text, sigColonMuralThickTB.Text, jejuMuralHyperCB.Text, ileumMuralHyperCB.Text, rtColonMuralHyperCB.Text,
                    trColonMuralHyperCB.Text, ltColonMuralHyperCB.Text, sigColonMuralHyperCB.Text, jejuMuralHyperCB.Text, ileumMuralHyperCB.Text, rtColonMuralHyperCB.Text, trColonMuralHyperCB.Text,
                    ltColonMuralHyperCB.Text, sigColonMuralHyperCB.Text, jejuMuralRiTB.Text, ileumMuralRiTB.Text, rtColonMuralRiTB.Text, trColonMuralRiTB.Text, ltColonMuralRiTB.Text,
                    sigColonMuralRiTB.Text, jejuMuralPiTB.Text, ileumMuralPiTB.Text, rtColonMuralPiTB.Text, trColonMuralPiTB.Text, ltColonMuralPiTB.Text, sigColonMuralPiTB.Text, binToInt(fat_creep),
                    binToInt(local_ln_enlarg), jejuLocalLnSizeTB.Text, ileumLocalLnSizeTB.Text, rtColonLocalLnSizeTB.Text, trColonLocalLnSizeTB.Text, ltColonLocalLnSizeTB.Text, sigColonLocalLnSizeTB.Text,
                    jejuLocalLnVasCB.Text, ileumLocalLnVasCB.Text, rtColonLocalLnVasCB.Text, trColonLocalLnVasCB.Text, ltColonLocalLnVasCB.Text, sigColonLocalLnVasCB.Text, binToInt(mur_fib),
                    binToInt(lum_stric), binToInt(pres_dila), jejuPresDiaTB.Text, ileumPresDiaTB.Text, rtColonPresDiaTB.Text, trColonPresDiaTB.Text, ltColonPresDiaTB.Text, sigColonPresDiaTB.Text,
                    totalActiveLengthTB.Text, pof, fistulaLengthTB.Text, fistulaDiamTB.Text, fistTypeCB.Text, otherFisTypeTB.Text, pres_abc, abcDiaTB.Text, abcDiaTB.Text, locationAbcCB.Text, otherTypeAbcTB.Text, otherFindingsTB.Text, usReportTB.Text, p_id);


            }
            catch (Exception ex)
            {

            }

        }
    }
}
