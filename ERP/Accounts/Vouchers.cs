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
using ERP.DAL;
using ERP.BLL.AC;
using DevExpress.XtraGrid.Views.Grid;
using ERP.BLL.SYS;

namespace ERP.Accounts
{
    public partial class Vouchers : RibbonForm
    {
        private string strAuth_D = "";
        HomeScreen clsHomeScreen;
        public Vouchers()
        {
            InitializeComponent();
            Set_Refresh();
            Fill_Combo();
            Fill_Grid();
        }

        private void Vouchers_Load(object sender, EventArgs e)
        {
            clsHomeScreen = (HomeScreen)this.MdiParent;
        }
        private void Set_Refresh()
        {
            lblAcc_SqNo.Text = "";
            lblTrLevel.Text = "";
            txtTr_No.Text = "";
            txtCheck_No.Text = "";
            txtNarration.Text = "";
            txtRef1.Text = "";

            lookAcc.EditValue = null;
            lookAcc.Text = "";
            lookVrType.EditValue = null;
            lookVrType.Text = "";

            dtpTr_Date.EditValue = null;
            dtpCheck_Date.EditValue = null;

            Set_TrLevel();
            Set_DataSource();
            gridView1.AddNewRow();
            
        }
        private void Set_Refresh_1()
        {
            lookBranch_Search.EditValue = null;
            lookBranch_Search.Text = "";
            lookTrLevel.EditValue = null;
            lookTrLevel.Text = "";

            lookVrType_Serch.EditValue = null;
            lookVrType_Serch.Text = "";

            dtpBegDate.EditValue = DateTime.Now;
            dtpEndDate.EditValue = DateTime.Now;

            txtSearch.Text = "";
        }
        private void Button_Setting()
        {
            if(Tab_Main.SelectedTabPage == Tab_P1)
            {
                btn_New.Enabled = true;
                btn_Save.Enabled = true;
                btn_Clear.Enabled = true;
                btn_Cancel.Enabled = true;
                btn_Rollback.Enabled = true;
                btn_Print.Enabled = true;
                btn_AckPrint.Enabled = true;

                btnSearch.Enabled = false;
                Set_TrLevel();

            }
            if (Tab_Main.SelectedTabPage == Tab_P2)
            {
                btn_New.Enabled = false;
                btn_Save.Enabled = false;
                btn_Clear.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_Rollback.Enabled = false;
                btn_Print.Enabled = false;
                btn_AckPrint.Enabled = false;

                btnSearch.Enabled = true;

            }
        }
        private void Fill_Combo()
        {
            database1 clsdatabase1 = new database1();
            ACVoucher clsACVoucher = new ACVoucher();
            DataSet ds = new DataSet();
            ds = clsACVoucher.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsACVoucher.strErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                lookVrType.Properties.DataSource = ds.Tables[0];
                lookVrType.Properties.DisplayMember = "VrTypeDD";
                lookVrType.Properties.ValueMember = "VrType";

                lookVrType_Serch.Properties.DataSource = ds.Tables[0];
                lookVrType_Serch.Properties.DisplayMember = "VrTypeDD";
                lookVrType_Serch.Properties.ValueMember = "VrType";

                lookBranch_ID.Properties.DataSource = ds.Tables[1];
                lookBranch_ID.Properties.DisplayMember = "Branch_FName";
                lookBranch_ID.Properties.ValueMember = "Branch_ID";

                lookBranch_Search.Properties.DataSource = ds.Tables[1];
                lookBranch_Search.Properties.DisplayMember = "Branch_FName";
                lookBranch_Search.Properties.ValueMember = "Branch_ID";

                lookTrLevel.Properties.DataSource = ds.Tables[2];
                lookTrLevel.Properties.DisplayMember = "TrLevelD";
                lookTrLevel.Properties.ValueMember = "TrLevel";
                //Set_Combo(lookVrType, ds.Tables[0], "VrTypeDD,", "VrType", true);
                //Set_Combo(lookVrType_Serch, ds.Tables[0], "VrTypeDD,", "VrType", true);
                //Set_Combo(lookBranch_ID, ds.Tables[1], "Branch_FName,", "Branch_ID", true);
                //Set_Combo(lookBranch_Search, ds.Tables[1], "Branch_FName,", "Branch_ID", true);
                //Set_Combo(lookTrLevel, ds.Tables[1], "TrLevelD,", "TrLevel", true);
            }
        }
        private void Fill_Accounts()
        {
            database1 clsdatabase1 = new database1();
            ACVoucher clsACVoucher = new ACVoucher();
            DataSet ds = new DataSet();
            int VrType = -1;
            int Branch = mSys_System.pBranch_ID;
            if (lookVrType.EditValue != null)
            {
                VrType = Convert.ToInt32(lookVrType.EditValue);
            }
            if (lookBranch_ID.EditValue != null)
            {
                Branch = Convert.ToInt32(lookBranch_ID.EditValue);
            }
            ds = clsACVoucher.Fill_Accounts(mSys_System.pComp_ID, Branch, mSys_System.pUser_ID, VrType);
            if (clsACVoucher.strErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                lookAcc.Properties.DataSource = ds.Tables[0];
                lookAcc.Properties.DisplayMember = "Acc_Name";
                lookAcc.Properties.ValueMember = "Acc_ID";

                //Set_Combo(lookAcc, ds.Tables[0], "Acc_Name,", "Acc_ID", true);
            }
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

        private void Set_TrLevel()
        {
            if(lblTrLevel.Text.Trim() == mSys_System.pTrLevel_Cleared.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cleared_D;
                lblTrLevelD.Appearance.Image = imageCollection1.Images["Cleared.png"];
                lblTrLevelD.Appearance.ForeColor = Color.Green;

                btn_Save.Enabled = false;
                btn_Clear.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_Rollback.Enabled = true;
                btn_Print.Enabled = true;
                btn_AckPrint.Enabled = true;

            }
            if (lblTrLevel.Text.Trim() == mSys_System.pTrLevel_Cancelled.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cancelled_D;
                lblTrLevelD.Appearance.Image = imageCollection1.Images["Cancel.png"];
                lblTrLevelD.Appearance.ForeColor = Color.Red;

                btn_Save.Enabled = false;
                btn_Clear.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_Rollback.Enabled = false;
                btn_Print.Enabled = true;
                btn_AckPrint.Enabled = true;

            }
            if (lblTrLevel.Text.Trim() == mSys_System.pTrLevel_Pending.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Pending_D;
                lblTrLevelD.Appearance.Image = imageCollection1.Images["Pending.png"];
                lblTrLevelD.Appearance.ForeColor = Color.Black;

                btn_Save.Enabled = true;
                btn_Clear.Enabled = true;
                btn_Cancel.Enabled = true;
                btn_Rollback.Enabled = false;
                btn_Print.Enabled = true;
                btn_AckPrint.Enabled = true;

            }
            if (lblTrLevel.Text.Trim() == "")
            {
                lblTrLevelD.Text = "";
                lblTrLevelD.Appearance.Image = null;

                btn_Save.Enabled = true;
                btn_Clear.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_Rollback.Enabled = false;
                btn_Print.Enabled = false;
                btn_AckPrint.Enabled = false;

            }

        }
        private bool Save_Validate(int IsUpdate)
        {
            string Vr = "";
            Vr = lookVrType.Text.Split('|')[0];
            if (IsUpdate == 1)
            {
                if (lblAcc_SqNo.Text == "")
                {
                    clsHomeScreen.Display_Message("Please select a record to update", false);
                    txtTr_No.Focus();
                    return false;
                }
            }
            if (dtpTr_Date.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please select Transaction date", false);
                dtpTr_Date.Focus();
                return false;
            }
            if (lookVrType.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please select Voucher Type", false);
                lookVrType.Focus();
                return false;
            }
            if (Vr != "JV")
            {
                if (lookAcc.EditValue == null)
                {
                    clsHomeScreen.Display_Message("Please select Account", false);
                    lookAcc.Focus();
                    return false;
                }
                Vr = lookVrType.Text.Split('|')[0];
                if (Vr == "BR" || Vr == "BP")
                {
                    if (txtCheck_No.Text == "")
                    {
                        clsHomeScreen.Display_Message("Please enter Cheque No......", false);
                        txtCheck_No.Focus();
                        return false;
                    }
                    if (dtpCheck_Date.EditValue == null)
                    {
                        clsHomeScreen.Display_Message("Please Select Cheque Date......", false);
                        dtpCheck_Date.Focus();
                        return false;
                    }
                }
                if (Vr == "BP" && txtRef1.Text == "")
                {
                    clsHomeScreen.Display_Message("Please enter Payment Reference......................", false);
                    txtRef1.Focus();
                    return false;
                }
                if (txtNarration.Text == "")
                {
                    clsHomeScreen.Display_Message("Please enter Narration......................", false);
                    txtNarration.Focus();
                    return false;
                }
            }
            if(gridView1.DataRowCount == 0)
            {
                clsHomeScreen.Display_Message("Please enter atleast one Debit and Credit Entry in the Grid......................", false);
                gridView1.Focus();
                return false;
            }
            bool chk = false;
            int I = new int();
            int J = 0;
            for (I = 0; I < gridView1.DataRowCount; I++)
            {
                if (gridView1.GetRowCellValue(I, "Detail_ID") != null && gridView1.GetRowCellValue(I, "Detail_ID").ToString() != "")
                {

                    if (gridView1.GetRowCellValue(I, "Narration") == null || gridView1.GetRowCellValue(I, "Narration").ToString() == "")
                    {
                        clsHomeScreen.Display_Message("Please enter Narration in row no: " + (I+1) + "......................", false);
                        return false;
                    }

                    if (gridView1.GetRowCellValue(I, "Dr") == null || gridView1.GetRowCellValue(I, "Dr").ToString() == "")
                    {
                        clsHomeScreen.Display_Message("Please enter Dr in row no: " + I + ".....................", false);
                        return false;
                    }
                    if (gridView1.GetRowCellValue(I, "Cr") == null || gridView1.GetRowCellValue(I, "Cr").ToString() == "")
                    {
                        clsHomeScreen.Display_Message("Please enter Cr in row no: " + I + ".....................", false);
                        return false;
                    }
                    if (Convert.ToDouble(gridView1.GetRowCellValue(I, "Cr")) == 0D && Convert.ToDouble(gridView1.GetRowCellValue(I, "Dr")) == 0D)
                    {
                        clsHomeScreen.Display_Message("Please enter Dr/Cr in row no: " + I + ".....................", false);
                        return false;
                    }
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(I, "IsControl")) && (gridView1.GetRowCellValue(I, "Sub_ID") == null || gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Sub_ID").ToString() == ""))
                    {
                        clsHomeScreen.Display_Message(gridView1.GetRowCellValue(I, "Detail_CodeD") + " is a Control Account but Sub A/C not Selected. The system can not process your request, please check....................", false);
                        return false;
                    }
                    //---detail code

                    if (Vr == "BR" || Vr == "CR")
                    {
                        if (gridView1.GetRowCellValue(I, "Detail_ID").ToString() == lookAcc.EditValue.ToString())
                        {
                            if (Convert.ToDouble(gridView1.GetRowCellValue(I, "Dr")) != 0 && Convert.ToDouble(gridView1.GetRowCellValue(I, "Cr")) == 0)
                            {
                                chk = true;
                            }
                        }
                    }
                    else if (Vr == "BP" || Vr == "CP")
                    {
                        if (gridView1.GetRowCellValue(I, "Detail_ID").ToString() == lookAcc.EditValue.ToString())
                        {
                            if (Convert.ToDouble(gridView1.GetRowCellValue(I, "Dr")) == 0 && Convert.ToDouble(gridView1.GetRowCellValue(I, "Cr")) != 0)
                            {
                                chk = true;
                            }
                        }
                    }
                    else
                        chk = true;
                }
            }
            if (gridView1.DataRowCount == (J + 1))
            {
                I = I + 1;
            }
            if (!chk)
            {
                if (Vr == "BR" || Vr == "CR")
                {
                    clsHomeScreen.Display_Message("Account " + lookAcc.Text.Trim() + " must be Dr once in List Please Check ......................", false);
                }
                if (Vr == "BP" || Vr == "CP")
                {
                    clsHomeScreen.Display_Message("Account " + lookAcc.Text.Trim() + " must be Cr once in List Please Check ......................", false);
                }
                return false;
            }
            string Dr = gridView1.Columns["Dr"].SummaryItem.SummaryValue.ToString();
            string Cr = gridView1.Columns["Cr"].SummaryItem.SummaryValue.ToString();
            if (Dr != Cr)
            {
                clsHomeScreen.Display_Message("Dr/Cr must be equal in amount. The system cannot process unbalanced voucher. Please try again ......................", false);
                gridView1.Focus();
                return false;
            }
            return true;
        }
        private DataTable Set_Grid()
        {
            DataTable dt_1 = new DataTable("tbl");

            dt_1.Columns.Add("Detail_ID", typeof(int)).DefaultValue = 0;
            dt_1.Columns.Add("Sub_ID", typeof(int)).DefaultValue = 0;
            dt_1.Columns.Add("Detail_Code", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("Sub_Code", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("Acc_Name", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("Narration", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("Dr", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Cr", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Detail_SubLedger", typeof(bool)).DefaultValue = false;
            dt_1.Columns.Add("FCY", typeof(bool)).DefaultValue = false;
            return dt_1;
        }
        private void Set_DataSource()
        {
            gridControl1.DataSource = Set_Grid();
            Load_Accounts();
        }
        private void Load_Accounts()
        {
            ACVoucher clsACVoucher = new ACVoucher();
            int Branch = mSys_System.pBranch_ID;
            if (lookBranch_ID.EditValue != null)
            {
                Branch = Convert.ToInt32(lookBranch_ID.EditValue);
            }
            DataSet ds = clsACVoucher.Load_Accounts(mSys_System.pComp_ID, Branch, mSys_System.pUser_ID);
            if (clsACVoucher.strErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsACVoucher.strErrorCode + "'", false);
                return;
            }
            DataTable dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row["Acc_Name"] = string.Empty;
            dt.Rows.InsertAt(row, 0);
            repositoryItemGridLookUpEdit1.DataSource = dt;
            repositoryItemGridLookUpEdit1.ValueMember = "Acc_Name";
            repositoryItemGridLookUpEdit1.DisplayMember = "Acc_Name";
            gridView1.Columns["Acc_Name"].ColumnEdit = repositoryItemGridLookUpEdit1;
        }
        private void Save_Update(int IsUpdate)
        {
            ACVoucher clsACVoucher = new ACVoucher();
            bool bln_Tr = false;
            bln_Tr = true;
            int nRet_Val = 0;
            //---save
            if (IsUpdate == 0)
            {
                //strAuth_D = mSys_Acc.pcU_M_02_C21_S;
                //---alert
                //if (MessageBox.Show(cnMsg_BeforeSave, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return false;
                //}

            }
            if (IsUpdate == 1)
            {
                //strAuth_D = mSys_Acc.pcU_M_02_C21_U;
                ////---alert
                //if (MessageBox.Show(cnMsg_BeforeUpdate, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return false;
                //}

            }
            DataTable dt_1 = Set_Grid();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row = dt_1.NewRow();
                if (gridView1.GetRowCellValue(i, "Detail_ID") != null)
                {
                    if (gridView1.GetRowCellValue(i, "Detail_ID").ToString() != "")
                    {
                        row["Detail_ID"] = gridView1.GetRowCellValue(i, "Detail_ID");
                        row["Sub_ID"] = gridView1.GetRowCellValue(i, "Sub_ID");
                        row["Narration"] = gridView1.GetRowCellValue(i, "Narration");
                        row["Dr"] = gridView1.GetRowCellValue(i, "Dr");
                        row["Cr"] = gridView1.GetRowCellValue(i, "Cr");
                        dt_1.Rows.Add(row);
                    }
                }
            }
            List<DataRow> List_Detail = new List<DataRow>(dt_1.Select());
            double nAmt_Total = Convert.ToDouble(gridView1.Columns["Dr"].SummaryItem.SummaryValue);

            int nVrType = -1;
            int nBranch_ID = mSys_System.pUser_Branch_ID;
            //if (cmbBranch_ID.SelectedValue != null && cmbBranch_ID.SelectedValue.ToString() != "") nBranch_ID = Convert.ToInt32(cmbBranch_ID.SelectedValue.ToString());
            if (lookVrType.EditValue != null) nVrType = Convert.ToInt32(lookVrType.EditValue);
            int nBank_ID = 0;
            if (lookAcc.EditValue != null)
            {
                nBank_ID = Convert.ToInt32(lookAcc.EditValue);
            }

            nRet_Val = clsACVoucher.Save_Update(lblAcc_SqNo.Text.Trim(), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pComp_ID, nVrType,
                nBank_ID, txtCheck_No.Text.Trim(), dtpCheck_Date.EditValue, mSys_System.pBranch_ID, nAmt_Total, txtNarration.Text.Trim(), txtRef1.Text.Trim(),
                List_Detail, mSys_System.pUserName, mSys_System.pUser_ID, IsUpdate,
                strAuth_D,
                 mSys_System.pFY_ID);


            if (clsACVoucher.strErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsACVoucher.strErrorCode, false);
                return;
            }

            if (nRet_Val == 1)
            {
                if (IsUpdate == 0)
                {
                    txtTr_No.Text = clsACVoucher.Vr_No;
                    lblAcc_SqNo.Text = clsACVoucher.Tr_SqNo.ToString();
                    //lblU_S.Text = mSys_System.pUserName;
                    //lblPDate.Text = clsACVoucher.strPDate.ToString();

                }
                lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();
                lookVrType.Enabled = false;
                Fill_Grid();
                Set_TrLevel();
                //MessageBox.Show(cnMsg_SaveUpdateComplete + "....................", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsACVoucher.strErr_Msg, false);
                return;
            }
            if (nRet_Val == 0)
            {
                //MessageBox.Show(cnMsg_ErrSaveUpdate + "....................", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
        private void Fill_Grid()
        {
            ACVoucher clsACVoucher = new ACVoucher();
            DataSet ds_Record = new DataSet();
            DataTable dt_1 = new DataTable();
            
            int nBranch_ID = -1;
            int nVrType = -1;
            int nTrLevel = -1;
            object dBegDate = dtpBegDate.EditValue;
            object dEndDate = dtpEndDate.EditValue;

            if (lookBranch_Search.EditValue != null) nBranch_ID = Convert.ToInt32(lookBranch_Search.EditValue);
            if (lookTrLevel.EditValue != null) nTrLevel = Convert.ToInt32(lookTrLevel.EditValue);
            if (lookVrType_Serch.EditValue != null) nVrType = Convert.ToInt32(lookVrType_Serch.EditValue);

            database1 clsdatabase1 = new database1();
            DataSet ds = new DataSet();
            ds = clsACVoucher.Fill_Grid(mSys_System.pComp_ID, nBranch_ID, nVrType, nTrLevel, dBegDate, dEndDate, txtSearch.Text.Trim(), mSys_System.pUser_ID);
            if (clsACVoucher.strErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsACVoucher.strErrorCode + "'", false);
                return;
            }
            DataTable dt = ds.Tables[0];
            gridControl2.DataSource = dt;
        }
        private void Find_Record(int ID)
        {
            database1 clsdatabase1 = new database1();
            ACVoucher clsACVoucher = new ACVoucher();
            DataSet ds = new DataSet();
            ds = clsACVoucher.Find_Record(mSys_System.pComp_ID, ID);
            if (clsACVoucher.strErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsACVoucher.strErrorCode + "'", false);
                return;
            }
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lblAcc_SqNo.Text = dt.Rows[i]["Acc_SqNo"].ToString();
                txtTr_No.Text = dt.Rows[i]["VrNo"].ToString();
                dtpTr_Date.Text = dt.Rows[i]["VrDate"].ToString();
                txtCheck_No.Text = dt.Rows[i]["Check_No"].ToString();
                dtpCheck_Date.Text = dt.Rows[i]["Check_Date"].ToString();

                lookAcc.EditValue = dt.Rows[i]["Bank_ID"];
                
                lookVrType.EditValue = dt.Rows[i]["VrType"];
                lblTrLevel.Text = dt.Rows[i]["TrLevel"].ToString();
                txtRef1.Text = dt.Rows[i]["Ref1"].ToString();
                txtNarration.Text = dt.Rows[i]["Ref2"].ToString();
            }
            DataTable dt1 = ds.Tables[1];
            gridControl1.DataSource = dt1;
            Set_TrLevel();

            Tab_Main.SelectedTabPage = Tab_P1;
        }

        private void lookVrType_EditValueChanged(object sender, EventArgs e)
        {
            Fill_Accounts();
        }

        private void lookBranch_ID_EditValueChanged(object sender, EventArgs e)
        {
            Fill_Accounts();
        }
        private void repositoryItemGridLookUpEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            GridView view = gridControl1.FocusedView as GridView;

            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            int row = Convert.ToInt32(view.FocusedRowHandle);
            DataRow lookupRow = gridLookUpEdit.Properties.View.GetFocusedDataRow();
            if (lookupRow == null) return;
            string D_ID = lookupRow["Detail_ID"].ToString();
            string S_ID = lookupRow["Sub_ID"].ToString();
            string D_Code = lookupRow["Detail_Code"].ToString();
            string S_Code = lookupRow["Sub_Code"].ToString();
            string AC_Name = lookupRow["Acc_Name"].ToString();
            string AC_FCY = lookupRow["FCY"].ToString();
            string D_Ledger = lookupRow["Detail_SubLedger"].ToString();

            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Acc_Name"], AC_Name);
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Detail_ID"], D_ID);
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Sub_ID"], S_ID);
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Detail_Code"], D_Code);
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Sub_Code"], S_Code);
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["FCY"], AC_FCY);
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Detail_Ledger"], D_Ledger);

        }

        private void btn_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Set_Refresh();
            clsHomeScreen.Display_Message("", false);
        }

        private void Tab_Main_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            Button_Setting();
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Fill_Grid();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            object vID = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Acc_SqNo");
            if (vID != null && vID.ToString() != "")
            {
                Find_Record(Convert.ToInt32(vID));
            }
        }
        private void Save_Authorize()
        {
            ACVoucher clsACVoucher = new ACVoucher();
            int nRet_Val = 0;

            //if (lblAcc_SqNo.Text == "")
            //{
            //    MessageBox.Show("Please select a record to Authorize...", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            ////---alert
            //if (MessageBox.Show(cnMsg_BeforeAuthorize_1, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}
            //strAuth_D = mSys_IN.pcU_M_09_C09_A;

            int nBranch_ID = mSys_System.pBranch_ID;
            int nVrType = -1;
            double nAmt_Total = Convert.ToDouble(gridView1.Columns["Dr"].SummaryItem.SummaryValue);

            if (lookBranch_ID.EditValue != null) nBranch_ID = Convert.ToInt32(lookBranch_ID.EditValue);
            if (lookVrType.EditValue != null) nVrType = Convert.ToInt32(lookVrType.EditValue);


            nRet_Val = clsACVoucher.Save_Authorize(Convert.ToInt32(lblAcc_SqNo.Text), txtTr_No.Text.Trim(), nVrType, Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pTrLevel_Cleared,
                nAmt_Total, mSys_System.pComp_ID, nBranch_ID, mSys_System.pFYSDate,
                mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsACVoucher.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message("DB Error: " + clsACVoucher.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(" Your request has successfully been processed............", true);
                lblTrLevel.Text = mSys_System.pTrLevel_Approved.ToString();
                Set_TrLevel();
                Fill_Grid();
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsACVoucher.strErr_Msg, false);
                return;
            }
        }

        private void Save_Rollback()
        {
            int nRet_Val = 0;
            ACVoucher clsACVoucher = new ACVoucher();

            if (lblAcc_SqNo.Text == "")
            {
                MessageBox.Show("Please select a record to Rollback...", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //---user authorizations
            //if (!(pUser_Auth(pcU_M_09_C03_D, 1, 1)))
            //{
            //    return;
            //}

            //---alert
            //if (MessageBox.Show(cnMsg_BeforeRollback, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}
            //strAuth_D = mSys_IN.pcU_M_09_C09_RB;

            int nBranch_ID = -1;
            int nVrType = -1;
            double nAmt_Total = Convert.ToDouble(gridView1.Columns["Dr"].SummaryItem.SummaryValue);

            if (lookBranch_ID.EditValue != null) nBranch_ID = Convert.ToInt32(lookBranch_ID.EditValue);
            if (lookVrType.EditValue != null) nVrType = Convert.ToInt32(lookVrType.EditValue);


            nRet_Val = clsACVoucher.Save_Rollback(Convert.ToInt32(lblAcc_SqNo.Text), Convert.ToInt32(lblTrLevel.Text), nVrType, mSys_System.pComp_ID, mSys_System.pBranch_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);
            if (clsACVoucher.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message("DB Error: " + clsACVoucher.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 0)
            {
                clsHomeScreen.Display_Message(" Your request cannot be processed...........", true);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(" Your request has successfully been processed............", true);
                lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();

                Set_TrLevel();
                Fill_Grid();
                return;
            }
            if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsACVoucher.strErr_Msg, false);
                return;
            }
        }

        private void Save_Cancel()
        {
            ACVoucher clsACVoucher = new ACVoucher();

            {
                int nRet_Val = 0;

                if (lblAcc_SqNo.Text == "")
                {
                    MessageBox.Show("Please select a record to cancel...", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //---user authorizations
                //if (!(pUser_Auth(pcU_M_09_C03_D, 1, 1)))
                //{
                //    return;
                //}

                //---alert
                //if (MessageBox.Show(cnMsg_BeforeAuthorize_1, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return;
                //}
                //strAuth_D = mSys_IN.pcU_M_09_C09_C;
                int nBranch_ID = -1;
                int nVrType = -1;
                double nAmt_Total = Convert.ToDouble(gridView1.Columns["Dr"].SummaryItem.SummaryValue);

                if (lookBranch_ID.EditValue != null) nBranch_ID = Convert.ToInt32(lookBranch_ID.EditValue);
                if (lookVrType.EditValue != null) nVrType = Convert.ToInt32(lookVrType.EditValue);

                nRet_Val = clsACVoucher.Save_Authorize(Convert.ToInt32(lblAcc_SqNo.Text), txtTr_No.Text.Trim(), nVrType, Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pTrLevel_Cancelled,
                                nAmt_Total, mSys_System.pComp_ID, nBranch_ID, mSys_System.pFYSDate,
                                mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

                //            nRet_Val = clsACVoucher.Save_Authorize(Convert.ToInt32(lblAcc_SqNo.Text), mSys_System.pTrLevel_Cancelled, mSys_System.pComp_ID, mSys_System.pBranch_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D);
                if (clsACVoucher.strErrorCode.Trim() != "")
                {
                    clsHomeScreen.Display_Message("DB Error: " + clsACVoucher.strErrorCode + "....................", false);
                    return;
                }
                if (nRet_Val == 1)
                {
                    clsHomeScreen.Display_Message(" Your request has successfully been processed............", true);
                    lblTrLevel.Text = mSys_System.pTrLevel_Cancelled.ToString();
                    Set_TrLevel();
                    Fill_Grid();
                    return;
                }
                else if (nRet_Val == -1)
                {
                    clsHomeScreen.Display_Message(clsACVoucher.strErr_Msg, true);
                    return;
                }
            }
        }

        private void btn_Clear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save_Authorize();
        }

        private void btn_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save_Cancel();
        }

        private void btn_Rollback_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save_Rollback();
        }

        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int IsUpdate = 0;
            if (lblAcc_SqNo.Text.Trim() != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate(IsUpdate))
            {
                return;
            }
            Save_Update(IsUpdate);
            
        }

        private void btn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Set_Refresh_1();
        }
    }
}