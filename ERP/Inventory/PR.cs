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
using ERP.BLL.IN;
using ERP.BLL.SYS;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;

namespace ERP.Inventory
{
    public partial class PR : RibbonForm
    {
        #region  Messages on This form
        private const string Msg_BeforeSave = "This request will create a new record. Are you sure to save new record? Press YES for save changes, NO for cancel...................";
        private const string Msg_BeforeUpdate = "This request will update the existing record. Are you sure to update the record? Press YES for save changes, NO for cancel...................";
        private const string Msg_ErrSaveUpdate = "The system is unable to process the transaction. Please check error: ";
        private const string Msg_SaveUpdateComplete = "The request has successfully been processed.....................";
        private const string cnMsg_Before_Under_Inspection = "Are you sure to make record to be marked as Under Inspections? Press YES to save changes, NO for cancel...................";
        private const string cnMsg_Before_Inspection_Done = "Are you sure to make the record to be marked as Inspection Done? Press YES to save changes, NO for cancel...................";
        private const string cnMsg_Before_Cancel = "Are you sure to make the record to be marked as Cancel? Press YES to save changes, NO for cancel...................";
        private const string cnMsg_BeforeAuthorize_1 = "Are you sure to Authorize the record? Press YES to Authorize the record, NO for cancel...................";
        private const string cnMsg_BeforeRollback = "This will rollback the record to previous state. Are you sure to Rollback the record? Press YES to Rollback the record, NO for cancel...................";

        private const string cnMsg_ErrSaveUpdate = "The system is unable to process the transaction. Please check error: ";
        private const string cnMsg_SaveUpdateComplete = "The request has been successfully processed.....................";
        #endregion

        #region Date Members
        HomeScreen clsHomeScreen;
        private string strAuth_D = "";
        private string vGRN_No = "";
        private DataTable dt_Grid;
        #endregion

        public PR(string vGRN_tr_No)
        {
            InitializeComponent();
            vGRN_No = vGRN_tr_No;
            Set_Refresh();
            Fill_Combo();
        }
        public PR()
        {
            InitializeComponent();
            Set_Refresh();
            Fill_Combo();
        }

        private void PR_Load(object sender, EventArgs e)
        {
            clsHomeScreen = (HomeScreen)this.MdiParent;
        }
        private void Fill_Combo()
        {
            database1 clsdatabase1 = new database1();
            INPR clsINPR = new INPR();
            DataSet ds = clsINPR.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINPR.sErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            Set_Combo(lookBranch_ID, ds.Tables[0], "Branch_SName", "Branch_ID", true);
            Set_Combo(lookCredit_ID, ds.Tables[1], "CreditD", "CReditID", true);
            Set_Combo(lookDType, ds.Tables[2], "DType_DD", "DType_ID", true);
        }


        private void lookBranch_ID_EditValueChanged(object sender, EventArgs e)
        {
            database1 clsdatabase1 = new database1();
            INGRN clsINGRN = new INGRN();
            DataSet ds = new DataSet();
            int vBranch = -1;
            if (lookBranch_ID.EditValue != null)
            {
                vBranch = Convert.ToInt32(lookBranch_ID.EditValue);
            }
            ds = clsINGRN.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID, vBranch);
            if (clsINGRN.sErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            Set_Combo(cmbDept_ID, ds.Tables[0], "Dept_DD", "Dept_ID", true);
            Set_Combo(cmbDept_ID_Store, ds.Tables[1], "Dept_DD", "Dept_ID", true);
            Set_Combo(lookSub_ID, ds.Tables[2], "Sub_CodeD", "Sub_ID", true);
        }

        private void Set_Combo(LookUpEdit cmdToFill, DataTable dt_Source, string DisplayField, string EditValueField, bool All)
        {
            DataTable dt_1 = new DataTable();
            if (dt_Source == null)
            {
                return;
            }

            dt_1 = dt_Source.Copy();

            if (DisplayField.Trim() == "" || EditValueField.Trim() == "")
            {
                return;
            }
            cmdToFill.Properties.DataSource = null;

            cmdToFill.Properties.DisplayMember = DisplayField.Trim();
            cmdToFill.Properties.ValueMember = EditValueField.Trim();

            if (All)
            {
                DataRow row = dt_1.NewRow();
                row[0] = "";
                row[1] = -1;
                dt_1.Rows.InsertAt(row, 0);
            }
            cmdToFill.Properties.DataSource = dt_1;
        }
        private void Set_DataSource()
        {
            dt_Grid = Set_Grid();
            gridControl1.DataSource = dt_Grid;
            Fill_SubCat();
        }
        private void Fill_SubCat()
        {
            INPR clsINPR = new INPR();
            DataSet ds = clsINPR.Fill_SCat(mSys_System.pComp_ID, mSys_System.pUser_ID);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row["SCat_DD"] = string.Empty;
            row["SCat_ID"] = 0;
            dt.Rows.InsertAt(row, 0);
            repositoryItemGridLookUpEdit1.DataSource = dt;
            repositoryItemGridLookUpEdit1.ValueMember = "SCat_ID";
            repositoryItemGridLookUpEdit1.DisplayMember = "SCat_DD";
            gridView1.Columns["SCat_ID"].ColumnEdit = repositoryItemGridLookUpEdit1;
        }

