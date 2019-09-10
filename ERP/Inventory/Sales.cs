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
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace ERP.Inventory
{
    public partial class Sales : RibbonForm
    {
        #region  Messages on This form
        private const string Msg_BeforeSave = "This request will create a new record. Are you sure to save new record? Press YES for save changes, NO for cancel...................";
        private const string Msg_BeforeUpdate = "This request will update the existing record. Are you sure to update the record? Press YES for save changes, NO for cancel...................";
        private const string Msg_ErrSaveUpdate = "The system is unable to process the transaction. Please check error: ";
        private const string Msg_SaveUpdateComplete = "The request has successfully been processed.....................";
        private const string cnMsg_Before_Cancel = "Are you sure to Cancel the record? Press YES to save changes, NO for cancel...................";
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

        public Sales()
        {
            InitializeComponent();
            Fill_Combo();
            Set_Refresh();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            clsHomeScreen = (HomeScreen)this.MdiParent;
        }
        private void Fill_Combo()
        {
            database1 clsdatabase1 = new database1();
            INCS clsINCS = new INCS();
            DataSet ds = clsINCS.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINCS.sErrorCode != "")
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
            INCS clsINCS = new INCS();
            DataSet ds = new DataSet();
            int vBranch = -1;
            if (lookBranch_ID.EditValue != null)
            {
                vBranch = Convert.ToInt32(lookBranch_ID.EditValue);
            }
            ds = clsINCS.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID, vBranch);
            if (clsINCS.sErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            Set_Combo(cmbDept_ID, ds.Tables[0], "Dept_DD", "Dept_ID", true);
            Set_Combo(cmbDept_ID_Store, ds.Tables[1], "Dept_DD", "Dept_ID", true);
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
            INCS clsINSales = new INCS();
            DataSet ds = clsINSales.Fill_SCat(mSys_System.pComp_ID, mSys_System.pUser_ID);
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
            if (cmbDept_ID.Text == "")
            {
                clsHomeScreen.Display_Message("Please select Department", false);
                cmbDept_ID.Focus();
                return;
            }
            INCS clsINSales = new INCS();
            DataSet ds = clsINSales.Fill_Items(mSys_System.pComp_ID, mSys_System.pUser_ID, SCat_ID, Convert.ToInt32(cmbDept_ID.EditValue));
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
            //txtCurr_Rate.Text = "0";

            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCell.Text = "";

            cmbDept_ID.EditValue = mSys_System.pUser_Dept_ID;

            cmbDept_ID_Store.EditValue = -1;
            cmbCC.EditValue = -1;
            lookDType.EditValue = -1;
            dtpTr_Date.EditValue = DateTime.Now;
            Set_DataSource();
            gridView1.AddNewRow();
            lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();
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
                lblTrLevelD.ForeColor = Color.Blue;

                cmd0_Save.Enabled = true;
                cmd0_Rollback.Enabled = false;
                cmd0_Authorize.Enabled = true;
                cmd0_Cancel.Enabled = true;
            }
            else if (lblTrLevel.Text == mSys_System.pTrLevel_Cleared.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cleared_D;
                lblTrLevelD.ForeColor = Color.Green;

                cmd0_Save.Enabled = false;
                cmd0_Rollback.Enabled = true;
                cmd0_Authorize.Enabled = false;
                cmd0_Cancel.Enabled = false;
            }
            else if (lblTrLevel.Text == mSys_System.pTrLevel_Cancelled.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cancelled_D;
                lblTrLevelD.ForeColor = Color.Red;

                cmd0_Save.Enabled = false;
                cmd0_Rollback.Enabled = false;
                cmd0_Authorize.Enabled = false;
                cmd0_Cancel.Enabled = false;
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
            dt_1.Columns.Add("Unit_DD", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("I_Qty", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("I_Qty_FOC", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("I_Rate", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("S_Rate", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Item_Rate_Min", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Item_Rate_Max", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Rate_1", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Item_A2", typeof(bool)).DefaultValue = 0;
            dt_1.Columns.Add("Item_A3", typeof(bool)).DefaultValue = 0;
            dt_1.Columns.Add("Ref4", typeof(string)).DefaultValue = "";
            return dt_1;
        }
        //private void Fill_Grid()
        //{
        //    INCS clsINSales = new INCS();
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
        //    ds = clsINSales.Fill_Grid(mSys_System.pComp_ID, nTrLevel, "", strSearch_1, mSys_System.pBranch_ID, nDept_ID, nDept_ID_Store_1, dBegDate, dEndDate, 1);
        //    if (clsINSales.strErrorCode != "")
        //    {
        //        clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsINSales.sErrorCode + "'", false);
        //        return;
        //    }
        //    //Set_Grid();
        //    DataTable dt = ds.Tables[0];
        //    gridControl3.DataSource = dt;
        //}
        private void Find_Record(int ID)
        {
            database1 clsdatabase1 = new database1();
            INCS clsINSales = new INCS();
            DataSet ds = new DataSet();
            ds = clsINSales.Find_Record(mSys_System.pComp_ID, ID);
            if (clsINSales.strErrorCode != "")
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

                cmbDept_ID.EditValue = (dt.Rows[i]["Dept_ID"] == null || dt.Rows[i]["Dept_ID"].ToString() == "" ? "-1" : dt.Rows[i]["Dept_ID"]);
                cmbDept_ID_Store.EditValue = (dt.Rows[i]["Dept_ID_Store"] == null || dt.Rows[i]["Dept_ID_Store"].ToString() == "" ? "-1" : dt.Rows[i]["Dept_ID_Store"]);
                lookDType.EditValue = (dt.Rows[i]["DType_ID"] == null || dt.Rows[i]["DType_ID"].ToString() == "" ? "-1" : dt.Rows[i]["DType_ID"]);
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
        private void Grid_Validate()
        {
            if (lblTrLevel.Text == "0")
            {
                if (gridView1 == null) return;
                double R_Rate = 0;
                double S_Rate = 0;
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SCat_ID") != null && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Item_ID") != null)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SCat_ID").ToString() != "" && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Item_ID").ToString() != "")
                    {
                        if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "R_Qty") == null || gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "R_Qty").ToString() == "")
                        {
                            return;
                        }
                        //if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "S_Rate") != null && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "S_Rate").ToString() != "")
                        //    S_Rate = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "S_Rate"));

                        double Stock = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Stock_Balance"));
                        double Qty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "R_Qty"));

                        //int SaleWithoutStock = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Item_A2"));
                        //int SaleBelowAvgRate = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Item_A1"));

                        //if (gridView1.FocusedColumn.Name == "R_Qty")
                        {
                            //if (Qty == 0)
                            //{
                            //   clsHomeScreen.Display_Message("Item Quantity cannot be 0/empty at row " + (gridView1.FocusedRowHandle + 1) + ", please check............");
                            //    gridView1.FocusedColumn = gridView1.Columns["R_Qty"];
                            //    return;

                            //}
                            //if (SaleWithoutStock == 0)
                            //{
                            //    if (Qty > Stock)
                            //    {
                            //        clsHomeScreen.Display_Message("Issue Qty can not be greater then Available Qty.Please check row No.: " + (gridView1.FocusedRowHandle + 1), false);
                            //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "R_Qty", 0);
                            //        gridView1.FocusedColumn = gridView1.Columns["R_Qty"];
                            //        return;

                            //    }
                            //}
                        }
                        //if (gridView1.FocusedColumn.Name == "R_Rate")
                        {

                            //if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "R_Rate") != null && gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "R_Rate").ToString() != "")
                            //    R_Rate = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "R_Rate"));

                            //if (R_Rate == 0) return;
                            //if (SaleBelowAvgRate == 0)
                            //{

                            //    if (R_Rate < S_Rate)
                            //    {
                            //       clsHomeScreen.Display_Message("Sale Rate cannot be below Avg. Rate.Please check row No.: " + (gridView1.FocusedRowHandle + 1));
                            //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "R_Rate", 0);
                            //        gridView1.FocusedColumn = gridView1.Columns["R_Rate"];
                            //        return;

                            //    }
                            //}
                        }
                        //string CatSub_NoSale = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CatSub_NoSale").ToString();
                        //string Item_NoSale = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Item_NoSale").ToString();
                        //if (Convert.ToBoolean(CatSub_NoSale))
                        //{
                        //    string SCat_DD = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SCat_DD").ToString();
                        //    clsHomeScreen.Display_Message("Sale for Sub Category: '" + SCat_DD + "' is blocked. The system cannot process your request.", false);
                        //    return;
                        //}
                        //if (Convert.ToBoolean(Item_NoSale))
                        //{
                        //    string Item_DD = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Item_DD").ToString();
                        //    clsHomeScreen.Display_Message("Sale for Item: '" + SCat_DD + "' is blocked. The system cannot process your request.",false);
                        //    return;
                        //}

                    }

                }
            }
        }
        private void repositoryItemGridLookUpEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (gridView1 == null) return;
            GridView view = gridControl1.FocusedView as GridView;

            DataRowView dRow = repositoryItemGridLookUpEdit1.GetRowByKeyValue(e.Value) as DataRowView;
            if (dRow != null && Convert.ToInt32(dRow["SCat_ID"]) != 0)
            {
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_DD"], dRow["SCat_DD"]);
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_ID"], dRow["SCat_ID"]);

                for (int i = 2; i <= gridView1.Columns["I_Qty"].VisibleIndex; i++)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[i], "");
                }
                Fill_Items(Convert.ToInt32(dRow["SCat_ID"]));
                
            }
            if (gridView1.GetRowCellValue(view.FocusedRowHandle, gridView1.Columns["SCat_DD"]) != null)
                gridView1.FocusedColumn = gridView1.Columns["Item_DD"];
            gridView1.ShowEditor();
        }

        private void repositoryItemGridLookUpEdit2_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (gridView1 == null) return;
            GridView view = gridControl1.FocusedView as GridView;
            DataRowView dRow = repositoryItemGridLookUpEdit2.GetRowByKeyValue(e.Value) as DataRowView;

            object SubID = view.GetRowCellValue(view.FocusedRowHandle, "SCat_ID");
            if (SubID != null && SubID.ToString() == "0" && !(view.IsFirstRow))
            {
                object Pre_SubID = view.GetRowCellValue(view.FocusedRowHandle - 1, "SCat_ID");
                if (Pre_SubID != null && Pre_SubID.ToString() != "0")
                {
                    object subCat_DD = view.GetRowCellValue(view.FocusedRowHandle - 1, "SCat_DD");
                    
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_DD"], subCat_DD);
                    //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_D"], SCat_D);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_ID"], Pre_SubID);
                }
            }

            if (dRow != null && dRow["Item_ID"].ToString() != "0")
            {
                object vID = dRow["Item_ID"];
                if (vID != null && vID.ToString() != "0")
                {
                    object SID = dRow["SCat_ID"].ToString();
                    object IName = dRow["Item_DD"].ToString();
                    object iCode = dRow["Item_D"].ToString();
                    //object color = dRow["Color_DD"].ToString();
                    object Unit = dRow["Unit_DD"].ToString();
                    object Rate = dRow["Item_Rate"].ToString();
                    object SRate = dRow["Item_Rate"].ToString();
                    //object Qty = dRow["Item_Qty"].ToString();
                    //object RateMin = dRow["Item_Rate_Min"].ToString();
                    //object RateMax = dRow["Item_Rate_Max"].ToString();

                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SCat_ID"], SID);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_ID"], vID);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_D"], iCode);
                    //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Color_DD"], color);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Unit_DD"], Unit);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["I_Rate"], Rate);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["S_Rate"], SRate);
                    //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_Qty"], Qty);
                    //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_Rate_Min"], RateMin);
                    //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_Rate_Max"], RateMax);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_DD"], IName);
                }
            }
            else
            {
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_DD"], string.Empty);
            }
            if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Item_ID"]).ToString() != "0")
                gridView1.FocusedColumn = gridView1.Columns["I_Qty"];
            gridView1.ShowEditor();
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
            if (gridView1.DataRowCount <= 0)
            {
                clsHomeScreen.Display_Message("Please enter some data into grid to save record.", false);
                gridView1.Focus();
                return false;
            }
            return true;
        }
        private void cmd0_Save_Click(object sender, ItemClickEventArgs e)
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
            INCS clsINSales = new INCS();
            int Ret_Value = 0;
            if (IsUpdate == 0)
            {
                //---alert
                //strAuth_D = "";
                if (MessageBox.Show(Msg_BeforeSave, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }

            }
            else if (IsUpdate == 1) //---update
            {
                //strAuth_D = "";
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
                    if (gridView1.GetRowCellValue(i, "Item_ID").ToString() != "")
                    {
                        row["Item_ID"] = gridView1.GetRowCellValue(i, "Item_ID");
                        row["SCat_ID"] = gridView1.GetRowCellValue(i, "SCat_ID");
                        row["I_Qty"] = gridView1.GetRowCellValue(i, "I_Qty");
                        row["I_Qty_FOC"] = gridView1.GetRowCellValue(i, "I_Qty_FOC");
                        row["I_Rate"] = gridView1.GetRowCellValue(i, "I_Rate");
                        row["S_Rate"] = gridView1.GetRowCellValue(i, "S_Rate");
                        row["Item_Rate_Min"] = gridView1.GetRowCellValue(i, "Item_Rate_Min");
                        row["Item_Rate_Max"] = gridView1.GetRowCellValue(i, "Item_Rate_Max");
                        row["Rate_1"] = gridView1.GetRowCellValue(i, "Rate_1");
                        row["Ref4"] = gridView1.GetRowCellValue(i, "Ref4");
                        dt_1.Rows.Add(row);
                    }
                }
            }
            List<DataRow> Child = new List<DataRow>(dt_1.Select());


            string TrType = lblTrType.Text.Trim();
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
            double Qty_Item = Convert.ToDouble(gridView1.Columns["I_Qty"].SummaryItem.SummaryValue);
            double Qty_FOC = Convert.ToDouble(gridView1.Columns["I_Qty_FOC"].SummaryItem.SummaryValue);
            //double Curr_Rate = txtCurr_Rate.Text == "" ? 1 : Convert.ToDouble(txtCurr_Rate.Text);
            double GST_Total = Convert.ToDouble(gridView1.Columns["Amt_R1"].SummaryItem.SummaryValue);

            if (cmbCC.EditValue != null && cmbCC.EditValue.ToString() != "") CC = Convert.ToInt32(cmbCC.EditValue.ToString());
            if (lookDType.EditValue != null && lookDType.EditValue.ToString() != "") nDType_ID = Convert.ToInt32(lookDType.EditValue.ToString());
            if (cmbDept_ID.EditValue != null && cmbDept_ID.EditValue.ToString() != "") Dept_ID = Convert.ToInt32(cmbDept_ID.EditValue.ToString());
            if (cmbDept_ID_Store.EditValue != null && cmbDept_ID_Store.EditValue.ToString() != "") Dept_ID_Store = Convert.ToInt32(cmbDept_ID_Store.EditValue.ToString());
            if (lookBranch_ID.EditValue != null && lookBranch_ID.EditValue.ToString() != "") Branch_ID= Convert.ToInt32(lookBranch_ID.EditValue.ToString());

            int nRet_Val = clsINSales.Save_Master(lblInv_SqNo.Text, txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pComp_ID,
                 Convert.ToInt32(lookSub_ID.GetColumnValue("Detail_ID")), Convert.ToInt32(lookSub_ID.GetColumnValue("Sub_ID")), Dept_ID, Dept_ID_Store, Branch_ID, txtAddress1.Text, txtAddress2.Text,
                 "", txtContact_Person.Text, txtCell.Text, nDType_ID, CurrID, Curr_Rate, CC, nTrType, false,
                 txtRef1.Text.Trim(), "", 0, 0,
                 Qty_Item, Qty_FOC, Amt_Item, Amt_Dis, Amt_Total, Amt_Bal, Amt_Cash, Amt_CC, GST_Total, Child, mSys_System.pTrLevel_Pending, mSys_System.pUserName,
                 mSys_System.pUser_ID, IsUpdate, strAuth_D, mSys_System.pFY_ID);

            if (clsINSales.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINSales.sErrorCode + "......", false);
                return false;
            }
            if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINSales.strErr_Msg + "....................", false);
                return false;
            }
            if (nRet_Val == 0)
            {
                clsHomeScreen.Display_Message(Msg_ErrSaveUpdate + "....................", false);
                return false;
            }
            if (nRet_Val == 1)
            {
                txtTr_No.Text = clsINSales.str_Tr_No;
                lblInv_SqNo.Text = clsINSales.str_Inv_SqNo.ToString();
                lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();
                Set_TrLevel();
                clsHomeScreen.Display_Message(Msg_SaveUpdateComplete + "....................", true);
            }

            return true;
        }

        private void cmd0_Refresh_Click(object sender, ItemClickEventArgs e)
        {
            Set_Refresh();
        }
        
        private void Save_Authorize()
        {
            INCS clsINCS = new INCS();
            int nRet_Val = 0;

            if (lblInv_SqNo.Text == "")
            {
                clsHomeScreen.Display_Message("Please select a record to Authorize...", false);
                return;
            }

            //---alert
            if (MessageBox.Show(cnMsg_BeforeAuthorize_1, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //strAuth_D = mSys_IN.pcU_M_09_C09_A;

            int nDept_ID = -1;
            int nDept_ID_Store = -1;
            int nBranch_ID = -1;

            double nQty_Item = Convert.ToDouble(gridView1.Columns["I_Qty"].SummaryItem.SummaryValue);
            double nQty_FOC = Convert.ToDouble(gridView1.Columns["I_Qty_FOC"].SummaryItem.SummaryValue);

            if (cmbDept_ID.EditValue != null && cmbDept_ID.EditValue.ToString() != "") nDept_ID = Convert.ToInt32(cmbDept_ID.EditValue.ToString());
            if (cmbDept_ID_Store.EditValue != null && cmbDept_ID_Store.EditValue.ToString() != "") nDept_ID_Store = Convert.ToInt32(cmbDept_ID_Store.EditValue.ToString());
            if (lookBranch_ID.EditValue != null && lookBranch_ID.EditValue.ToString() != "") nBranch_ID = Convert.ToInt32(lookBranch_ID.EditValue.ToString());


            nRet_Val = clsINCS.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                nBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, nQty_FOC, txtRef1.Text, "",
                mSys_System.pTrLevel_Cleared, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsINCS.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINCS.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete+".......................", true);
                lblTrLevel.Text = mSys_System.pTrLevel_Approved.ToString();
                Set_TrLevel();

                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINCS.strErr_Msg, false);
                return;
            }
        }
        private void cmd0_Authorize_Click(object sender, ItemClickEventArgs e)
        {
            Save_Authorize();
        }

        private void cmd0_Rollback_Click(object sender, ItemClickEventArgs e)
        {
            int nRet_Val = 0;
            INCS clsINCS = new INCS();

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
            //strAuth_D = mSys_IN.pcU_M_09_C09_RB;
            int nBranch_ID = 0;
            if (lookBranch_ID.EditValue != null && lookBranch_ID.EditValue.ToString() != "") nBranch_ID = Convert.ToInt32(lookBranch_ID.EditValue.ToString());


            nRet_Val = clsINCS.Save_Rollback(Convert.ToInt32(lblInv_SqNo.Text), Convert.ToInt32(lblTrLevel.Text), mSys_System.pComp_ID, nBranch_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);
            if (clsINCS.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINCS.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, true);
                lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();

                Set_TrLevel();

                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINCS.strErr_Msg, false);
                return;
            }
        }

        private void cmd0_Cancel_Click(object sender, ItemClickEventArgs e)
        {
            INCS clsINCS = new INCS();

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
                if (MessageBox.Show(cnMsg_Before_Cancel, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                //strAuth_D = mSys_IN.pcU_M_09_C09_C;
                int nDept_ID = -1;
                int nDept_ID_Store = -1;
                int nBranch_ID = -1;

                double nQty_Item = Convert.ToDouble(gridView1.Columns["I_Qty"].SummaryItem.SummaryValue);
                double nQty_FOC = Convert.ToDouble(gridView1.Columns["I_Qty_FOC"].SummaryItem.SummaryValue);

                if (cmbDept_ID.EditValue != null && cmbDept_ID.EditValue.ToString() != "") nDept_ID = Convert.ToInt32(cmbDept_ID.EditValue.ToString());
                if (cmbDept_ID_Store.EditValue != null && cmbDept_ID_Store.EditValue.ToString() != "") nDept_ID_Store = Convert.ToInt32(cmbDept_ID_Store.EditValue.ToString());
                if (lookBranch_ID.EditValue != null && lookBranch_ID.EditValue.ToString() != "") nBranch_ID = Convert.ToInt32(lookBranch_ID.EditValue.ToString());
                
                nRet_Val = clsINCS.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                      nBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, nQty_FOC, txtRef1.Text, "",
                      mSys_System.pTrLevel_Cancelled, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

                //            nRet_Val = clsINCS.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), mSys_System.pTrLevel_Cancelled, mSys_System.pComp_ID, mSys_System.pBranch_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D);
                if (clsINCS.strErrorCode.Trim() != "")
                {
                    clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINCS.strErrorCode + "....................", false);
                    return;
                }
                if (nRet_Val == 1)
                {
                    clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, true);
                    lblTrLevel.Text = mSys_System.pTrLevel_Cancelled.ToString();
                    Set_TrLevel();

                    return;
                }
                else if (nRet_Val == -1)
                {
                    clsHomeScreen.Display_Message(clsINCS.strErr_Msg, false);
                    return;
                }
            }
        }

        private void txtAmt_CC_EditValueChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        //private void cmd0_Print_Click(object sender, EventArgs e)
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
        //        strRpt = strRpt.Substring(0, strRpt.Length - 3) + "Reports\\rptIN0022.rpt";

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
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Unit_DD"], string.Empty);
            }

            if (gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, "Item_ID").ToString() == "")
            {

                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_ID"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_D"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Item_ID"], string.Empty);
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Unit_DD"], string.Empty);
            }
            gridControl1.EmbeddedNavigator.NavigatableControl.DoAction(DevExpress.XtraEditors.NavigatorButtonType.EndEdit);

            if (gridView1.Columns["Amount"].SummaryItem.SummaryValue != null)
            {
                txtAmt_Total.Text = Convert.ToDouble(gridView1.Columns["Amount"].SummaryItem.SummaryValue).ToString();
                //txtAmt_R1.Text = Convert.ToDouble(gridView1.Columns["Amt_R1"].SummaryItem.SummaryValue).ToString();
            }
        }
    }
}