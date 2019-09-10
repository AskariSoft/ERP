using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ERP.BLL;
using DevExpress.XtraEditors;
using ERP.BLL.SYS;

namespace ERP.Accounts
{
    public partial class frmAccounts : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string strAuth_D = "";
        HomeScreen clsHomeScreen;
        public frmAccounts()
        {
            InitializeComponent();
            Set_Refresh_0();
            Set_Refresh_1();
            Set_Refresh_2();
            Set_Refresh_3();
            Set_Refresh_4();
            Fill_Combo();
            //Fill_Grid_0();
            Fill_Grid_1();
            Fill_Grid_2();
            Fill_Grid_3();
            Fill_Grid_4();

            Tab_Main.Pages[0].PageVisible = false;
            Tab_Main.SelectedPage = Tab_P2;
        }
        private void frmAccounts_Load(object sender, EventArgs e)
        {
            clsHomeScreen = (HomeScreen)this.MdiParent;
        }
        private void Set_Refresh_0()
        {
            lblCType_ID.Text = "";
            txtCType_D.Text = "";
            txtCType_DD.Text = "";
        }
        private void Set_Refresh_1()
        {
            lblMain_ID.Text = "";
            txtMain_Code.Text = "";
            txtMain_CodeD.Text = "";
            txtMain_CodeDD.Text = "";
            lookMain_AccType_ID.EditValue = null;
            lookMain_AccType_ID.Text = "";
            //lookMain_CType_ID.EditValue = null;
            //lookMain_CType_ID.Text = "";

            chkMain_Active.Checked = true;
        }
        private void Set_Refresh_2()
        {
            lblGroup_ID.Text = "";
            txtGroup_Code.Text = "";
            txtGroup_CodeD.Text = "";
            lookMain_ID.EditValue = null;
            lookMain_ID.Text = "";
            chkGroup_NoDetail.Checked = false;
        }
        private void Set_Refresh_3()
        {
            lblDetail_ID.Text = "";
            txtDetail_Code.Text = "";
            txtDetail_CodeD.Text = "";
            lookDetail_AccType.EditValue = null;
            lookDetail_AccType.Text = "";
            lookGroup_ID.EditValue = null;
            lookGroup_ID.Text = "";
            lookDetail_CurrID.EditValue = null;
            lookDetail_CurrID.Text = "";
            lookDetail_Location.EditValue = null;
            lookDetail_Location.Text = "";


            chkDetail_FCY.Checked = false;
            chkDetail_Active.Checked = true;
            chkDetail_SubLedger.Checked = false;
            //chkDetail_AZ.Checked = false;
            //chkDetail_NOU.Checked = false;
            //chkDetail_AC_1.Checked = false;
            //chkDetail_AC_2.Checked = false;
            //chkDetail_AC_3.Checked = false;
            //chkDetail_AC_4.Checked = false;
            //chkDetail_AC_5.Checked = false;
            //chkDetail_AC_6.Checked = false;
            //chkDetail_AC_7.Checked = false;
            //chkDetail_AC_8.Checked = false;
        }
        private void Set_Refresh_4()
        {
            lblSub_ID.Text = "";
            txtSub_Code.Text = "";
            txtSub_CodeD.Text = "";
            txtSub_GST.Text = "0";
            //txtSub_TaxRate.Text = "0";
            txtSub_NTN.Text = "";
            txtSub_Tel.Text = "";
            //txtSub_Tel2.Text = "";
            txtSub_CNIC.Text = "";
            txtSub_Email.Text = "";
            //txtSub_Reference.Text = "";
            txtSub_Address1.Text = "";
            txtSub_Address2.Text = "";
            txtSub_City.Text = "";
            txtSub_State.Text = "";
            txtSub_Country.Text = "";
            txtSub_Zip.Text = "";
            txtSub_ContactPerson.Text = "";
            txtSub_ContactDesig.Text = "";
            txtSub_ContactTel.Text = "";
            //txtSub_ContactTel2.Text = "";
            //txtSub_Contact_Ladnline.Text = "";
            dtpSub_Credit_U_SD.EditValue = null;
            txtSub_Credit_Amt.Text = "0";
            txtSub_Credit_Days.Text = "0";
            txtSub_Credit_Bal.Text = "0";

            lookDetail_ID.EditValue = null;
            lookDetail_ID.Text = "";
            lookSub_AccType_ID.EditValue = null;
            lookSub_AccType_ID.Text = "";
            //lookRegion_ID.EditValue = null;
            //lookRegion_ID.Text = "";
            //lookSub_SCat_ID.EditValue = null;
            //lookSub_SCat_ID.Text = "";
            //lookSub_GCat_ID.EditValue = null;
            //lookSub_GCat_ID.Text = "";
            lookSub_CurrID.EditValue = null;
            lookSub_CurrID.Text = "";
            //lookSub_Tax.EditValue = null;
            //lookSub_Tax.Text = "";
            //lookSub_SE.EditValue = null;
            //lookSub_SE.Text = "";

            //lookSub_Nationality.EditValue = null;
            //lookSub_Nationality.Text = "";
            lookSub_Credit_S_ID.EditValue = null;
            lookSub_Credit_S_ID.Text = "";
            lookSub_Location.EditValue = null;
            lookSub_Location.Text = "";
            
            chkSub_FCY.Checked = false;
            chkSub_Active.Checked = true;
            //chkSub_GST.Checked = false;
            //chkSub_NOU.Checked = false;
            chkSub_Sale.Checked = true;
            //chkSub_Purchase.Checked = false;
            chkSub_Credit_Limit.Checked = false;
            
            rdb_Cash_Credit.EditValue = 0;
            //imgSub_Image.Image = null;
            //imgSub_Contact_Image.Image = null;
        }
        private void Fill_Combo()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if(clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if(ds.Tables.Count > 0)
            {
                Set_Combo(lookMain_AccType_ID, ds.Tables[0], "AType_D", "AType_ID", true);
                Set_Combo(lookDetail_AccType, ds.Tables[1], "AccType_D", "AccType_ID", true);
                Set_Combo(lookSub_AccType_ID, ds.Tables[2], "AccType_D", "AccType_ID", true);
                Set_Combo(lookDetail_CurrID, ds.Tables[3], "Curr_D", "CurrID", true);
                Set_Combo(lookSub_CurrID, ds.Tables[3], "Curr_D", "CurrID", true);
                Set_Combo(lookDetail_Location, ds.Tables[4], "Branch_FName", "Branch_ID", true);
                Set_Combo(lookSub_Location, ds.Tables[4], "Branch_FName", "Branch_ID", true);
                Set_Combo(lookSub_Credit_S_ID, ds.Tables[5], "S_D", "S_ID", true);
            }
            //Fill_CType_ID();
            Fill_Main_ID();
            Fill_Group_ID();
            Fill_Detail_ID();
        }
        private void Set_Combo(LookUpEdit cmdToFill, DataTable dt_Source, string DisplayField, string ValueField, bool All)
        {
            DataTable dt_1 = new DataTable();
            if (dt_Source == null)
            {
                return;
            }

            dt_1 = dt_Source.Copy();

            if (DisplayField.Trim() == "" || ValueField.Trim() == "")
            {
                return;
            }
            cmdToFill.Properties.DataSource = null;

            cmdToFill.Properties.DisplayMember = DisplayField.Trim();
            cmdToFill.Properties.ValueMember = ValueField.Trim();

            if (All)
            {
                DataRow row = dt_1.NewRow();
                row[0] = "";
                row[1] = -1;
                dt_1.Rows.InsertAt(row, 0);
            }
            cmdToFill.Properties.DataSource = dt_1;
        }

