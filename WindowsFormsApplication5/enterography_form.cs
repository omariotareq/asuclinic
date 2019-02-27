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
    public partial class enterography_form : Form
    {

        int p_id = 0;
        string muc_enhanc = "";
        string muc_irr = "";
        string sub_edema = "";
        string mural_abcess = "";
        string fat_edema = "";
        string comb_sign = "";
        string mural_fibrosis = "";
        string pres_dila = "";
        string loss_haus = "";

        char[] muc_enhanc_char ;
        char[] muc_irr_char;
        char[] sub_edema_char;
        char[] mural_abcess_char;
        char[] fat_edema_char;
        char[] comb_sign_char;
        char[] mural_fibrosis_char;
        char[] pres_dila_char;
        char[] loss_haus_char;

        DataTable dt_date = new DataTable();
        BindingSource dateBindingSource = new BindingSource();
        public enterography_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            patNameLb.Text = name;
            ageLbl.Text = "" + age;
            p_id = pa_id;

            refreshDateCB();
        }

        private void refreshDateCB()
        {
            enteroDatesCB.SelectedIndexChanged -= enteroDatesCB_SelectedIndexChanged;


            dt_date = DataSet.getPatiententerographyDates(p_id);
            dateBindingSource.DataSource = dt_date;
            enteroDatesCB.DataSource = dt_date;
            enteroDatesCB.DisplayMember = "date";

            enteroDatesCB.SelectedIndexChanged += enteroDatesCB_SelectedIndexChanged;
        }
        public static char[] intToBinary(int number)
        {
            

            var array = Convert.ToString(number, 2).PadLeft(7, '0').ToArray();

            return array;
        }

        public static int binToInt(string number)
        {
            int output = Convert.ToInt32(number, 2);
            

            return output;
        }

        #region Encoding
        private void gatherMucEnhanc()
        {
            muc_enhanc = "";

            if (jejuMucosalEnhancChkb.Checked)
            {
                muc_enhanc = muc_enhanc + "1";
            }
            else{
                muc_enhanc = muc_enhanc + "0";
            }

            if (ileumMucosalEnhancChkb.Checked)
            {
                muc_enhanc = muc_enhanc + "1";
            }
            else
            {
                muc_enhanc = muc_enhanc + "0";
            }

            if (rtColonMucosalEnhancChkb.Checked)
            {
                muc_enhanc = muc_enhanc + "1";
            }
            else{
                muc_enhanc = muc_enhanc + "0";
            }
            if (trColonMucosalEnhancChkb.Checked)
            {
                muc_enhanc = muc_enhanc + "1";
            }
            else
            {
                muc_enhanc = muc_enhanc + "0";
            }
            if (ltColonMucosalEnhancChkb.Checked)
            {
                muc_enhanc = muc_enhanc + "1";
            }
            else
            {
                muc_enhanc = muc_enhanc + "0";
            }
            if (sigColonMucosalEnhancChkb.Checked)
            {
                muc_enhanc = muc_enhanc + "1";
            }
            else
            {
                muc_enhanc = muc_enhanc + "0";
            }
            if (rectumMucosalEnhancChkb.Checked)
            {
                muc_enhanc = muc_enhanc + "1";
            }
            else
            {
                muc_enhanc = muc_enhanc + "0";
            }

        }

        private void gatherMucIrr()
        {
            muc_irr = "";

            if (jejuMucIrrChkbx.Checked)
            {
                muc_irr = muc_irr + "1";
            }
            else
            {
                muc_irr = muc_irr + "0";
            }

            if (ileumMucIrrChkbx.Checked)
            {
                muc_irr = muc_irr + "1";
            }
            else
            {
                muc_irr = muc_irr + "0";
            }

            if (rtColonMucIrrChkbx.Checked)
            {
                muc_irr = muc_irr + "1";
            }
            else
            {
                muc_irr = muc_irr + "0";
            }
            if (trColonMucIrrChkbx.Checked)
            {
                muc_irr = muc_irr + "1";
            }
            else
            {
                muc_irr = muc_irr + "0";
            }
            if (ltColonMucIrrChkbx.Checked)
            {
                muc_irr = muc_irr + "1";
            }
            else
            {
                muc_irr = muc_irr + "0";
            }
            if (sigColonMucIrrChkbx.Checked)
            {
                muc_irr = muc_irr + "1";
            }
            else
            {
                muc_irr = muc_irr + "0";
            }
            if (rectumMucIrrChkbx.Checked)
            {
                muc_irr = muc_irr + "1";
            }
            else
            {
                muc_irr = muc_irr + "0";
            }

        }

        private void gatherSubEdema()
        {
            sub_edema = "";

            if (jejuSubMucEdemaChkbx.Checked)
            {
                sub_edema = sub_edema + "1";
            }
            else
            {
                sub_edema = sub_edema + "0";
            }

            if (ileumSubMucEdemaChkbx.Checked)
            {
                sub_edema = sub_edema + "1";
            }
            else
            {
                sub_edema = sub_edema + "0";
            }

            if (rtColonSubMucEdemaChkbx.Checked)
            {
                sub_edema = sub_edema + "1";
            }
            else
            {
                sub_edema = sub_edema + "0";
            }
            if (trColonSubMucEdemaChkbx.Checked)
            {
                sub_edema = sub_edema + "1";
            }
            else
            {
                sub_edema = sub_edema + "0";
            }
            if (ltColonSubMucEdemaChkbx.Checked)
            {
                sub_edema = sub_edema + "1";
            }
            else
            {
                sub_edema = sub_edema + "0";
            }
            if (sigColonSubMucEdemaChkbx.Checked)
            {
                sub_edema = sub_edema + "1";
            }
            else
            {
                sub_edema = sub_edema + "0";
            }
            if (rectumSubMucEdemaChkbx.Checked)
            {
                sub_edema = sub_edema + "1";
            }
            else
            {
                sub_edema = sub_edema + "0";
            }

        }

        private void gatherMurAbc()
        {
            mural_abcess = "";

            if (jejuMuralAbcChkb.Checked)
            {
                mural_abcess = mural_abcess + "1";
            }
            else
            {
                mural_abcess = mural_abcess + "0";
            }

            if (ileumMuralAbcChkb.Checked)
            {
                mural_abcess = mural_abcess + "1";
            }
            else
            {
                mural_abcess = mural_abcess + "0";
            }

            if (rtColonMuralAbcChkb.Checked)
            {
                mural_abcess = mural_abcess + "1";
            }
            else
            {
                mural_abcess = mural_abcess + "0";
            }
            if (trColonMuralAbcChkb.Checked)
            {
                mural_abcess = mural_abcess + "1";
            }
            else
            {
                mural_abcess = mural_abcess + "0";
            }
            if (ltColonMuralAbcChkb.Checked)
            {
                mural_abcess = mural_abcess + "1";
            }
            else
            {
                mural_abcess = mural_abcess + "0";
            }
            if (sigColonMuralAbcChkb.Checked)
            {
                mural_abcess = mural_abcess + "1";
            }
            else
            {
                mural_abcess = mural_abcess + "0";
            }
            if (rectumMuralAbcChkb.Checked)
            {
                mural_abcess = mural_abcess + "1";
            }
            else
            {
                mural_abcess = mural_abcess + "0";
            }

        }

        private void gatherFatEdm()
        {
            fat_edema = "";

            if (jejuFatEdemaChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }

            if (ileumFatEdemaChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }

            if (rtColonFatEdemaChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }
            if (trColonFatEdemaChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }
            if (ltColonFatEdemaChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }
            if (sigColonFatEdemaChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }
            if (rectumFatEdemaChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }

        }

        private void gatherCombSign()
        {
            comb_sign = "";

            if (jejuCombSignChkbx.Checked)
            {
                comb_sign = comb_sign + "1";
            }
            else
            {
                comb_sign = comb_sign + "0";
            }

            if (ileumCombSignChkbx.Checked)
            {
                comb_sign = comb_sign + "1";
            }
            else
            {
                comb_sign = comb_sign + "0";
            }

            if (rtColonCombSignChkbx.Checked)
            {
                comb_sign = comb_sign + "1";
            }
            else
            {
                comb_sign = comb_sign + "0";
            }
            if (trColonCombSignChkbx.Checked)
            {
                comb_sign = comb_sign + "1";
            }
            else
            {
                comb_sign = comb_sign + "0";
            }
            if (ltColonCombSignChkbx.Checked)
            {
                comb_sign = comb_sign + "1";
            }
            else
            {
                comb_sign = comb_sign + "0";
            }
            if (sigColonCombSignChkbx.Checked)
            {
                comb_sign = comb_sign + "1";
            }
            else
            {
                comb_sign = comb_sign + "0";
            }
            if (rectumCombSignChkbx.Checked)
            {
                comb_sign = comb_sign + "1";
            }
            else
            {
                comb_sign = comb_sign + "0";
            }

        }

        private void gatherMuralFib()
        {
            mural_fibrosis = "";

            if (jejuMuralFibrosisChkbx.Checked)
            {
                mural_fibrosis = mural_fibrosis + "1";
            }
            else
            {
                mural_fibrosis = mural_fibrosis + "0";
            }

            if (ileumMuralFibrosisChkbx.Checked)
            {
                mural_fibrosis = mural_fibrosis + "1";
            }
            else
            {
                mural_fibrosis = mural_fibrosis + "0";
            }

            if (rtColonMuralFibrosisChkbx.Checked)
            {
                mural_fibrosis = mural_fibrosis + "1";
            }
            else
            {
                mural_fibrosis = mural_fibrosis + "0";
            }
            if (trColonMuralFibrosisChkbx.Checked)
            {
                mural_fibrosis = mural_fibrosis + "1";
            }
            else
            {
                mural_fibrosis = mural_fibrosis + "0";
            }
            if (ltColonMuralFibrosisChkbx.Checked)
            {
                mural_fibrosis = mural_fibrosis + "1";
            }
            else
            {
                mural_fibrosis = mural_fibrosis + "0";
            }
            if (sigColonMuralFibrosisChkbx.Checked)
            {
                mural_fibrosis = mural_fibrosis + "1";
            }
            else
            {
                mural_fibrosis = mural_fibrosis + "0";
            }
            if (rectumMuralFibrosisChkbx.Checked)
            {
                mural_fibrosis = mural_fibrosis + "1";
            }
            else
            {
                mural_fibrosis = mural_fibrosis + "0";
            }

        }

        private void gatherPressDila()
        {
            pres_dila  = "";

            if (jejuPresDilatatiorChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }

            if (ileumPresDilatatiorChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }

            if (rtColonPresDilatatiorChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }
            if (trColonPresDilatatiorChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }
            if (ltColonPresDilatatiorChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }
            if (sigColonPresDilatatiorChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }
            if (rectumPresDilatatiorChkbx.Checked)
            {
                pres_dila = pres_dila + "1";
            }
            else
            {
                pres_dila = pres_dila + "0";
            }

        }

        private void gatherLossHaus()
        {
            loss_haus = "00";

           

            if (rtColonLossHausChkb.Checked)
            {
                loss_haus = loss_haus + "1";
            }
            else
            {
                loss_haus = loss_haus + "0";
            }
            if (trColonLossHausChkb.Checked)
            {
                loss_haus = loss_haus + "1";
            }
            else
            {
                loss_haus = loss_haus + "0";
            }
            if (ltColonLossHausChkb.Checked)
            {
                loss_haus = loss_haus + "1";
            }
            else
            {
                loss_haus = loss_haus + "0";
            }
            if (sigColonLossHausChkb.Checked)
            {
                loss_haus = loss_haus + "1";
            }
            else
            {
                loss_haus = loss_haus + "0";
            }
            if (rectumLossHausChkb.Checked)
            {
                loss_haus = loss_haus + "1";
            }
            else
            {
                loss_haus = loss_haus + "0";
            }

        }
        #endregion

        #region Decoding

        #endregion

        private void ileumMucosalEnhancChkb_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gatherMucEnhanc();
            int trans = binToInt(muc_enhanc);
            MessageBox.Show(muc_enhanc +" - "+trans);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                gatherMucEnhanc();
                gatherMucIrr();
                gatherSubEdema();
                gatherMurAbc();
                gatherFatEdm();
                gatherCombSign();
                gatherMuralFib();
                gatherPressDila();
                gatherLossHaus();

                int fistula =0;
                int abcess_form = 0;

                if(fistulaChkbx.Checked){
                    fistula =1;
                }
                else{
                    fistula = 0;
                }

                if(abcessFormChkbx.Checked){
                    abcess_form =1;
                }
                else{
                    abcess_form = 0;
                }

                DataSet.InsertenterographyyInfo(enterDate.Value.Date, studyTypeCB.Text, binToInt(muc_enhanc), jejuEnhancAmountTB.Text, ileumEnhancAmountTB.Text, rtColonEnhancAmountTB.Text, trColonEnhancAmountTB.Text,
                    ltColonEnhancAmountTB.Text, sigColonEnhancAmountTB.Text, rectumEnhancAmountTB.Text, binToInt(muc_irr), binToInt(sub_edema), jejuThicknessEdemaTB.Text, ileumThicknessEdemaTB.Text, rtColonThicknessEdemaTB.Text, trColonThicknessEdemaTB.Text,
                    ltColonThicknessEdemaTB.Text, sigColonThicknessEdemaTB.Text, rectumThicknessEdemaTB.Text, binToInt(mural_abcess), jejuLengthActTB.Text, ileumLengthActTB.Text, rtColonLengthActTB.Text, trColonLengthActTB.Text, ltColonLengthActTB.Text, sigColonLengthActTB.Text,
                    rectumLengthActTB.Text, jejuMuralThicknessTB.Text, ileumMuralThicknessTB.Text, rtColonMuralThicknessTB.Text, trColonMuralThicknessTB.Text, ltColonMuralThicknessTB.Text, sigColonMuralThicknessTB.Text, rectumMuralThicknessTB.Text,
                    binToInt(fat_edema), binToInt(comb_sign), binToInt(mural_fibrosis), jejuNarrwoingCB.Text, ileumNarrwoingCB.Text, rtColonNarrwoingCB.Text, trColonNarrwoingCB.Text, ltColonNarrwoingCB.Text, sigColonNarrwoingCB.Text, rectumNarrwoingCB.Text, binToInt(pres_dila), jejuPresDiameterTB.Text,
                    ileumPresDiameterTB.Text, rtColonPresDiameterTB.Text, trColonPresDiameterTB.Text, ltColonPresDiameterTB.Text, sigColonPresDiameterTB.Text, rectumPresDiameterTB.Text, binToInt(loss_haus),Convert.ToInt16(activeSegmentTB.Text), fistula, abcess_form, Convert.ToInt16(lengthOfTrackTB.Text), 
                    Convert.ToInt16(diameterOfAbcTB.Text), Convert.ToInt16(diameterOfTrackTB.Text), Convert.ToInt16(volOfAbcTB.Text), typeOfFistulaCB.Text, abcessLocationCB.Text, otherFistulaTypeTB.Text, otherAbcLocTB.Text, otherEnterographyTB.Text, enteroReportTB.Text, p_id);

                refreshDateCB();

                MessageBox.Show("Saved successfully");
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void enteroDatesCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
       
    }
}
