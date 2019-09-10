using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using ERP.BLL;
using ERP.BLL.SYS;

namespace ERP.Accounts
{
    public partial class Acc_OB : RibbonForm
    {
        HomeScreen clsHomeScreen;
        private HomeScreen ObjHomeScreen;
        string strAuth = "";
        public Acc_OB()
        {
            InitializeComponent();
            ObjHomeScreen = new HomeScreen();
            Set_Refresh();
            Fill_Combo();
        }

        private void Acc_OB_Load(object sender, EventArgs e)
        {
            clsHomeScreen = (HomeScreen)this.MdiParent;
        }
        private void Set_Refresh()
        {
            lblOB_ID.Text = "";
            txtOB_Dr.Text = "0";
            txtOB_Cr.Text = "0";
            txtOB_Ref1.Text = "";
            lookBranch_ID.EditValue = null;
            lookBranch_ID.Text = "";
            lookAccounts.EditValue = null;
            lookAccounts.Text = "";

            chkSub_Ledger.Checked = false;
        }
        private void Fill_Combo()
        {
            AC_OB clsAC_OB = new AC_OB();
            
            DataSet ds = clsAC_OB.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if(clsAC_OB.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsAC_OB.sErrorCode, false);
                return;
            }
            Set_Combo(lookBranch_ID, ds.Tables[0], "Branch_FName", "Branch_ID", true);
            
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
        private void Fill_Account()
        {
            AC_OB clsAC_OB = new AC_OB();
            int vBranch_ID = -1;
            if (lookBranch_ID.EditValue != null)
            {
                vBranch_ID = Convert.ToInt32(lookBranch_ID.EditValue);
            }
            DataSet ds = clsAC_OB.Fill_Account(mSys_System.pComp_ID, vBranch_ID,mSys_System.pUser_ID, chkSub_Ledger.Checked);
            if (clsAC_OB.sErrorCode != "")
            {
                clsHomeScreen.Display_Message( clsAC_OB.sErrorCode, false);
                return;
            }
            Set_Combo(lookAccounts, ds.Tables[0], "Acc_Name", "Acc_ID", true);

        }
        private void chkSub_Acc_CheckedChanged(object sender, EventArgs e)
        {
            Fill_Account();
            Fill_Grid();
        }
        private void Fill_Grid()
        {
            AC_OB clsAC_OB = new AC_OB();
            DataSet ds = clsAC_OB.Fill_Grid(mSys_System.pComp_ID, mSys_System.pUser_ID, "",chkSub_Ledger.Checked);
            if (clsAC_OB.sErrorCode != "")
            {
                clsHomeScreen.Display_Message( clsAC_OB.sErrorCode, false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                gridControl1.DataSource = ds.Tables[0];
            }
        }
        private void Find_Record(int vID)
        {
            AC_OB clsAC_OB = new AC_OB();
            DataSet ds = clsAC_OB.Find_Record(mSys_System.pComp_ID, mSys_System.pUser_ID, vID);
            if (clsAC_OB.sErrorCode != "")
            {
                clsHomeScreen.Display_Message( clsAC_OB.sErrorCode, false);
                return;
            }
            if(ds.Tables.Count > 0)
            {
                lblOB_ID.Text = vID.ToString();
                chkSub_Ledger.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSub_Acc"]);
                lookAccounts.EditValue = ds.Tables[0].Rows[0]["Acc_ID"];
                lookBranch_ID.EditValue = ds.Tables[0].Rows[0]["Branch_ID"];
                txtOB_Dr.Text = ds.Tables[0].Rows[0]["OB_Dr"].ToString();
                txtOB_Cr.Text = ds.Tables[0].Rows[0]["OB_Cr"].ToString();
                txtOB_Ref1.Text = ds.Tables[0].Rows[0]["OB_Ref1"].ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            object ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Acc_ID");
            if(ID != null && ID.ToString() != "")
            {
                Find_Record(Convert.ToInt32(ID));
            }
        }
        private bool Save_Validate(int IsUpdate)
        {
            if(IsUpdate == 1)
            {
                if(lblOB_ID.Text.Trim() == "")
                {
                    clsHomeScreen.Display_Message("Please Select a record to update.",false);
                    lookAccounts.Focus();
                    return false;
                }
            }
            
            if (lookAccounts.EditValue == null)
            {
                clsHomeScreen.Display_Message( "Please Select Account", false);
                lookAccounts.Focus();
                return false;
            }
            if (lookBranch_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message( "Please Select Branch", false);
                lookBranch_ID.Focus();
                return false;
            }
            if (txtOB_Dr.Text.Trim() == "" && txtOB_Cr.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message( "Please Enter Dr/Cr Value", false);
                txtOB_Dr.Focus();
                return false;
            }
            if (Convert.ToDouble(txtOB_Dr.Text.Trim()) <= 0D && Convert.ToDouble(txtOB_Cr.Text.Trim()) <= 0D)
            {
                clsHomeScreen.Display_Message( "Please Enter Dr/Cr Value. It must be greater than 0", false);
                txtOB_Dr.Focus();
                return false;
            }

            return true;
        }

        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int Isupdate = 0;
            if(lblOB_ID.Text.Trim() != "")
            {
                Isupdate = 1;
            }
            if(!Save_Validate(Isupdate))
            {
                return;
            }
            Save_Update(Isupdate);
        }

        private void Save_Update(int isupdate)
        {
            AC_OB clsAC_OB = new AC_OB();
            int vRet_Val = 0;

            int vDetail_ID = 0;
            string vSub_ID = "";

            if(chkSub_Ledger.Checked)
            {
                vDetail_ID = Convert.ToInt32(lookAccounts.EditValue.ToString().Split('|')[0]);
                vSub_ID = lookAccounts.EditValue.ToString().Split('|')[1];
            }
            else
            {
                vDetail_ID = Convert.ToInt32(lookAccounts.EditValue);
            }
            vRet_Val = clsAC_OB.Save_Update(vDetail_ID,vSub_ID, Convert.ToDouble(txtOB_Dr.Text.Trim()),
                        Convert.ToDouble(txtOB_Cr.Text.Trim()),chkSub_Ledger.Checked,
                        mSys_System.pComp_ID, Convert.ToInt32(lookBranch_ID.EditValue),
                        mSys_System.pUser_ID,  mSys_System.pUserName, isupdate
                        ,mSys_System.pFYSDate,mSys_System.pFYEDate, strAuth, mSys_System.pFY_ID);

            if (clsAC_OB.sErrorCode != "")
            {
                clsHomeScreen.Display_Message( clsAC_OB.sErrorCode, false);
                return;
            }
            if (vRet_Val == -1)
            {
                clsHomeScreen.Display_Message( clsAC_OB.sErr_Msg, false);
                return;
            }
            if (vRet_Val == 0)
            {
                clsHomeScreen.Display_Message( "ERROR", false);
                return;
            }
            if (vRet_Val == 1)
            {
                clsHomeScreen.Display_Message( "SAVE RECORDS SUCCESSFULY", true);
                Fill_Grid();
                return;
            }
        }

        private void btn_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Set_Refresh();
        }

    }
}