        private void Fill_Items(int SCat_ID)
        {
            INPR clsINPR = new INPR();
            DataSet ds = clsINPR.Fill_Items(mSys_System.pComp_ID, mSys_System.pUser_ID, SCat_ID);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row["Item_ID"] = string.Empty;
            row["Item_D"] = string.Empty;
            row["Item_ID"] = 0;
            dt.Rows.InsertAt(row, 0);
            repositoryItemGridLookUpEdit2.DataSource = dt;
            repositoryItemGridLookUpEdit2.ValueMember = "Item_ID";
            repositoryItemGridLookUpEdit2.DisplayMember = "Item_ID";
            gridView1.Columns["Item_ID"].ColumnEdit = repositoryItemGridLookUpEdit2;

        }

        private void Set_Refresh()
        {
            lblInv_SqNo.Text = "";
            txtTr_No.Text = "";
            txtTr_No.ReadOnly = true;

            //lblDetail_ID.Text = "";
            //lblSub_ID.Text = "";
            //txtDetail_Code.Text = "";
            //txtSub_Code.Text = "";
            //txtSub_CodeD.Text = "";

            txtRef1.Text = "";
            txtGP_No.Text = "";
            txtInv_No.Text = "";
            txtAmt_Bal.Text = "";
            txtAmt_Cash.Text = "";
            txtAmt_CC.Text = "";
            txtAmt_Item.Text = "";
            txtAmt_Total.Text = "";
            txtAmt_Dis.Text = "";
            txtCurr_Rate.Text = "1.00";

            txtGRN_Tr_No.Text = "";
            lblGRN_Inv_SqNo.Text = "";
            dtpGRN_Tr_Date.EditValue = DateTime.Now;
            cmbDept_ID.EditValue = mSys_System.pUser_Dept_ID;
            cmbDept_ID_Store.EditValue = -1;
            cmbCC.EditValue = -1;
            lookCredit_ID.EditValue = -1;
            lblCurrID.Text = "PKT";

            rdbPO_D.EditValue = 0;
            dtpTr_Date.EditValue = DateTime.Now;
            dtpGP_Date.EditValue = DateTime.Now;
            Set_DataSource();
            gridView1.AddNewRow();
            lblTrLevel.Text = "";
            Set_TrLevel();
            //Set_Refresh_1();

        }
        //private void Set_Refresh_1()
        //{
        //    cmb1Dept_ID.EditValue = -1;
        //    cmb1Dept_ID_Store.EditValue = -1;
        //    cmb1TrLevel.EditValue = -1;
        //    txtSearch.Text = "";
        //    dtpBegDate.EditValue = mSys_System.pFYSDate;
        //    dtpEndDate.EditValue = DateTime.Now;
        //}
        private void Set_TrLevel()
        {
            if (lblTrLevel.Text == mSys_System.pTrLevel_Pending.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Pending_D;
                lblTrLevelD.ForeColor = Color.Red;

                btn_Rollback.Enabled = false;
                btn_Authorize.Enabled = true;
                btn_Cancel.Enabled = true;
            }

            else if (lblTrLevel.Text == mSys_System.pTrLevel_Cleared.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cleared_D;
                lblTrLevel.ForeColor = Color.Green;
                lblTrLevelD.ForeColor = Color.Green;

                btn_Rollback.Enabled = true;
                btn_Authorize.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            else if (lblTrLevel.Text == mSys_System.pTrLevel_Cancelled.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cancelled_D;
                lblTrLevel.ForeColor = Color.Red;
                lblTrLevelD.ForeColor = Color.Red;

                btn_Rollback.Enabled = false;
                btn_Authorize.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            if (lblTrLevel.Text == "")
            {
                lblTrLevelD.Text = "";
                lblTrLevelD.ForeColor = Color.Red;

                btn_Rollback.Enabled = false;
                btn_Authorize.Enabled = false;
                btn_Cancel.Enabled = false;
            }
        }

        private DataTable Set_Grid()
        {
            DataTable dt_1 = new DataTable("tbl");

            dt_1.Columns.Add("Item_ID", typeof(int)).DefaultValue = 0;
            dt_1.Columns.Add("SCat_ID", typeof(int)).DefaultValue = 0;
            dt_1.Columns.Add("Unit_DD", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("R_Qty", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Qty_Damaged", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Qty_Reject", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Rate", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Rate_FCY", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Rate_Min", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Rate_Max", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Rate_1", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Ref4", typeof(string)).DefaultValue = "";
            return dt_1;
        }
        //private void Fill_Grid()
        //{
        //    INPR clsINPR = new INPR();
        //    DataSet ds_Record = new DataSet();
        //    DataTable dt_1 = new DataTable();
        //    string strSearch_1 = "";
        //    string strSearch_2 = "";
        //    string strSearch_3 = "";

        //    //string strSearchText = txtSearch.Text.Trim();

        //    string[] strArr;
        //    //strArr = strSearchText.Split(" ".ToCharArray());
        //    for (int i = 0; i < strArr.Length; i++)
        //    {
        //        if (i == 0)
        //        {
        //            strSearch_1 = strArr[0].ToString(); continue;
        //        }
        //        if (i == 1)
        //        {
        //            strSearch_2 = strArr[1].ToString(); continue;
        //        }
        //        if (i == 2)
        //        {
        //            strSearch_3 = strArr[2].ToString(); continue;
        //        }

        //    }
        //    int nBranch_ID = -1;
        //    int nDept_ID = -1;
        //    int nDept_ID_Store_1 = -1;
        //    int nTrLevel = -1;
        //    string dBegDate = dtpBegDate.EditValue.ToString();
        //    string dEndDate = dtpEndDate.EditValue.ToString();

        //    //if (cmbBranch_ID.EditValue != null && cmb1Branch_ID.EditValue.ToString() != "") nBranch_ID = Convert.ToInt32(cmb1Branch_ID.EditValue.ToString());
        //    if (cmb1TrLevel.EditValue != null && cmb1TrLevel.EditValue.ToString() != "") nTrLevel = Convert.ToInt32(cmb1TrLevel.EditValue.ToString());
        //    if (cmb1Dept_ID_Store.EditValue != null && cmb1Dept_ID_Store.EditValue.ToString() != "") nDept_ID = Convert.ToInt32(cmb1Dept_ID_Store.EditValue.ToString());
        //    if (cmb1Dept_ID.EditValue != null && cmb1Dept_ID.EditValue.ToString() != "") nDept_ID_Store_1 = Convert.ToInt32(cmb1Dept_ID.EditValue.ToString());

        //    database1 clsdatabase1 = new database1();
        //    DataSet ds = new DataSet();
        //    ds = clsINPR.Fill_Grid(nTrLevel, nBranch_ID, nDept_ID, nDept_ID_Store_1, strSearch_1, strSearch_2, strSearch_3, dBegDate, dEndDate, mSys_System.pComp_ID, mSys_System.pUser_ID);
        //    if (clsINPR.sErrorCode != "")
        //    {
        //        clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsINPR.sErrorCode + "'", false);
        //        return;
        //    }
        //    //Set_Grid();
        //    DataTable dt = ds.Tables[0];
        //    gridControl3.DataSource = dt;
        //}
        private void Find_Record(int ID)
        {
            database1 clsdatabase1 = new database1();
            INPR clsINPR = new INPR();
            DataSet ds = new DataSet();
            ds = clsINPR.Find_Record(mSys_System.pComp_ID, ID);
            if (clsINPR.sErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lblInv_SqNo.Text = dt.Rows[i]["Inv_SqNo"].ToString();
                txtTr_No.Text = dt.Rows[i]["Tr_No"].ToString();
                dtpTr_Date.Text = dt.Rows[i]["Tr_Date"].ToString();


                lblGRN_Inv_SqNo.Text = dt.Rows[i]["Inv_SqNo"].ToString();
                txtGRN_Tr_No.Text = dt.Rows[i]["Tr_No"].ToString();
                dtpGRN_Tr_Date.Text = dt.Rows[i]["Tr_Date"].ToString();


                lookSub_ID.EditValue = dt.Rows[i]["Sub_ID"].ToString();

                cmbDept_ID.EditValue = (dt.Rows[i]["Dept_ID"] == null || dt.Rows[i]["Dept_ID"].ToString() == "" ? "-1" : dt.Rows[i]["Dept_ID"]);
                cmbDept_ID_Store.EditValue = (dt.Rows[i]["Dept_ID_Store"] == null || dt.Rows[i]["Dept_ID_Store"].ToString() == "" ? "-1" : dt.Rows[i]["Dept_ID_Store"]);
                lookCredit_ID.EditValue = (dt.Rows[i]["Credit_ID"] == null || dt.Rows[i]["Credit_ID"].ToString() == "" ? "-1" : dt.Rows[i]["Credit_ID"]);
                //cmbCC.EditValue = (dt.Rows[i]["cmbCC"] == null || dt.Rows[i]["cmbCC"].ToString() == "" ? "-1" : dt.Rows[i]["cmbCC"]);

                txtAmt_Item.Text = dt.Rows[i]["Amt_Item"].ToString();
                txtAmt_Total.Text = dt.Rows[i]["Amt_Total"].ToString();
                txtAmt_CC.Text = dt.Rows[i]["Amt_CC"].ToString();
                txtAmt_Cash.Text = dt.Rows[i]["Amt_Cash"].ToString();
                txtAmt_Dis.Text = dt.Rows[i]["Amt_Dis"].ToString();
                txtAmt_Bal.Text = dt.Rows[i]["Amt_Bal"].ToString();
                lblTrLevel.Text = dt.Rows[i]["TrLevel"].ToString();
                lblTrLevelD.Text = dt.Rows[i]["TrLevelD"].ToString();
                txtRef1.Text = dt.Rows[i]["Ref1"].ToString();

                txtInv_No.Text = dt.Rows[i]["Party_InvNo"].ToString();
                txtGP_No.Text = dt.Rows[i]["GP_No"].ToString();

                dtpGP_Date.Text = dt.Rows[i]["GP_Date"].ToString();
            }
            DataTable dt1 = ds.Tables[1];
            gridControl1.DataSource = dt1;
            Set_TrLevel();
        }
        private void Calculation()
        {
            double Amt_Item = 0;
            double Amt_Total = 0;
            double Amt_Dis = 0;
            double Amt_Cash = 0;
            double Amt_CC = 0;
            double Amt_Bal = 0;

            if (txtAmt_Total.Text.Trim() != "")
            {
                Amt_Total = Convert.ToDouble(txtAmt_Total.Text.Trim());
            }
            if (txtAmt_Item.Text.Trim() != "")
            {
                Amt_Item = Convert.ToDouble(txtAmt_Item.Text.Trim());
            }
            if (txtAmt_Dis.Text.Trim() != "")
            {
                Amt_Dis = Convert.ToDouble(txtAmt_Dis.Text.Trim());
            }
            if (txtAmt_Total.Text.Trim() != "")
            {
                Amt_Total = Convert.ToDouble(txtAmt_Total.Text.Trim());
            }
            if (txtAmt_Cash.Text.Trim() != "")
            {
                Amt_Cash = Convert.ToDouble(txtAmt_Cash.Text.Trim());
            }
            if (txtAmt_CC.Text.Trim() != "")
            {
                Amt_CC = Convert.ToDouble(txtAmt_CC.Text.Trim());
            }

            Amt_Item = Amt_Total - Amt_Dis;
            txtAmt_Item.Text = Amt_Item.ToString();
            txtAmt_Bal.Text = (Amt_Item - (Amt_Cash + Amt_CC)).ToString();
        }
        private bool Save_Validate(int IsUpdate)
        {
            if (IsUpdate == 1)
            {
                if (lblInv_SqNo.Text == "")
                {
                    clsHomeScreen.Display_Message("Please select record to Update", false);
                    return false;
                }
            }

            if (cmbDept_ID.Text == "")
            {
                clsHomeScreen.Display_Message("Please select Department", false);
                cmbDept_ID.Focus();
                return false;
            }
            if (cmbDept_ID_Store.Text == "")
            {
                clsHomeScreen.Display_Message("Please select Warehouse", false);
                cmbDept_ID_Store.Focus();
                return false;
            }
            if (lookSub_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please select Party", false);
                lookSub_ID.Focus();
                return false;
            }
            if (txtInv_No.Text == "")
            {
                clsHomeScreen.Display_Message("Please enter Invoice No.", false);
                txtInv_No.Focus();
                return false;
            }
            return true;
        }
        private void btn_Save_Click(object sender, ItemClickEventArgs e)
        {
            int IsUpdate = 0;
            if (lblInv_SqNo.Text != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate(IsUpdate))
            {
                return;
            }

            if (Save_Update(IsUpdate))
            {
                //Fill_Grid();
            }
        }
        private bool Save_Update(int IsUpdate)
        {
            INPR clsINPR = new INPR();
            int Ret_EditValue = 0;
            if (IsUpdate == 0)
            {
                //---alert
                //strAuth_D = mSys_IN.pcU_M_01_C09_S;
                if (MessageBox.Show(Msg_BeforeSave, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }

            }
            else if (IsUpdate == 1) //---update
            {
                //strAuth_D = mSys_IN.pcU_M_01_C09_U;
                //---alert
                if (MessageBox.Show(Msg_BeforeUpdate, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }

            DataTable dt_1 = Set_Grid();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row = dt_1.NewRow();
                if (gridView1.GetRowCellValue(i, "Item_ID") != null)
                {
                    if (gridView1.GetRowCellValue(i, "Item_ID").ToString() != "0")
                    {
                        row["Item_ID"] = gridView1.GetRowCellValue(i, "Item_ID");
                        row["SCat_ID"] = gridView1.GetRowCellValue(i, "SCat_ID");
                        row["R_Qty"] = gridView1.GetRowCellValue(i, "R_Qty");
                        row["R_Qty_Damaged"] = gridView1.GetRowCellValue(i, "R_Qty_Damaged");
                        row["R_Qty_Reject"] = gridView1.GetRowCellValue(i, "R_Qty_Reject");
                        row["R_Rate"] = gridView1.GetRowCellValue(i, "R_Rate");
                        row["R_Rate_FCY"] = gridView1.GetRowCellValue(i, "R_Rate");
                        row["Rate_1"] = gridView1.GetRowCellValue(i, "Rate_1");
                        row["Ref4"] = gridView1.GetRowCellValue(i, "Ref4");
                        dt_1.Rows.Add(row);
                    }
                }
            }
            List<DataRow> Child = new List<DataRow>(dt_1.Select());


            string TrType = "Cash";
            int CC = 0;
            int Credit_ID = 0;
            int Dept_ID = 0;
            int Dept_ID_Store = 0;
            int nTrLevel = 0;
            lblPO_For.Text = "Credit";

            double Amt_Cash = txtAmt_Cash.Text == "" ? 0 : Convert.ToDouble(txtAmt_Cash.Text);
            double Amt_CC = txtAmt_CC.Text == "" ? 0 : Convert.ToDouble(txtAmt_CC.Text);
            double Amt_Bal = txtAmt_Bal.Text == "" ? 0 : Convert.ToDouble(txtAmt_Bal.Text);
            double Amt_Item = txtAmt_Item.Text == "" ? 0 : Convert.ToDouble(txtAmt_Item.Text);
            double Amt_Total = txtAmt_Total.Text == "" ? 0 : Convert.ToDouble(txtAmt_Total.Text);
            double Amt_Dis = txtAmt_Dis.Text == "" ? 0 : Convert.ToDouble(txtAmt_Dis.Text);
            double Qty_Item = Convert.ToDouble(gridView1.Columns["R_Qty"].SummaryItem.SummaryValue);
            double Qty_Item_Reject = Convert.ToDouble(gridView1.Columns["R_Qty_Reject"].SummaryItem.SummaryValue);
            double Qty_Item_Damaged = Convert.ToDouble(gridView1.Columns["R_Qty_Damaged"].SummaryItem.SummaryValue);
            double Curr_Rate = txtCurr_Rate.Text == "" ? 1 : Convert.ToDouble(txtCurr_Rate.Text);
            double GST_Total = Convert.ToDouble(gridView1.Columns["Amt_R1"].SummaryItem.SummaryValue);

            if (cmbCC.EditValue != null && cmbCC.EditValue.ToString() != "") CC = Convert.ToInt32(cmbCC.EditValue.ToString());
            if (lookCredit_ID.EditValue != null && lookCredit_ID.EditValue.ToString() != "") Credit_ID = Convert.ToInt32(lookCredit_ID.EditValue.ToString());
            if (cmbDept_ID.EditValue != null && cmbDept_ID.EditValue.ToString() != "") Dept_ID = Convert.ToInt32(cmbDept_ID.EditValue.ToString());
            if (cmbDept_ID_Store.EditValue != null && cmbDept_ID_Store.EditValue.ToString() != "") Dept_ID_Store = Convert.ToInt32(cmbDept_ID_Store.EditValue.ToString());
            if (lblTrLevel.Text != "")
            {

                nTrLevel = Convert.ToInt32(lblTrLevel.Text);
            }

            Ret_EditValue = clsINPR.Save_Master(lblInv_SqNo.Text, txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue).Date,
                        lblGRN_Inv_SqNo.Text, txtGRN_Tr_No.Text.Trim(), Convert.ToDateTime(dtpGRN_Tr_Date.EditValue).Date,
                        lblCurrID.Text.Trim(), Curr_Rate, GST_Total, Qty_Item,
                        Convert.ToInt32(lookSub_ID.GetColumnValue("Detail_ID")), Convert.ToInt32(lookSub_ID.GetColumnValue("Sub_ID")), Dept_ID, Dept_ID_Store, mSys_System.pBranch_ID,
                        Credit_ID, TrType, txtInv_No.Text.Trim(), txtGP_No.Text.Trim(), Convert.ToDateTime(dtpGP_Date.EditValue), txtRef1.Text,
                        Amt_Cash, Amt_CC, Amt_Dis, Amt_Item, Amt_Total, Amt_Bal, CC, chkGrade_ID.Checked,
                        Child, mSys_System.pComp_ID,
                        mSys_System.pUserName, mSys_System.pUser_ID, nTrLevel, IsUpdate, strAuth_D
                        );
            if (clsINPR.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINPR.sErrorCode + "......", false);
                return false;
            }
            if (Ret_EditValue == -1)
            {
                clsHomeScreen.Display_Message(clsINPR.strErr_Msg + "....................", false);
                return false;
            }
            if (Ret_EditValue == 0)
            {
                clsHomeScreen.Display_Message(Msg_ErrSaveUpdate + "....................", false);
                return false;
            }
            if (Ret_EditValue == 1)
            {
                txtTr_No.Text = clsINPR.str_Code;
                lblInv_SqNo.Text = clsINPR.str_ID.ToString();
                lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();
                Set_TrLevel();
                clsHomeScreen.Display_Message(Msg_SaveUpdateComplete + "....................", false);
            }

            return true;
        }
        private void btn_Refresh_Click(object sender, ItemClickEventArgs e)
        {
            Set_Refresh();
        }
        
        private void btn_Authorize_Click(object sender, ItemClickEventArgs e)
        {
            INPR clsINPR = new INPR();

            int nRet_Val = 0;

            if (lblInv_SqNo.Text == "")
            {
                clsHomeScreen.Display_Message("Please select a record to Authorize...", false);
                return;
            }

            //---user authorizations
            //if (!(pUser_Auth(pcU_M_09_C03_D, 1, 1)))
            //{
            //    return;
            //}

            //---alert
            if (MessageBox.Show(cnMsg_BeforeAuthorize_1, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int nDept_ID = -1;
            int nDept_ID_Store = -1;
            int nBranch_ID = -1;

            double nQty_Item = Convert.ToDouble(gridView1.Columns["R_Qty"].SummaryItem.SummaryValue);
            //double nQty_Accepted = Convert.ToDouble(gridView1.Columns["R_Qty_Accepted"].SummaryItem.SummaryValue);

            if (cmbDept_ID.EditValue != null && cmbDept_ID.EditValue.ToString() != "") nDept_ID = Convert.ToInt32(cmbDept_ID.EditValue.ToString());
            if (cmbDept_ID_Store.EditValue != null && cmbDept_ID_Store.EditValue.ToString() != "") nDept_ID_Store = Convert.ToInt32(cmbDept_ID_Store.EditValue.ToString());


            //strAuth_D = mSys_IN.pcU_M_01_C09_A;
            nRet_Val = clsINPR.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                 mSys_System.pBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, txtRef1.Text, txtRef1.Text,
                mSys_System.pTrLevel_Cleared, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsINPR.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINPR.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, false);
                lblTrLevel.Text = mSys_System.pTrLevel_Approved.ToString();
                Set_TrLevel();
                //Fill_Grid();
                ////Fill_Grid();
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINPR.strErr_Msg, false);
                return;
            }
        }

        private void btn_Rollback_Click(object sender, ItemClickEventArgs e)
        {
            int nRet_Val = 0;
            INPR clsINPR = new INPR();

            if (lblInv_SqNo.Text == "")
            {
                clsHomeScreen.Display_Message("Please select a record to Rollback...", false);
                return;
            }

            //---user authorizations
            //if (!(pUser_Auth(pcU_M_09_C03_D, 1, 1)))
            //{
            //    return;
            //}

            //---alert
            if (MessageBox.Show(cnMsg_BeforeRollback, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //strAuth_D = mSys_IN.pcU_M_01_C09_RB;
            nRet_Val = clsINPR.Save_Rollback(Convert.ToInt32(lblInv_SqNo.Text), Convert.ToInt32(lblTrLevel.Text), mSys_System.pComp_ID, mSys_System.pBranch_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);
            if (clsINPR.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINPR.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, false);
                if (lblTrLevel.Text == mSys_System.pTrLevel_Cleared.ToString())
                    lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();

                Set_TrLevel();
                //Fill_Grid();
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINPR.strErr_Msg, false);
                return;
            }
        }

        private void btn_Cancel_Click(object sender, ItemClickEventArgs e)
        {
            int nRet_Val = 0;
            INPR clsINPR = new INPR();

            if (lblInv_SqNo.Text == "")
            {
                clsHomeScreen.Display_Message("Please select a record for Cancel...", false);
                return;
            }

            //---user authorizations
            //if (!(pUser_Auth(pcU_M_09_C03_D, 1, 1)))
            //{
            //    return;
            //}

            //---alert
            if (MessageBox.Show(cnMsg_Before_Cancel, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //strAuth_D = mSys_IN.pcU_M_01_C09_C;


            int nDept_ID = -1;
            int nDept_ID_Store = -1;
            int nBranch_ID = -1;

            double nQty_FOC = 0;
            double nQty_Accepted = 0;
            double nQty_Item = nQty_FOC + nQty_Accepted;



            nRet_Val = clsINPR.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                mSys_System.pBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, txtRef1.Text, txtRef1.Text,
                mSys_System.pTrLevel_Cancelled, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsINPR.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINPR.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, false);
                lblTrLevel.Text = mSys_System.pTrLevel_Cancelled.ToString();
                Set_TrLevel();
                //Fill_Grid();
                //  //Fill_Grid();
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINPR.strErr_Msg, false);
                return;
            }
        }

        private void txtAmt_CC_EditValueChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void repositoryItemGridLookUpEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (gridView1 == null) return;
            GridView view = gridView1;

            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            DataRow lookupRow = gridLookUpEdit.Properties.View.GetFocusedDataRow();
            if (lookupRow != null)
            {
                int SCat_ID = Convert.ToInt32(lookupRow["SCat_ID"]);
                if (SCat_ID != 0)
                {
                    string SCat_DD = lookupRow["SCat_ID"].ToString();

                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_ID"], SCat_ID);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_DD"], SCat_DD);

                    for (int i = 2; i <= gridView1.Columns["R_Qty"].VisibleIndex; i++)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[i], "");
                    }
                    Fill_Items(SCat_ID);
                }
            }
            if (gridView1.GetRowCellValue(view.FocusedRowHandle, gridView1.Columns["SCat_ID"]) != null)
                gridView1.FocusedColumn = gridView1.Columns["Item_ID"];
            gridView1.ShowEditor();
        }

        private void repositoryItemGridLookUpEdit2_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (gridView1 == null) return;
            GridView view = gridView1;

            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            int row = Convert.ToInt32(view.FocusedRowHandle);
            DataRow lookupRow = gridLookUpEdit.Properties.View.GetFocusedDataRow();

            string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SCat_ID").ToString();
            if (ID == "" && !(gridView1.IsFirstRow))
            {
                int PreRow = gridView1.GetPrevVisibleRow(gridView1.FocusedRowHandle);
                string SCat_ID = gridView1.GetRowCellValue(PreRow, "SCat_ID").ToString();
                if (SCat_ID != "")
                {
                    //string CatSub_D = gridView1.GetRowCellValue(PreRow, "CatSub_D").ToString();
                    string SCat_DD = gridView1.GetRowCellValue(PreRow, "SCat_DD").ToString();

                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_ID"], SCat_ID);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_DD"], SCat_DD);
                }
            }

            if (lookupRow != null)
            {
                int item_ID = Convert.ToInt32(lookupRow["Item_ID"]);
                if (item_ID != 0)
                {
                    string Item_ID = lookupRow["Item_ID"].ToString();
                    string item_D = lookupRow["Item_D"].ToString();
                    string color_DD = lookupRow["Color_DD"].ToString();
                    string Unit = lookupRow["Item_Unit"].ToString();
                    string Rate = lookupRow["Item_Rate"].ToString();

                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_ID"], item_ID);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_D"], item_D);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Color_DD"], color_DD);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_Unit"], Unit);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["R_Rate"], Rate);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_ID"], Item_ID);
                }
            }
            else
            {
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_ID"], string.Empty);
            }
            if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Item_ID"]).ToString() != "")
                gridView1.FocusedColumn = gridView1.Columns["R_Qty_Damaged"];
            gridView1.ShowEditor();
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            int row = gridView1.FocusedRowHandle;
            if (e.KeyCode == Keys.Down && row == gridView1.RowCount - 1)
            {
                if (gridView1.GetRowCellValue(row, "SCat_ID").ToString() != "" && gridView1.GetRowCellValue(row, "Item_ID").ToString() != "" && !(gridView1.HasColumnErrors))
                {
                    gridView1.CloseEditor();
                    gridView1.AddNewRow();
                    gridView1.FocusedColumn = gridView1.Columns["Item_ID"];
                }
            }
            if (e.Shift && e.KeyCode == Keys.Delete)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }

            if (e.KeyCode == Keys.Enter && gridView1.IsLastRow && gridView1.FocusedColumn.Name == "Ref4")
            {
                if (gridView1.GetRowCellValue(row, "SCat_ID").ToString() != "" && gridView1.GetRowCellValue(row, "Item_ID").ToString() != "" && !(gridView1.HasColumnErrors))
                {
                    gridView1.CloseEditor();
                    gridView1.AddNewRow();
                    gridView1.FocusedColumn = gridView1.Columns["Item_ID"];
                }
            }
            if (e.KeyCode == Keys.Enter && gridView1.FocusedColumn.Name == "Ref4")
            {
                if (gridView1.GetRowCellValue(row, "SCat_ID").ToString() == "" || gridView1.GetRowCellValue(row, "Item_ID").ToString() == "")
                    gridView1.FocusedColumn = gridView1.Columns["Item_ID"];
            }
            if (e.KeyCode == Keys.Tab)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView1.CloseEditor();
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (gridView1 == null) return;

            if (gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "SCat_ID").ToString() == "")
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["SCat_ID"], string.Empty);
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CatSub_D"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["SCat_ID"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_ID"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_D"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_ID"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_Unit"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Color_DD"], string.Empty);
            }

            if (gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "Item_ID").ToString() == "")
            {

                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_ID"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_D"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_ID"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_Unit"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Color_DD"], string.Empty);
            }
            gridControl1.EmbeddedNavigator.NavigatableControl.DoAction(DevExpress.XtraEditors.NavigatorButtonType.EndEdit);

            if (gridView1.Columns["Amount"].SummaryItem.SummaryValue != null)
            {
                txtAmt_Total.Text = Convert.ToDouble(gridView1.Columns["Amount"].SummaryItem.SummaryValue).ToString();
                //txtAmt_R1.Text = Convert.ToDouble(gridView1.Columns["Amt_R1"].SummaryItem.SummaryValue).ToString();
            }
        }
        
        //private void btn_Print_Click(object sender, EventArgs e)
        //{
        //    BMS.RptViewer frmRptViewer = new BMS.RptViewer();
        //    ParameterField rptParamField = new ParameterField();
        //    ParameterFields rptParamFields = new ParameterFields();
        //    ParameterDiscreteEditValue rptParamDiscreteEditValue = new ParameterDiscreteEditValue();
        //    ReportDocument rptDocument = new ReportDocument();

        //    string strRptNo = "";
        //    string strRpt = "";

        //    rptParamField = new ParameterField();
        //    rptParamDiscreteEditValue = new ParameterDiscreteEditValue();
        //    rptParamField.Name = "@nComp_ID";
        //    rptParamDiscreteEditValue.EditValue = mSys_System.pComp_ID.ToString();
        //    rptParamField.CurrentEditValues.Add(rptParamDiscreteEditValue);
        //    rptParamFields.Add(rptParamField);

        //    rptParamField = new ParameterField();
        //    rptParamDiscreteEditValue = new ParameterDiscreteEditValue();
        //    rptParamField.Name = "@nInv_SqNo";
        //    rptParamDiscreteEditValue.EditValue = lblInv_SqNo.Text;
        //    rptParamField.CurrentEditValues.Add(rptParamDiscreteEditValue);
        //    rptParamFields.Add(rptParamField);

        //    try
        //    {
        //        strRpt = Application.StartupPath;
        //        strRpt = strRpt.Substring(0, strRpt.Length - 3) + "Reports\\rptIN0021.rpt";

        //        rptDocument.Load(strRpt);
        //        Set_ReportConnection(rptDocument);
        //    }
        //    catch (Exception ex)
        //    {
        //        clsHomeScreen.Display_Message(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    //---Passing Report Formula's
        //    FormulaFieldDefinitions formulaList;
        //    formulaList = rptDocument.DataDefinition.FormulaFields;
        //    formulaList["CN"].Text = "'" + mSys_System.pCN.ToString().ToUpper() + "'";
        //    formulaList["Branch_Name"].Text = "'" + mSys_System.pBranch_SName.ToUpper() + "'";
        //    formulaList["Criteria1"].Text = "'Purchase Order'";
        //    formulaList["RPT"].Text = "'" + strRptNo + "'";
        //    formulaList["UserName"].Text = "'" + mSys_System.pUser_FullName + "'";

        //    //---Passing Selection formula
        //    rptDocument.DataDefinition.RecordSelectionFormula = "";

        //    //---Setting Report to view
        //    frmRptViewer.crv.ParameterFieldInfo = rptParamFields;
        //    frmRptViewer.crv.ReportSource = rptDocument;
        //    frmRptViewer.Show();

        //}
        //private void Set_ReportConnection(ReportDocument rptDocument)
        //{
        //    TableLogOnInfo crLogonInfo;

        //    database1 clsDatabase1 = new database1();
        //    crLogonInfo = rptDocument.Database.Tables[0].LogOnInfo;
        //    crLogonInfo.ConnectionInfo.ServerName = database1.strServerName;
        //    crLogonInfo.ConnectionInfo.DatabaseName = database1.strDatabaseName;
        //    crLogonInfo.ConnectionInfo.UserID = database1.strUserID;
        //    crLogonInfo.ConnectionInfo.Password = database1.strPassword;
        //    rptDocument.Database.Tables[0].ApplyLogOnInfo(crLogonInfo);
        //}
        
        public void Find_Record_GRN(string GRN_Tr_No)
        {

            database1 clsdatabase1 = new database1();
            INPR clsINPR = new INPR();
            DataSet ds = new DataSet();
            ds = clsINPR.Find_Record_GRN(mSys_System.pComp_ID, GRN_Tr_No);
            if (clsINPR.sErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            if (clsINPR.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINPR.sErrorCode + "'", false);
                return;
            }
            if (ds.Tables.Count > 1)
            {

                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lblGRN_Inv_SqNo.Text = dt.Rows[i]["Inv_SqNo"].ToString();
                    txtGRN_Tr_No.Text = dt.Rows[i]["Tr_No"].ToString();
                    dtpGRN_Tr_Date.Text = dt.Rows[i]["Tr_Date"].ToString();

                    lookSub_ID.EditValue = dt.Rows[i]["Sub__ID"].ToString();

                    cmbDept_ID.EditValue = (dt.Rows[i]["Dept_ID"] == null || dt.Rows[i]["Dept_ID"].ToString() == "" ? "-1" : dt.Rows[i]["Dept_ID"]);
                    cmbDept_ID_Store.EditValue = (dt.Rows[i]["Dept_ID_Store"] == null || dt.Rows[i]["Dept_ID_Store"].ToString() == "" ? "-1" : dt.Rows[i]["Dept_ID_Store"]);
                    cmbDept_ID_Store.Enabled = false;
                    cmbDept_ID.Enabled = false;

                    lookCredit_ID.EditValue = (dt.Rows[i]["Credit_ID"] == null || dt.Rows[i]["Credit_ID"].ToString() == "" ? "-1" : dt.Rows[i]["Credit_ID"]);
                    //cmbCC.EditValue = (dt.Rows[i]["cmbCC"] == null || dt.Rows[i]["cmbCC"].ToString() == "" ? "-1" : dt.Rows[i]["cmbCC"]);

                    txtAmt_Item.Text = dt.Rows[i]["Amt_Item"].ToString();
                    txtAmt_Total.Text = dt.Rows[i]["Amt_Total"].ToString();
                    txtAmt_CC.Text = dt.Rows[i]["Amt_CC"].ToString();
                    txtAmt_Cash.Text = dt.Rows[i]["Amt_Cash"].ToString();
                    txtAmt_Dis.Text = dt.Rows[i]["Amt_Dis"].ToString();
                    txtAmt_Bal.Text = dt.Rows[i]["Amt_Bal"].ToString();
                    //lblTrLevel.Text = dt.Rows[i]["TrLevel"].ToString();
                    //lblTrLevelD.Text = dt.Rows[i]["TrLevelD"].ToString();
                    txtRef1.Text = dt.Rows[i]["Ref1"].ToString();

                    txtInv_No.Text = dt.Rows[i]["Party_InvNo"].ToString();
                    txtGP_No.Text = dt.Rows[i]["GP_No"].ToString();

                    dtpGP_Date.Text = dt.Rows[i]["GP_Date"].ToString();
                }
                DataTable dt1 = ds.Tables[1];
                gridControl1.DataSource = dt1;
                Set_TrLevel();
            }

        }
        
    }
}