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
    public partial class SR : RibbonForm
    {
        #region  Messages on This form
        private const string Msg_BeforeSave = "This request will create a new record. Are you sure to save new record? Press YES for save changes, NO for cancel...................";
        private const string Msg_BeforeUpdate = "This request will update the existing record. Are you sure to update the record? Press YES for save changes, NO for cancel...................";
        private const string Msg_ErrSaveUpdate = "The system is unable to process the transaction. Please check error: ";
        private const string Msg_SaveUpdateComplete = "The request has successfully been processed.....................";
        private const string cnMsg_Before_Under_Inspection = "Are you sure to make record to be marked as Under Inspections? Press YES to save changes, NO for cancel...................";
        private const string cnMsg_Before_Inspection_Done = "Are you sure to make the record to be marked as Inspection Done? Press YES to save changes, NO for cancel...................";
        private const string cnMsg_BeforeAuthorize_1 = "Are you sure to Authorize the record? Press YES to Authorize the record, NO for cancel...................";
        private const string cnMsg_BeforeRollback = "This will rollback the record to previous state. Are you sure to Rollback the record? Press YES to Rollback the record, NO for cancel...................";

        private const string cnMsg_ErrSaveUpdate = "The system is unable to process the transaction. Please check error: ";
        private const string cnMsg_SaveUpdateComplete = "The request has been successfully processed.....................";
        #endregion

        #region Date Members
        HomeScreen clsHomeScreen;
        private string strAuth_D = "";
        private DataTable dt_Grid;
        #endregion

        public SR()
        {
            InitializeComponent();
            Fill_Combo();
            Set_Refresh();
        }
        public SR(string vDoc_Tr_No)
        {
            InitializeComponent();
            txtDoc_Tr_No.Text = vDoc_Tr_No;
            Fill_Combo();
            Set_Refresh();
            if (txtDoc_Tr_No.Text.Trim() != "")
            {
                get_Sale();
            }
        }
        private void get_Sale()
        {
            database1 clsdatabase1 = new database1();
            INCSR clsINCSR = new INCSR();
            DataSet ds = new DataSet();
            ds = clsINCSR.Find_Sale(mSys_System.pComp_ID, txtDoc_Tr_No.Text.Trim());
            if (clsINCSR.strErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lblDoc_Inv_SqNo.Text = dt.Rows[i]["Inv_SqNo"].ToString();
                txtDoc_Tr_No.Text = dt.Rows[i]["Tr_No"].ToString();
                dtpDoc_Tr_Date.Text = dt.Rows[i]["Tr_Date"].ToString();

                lookSub_ID.EditValue = dt.Rows[i]["Sub_ID"].ToString();
                txtRef1.Text = dt.Rows[i]["Ref1"].ToString();

                txtContact_Person.Text = dt.Rows[i]["Person"].ToString();
                txtAddress1.Text = dt.Rows[i]["Address1"].ToString();
                txtAddress2.Text = dt.Rows[i]["Address2"].ToString();
                txtCell.Text = dt.Rows[i]["Cell"].ToString();

            }
            DataTable dt1 = ds.Tables[1];
            gridControl1.DataSource = dt1;
        }
        private void SR_Load(object sender, EventArgs e)
        {
            clsHomeScreen = (HomeScreen)this.MdiParent;
        }
        private void Fill_Combo()
        {
            database1 clsdatabase1 = new database1();
            INCSR clsINCSR = new INCSR();
            DataSet ds = clsINCSR.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINCSR.sErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            Set_Combo(lookBranch_ID, ds.Tables[0], "Branch_SName", "Branch_ID", true);
            Set_Combo(lookDType, ds.Tables[2], "DType_DD", "DType_ID", true);
        }

        private void lookBranch_ID_EditValueChanged(object sender, EventArgs e)
        {
            database1 clsdatabase1 = new database1();
            INCSR clsINCSR = new INCSR();
            DataSet ds = new DataSet();
            int vBranch = -1;
            if (lookBranch_ID.EditValue != null)
            {
                vBranch = Convert.ToInt32(lookBranch_ID.EditValue);
            }
            ds = clsINCSR.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID, vBranch);
            if (clsINCSR.sErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            Set_Combo(lookDept_ID, ds.Tables[0], "Dept_DD", "Dept_ID", true);
            Set_Combo(lookDept_ID_Store, ds.Tables[1], "Dept_DD", "Dept_ID", true);
            Set_Combo(lookSub_ID, ds.Tables[2], "Sub_CodeD", "Sub_ID", true);
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
        private void Set_DataSource()
        {
            dt_Grid = Set_Grid();
            gridControl1.DataSource = dt_Grid;
            Fill_SubCat();
        }
        private void Fill_SubCat()
        {
            INCSR clsINCSR = new INCSR();
            DataSet ds = clsINCSR.Fill_CatSub(mSys_System.pComp_ID, mSys_System.pUser_ID);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row["SCat_DD"] = string.Empty;
            row["SCat_ID"] = 0;
            dt.Rows.InsertAt(row, 0);
            repositoryItemGridLookUpEdit1.DataSource = dt;
            repositoryItemGridLookUpEdit1.ValueMember = "SCat_DD";
            repositoryItemGridLookUpEdit1.DisplayMember = "SCat_DD";
            gridView1.Columns["SCat_DD"].ColumnEdit = repositoryItemGridLookUpEdit1;
        }

        private void Fill_Items(int SCat_ID)
        {
            INCSR clsINCSR = new INCSR();
            DataSet ds = clsINCSR.Fill_Items(mSys_System.pComp_ID, mSys_System.pUser_ID, SCat_ID);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row["Item_DD"] = string.Empty;
            row["Item_D"] = string.Empty;
            row["Item_ID"] = 0;
            dt.Rows.InsertAt(row, 0);
            repositoryItemGridLookUpEdit2.DataSource = dt;
            repositoryItemGridLookUpEdit2.ValueMember = "Item_DD";
            repositoryItemGridLookUpEdit2.DisplayMember = "Item_DD";
            gridView1.Columns["Item_DD"].ColumnEdit = repositoryItemGridLookUpEdit2;

        }

        private void Set_Refresh()
        {
            lblInv_SqNo.Text = "";
            lblDoc_Inv_SqNo.Text = "";
            lookSub_ID.EditValue = null;
            txtTr_No.Text = "";

            txtRef1.Text = "";
            txtContact_Person.Text = "";
            txtAmt_Bal.Text = "";
            txtAmt_Cash.Text = "";
            txtAmt_CC.Text = "";
            txtAmt_Item.Text = "";
            txtAmt_Total.Text = "";
            txtAmt_Dis.Text = "";
            lblTrType.Text = "CASH";

            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCell.Text = "";
            txtContact_Person.Text = "";

            lookDept_ID.EditValue = mSys_System.pUser_Dept_ID;
            lookDept_ID_Store.EditValue = -1;
            cmbCC.EditValue = -1;
            lookDType.EditValue = -1;

            dtpTr_Date.EditValue = DateTime.Now;
            Set_DataSource();
            gridView1.AddNewRow();
            lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();
            //Set_Refresh_1();
            Set_TrLevel();

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
                lblTrLevelD.ForeColor = Color.Blue;

                btn_Rollback.Enabled = false;
                btn_Authorize.Enabled = true;
                btn_Cancel.Enabled = true;
            }
            else if (lblTrLevel.Text == mSys_System.pTrLevel_Cleared.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cleared_D;
                lblTrLevelD.ForeColor = Color.Green;

                btn_Rollback.Enabled = true;
                btn_Authorize.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            else if (lblTrLevel.Text == mSys_System.pTrLevel_Cancelled.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cancelled_D;
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
            dt_1.Columns.Add("Item_D", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("Item_DD", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("SCat_ID", typeof(int)).DefaultValue = 0;
            dt_1.Columns.Add("SCat_DD", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("Color_DD", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("I_Qty", typeof(double));
            dt_1.Columns.Add("I_Qty_FOC", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Qty", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Qty_FOC", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Rate", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("S_Rate", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Item_Rate_Min", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Item_Rate_Max", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Rate_1", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Ref4", typeof(string)).DefaultValue = "";
            return dt_1;
        }
        //private void Fill_Grid()
        //{
        //    INCSR clsINCSR = new INCSR();
        //    DataSet ds_Record = new DataSet();
        //    DataTable dt_1 = new DataTable();
        //    string strSearch_1 = "";
        //    string strSearch_2 = "";
        //    string strSearch_3 = "";

        //    string strSearchText = txtSearch.Text.Trim();

        //    string[] strArr;
        //    strArr = strSearchText.Split(" ".ToCharArray());
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
        //    DateTime dBegDate = Convert.ToDateTime(dtpBegDate.EditValue);
        //    DateTime dEndDate = Convert.ToDateTime(dtpEndDate.EditValue);

        //    //if (cmbBranch_ID.EditValue != null && cmb1Branch_ID.EditValue.ToString() != "") nBranch_ID = Convert.ToInt32(cmb1Branch_ID.EditValue.ToString());
        //    if (cmb1TrLevel.EditValue != null && cmb1TrLevel.EditValue.ToString() != "") nTrLevel = Convert.ToInt32(cmb1TrLevel.EditValue.ToString());
        //    if (cmb1Dept_ID_Store.EditValue != null && cmb1Dept_ID_Store.EditValue.ToString() != "") nDept_ID = Convert.ToInt32(cmb1Dept_ID_Store.EditValue.ToString());
        //    if (cmb1Dept_ID.EditValue != null && cmb1Dept_ID.EditValue.ToString() != "") nDept_ID_Store_1 = Convert.ToInt32(cmb1Dept_ID.EditValue.ToString());

        //    database1 clsdatabase1 = new database1();
        //    DataSet ds = new DataSet();
        //    ds = clsINCSR.Fill_Grid(mSys_System.pComp_ID, nTrLevel, "", strSearch_1, mSys_System.pBranch_ID, nDept_ID, nDept_ID_Store_1, dBegDate, dEndDate, 1);
        //    if (clsINCSR.strErrorCode != "")
        //    {
        //        clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsINCSR.sErrorCode + "'", false);
        //        return;
        //    }
        //    //Set_Grid();
        //    DataTable dt = ds.Tables[0];
        //    gridControl3.DataSource = dt;
        //}
        private void Find_Record(int ID)
        {
            database1 clsdatabase1 = new database1();
            INCSR clsINCSR = new INCSR();
            DataSet ds = new DataSet();
            ds = clsINCSR.Find_Record(mSys_System.pComp_ID, ID);
            if (clsINCSR.strErrorCode != "")
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

                lookSub_ID.EditValue = dt.Rows[i]["Sub_ID"].ToString();

                lookDept_ID.EditValue = (dt.Rows[i]["Dept_ID"] == null || dt.Rows[i]["Dept_ID"].ToString() == "" ? "-1" : dt.Rows[i]["Dept_ID"]);
                lookDept_ID_Store.EditValue = (dt.Rows[i]["Dept_ID_Store"] == null || dt.Rows[i]["Dept_ID_Store"].ToString() == "" ? "-1" : dt.Rows[i]["Dept_ID_Store"]);
                lookDType.EditValue = (dt.Rows[i]["DType_ID"] == null || dt.Rows[i]["DType_ID"].ToString() == "" ? "-1" : dt.Rows[i]["DType_ID"]);
                //cmbCC.EditValue = (dt.Rows[i]["cmbCC"] == null || dt.Rows[i]["cmbCC"].ToString() == "" ? "-1" : dt.Rows[i]["cmbCC"]);

                txtAmt_Item.Text = dt.Rows[i]["Amt_Item"].ToString();
                txtAmt_Total.Text = dt.Rows[i]["Amt_Total"].ToString();
                txtAmt_CC.Text = dt.Rows[i]["Amt_CC"].ToString();
                txtAmt_Cash.Text = dt.Rows[i]["Amt_Cash"].ToString();
                txtAmt_Dis.Text = dt.Rows[i]["Amt_Dis"].ToString();
                //txtAmt_R1.Text = dt.Rows[i]["Amt_R1"].ToString();
                txtAmt_Bal.Text = dt.Rows[i]["Amt_Bal"].ToString();
                lblTrLevel.Text = dt.Rows[i]["TrLevel"].ToString();
                lblTrLevelD.Text = dt.Rows[i]["TrLevelD"].ToString();
                txtRef1.Text = dt.Rows[i]["Ref1"].ToString();

                txtContact_Person.Text = dt.Rows[i]["Person"].ToString();
                txtAddress1.Text = dt.Rows[i]["Address1"].ToString();
                txtAddress2.Text = dt.Rows[i]["Address2"].ToString();
                txtCell.Text = dt.Rows[i]["Cell"].ToString();

                //dtpGP_Date.Text = dt.Rows[i]["GP_Date"].ToString();
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

            if (lookDept_ID.Text == "")
            {
                clsHomeScreen.Display_Message("Please select Department", false);
                lookDept_ID.Focus();
                return false;
            }
            if (lookDept_ID_Store.Text == "")
            {
                clsHomeScreen.Display_Message("Please select Warehouse", false);
                lookDept_ID_Store.Focus();
                return false;
            }
            if (lookSub_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please select Party", false);
                lookSub_ID.Focus();
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
                
            }
        }
        private bool Save_Update(int IsUpdate)
        {
            INCSR clsINCSR = new INCSR();
            int Ret_Value = 0;
            if (IsUpdate == 0)
            {
                //---alert
                //strAuth_D = "";
                if (XtraMessageBox.Show(Msg_BeforeSave, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }

            }
            else if (IsUpdate == 1) //---update
            {
                //strAuth_D = "";
                //---alert
                if (XtraMessageBox.Show(Msg_BeforeUpdate, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                    if (gridView1.GetRowCellValue(i, "Item_ID").ToString() != "")
                    {
                        row["Item_ID"] = gridView1.GetRowCellValue(i, "Item_ID");
                        row["SCat_ID"] = gridView1.GetRowCellValue(i, "SCat_ID");
                        if (gridView1.GetRowCellValue(i, "I_Qty").ToString() == "")
                        {

                            row["I_Qty"] = 0;
                        }
                        else
                        {
                            row["I_Qty"] = gridView1.GetRowCellValue(i, "I_Qty");
                        }
                        if (gridView1.GetRowCellValue(i, "I_Qty_FOC").ToString() == "")
                        {

                            row["I_Qty_FOC"] = 0;
                        }
                        else
                        {
                            row["I_Qty_FOC"] = gridView1.GetRowCellValue(i, "I_Qty_FOC");
                        }
                        //row["I_Qty_FOC"] = gridView1.GetRowCellValue(i, "I_Qty_FOC");
                        row["R_Qty"] = gridView1.GetRowCellValue(i, "R_Qty");
                        row["R_Qty_FOC"] = gridView1.GetRowCellValue(i, "R_Qty_FOC");
                        row["R_Rate"] = gridView1.GetRowCellValue(i, "R_Rate");
                        row["S_Rate"] = gridView1.GetRowCellValue(i, "S_Rate");
                        //row["Item_Rate_Min"] = gridView1.GetRowCellValue(i, "Item_Rate_Min");
                        //row["Item_Rate_Max"] = gridView1.GetRowCellValue(i, "Item_Rate_Max");
                        row["Rate_1"] = gridView1.GetRowCellValue(i, "Rate_1");
                        row["Ref4"] = gridView1.GetRowCellValue(i, "Ref4");
                        dt_1.Rows.Add(row);
                    }
                }
            }
            List<DataRow> Child = new List<DataRow>(dt_1.Select());


            string TrType = "Cash";
            int CC = 0;
            int nDType_ID = 0;
            int nTrType = 0;
            int Dept_ID = 0;
            int Dept_ID_Store = 0;
            int Branch_ID = 0;
            nTrType = 15;

            if (lblTrType.Text == "CREDIT")
            {
                nTrType = 16;
            }
            string CurrID = "PKR";
            double Curr_Rate = 0;
            double Amt_Cash = txtAmt_Cash.Text == "" ? 0 : Convert.ToDouble(txtAmt_Cash.Text);
            double Amt_CC = txtAmt_CC.Text == "" ? 0 : Convert.ToDouble(txtAmt_CC.Text);
            double Amt_Bal = txtAmt_Bal.Text == "" ? 0 : Convert.ToDouble(txtAmt_Bal.Text);
            double Amt_Item = txtAmt_Item.Text == "" ? 0 : Convert.ToDouble(txtAmt_Item.Text);
            double Amt_Total = txtAmt_Total.Text == "" ? 0 : Convert.ToDouble(txtAmt_Total.Text);
            double Amt_Dis = txtAmt_Dis.Text == "" ? 0 : Convert.ToDouble(txtAmt_Dis.Text);
            double Qty_Item = Convert.ToDouble(gridView1.Columns["R_Qty"].SummaryItem.SummaryValue);
            double Qty_FOC = Convert.ToDouble(gridView1.Columns["R_Qty_FOC"].SummaryItem.SummaryValue);
            double GST_Total = Convert.ToDouble(gridView1.Columns["Amt_R1"].SummaryItem.SummaryValue);

            if (cmbCC.EditValue != null && cmbCC.EditValue.ToString() != "") CC = Convert.ToInt32(cmbCC.EditValue.ToString());
            if (lookDType.EditValue != null && lookDType.EditValue.ToString() != "") nDType_ID = Convert.ToInt32(lookDType.EditValue.ToString());
            if (lookDept_ID.EditValue != null && lookDept_ID.EditValue.ToString() != "") Dept_ID = Convert.ToInt32(lookDept_ID.EditValue.ToString());
            if (lookDept_ID_Store.EditValue != null && lookDept_ID_Store.EditValue.ToString() != "") Dept_ID_Store = Convert.ToInt32(lookDept_ID_Store.EditValue.ToString());

            int nRet_Val = clsINCSR.Save_Master(lblInv_SqNo.Text, lblDoc_Inv_SqNo.Text.Trim(), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pComp_ID,
                 Convert.ToInt32(lookSub_ID.GetColumnValue("Detail_ID")), Convert.ToInt32(lookSub_ID.GetColumnValue("Sub_ID")), Dept_ID, Dept_ID_Store, Branch_ID, txtAddress1.Text, txtAddress2.Text,
                 "", txtContact_Person.Text, txtCell.Text, nDType_ID, CurrID, Curr_Rate, CC, nTrType,
                 txtRef1.Text.Trim(), "",
                 Qty_Item, Qty_FOC, Amt_Item, Amt_Dis, Amt_Total, Amt_Bal, Amt_Cash, Amt_CC, GST_Total, Child, mSys_System.pTrLevel_Pending, mSys_System.pUserName,
                 mSys_System.pUser_ID, IsUpdate, strAuth_D, mSys_System.pFY_ID);

            if (clsINCSR.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINCSR.sErrorCode + "......", false);
                return false;
            }
            if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINCSR.strErr_Msg + "....................", false);
                return false;
            }
            if (nRet_Val == 0)
            {
                clsHomeScreen.Display_Message(Msg_ErrSaveUpdate + "....................", false);
                return false;
            }
            if (nRet_Val == 1)
            {
                txtTr_No.Text = clsINCSR.str_Tr_No;
                lblInv_SqNo.Text = clsINCSR.str_Inv_SqNo.ToString();

                //lblU_S.Text = clsINCSR.strU_S;
                //lblPDate.Text = clsINCSR.strPDate;
                //lblU_U.Text = clsINCSR.strU_U;
                //lblU_UD.Text = clsINCSR.strU_UD;

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
            INCSR clsINCSR = new INCSR();
            int nRet_Val = 0;

            if (lblInv_SqNo.Text == "")
            {
                clsHomeScreen.Display_Message("Please select a record to Authorize...", false);
                return;
            }

            //---alert
            if (XtraMessageBox.Show(cnMsg_BeforeAuthorize_1, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //strAuth_D = mSys_IN.pcU_M_09_C09_A;

            int nDept_ID = -1;
            int nDept_ID_Store = -1;
            int nBranch_ID = -1;

            double nQty_Item = Convert.ToDouble(gridView1.Columns["I_Qty"].SummaryItem.SummaryValue);

            if (lookDept_ID.EditValue != null && lookDept_ID.EditValue.ToString() != "") nDept_ID = Convert.ToInt32(lookDept_ID.EditValue.ToString());
            if (lookDept_ID_Store.EditValue != null && lookDept_ID_Store.EditValue.ToString() != "") nDept_ID_Store = Convert.ToInt32(lookDept_ID_Store.EditValue.ToString());


            nRet_Val = clsINCSR.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                nBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, txtRef1.Text, "",
                mSys_System.pTrLevel_Cleared, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsINCSR.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINCSR.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, false);
                lblTrLevel.Text = mSys_System.pTrLevel_Approved.ToString();
                Set_TrLevel();
                
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINCSR.strErr_Msg, false);
                return;
            }
        }

        private void btn_Rollback_Click(object sender, ItemClickEventArgs e)
        {
            int nRet_Val = 0;
            INCSR clsINCSR = new INCSR();

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
            if (XtraMessageBox.Show(cnMsg_BeforeRollback, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //strAuth_D = mSys_IN.pcU_M_09_C09_RB;
            nRet_Val = clsINCSR.Save_Rollback(Convert.ToInt32(lblInv_SqNo.Text), Convert.ToInt32(lblTrLevel.Text), mSys_System.pComp_ID, mSys_System.pBranch_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);
            if (clsINCSR.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINCSR.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, false);
                lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();

                Set_TrLevel();
                
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINCSR.strErr_Msg, false);
                return;
            }
        }

        private void btn_Cancel_Click(object sender, ItemClickEventArgs e)
        {
            INCSR clsINCSR = new INCSR();

            {
                int nRet_Val = 0;

                if (lblInv_SqNo.Text == "")
                {
                    clsHomeScreen.Display_Message("Please select a record to cancel...", false);
                    return;
                }

                //---user authorizations
                //if (!(pUser_Auth(pcU_M_09_C03_D, 1, 1)))
                //{
                //    return;
                //}

                //---alert
                if (XtraMessageBox.Show(cnMsg_BeforeAuthorize_1, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                //strAuth_D = mSys_IN.pcU_M_09_C09_C;
                int nDept_ID = -1;
                int nDept_ID_Store = -1;
                int nBranch_ID = -1;

                double nQty_Item = Convert.ToDouble(gridView1.Columns["I_Qty"].SummaryItem.SummaryValue);

                if (lookDept_ID.EditValue != null && lookDept_ID.EditValue.ToString() != "") nDept_ID = Convert.ToInt32(lookDept_ID.EditValue.ToString());
                if (lookDept_ID_Store.EditValue != null && lookDept_ID_Store.EditValue.ToString() != "") nDept_ID_Store = Convert.ToInt32(lookDept_ID_Store.EditValue.ToString());
                //if (cmbBranch_ID.EditValue != null && cmbBranch_ID.EditValue.ToString() != "") nBranch_ID = Convert.ToInt32(cmbBranch_ID.EditValue.ToString());

                nRet_Val = clsINCSR.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                      nBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, txtRef1.Text, "",
                      mSys_System.pTrLevel_Cleared, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

                //            nRet_Val = clsINCSR.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), mSys_System.pTrLevel_Cancelled, mSys_System.pComp_ID, mSys_System.pBranch_ID, mSys_System.pUserName, mSys_System.pUser_ID, //strAuth_D);
                if (clsINCSR.strErrorCode.Trim() != "")
                {
                    clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINCSR.strErrorCode + "....................", false);
                    return;
                }
                if (nRet_Val == 1)
                {
                    clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, false);
                    lblTrLevel.Text = mSys_System.pTrLevel_Cancelled.ToString();
                    Set_TrLevel();
                    
                    return;
                }
                else if (nRet_Val == -1)
                {
                    clsHomeScreen.Display_Message(clsINCSR.strErr_Msg, false);
                    return;
                }
            }
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
                    string SCat_DD = lookupRow["SCat_DD"].ToString();
                    //string SCat_D = lookupRow["SCat_D"].ToString();

                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_DD"], SCat_DD);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_ID"], SCat_ID);
                    //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_D"], SCat_D);

                    for (int i = 2; i <= gridView1.Columns["I_Qty"].VisibleIndex; i++)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[i], "");
                    }
                    Fill_Items(SCat_ID);
                }
            }
            if (gridView1.GetRowCellValue(view.FocusedRowHandle, gridView1.Columns["SCat_DD"]) != null)
                gridView1.FocusedColumn = gridView1.Columns["Item_DD"];
            gridView1.ShowEditor();
        }

        private void repositoryItemGridLookUpEdit2_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (gridView1 == null) return;
            GridView view = gridView1;

            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            DataRow lookupRow = gridLookUpEdit.Properties.View.GetFocusedDataRow();

            //string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SCat_ID").ToString();
            //if (ID == "" && !(gridView1.IsFirstRow))
            //{
            //    int PreRow = gridView1.GetPrevVisibleRow(gridView1.FocusedRowHandle);
            //    string SCat_ID = gridView1.GetRowCellValue(PreRow, "SCat_ID").ToString();
            //    if (SCat_ID != "")
            //    {
            //        //string SCat_D = gridView1.GetRowCellValue(PreRow, "SCat_D").ToString();
            //        string SCat_DD = gridView1.GetRowCellValue(PreRow, "SCat_DD").ToString();

            //        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_DD"], SCat_DD);
            //        //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_D"], SCat_D);
            //        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_ID"], SCat_ID);
            //    }
            //}

            if (lookupRow != null)
            {
                int item_ID = Convert.ToInt32(lookupRow["Item_ID"]);
                if (item_ID != 0)
                {
                    string Sub_ID = lookupRow["SCat_ID"].ToString();
                    string Item_Name = lookupRow["Item_DD"].ToString();
                    string item_Code = lookupRow["Item_D"].ToString();
                    string color = lookupRow["Color_DD"].ToString();
                    string Unit = lookupRow["Item_Unit"].ToString();
                    string Rate = lookupRow["Item_Rate"].ToString();

                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_ID"], Sub_ID);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_ID"], item_ID);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_D"], item_Code);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Color_DD"], color);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_Unit"], Unit);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["R_Rate"], Rate);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_DD"], Item_Name);
                }
            }
            else
            {
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_DD"], string.Empty);
            }
            if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Item_DD"]).ToString() != "")
                gridView1.FocusedColumn = gridView1.Columns["I_Qty"];
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
                    gridView1.FocusedColumn = gridView1.Columns["Item_DD"];
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
                    gridView1.FocusedColumn = gridView1.Columns["Item_DD"];
                }
            }
            if (e.KeyCode == Keys.Enter && gridView1.FocusedColumn.Name == "Ref4")
            {
                if (gridView1.GetRowCellValue(row, "SCat_ID").ToString() == "" || gridView1.GetRowCellValue(row, "Item_DD").ToString() == "")
                    gridView1.FocusedColumn = gridView1.Columns["Item_DD"];
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
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["SCat_D"], string.Empty);
                //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["SCat_DD"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_ID"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_D"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_DD"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_Unit"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Color_DD"], string.Empty);
            }

            if (gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "Item_DD").ToString() == "")
            {

                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_ID"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_D"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_DD"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_Unit"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Color_DD"], string.Empty);
            }
            gridControl1.EmbeddedNavigator.NavigatableControl.DoAction(DevExpress.XtraEditors.NavigatorButtonType.EndEdit);

            if (gridView1.Columns["Amount"].SummaryItem.SummaryValue != null)
            {
                txtAmt_Total.Text = Math.Round(Convert.ToDouble(gridView1.Columns["Amount"].SummaryItem.SummaryValue), 0).ToString();
                txtAmt_Dis.Text = Math.Round(Convert.ToDouble(gridView1.Columns["Discount"].SummaryItem.SummaryValue), 0).ToString();
                //txtAmt_R1.Text = Math.Round(Convert.ToDouble(gridView1.Columns["Amt_R1"].SummaryItem.SummaryValue), 0).ToString();
                if (lblTrType.Text == "CASH")
                    txtAmt_Cash.Text = txtAmt_Item.Text;
            }
        }

        private void txtAmt_Total_EditValueChanged(object sender, EventArgs e)
        {
            Calculation();
        }
        
        //private void btn_Print_Click(object sender, EventArgs e)
        //{
        //    if (lblInv_SqNo.Text == "")
        //    {
        //        clsHomeScreen.Display_Message("Please select sales voucher first......", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    Set_Rpt();
        //}
        //private void Set_Rpt()
        //{
        //    BMS.RptViewer frmRptViewer = new BMS.RptViewer();
        //    ParameterField rptParamField = new ParameterField();
        //    ParameterFields rptParamFields = new ParameterFields();
        //    ParameterDiscreteValue rptParamDiscreteValue = new ParameterDiscreteValue();
        //    ReportDocument rptDocument = new ReportDocument();

        //    string strRptNo = "";
        //    string strRpt = "";

        //    rptParamField = new ParameterField();
        //    rptParamDiscreteValue = new ParameterDiscreteValue();
        //    rptParamField.Name = "@nComp_ID";
        //    rptParamDiscreteValue.Value = mSys_System.pComp_ID.ToString();
        //    rptParamField.CurrentValues.Add(rptParamDiscreteValue);
        //    rptParamFields.Add(rptParamField);

        //    rptParamField = new ParameterField();
        //    rptParamDiscreteValue = new ParameterDiscreteValue();
        //    rptParamField.Name = "@nInv_SqNo";
        //    rptParamDiscreteValue.Value = lblInv_SqNo.Text;
        //    rptParamField.CurrentValues.Add(rptParamDiscreteValue);
        //    rptParamFields.Add(rptParamField);

        //    try
        //    {
        //        strRpt = Application.StartupPath;
        //        strRpt = strRpt.Substring(0, strRpt.Length - 3) + "Reports\\rptIN0023.rpt";

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
    }
}