        private void Fill_CType_ID()
        {
            //AC_Accounts clsAC_Accounts = new AC_Accounts();
            //DataSet ds = clsAC_Accounts.Fill_CType_ID(mSys_System.pComp_ID, mSys_System.pUser_ID);
            //if (clsAC_Accounts.sErrorCode != "")
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, clsAC_Accounts.sErrorCode, false);
            //    return;
            //}
            //lookMain_CType_ID.Properties.DataSource = null;

        }
        private void Fill_Main_ID()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Fill_Main_ID(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                Set_Combo(lookMain_ID, ds.Tables[0], "Main_CodeDD", "Main_ID", true);
            }

        }
        private void Fill_Group_ID()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Fill_Group_ID(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                Set_Combo(lookGroup_ID, ds.Tables[0], "Group_CodeD", "Group_ID", true);
            }

        }
        private void Fill_Detail_ID()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Fill_Detail(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                Set_Combo(lookDetail_ID, ds.Tables[0], "Detail_CodeD", "Detail_ID", true);
            }

        }

        private bool Save_Validate_0(int IsUpdate)
        {
            if(IsUpdate == 1)
            {
                if(lblCType_ID.Text.Trim() == "")
                {
                    clsHomeScreen.Display_Message("Please Select a Category to Update",false);
                    return false;
                }
            }
            if (txtCType_D.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Category Code", false);
                txtCType_D.Focus();
                return false;
            }
            if (txtCType_DD.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Category Description", false);
                txtCType_DD.Focus();
                return false;
            }
            return true;
        }
        private bool Save_Validate_1(int IsUpdate)
        {
            if (IsUpdate == 1)
            {
                if (lblMain_ID.Text.Trim() == "")
                {
                    clsHomeScreen.Display_Message("Please Select an Account to Update", false);
                    return false;
                }
            }
            if (txtMain_Code.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Main Code", false);
                txtMain_Code.Focus();
                return false;
            }
            if (txtMain_CodeD.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Main Account Short Name", false);
                txtMain_CodeD.Focus();
                return false;
            }
            if (txtMain_CodeDD.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Main Account Description", false);
                txtMain_CodeDD.Focus();
                return false;
            }
            if (lookMain_AccType_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Account Type", false);
                lookMain_AccType_ID.Focus();
                return false;
            }
            //if (lookMain_CType_ID.EditValue == null)
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, "Please Select FS Group Account", false);
            //    lookMain_CType_ID.Focus();
            //    return false;
            //}
            return true;
        }
        private bool Save_Validate_2(int IsUpdate)
        {
            if (IsUpdate == 1)
            {
                if (lblGroup_ID.Text.Trim() == "")
                {
                    clsHomeScreen.Display_Message("Please Select an Account to Update", false);
                    return false;
                }
            }
            if (txtGroup_Code.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Group Code", false);
                txtGroup_Code.Focus();
                return false;
            }
            if (txtGroup_CodeD.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Group Account Description", false);
                txtGroup_CodeD.Focus();
                return false;
            }
            if (lookMain_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Main Account", false);
                lookMain_ID.Focus();
                return false;
            }
            return true;
        }
        private bool Save_Validate_3(int IsUpdate)
        {
            if (IsUpdate == 1)
            {
                if (lblDetail_ID.Text.Trim() == "")
                {
                    clsHomeScreen.Display_Message("Please Select an Account to Update", false);
                    return false;
                }
            }
            if (txtDetail_Code.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Detail Code", false);
                txtDetail_Code.Focus();
                return false;
            }
            if (txtDetail_CodeD.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Detail Account Description", false);
                txtDetail_CodeD.Focus();
                return false;
            }
            if (lookGroup_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Group Account", false);
                lookGroup_ID.Focus();
                return false;
            }
            if (lookDetail_AccType.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Account Type", false);
                lookDetail_AccType.Focus();
                return false;
            }
            if (lookDetail_CurrID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Account Currency", false);
                lookDetail_CurrID.Focus();
                return false;
            }
            return true;
        }
        private bool Validate_Detail_Location()
        {
            if (lookDetail_Location.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Location", false);
                lookDetail_Location.Focus();
                return false;
            }
            return true;
        }
        private bool Save_Validate_4(int IsUpdate)
        {
            if (IsUpdate == 1)
            {
                if (lblSub_ID.Text.Trim() == "")
                {
                    clsHomeScreen.Display_Message("Please Select an Account to Update", false);
                    return false;
                }
            }
            if (lookDetail_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Control Account", false);
                lookDetail_ID.Focus();
                return false;
            }
            //if (txtSub_Code.Text.Trim() == "")
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, "Please Enter Sub Code", false);
            //    txtSub_Code.Focus();
            //    return false;
            //}
            if (txtSub_CodeD.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Enter Sub Account Description", false);
                txtSub_CodeD.Focus();
                return false;
            }
            if (lookSub_AccType_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Account Type", false);
                lookSub_AccType_ID.Focus();
                return false;
            }
            //if (lookRegion_ID.EditValue == null)
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, "Please Select Region", false);
            //    lookRegion_ID.Focus();
            //    return false;
            //}
            //if (lookSub_SCat_ID.EditValue == null)
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, "Please Select Account Category", false);
            //    lookSub_SCat_ID.Focus();
            //    return false;
            //}

            //if (lookSub_GCat_ID.EditValue == null)
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, "Please Select Account Group", false);
            //    lookSub_GCat_ID.Focus();
            //    return false;
            //}
            if (lookSub_CurrID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Account Currency", false);
                lookSub_CurrID.Focus();
                return false;
            }
            //if(chkSub_GST.Checked)
            {
                if(txtSub_GST.Text.Trim() == "" || Convert.ToDouble(txtSub_GST.Text.Trim()) == 0D)
                {
                    clsHomeScreen.Display_Message("Please Enter Account GST", false);
                    txtSub_GST.Focus();
                    return false;
                }
            }
            //if (lookSub_Tax.EditValue == null)
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, "Please Select Account Tax Type", false);
            //    lookSub_Tax.Focus();
            //    return false;
            //}
            //if (txtSub_TaxRate.Text.Trim() == "" || Convert.ToDouble(txtSub_TaxRate.Text.Trim()) == 0D)
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, "Please Enter Tax Rate", false);
            //    txtSub_TaxRate.Focus();
            //    return false;
            //}
            //if (lookSub_SE.EditValue == null)
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, "Please Select Sales Person", false);
            //    lookSub_SE.Focus();
            //    return false;
            //}
            //if(!chkSub_Sale.Checked)
            //{
            //    clsGutil.Display_Message(ObjHomeScreen.barStaticItem1, "Please Specify Sales/Purchase of Account", false);
            //    chkSub_Sale.Focus();
            //    return false;
            //}
            if (chkSub_Sale.Checked)
            {
                if (rdb_Cash_Credit.EditValue == null)
                {
                    clsHomeScreen.Display_Message("Please Specify Cash/Credit of Account", false);
                    rdb_Cash_Credit.Focus();
                    return false;
                }
            }
            return true;
        }
        private bool Validate_Sub_Location()
        {
            if (lookSub_Location.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please Select Location", false);
                lookSub_Location.Focus();
                return false;
            }
            return true;
        }
        private void Save_FSGroup()
        {
            int IsUpdate = 0;
            if(lblCType_ID.Text != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate_0(IsUpdate))
            {
                return;
            }
            Save_Update_0(IsUpdate);
        }
        private void Save_Update_0(int IsUpdate)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;


            vRet_Val = clsAC_Accounts.Save_Update_0(lblCType_ID.Text.Trim(), txtCType_D.Text.Trim(), txtCType_DD.Text.Trim()
                                , mSys_System.pComp_ID, mSys_System.pUser_ID, mSys_System.pUserName, IsUpdate, strAuth_D, mSys_System.pFY_ID);

            if(clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if(vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("SAVE RECORDS SUCCESSFULY", true);
                Fill_Grid_0();
                return;
            }
        }
        private void Save_Main()
        {
            int IsUpdate = 0;
            if (lblMain_ID.Text != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate_1(IsUpdate))
            {
                return;
            }
            Save_Update_1(IsUpdate);
        }
        private void Save_Update_1(int IsUpdate)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;


            vRet_Val = clsAC_Accounts.Save_Update_1(lblMain_ID.Text.Trim(), txtMain_Code.Text.Trim(), txtMain_CodeD.Text.Trim(), txtMain_CodeDD.Text.Trim()
                                , Convert.ToInt32(lookMain_AccType_ID.EditValue), 
                                //Convert.ToInt32(lookMain_CType_ID.EditValue), 
                                mSys_System.pComp_ID,IsUpdate, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("SAVE RECORDS SUCCESSFULY", true);
                Fill_Grid_1();
                Fill_Main_ID();
                return;
            }
        }
        private void Save_Group()
        {
            int IsUpdate = 0;
            if (lblGroup_ID.Text != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate_2(IsUpdate))
            {
                return;
            }
            Save_Update_2(IsUpdate);
        }
        private void Save_Update_2(int IsUpdate)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;


            vRet_Val = clsAC_Accounts.Save_Update_2(lblGroup_ID.Text.Trim(), txtGroup_Code.Text.Trim(), txtGroup_CodeD.Text.Trim()
                                , Convert.ToInt32(lookMain_ID.EditValue), mSys_System.pComp_ID,chkGroup_NoDetail.Checked,
                                IsUpdate, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("SAVE RECORDS SUCCESSFULY", true);
                Fill_Grid_2();
                Fill_Group_ID();
                return;
            }
        }
        private void Save_Detail()
        {
            int IsUpdate = 0;
            if (lblDetail_ID.Text != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate_3(IsUpdate))
            {
                return;
            }
            Save_Update_3(IsUpdate);
        }
        private void Save_Update_3(int IsUpdate)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;


            vRet_Val = clsAC_Accounts.Save_Update_3(lblDetail_ID.Text.Trim(), txtDetail_Code.Text.Trim(), txtDetail_CodeD.Text.Trim()
                        , Convert.ToInt32(lookGroup_ID.EditValue), Convert.ToInt32(lookDetail_AccType.EditValue), lookDetail_CurrID.Text.Trim(),
                        chkDetail_FCY.Checked,chkDetail_Active.Checked,chkDetail_SubLedger.Checked,
                        //chkDetail_AC_1.Checked, chkDetail_AC_2.Checked,chkDetail_AC_3.Checked, chkDetail_AC_4.Checked, 
                        //chkDetail_AC_5.Checked, chkDetail_AC_6.Checked, chkDetail_AC_7.Checked, chkDetail_AC_8.Checked,chkDetail_AZ.Checked,
                        mSys_System.pComp_ID,Convert.ToInt32(lookDetail_Location.EditValue), IsUpdate, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("SAVE RECORDS SUCCESSFULY", true);
                Fill_Grid_3();
                Fill_Detail_ID();
                return;
            }
        }
        private void Save_Sub()
        {
            int IsUpdate = 0;
            if (lblSub_ID.Text != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate_4(IsUpdate))
            {
                return;
            }
            Save_Update_4(IsUpdate);
        }
        private void Save_Update_4(int IsUpdate)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;

            vRet_Val = clsAC_Accounts.Save_Update_4(lblSub_ID.Text.Trim(), txtSub_Code.Text.Trim(), txtSub_CodeD.Text.Trim()
                        ,chkSub_Active.Checked,mSys_System.pComp_ID,Convert.ToInt32(lookSub_Location.EditValue), Convert.ToInt32(lookDetail_ID.EditValue), 
                        Convert.ToInt32(lookSub_AccType_ID.EditValue), 
                        //Convert.ToInt32(lookRegion_ID.EditValue), Convert.ToInt32(lookSub_SCat_ID.EditValue),
                        //Convert.ToInt32(lookSub_GCat_ID.EditValue), 
                        lookSub_CurrID.Text.Trim(), 
                        //Convert.ToInt32(lookSub_SE.EditValue),
                        chkSub_FCY.Checked, 
                        //Convert.ToInt32(lookSub_Tax.EditValue),Convert.ToDouble(txtSub_TaxRate.Text.Trim()), 
                        txtSub_Address1.Text.Trim(),txtSub_Address2.Text.Trim(),txtSub_City.Text.Trim(),txtSub_State.Text.Trim(),txtSub_Country.Text.Trim()
                        ,txtSub_Zip.Text.Trim(),txtSub_Tel.Text.Trim(),
                        //txtSub_Tel2.Text.Trim(),
                        txtSub_Email.Text.Trim(),
                        //txtSub_Reference.Text.Trim(),
                        txtSub_ContactPerson.Text.Trim(),txtSub_ContactDesig.Text.Trim(),txtSub_ContactTel.Text.Trim(),
                        //txtSub_ContactTel2.Text.Trim(),
                        txtSub_GST.Text.Trim(),
                        txtSub_NTN.Text.Trim(),txtSub_CNIC.Text.Trim(),
                        //chkSub_NOU.Checked,
                        //chkSub_GST.Checked,
                        chkSub_Credit_Limit.Checked
                        ,mSys_System.pUserName, mSys_System.pUser_ID, IsUpdate, strAuth_D, mSys_System.pFY_ID);

            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("SAVE RECORDS SUCCESSFULY", true);
                Save_Update_Credit(IsUpdate);
                Fill_Grid_4();
                return;
            }
        }

        private void btn_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if(Tab_Main.SelectedPage == Tab_P1)
            //{
            //    Save_FSGroup();
            //}
            if (Tab_Main.SelectedPage == Tab_P2)
            {
                Save_Main();
            }
            if (Tab_Main.SelectedPage == Tab_P3)
            {
                Save_Group();
            }
            if (Tab_Main.SelectedPage == Tab_P4)
            {
                Save_Detail();
            }
            if (Tab_Main.SelectedPage == Tab_P5)
            {
                Save_Sub();
            }
        }
        private void Find_Record_0(int vID)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Find_Record(mSys_System.pComp_ID, mSys_System.pUser_ID, vID);
            if(clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if(ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                lblCType_ID.Text = dt.Rows[0]["CType_ID"].ToString();
                txtCType_D.Text = dt.Rows[0]["CType_D"].ToString();
                txtCType_DD.Text = dt.Rows[0]["CType_DD"].ToString();
            }
            txtCType_D.Focus();
        }
        private void Find_Record_1(int vID)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Find_Record_1(mSys_System.pComp_ID, mSys_System.pUser_ID, vID);
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                lblMain_ID.Text = dt.Rows[0]["Main_ID"].ToString();
                txtMain_Code.Text = dt.Rows[0]["Main_Code"].ToString();
                txtMain_CodeD.Text = dt.Rows[0]["Main_CodeD"].ToString();
                txtMain_CodeDD.Text = dt.Rows[0]["Main_CodeDD"].ToString();
                lookMain_AccType_ID.EditValue = dt.Rows[0]["AType_ID"];
                //lookMain_CType_ID.EditValue = dt.Rows[0]["CType_ID"];
            }
            txtMain_Code.Focus();
        }
        private void Find_Record_2(int vID)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Find_Record_2(mSys_System.pComp_ID, mSys_System.pUser_ID, vID);
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                lblGroup_ID.Text = dt.Rows[0]["Group_ID"].ToString();
                txtGroup_Code.Text = dt.Rows[0]["Group_Code"].ToString();
                txtGroup_CodeD.Text = dt.Rows[0]["Group_CodeD"].ToString();
                chkGroup_NoDetail.Checked = Convert.ToBoolean(dt.Rows[0]["Group_NoDetail"]);
                lookMain_ID.EditValue = dt.Rows[0]["Main_ID"];
            }
            txtGroup_Code.Focus();
        }
        private void Find_Record_3(int vID)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Find_Record_3(mSys_System.pComp_ID, mSys_System.pUser_ID, vID);
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                lblDetail_ID.Text = dt.Rows[0]["Detail_ID"].ToString();
                txtDetail_Code.Text = dt.Rows[0]["Detail_Code"].ToString();
                txtDetail_CodeD.Text = dt.Rows[0]["Detail_CodeD"].ToString();
                lookGroup_ID.EditValue = dt.Rows[0]["Group_ID"];
                lookDetail_AccType.EditValue = dt.Rows[0]["AccType_ID"];
                lookDetail_Location.EditValue = dt.Rows[0]["Branch_ID"];
                lookDetail_CurrID.Text = dt.Rows[0]["Detail_CurrID"].ToString();
                chkDetail_FCY.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_FCY"]);
                chkDetail_Active.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_Active"]);
                chkDetail_SubLedger.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_SubLedger"]);
                //chkDetail_AZ.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_AZ"]);
                //chkDetail_NOU.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_NOU"]);
                //chkDetail_AC_1.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_AC_1"]);
                //chkDetail_AC_2.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_AC_2"]);
                //chkDetail_AC_3.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_AC_3"]);
                //chkDetail_AC_4.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_AC_4"]);
                //chkDetail_AC_5.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_AC_5"]);
                //chkDetail_AC_6.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_AC_6"]);
                //chkDetail_AC_7.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_AC_7"]);
                //chkDetail_AC_8.Checked = Convert.ToBoolean(dt.Rows[0]["Detail_AC_8"]);
            }
            txtDetail_Code.Focus();
        }
        private void Find_Record_4(int vID)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Find_Record_4(mSys_System.pComp_ID, mSys_System.pUser_ID, vID);
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                lblSub_ID.Text = dt.Rows[0]["Sub_ID"].ToString();
                txtSub_Code.Text = dt.Rows[0]["Sub_Code"].ToString();
                txtSub_CodeD.Text = dt.Rows[0]["Sub_CodeD"].ToString();
                txtSub_GST.Text = dt.Rows[0]["Sub_GST"].ToString();
                txtSub_NTN.Text = dt.Rows[0]["Sub_NTN"].ToString();
                //txtSub_TaxRate.Text = dt.Rows[0]["Sub_TaxRate"].ToString();
                txtSub_Address1.Text = dt.Rows[0]["Sub_Address1"].ToString();
                txtSub_Address2.Text = dt.Rows[0]["Sub_Address2"].ToString();
                txtSub_City.Text = dt.Rows[0]["Sub_City"].ToString();
                txtSub_CNIC.Text = dt.Rows[0]["Sub_CNIC"].ToString();
                txtSub_Country.Text = dt.Rows[0]["Sub_Country"].ToString();
                txtSub_State.Text = dt.Rows[0]["Sub_Province"].ToString();
                txtSub_Tel.Text = dt.Rows[0]["Sub_Tel"].ToString();
                //txtSub_Tel2.Text = dt.Rows[0]["Sub_Tel2"].ToString();
                txtSub_Zip.Text = dt.Rows[0]["Sub_Zip"].ToString();
                txtSub_Email.Text = dt.Rows[0]["Sub_Email"].ToString();
                //txtSub_Reference.Text = dt.Rows[0]["Sub_Reference"].ToString();
                txtSub_ContactPerson.Text = dt.Rows[0]["Sub_Contact"].ToString();
                txtSub_ContactDesig.Text = dt.Rows[0]["Sub_ContactDesig"].ToString();
                txtSub_ContactTel.Text = dt.Rows[0]["Sub_ContactTel"].ToString();
                //txtSub_ContactTel2.Text = dt.Rows[0]["Sub_ContactTel2"].ToString();
                //txtSub_Contact_Ladnline.Text = dt.Rows[0]["Sub_Contact_Ladnline"].ToString();
                txtSub_Credit_Bal.Text = dt.Rows[0]["Sub_Credit_Bal"].ToString();
                dtpSub_Credit_U_SD.EditValue = dt.Rows[0]["Sub_Credit_U_SD"].ToString();
                txtSub_Credit_Days.Text = dt.Rows[0]["Sub_Credit_Days"].ToString();
                txtSub_Credit_Amt.Text = dt.Rows[0]["Sub_Credit_Amt"].ToString();

                lookDetail_ID.EditValue = dt.Rows[0]["Detail_ID"];
                lookSub_AccType_ID.EditValue = dt.Rows[0]["AccType_ID"];
                //lookRegion_ID.EditValue = dt.Rows[0]["Region_ID"];
                //lookSub_GCat_ID.EditValue = dt.Rows[0]["Sub_GCat_ID"];
                //lookSub_SCat_ID.EditValue = dt.Rows[0]["Sub_SCat_ID"];
                //lookSub_Tax.EditValue = dt.Rows[0]["Sub_Tax"];
                //lookSub_SE.EditValue = dt.Rows[0]["Sub_SE"];
                lookSub_CurrID.Text = dt.Rows[0]["Sub_CurrID"].ToString();
                //lookSub_Nationality.Text = dt.Rows[0]["Sub_Nationality"].ToString();
                lookSub_Credit_S_ID.EditValue = dt.Rows[0]["Sub_Credit_S_ID"];
                lookSub_Location.EditValue = dt.Rows[0]["Branch_ID"];

                chkSub_FCY.Checked = Convert.ToBoolean(dt.Rows[0]["Sub_FCY"]);
                chkSub_Active.Checked = Convert.ToBoolean(dt.Rows[0]["Sub_Active"]);
                chkSub_Credit_Limit.Checked = Convert.ToBoolean(dt.Rows[0]["Sub_Credit_Limit"]);
                //chkSub_GST.Checked = Convert.ToBoolean(dt.Rows[0]["Sub_GST"]);
                //chkSub_NOU.Checked = Convert.ToBoolean(dt.Rows[0]["Sub_NOU"]);
                //chkSub_Purchase.Checked = Convert.ToBoolean(dt.Rows[0]["Sub_Purchase"]);
                chkSub_Sale.Checked = Convert.ToBoolean(dt.Rows[0]["Sub_Sale"]);

                rdb_Cash_Credit.EditValue = Convert.ToBoolean(dt.Rows[0]["Sub_Credit"]);

                //imgSub_Image.Image = dt.Rows[0]["Sub_Sale"];
                //imgSub_Image.Image = dt.Rows[0]["Sub_Sale"];

            }
            txtSub_Code.Focus();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            object ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CType_ID");
            if(ID != null && ID.ToString() != "")
            {
                Find_Record_0(Convert.ToInt32(ID));
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            object ID = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Main_ID");
            if (ID != null && ID.ToString() != "")
            {
                Find_Record_1(Convert.ToInt32(ID));
            }
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            object ID = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Group_ID");
            if (ID != null && ID.ToString() != "")
            {
                Find_Record_2(Convert.ToInt32(ID));
            }
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            object ID = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Detail_ID");
            if (ID != null && ID.ToString() != "")
            {
                Find_Record_3(Convert.ToInt32(ID));
            }
        }

        private void gridView5_DoubleClick(object sender, EventArgs e)
        {
            object ID = gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "Sub_ID");
            if (ID != null && ID.ToString() != "")
            {
                Find_Record_4(Convert.ToInt32(ID));
            }
        }
        private void Fill_Grid_0()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Fill_Grid(mSys_System.pComp_ID, mSys_System.pUser_ID, "");
            if(clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if(ds.Tables.Count > 0)
            {
                gridControl1.DataSource = ds.Tables[0];
            }
        }
        private void Fill_Grid_1()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Fill_Grid_1(mSys_System.pComp_ID, mSys_System.pUser_ID, "");
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                gridControl2.DataSource = ds.Tables[0];
            }
        }
        private void Fill_Grid_2()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Fill_Grid_2(mSys_System.pComp_ID, mSys_System.pUser_ID, "");
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                gridControl3.DataSource = ds.Tables[0];
            }
        }
        private void Fill_Grid_3()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Fill_Grid_3(mSys_System.pComp_ID, mSys_System.pUser_ID, "");
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                gridControl4.DataSource = ds.Tables[0];
            }
        }
        private void Fill_Grid_4()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            DataSet ds = clsAC_Accounts.Fill_Grid_4(mSys_System.pComp_ID, mSys_System.pUser_ID, "");
            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                gridControl5.DataSource = ds.Tables[0];
            }
        }
        private void Save_Delete_0()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;

            if(lblCType_ID.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Select a Category to Delete",false);
                return;
            }
            vRet_Val = clsAC_Accounts.Save_Delete_0(Convert.ToInt32(lblCType_ID.Text.Trim()), txtSub_Code.Text.Trim(), mSys_System.pComp_ID
                        , mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("RECORD DELETED SUCCESSFULY", true);
                Fill_Grid_0();
                return;
            }
        }
        private void Save_Delete_1()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;

            if (lblMain_ID.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Select a Main Account to Delete", false);
                return;
            }
            vRet_Val = clsAC_Accounts.Save_Delete_1(Convert.ToInt32(lblMain_ID.Text.Trim()), txtSub_Code.Text.Trim(), mSys_System.pComp_ID
                        , mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("RECORD DELETED SUCCESSFULY", true);
                Fill_Grid_1();
                Fill_Main_ID();
                return;
            }
        }
        private void Save_Delete_2()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;

            if (lblGroup_ID.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Select a Group Account to Delete", false);
                return;
            }
            vRet_Val = clsAC_Accounts.Save_Delete_2(Convert.ToInt32(lblGroup_ID.Text.Trim()), txtSub_Code.Text.Trim(), mSys_System.pComp_ID
                        , mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("RECORD DELETED SUCCESSFULY", true);
                Fill_Grid_2();
                Fill_Group_ID();
                return;
            }
        }
        private void Save_Delete_3()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;

            if (lblDetail_ID.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Select a Nominal Account to Delete", false);
                return;
            }
            vRet_Val = clsAC_Accounts.Save_Delete_3(Convert.ToInt32(lblDetail_ID.Text.Trim()), txtDetail_Code.Text.Trim(), mSys_System.pComp_ID
                        , mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("RECORD DELETED SUCCESSFULY", true);
                Fill_Grid_3();
                Fill_Detail_ID();
                return;
            }
        }
        private void Save_Delete_4()
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int vRet_Val = 0;

            if (lblSub_ID.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please Select a Party Account to Delete", false);
                return;
            }
            vRet_Val = clsAC_Accounts.Save_Delete_4(Convert.ToInt32(lblSub_ID.Text.Trim()), txtSub_Code.Text.Trim(), mSys_System.pComp_ID
                        , mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsAC_Accounts.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message("ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message("RECORD DELETED SUCCESSFULY", true);
                Fill_Grid_4();
                return;
            }
        }

        private void btn_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Tab_Main.SelectedPage == Tab_P1)
            {
                Save_Delete_0();
            }
            if (Tab_Main.SelectedPage == Tab_P2)
            {
                Save_Delete_1();
            }
            if (Tab_Main.SelectedPage == Tab_P3)
            {
                Save_Delete_2();
            }
            if (Tab_Main.SelectedPage == Tab_P4)
            {
                Save_Delete_3();
            }
            if (Tab_Main.SelectedPage == Tab_P5)
            {
                Save_Delete_4();
            }
        }
        
        private void chkSub_Credit_Limit_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSub_Credit_Limit.Checked)
            {
                txtSub_Credit_Amt.ReadOnly = false;
            }
            else
            {
                txtSub_Credit_Amt.ReadOnly = true;
            }
        }

        private void btn_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(Tab_Main.SelectedPage == Tab_P1)
            {
                Set_Refresh_0();
            }
            if (Tab_Main.SelectedPage == Tab_P2)
            {
                Set_Refresh_1();
            }
            if (Tab_Main.SelectedPage == Tab_P3)
            {
                Set_Refresh_2();
            }
            if (Tab_Main.SelectedPage == Tab_P4)
            {
                Set_Refresh_3();
            }
            if (Tab_Main.SelectedPage == Tab_P5)
            {
                Set_Refresh_4();
            }
        }

        private void frmAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void btnCredit_Save_Click(object sender, EventArgs e)
        {
            if (!(Save_Validate_Credit()))
            {
                return;
            }

            Save_Update_Credit(0);
            
        }

        private void Save_Update_Credit(int IsUpdate)
        {
            AC_Accounts clsAC_Accounts = new AC_Accounts();
            int nRet_Val = 0;
            int Item_Pstock = 0;


            //if (IsUpdate == 0)
            //{
            //    strEvent = "Save";
            //    strAuth_D = mSys_Acc.pcU_M_02_C07_S1;
            //}
            //else if (IsUpdate == 1)
            //{
            //    strEvent = "Update";
            //    strAuth_D = mSys_Acc.pcU_M_02_C07_S1;
            //}


            //if (IsUpdate == 0)
            //{
            //    //---alert
            //    if (MessageBox.Show(cnMsg_BeforeSave_Cat, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        return false;
            //    }
            //    //---update
            //}
            //else if (IsUpdate == 1)
            //{
            //    //---alert
            //    if (MessageBox.Show(cnMsg_BeforeUpdate, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}


            int nSub_Credit_S_ID = -1;

            if (lookSub_Credit_S_ID.EditValue != null && lookSub_Credit_S_ID.EditValue.ToString() != "") nSub_Credit_S_ID = Convert.ToInt32(lookSub_Credit_S_ID.EditValue);

            double vSub_Credit_Bal = 0;
            //if (txtSub_Credit_Bal.Text.Trim() != "")
            //{
            //    vSub_Credit_Bal = Convert.ToDouble(txtSub_Credit_Bal.Text.Trim());
            //}

            nRet_Val = clsAC_Accounts.Save_Update_Credit(lblSub_ID.Text, nSub_Credit_S_ID, dtpSub_Credit_U_SD.EditValue, chkSub_Credit_Limit.Checked,
                Convert.ToDouble(txtSub_Credit_Amt.Text.Trim()), vSub_Credit_Bal,
                Convert.ToInt32(txtSub_Credit_Days.Text.Trim()),
                //Convert.ToInt32( txtSub_Credit_Bal.Text.Trim()),lblSub_Credit_U_Name.Text.Trim(),*/ 
                 mSys_System.pUserName, mSys_System.pUser_ID,
               IsUpdate, strAuth_D, mSys_System.pFY_ID, mSys_System.pFYSDate, mSys_System.pComp_ID
               );

            if (IsUpdate == 0 || IsUpdate == 1)
            {
                if (nRet_Val == 1)
                {
                    clsHomeScreen.Display_Message("Your Request has been processed Successfully ....................", true);
                }
                else if (nRet_Val == -1)
                {
                    clsHomeScreen.Display_Message(clsAC_Accounts.sErr_Msg, false);
                    return;
                }
            }
        }

        private bool Save_Validate_Credit()
        {
            if (lblSub_ID.Text == "")
            {
                MessageBox.Show("Please select a record......................", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (lookSub_Credit_S_ID.Text == "")
            {
                MessageBox.Show("Please select Status......................", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lookSub_Credit_S_ID.Focus();
                return false;
            }

            if (dtpSub_Credit_U_SD.EditValue == null)
            {
                MessageBox.Show("Please Enter Credit Date......................", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpSub_Credit_U_SD.Focus();
                return false;
            }
            return true;
        }

        private void btnRefresh_Balance_Click(object sender, EventArgs e)
        {

        }

    }
}