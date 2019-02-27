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
 
        public enterography_form(int pa_id, string name, int age)
        {
            InitializeComponent();

            patNameLb.Text = name;
            ageLbl.Text = "" + age;
            p_id = pa_id;
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
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }

            if (ileumCombSignChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }

            if (rtColonCombSignChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }
            if (trColonCombSignChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }
            if (ltColonCombSignChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }
            if (sigColonCombSignChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
            }
            if (rectumCombSignChkbx.Checked)
            {
                fat_edema = fat_edema + "1";
            }
            else
            {
                fat_edema = fat_edema + "0";
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

        
       
    }
}
