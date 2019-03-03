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
        DataTable dt = new DataTable();

        BindingSource mainBindingSource = new BindingSource();
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
                    ileumPresDiameterTB.Text, rtColonPresDiameterTB.Text, trColonPresDiameterTB.Text, ltColonPresDiameterTB.Text, sigColonPresDiameterTB.Text, rectumPresDiameterTB.Text, binToInt(loss_haus),(activeSegmentTB.Text), fistula, abcess_form, (lengthOfTrackTB.Text), 
                    diameterOfAbcTB.Text, (diameterOfTrackTB.Text), (volOfAbcTB.Text), typeOfFistulaCB.Text, abcessLocationCB.Text, otherFistulaTypeTB.Text, otherAbcLocTB.Text, otherEnterographyTB.Text, enteroReportTB.Text, p_id);

                refreshDateCB();

                MessageBox.Show("Saved successfully");
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void fillData()
        {
            int temp = 0;
            char[] temp_char = new char[7];

            /* char[] muc_enhanc_char ;
            char[] muc_irr_char;
            char[] sub_edema_char;
            char[] mural_abcess_char;
            char[] fat_edema_char;
            char[] comb_sign_char;
            char[] mural_fibrosis_char;
            char[] pres_dila_char;
            char[] loss_haus_char;*/

            clearChkBxes();
            clearBindings();
           dt =  DataSet.getEnterography(enteroDatesCB.Text, p_id);
           mainBindingSource.DataSource = dt;

           studyTypeCB.DataBindings.Clear();
           

            this.studyTypeCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Entrostudy", true));

           this.jejuEnhancAmountTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "jejEa", true));
           this.ileumEnhancAmountTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ilEa", true));
           this.rtColonEnhancAmountTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "RcEa", true));
           this.trColonEnhancAmountTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "TcEa", true));
           this.ltColonEnhancAmountTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "LcEa", true));
           this.sigColonEnhancAmountTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ScEa", true));
           this.rectumEnhancAmountTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ReEa", true));

           this.jejuThicknessEdemaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "jethofSMedema", true));
           this.ileumThicknessEdemaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ilthofSMedema", true));
           this.rtColonThicknessEdemaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "RcthofSMedema", true));
           this.trColonThicknessEdemaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "TcthofSMedema", true));
           this.ltColonThicknessEdemaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "LcthofSMedema", true));
           this.sigColonThicknessEdemaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ScthofSMedema", true));
           this.rectumThicknessEdemaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "RethofSMedema", true));

           this.jejuLengthActTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "jelengthactivity", true));
           this.ileumLengthActTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "illengthactivity", true));
           this.rtColonLengthActTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Rclengthactivity", true));
           this.trColonLengthActTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Tclengthactivity", true));
           this.ltColonLengthActTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Lclengthactivity", true));
           this.sigColonLengthActTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Sclengthactivity", true));
           this.rectumLengthActTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Relengthactivity", true));

           this.jejuMuralThicknessTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "jemuralthickness", true));
           this.ileumMuralThicknessTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ilmuralthickness", true));
           this.rtColonMuralThicknessTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Rcmuralthickness", true));
           this.trColonMuralThicknessTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Tcmuralthickness", true));
           this.ltColonMuralThicknessTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Lcmuralthickness", true));
           this.sigColonMuralThicknessTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Scmuralthickness", true));
           this.rectumMuralThicknessTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "Remuralthickness", true));

           this.jejuNarrwoingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "jeNarstr", true));
           this.ileumNarrwoingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ilNarstr", true));
           this.rtColonNarrwoingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "RcNarstr", true));
           this.trColonNarrwoingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "TcNarstr", true));
           this.ltColonNarrwoingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "LcNarstr", true));
           this.sigColonNarrwoingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ScNarstr", true));
           this.rectumNarrwoingCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ReNarstr", true));

           this.jejuPresDiameterTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "jePrestenoticdiam", true));
           this.ileumPresDiameterTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ilPrestenoticdiam", true));
           this.rtColonPresDiameterTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "RcPrestenoticdiam", true));
           this.trColonPresDiameterTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "TcPrestenoticdiam", true));
           this.ltColonPresDiameterTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "LcPrestenoticdiam", true));
           this.sigColonPresDiameterTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "ScPrestenoticdiam", true));
           this.rectumPresDiameterTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "RePrestenoticdiam", true));

           #region mucosalEnhancment
           temp = Convert.ToInt32(dt.Rows[0]["mucosalenh"]);
           temp_char = intToBinary(temp);
           if (temp_char[0] == '1')
           {
               jejuMucosalEnhancChkb.Checked = true;
           }
           if (temp_char[1] == '1')
           {
               ileumMucosalEnhancChkb.Checked = true;
           }
           if (temp_char[2] == '1')
           {
               rtColonMucosalEnhancChkb.Checked = true;
           }
           if (temp_char[3] == '1')
           {
               trColonMucosalEnhancChkb.Checked = true;
           }
           if (temp_char[4] == '1')
           {
               ltColonMucosalEnhancChkb.Checked = true;
           }
           if (temp_char[5] == '1')
           {
               sigColonMucosalEnhancChkb.Checked = true;
           }
           if (temp_char[6] == '1')
           {
               rectumMucosalEnhancChkb.Checked = true;
           }
           #endregion

           #region mucosalIrr
           temp = Convert.ToInt32(dt.Rows[0]["Mucosalirrefi"]);
           temp_char = intToBinary(temp);
           if (temp_char[0] == '1')
           {
               jejuMucIrrChkbx.Checked = true;
           }
           if (temp_char[1] == '1')
           {
               ileumMucIrrChkbx.Checked = true;
           }
           if (temp_char[2] == '1')
           {
               rtColonMucIrrChkbx.Checked = true;
           }
           if (temp_char[3] == '1')
           {
               trColonMucIrrChkbx.Checked = true;
           }
           if (temp_char[4] == '1')
           {
               ltColonMucIrrChkbx.Checked = true;
           }
           if (temp_char[5] == '1')
           {
               sigColonMucIrrChkbx.Checked = true;
           }
           if (temp_char[6] == '1')
           {
               rectumMucIrrChkbx.Checked = true;
           }
           #endregion

           #region SubMucosalEdema
           temp = Convert.ToInt32(dt.Rows[0]["submucosaledema"]);
           temp_char = intToBinary(temp);
           if (temp_char[0] == '1')
           {
               jejuSubMucEdemaChkbx.Checked = true;
           }
           if (temp_char[1] == '1')
           {
               ileumSubMucEdemaChkbx.Checked = true;
           }
           if (temp_char[2] == '1')
           {
               rtColonSubMucEdemaChkbx.Checked = true;
           }
           if (temp_char[3] == '1')
           {
               trColonSubMucEdemaChkbx.Checked = true;
           }
           if (temp_char[4] == '1')
           {
               ltColonSubMucEdemaChkbx.Checked = true;
           }
           if (temp_char[5] == '1')
           {
               sigColonSubMucEdemaChkbx.Checked = true;
           }
           if (temp_char[6] == '1')
           {
               rectumSubMucEdemaChkbx.Checked = true;
           }
           #endregion

           #region muralAbcess
           temp = Convert.ToInt32(dt.Rows[0]["muralabscess"]);
           temp_char = intToBinary(temp);
           if (temp_char[0] == '1')
           {
               jejuMuralAbcChkb.Checked = true;
           }
           if (temp_char[1] == '1')
           {
               ileumMuralAbcChkb.Checked = true;
           }
           if (temp_char[2] == '1')
           {
               rtColonMuralAbcChkb.Checked = true;
           }
           if (temp_char[3] == '1')
           {
               trColonMuralAbcChkb.Checked = true;
           }
           if (temp_char[4] == '1')
           {
               ltColonMuralAbcChkb.Checked = true;
           }
           if (temp_char[5] == '1')
           {
               sigColonMuralAbcChkb.Checked = true;
           }
           if (temp_char[6] == '1')
           {
               rectumMuralAbcChkb.Checked = true;
           }
           #endregion 

           #region FatEdema
           temp = Convert.ToInt32(dt.Rows[0]["Fatedema"]);
           temp_char = intToBinary(temp);
           if (temp_char[0] == '1')
           {
               jejuFatEdemaChkbx.Checked = true;
           }
           if (temp_char[1] == '1')
           {
               ileumFatEdemaChkbx.Checked = true;
           }
           if (temp_char[2] == '1')
           {
               rtColonFatEdemaChkbx.Checked = true;
           }
           if (temp_char[3] == '1')
           {
               trColonFatEdemaChkbx.Checked = true;
           }
           if (temp_char[4] == '1')
           {
               ltColonFatEdemaChkbx.Checked = true;
           }
           if (temp_char[5] == '1')
           {
               sigColonFatEdemaChkbx.Checked = true;
           }
           if (temp_char[6] == '1')
           {
               rectumFatEdemaChkbx.Checked = true;
           }
           #endregion

           #region CombSign
           temp = Convert.ToInt32(dt.Rows[0]["combsign"]);
           temp_char = intToBinary(temp);
           if (temp_char[0] == '1')
           {
               jejuCombSignChkbx.Checked = true;
           }
           if (temp_char[1] == '1')
           {
               ileumCombSignChkbx.Checked = true;
           }
           if (temp_char[2] == '1')
           {
               rtColonCombSignChkbx.Checked = true;
           }
           if (temp_char[3] == '1')
           {
               trColonCombSignChkbx.Checked = true;
           }
           if (temp_char[4] == '1')
           {
               ltColonCombSignChkbx.Checked = true;
           }
           if (temp_char[5] == '1')
           {
               sigColonCombSignChkbx.Checked = true;
           }
           if (temp_char[6] == '1')
           {
               rectumCombSignChkbx.Checked = true;
           }
           #endregion 

           #region MuralFibrosis
           temp = Convert.ToInt32(dt.Rows[0]["Muralfib"]);
           temp_char = intToBinary(temp);
           if (temp_char[0] == '1')
           {
               jejuMuralFibrosisChkbx.Checked = true;
           }
           if (temp_char[1] == '1')
           {
               ileumMuralFibrosisChkbx.Checked = true;
           }
           if (temp_char[2] == '1')
           {
               rtColonMuralFibrosisChkbx.Checked = true;
           }
           if (temp_char[3] == '1')
           {
               trColonMuralFibrosisChkbx.Checked = true;
           }
           if (temp_char[4] == '1')
           {
               ltColonMuralFibrosisChkbx.Checked = true;
           }
           if (temp_char[5] == '1')
           {
               sigColonMuralFibrosisChkbx.Checked = true;
           }
           if (temp_char[6] == '1')
           {
               rectumMuralFibrosisChkbx.Checked = true;
           }
           #endregion

            #region PresDia
           temp = Convert.ToInt32(dt.Rows[0]["Prestenoticdial"]);
           temp_char = intToBinary(temp);
           if (temp_char[0] == '1')
           {
               jejuPresDilatatiorChkbx.Checked = true;
           }
           if (temp_char[1] == '1')
           {
               ileumPresDilatatiorChkbx.Checked = true;
           }
           if (temp_char[2] == '1')
           {
               rtColonPresDilatatiorChkbx.Checked = true;
           }
           if (temp_char[3] == '1')
           {
               trColonPresDilatatiorChkbx.Checked = true;
           }
           if (temp_char[4] == '1')
           {
               ltColonPresDilatatiorChkbx.Checked = true;
           }
           if (temp_char[5] == '1')
           {
               sigColonPresDilatatiorChkbx.Checked = true;
           }
           if (temp_char[6] == '1')
           {
               rectumPresDilatatiorChkbx.Checked = true;
           }
            #endregion 

           #region LossHauss
           temp = Convert.ToInt32(dt.Rows[0]["LossofHaus"]);
           temp_char = intToBinary(temp);
           
           if (temp_char[2] == '1')
           {
               rtColonLossHausChkb.Checked = true;
           }
           if (temp_char[3] == '1')
           {
               trColonLossHausChkb.Checked = true;
           }
           if (temp_char[4] == '1')
           {
               ltColonLossHausChkb.Checked = true;
           }
           if (temp_char[5] == '1')
           {
               sigColonLossHausChkb.Checked = true;
           }
           if (temp_char[6] == '1')
           {
               rectumLossHausChkb.Checked = true;
           }
           #endregion

           this.activeSegmentTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "totallength", true));
           this.lengthOfTrackTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "complenoftrack", true));
           this.diameterOfTrackTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "compdiamoftrack", true));
           this.typeOfFistulaCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "comptypeoffistula", true));
           this.otherFistulaTypeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "compothertypefis", true));
           this.diameterOfAbcTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "compdiamofab", true));
           this.volOfAbcTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "compvolofab", true));
           this.abcessLocationCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "compabsloc", true));
           this.otherAbcLocTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "compotherabsloc", true));
           this.otherEnterographyTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "otherentrofindings", true));
           this.enteroReportTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainBindingSource, "EntroReport", true));

           if (Convert.ToInt32(dt.Rows[0]["compfistula"]) == 1)
           {
               fistulaChkbx.Checked = true;
           }
           if (Convert.ToInt32(dt.Rows[0]["compAbscessformation"]) == 1)
           {
               abcessFormChkbx.Checked = true;
           }

        }

        private void clearChkBxes()
        {
            foreach (Control gb in this.Controls)
            {
                foreach (Control tb in gb.Controls)
                {
                    if (gb is CheckBox)
                    {
                        ((CheckBox)gb).Checked = false;
                    }
                }
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


        private void enteroDatesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillData();
        }

        private void enterDate_ValueChanged(object sender, EventArgs e)
        {
            clearBindings();
        }

        
       
    }
}
