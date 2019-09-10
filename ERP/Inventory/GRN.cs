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

namespace ERP.Inventory
{
    public partial class GRN : RibbonForm
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

        public GRN()
        {
            InitializeComponent();
            Fill_Combo();
            Set_Refresh();
        }
        public GRN(int vID)
        {
            InitializeComponent();
            Set_Refresh();
            Fill_Combo();
        }

        private void GRN_Load(object sender, EventArgs e)
        {
            clsHomeScreen = (HomeScreen)this.MdiParent;
        }
        private void Fill_Combo()
        {
            database1 clsdatabase1 = new database1();
            INGRN clsINGRN = new INGRN();
            DataSet ds = clsINGRN.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINGRN.sErrorCode != "")
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
            Fill_SCat();
        }
        private void Fill_SCat()
        {
            INGRN clsINGRN = new INGRN();
            DataSet ds = clsINGRN.Fill_SCat(mSys_System.pComp_ID, mSys_System.pUser_ID);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row["SCat_DD"] = string.Empty;
            row["SCat_ID"] = 0;
            dt.Rows.InsertAt(row, 0);
            repositoryItemLookUpEdit3.DataSource = dt;
            repositoryItemLookUpEdit3.ValueMember = "SCat_ID";
            repositoryItemLookUpEdit3.DisplayMember = "SCat_DD";
            gridView1.Columns["SCat_ID"].ColumnEdit = repositoryItemLookUpEdit3;
        }

        private void Fill_Items(int SCat_ID)
        {
            INGRN clsINGRN = new INGRN();
            DataSet ds = clsINGRN.Fill_Items(mSys_System.pComp_ID, mSys_System.pUser_ID, SCat_ID);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row["Unit_DD"] = string.Empty;
            row["Item_Rate"] = 0;
            row["Item_DD"] = string.Empty;
            row["Item_ID"] = 0;
            dt.Rows.InsertAt(row, 0);
            repositoryItemLookUpEdit2.DataSource = dt;
            repositoryItemLookUpEdit2.ValueMember = "Item_ID";
            repositoryItemLookUpEdit2.DisplayMember = "Item_DD";
            gridView1.Columns["Item_ID"].ColumnEdit = repositoryItemLookUpEdit2;

        }

        private void Set_Refresh()
        {
            lblInv_SqNo.Text = "";
            txtTr_No.Text = "";
            txtTr_No.ReadOnly = true;

            txtRef1.Text = "";
            txtGP_No.Text = "";
            txtInv_No.Text = "";
            txtAmt_Bal.Text = "";
            txtAmt_Cash.Text = "";
            txtAmt_CC.Text = "";
            txtAmt_Item.Text = "";
            txtAmt_Total.Text = "";
            txtAmt_Dis.Text = "";
            txtCurr_Rate.Text = "1";

            lblTrLevel.Text = "";
            lblTrLevelD.Text = "";


            cmbDept_ID.EditValue = mSys_System.pUser_Dept_ID;
            cmbDept_ID_Store.EditValue = -1;
            cmbCC.EditValue = -1;
            lookCredit_ID.EditValue = -1;

            lblCurrID.Text = "PKR";

            rdbPO_D.EditValue = 0;
            dtpTr_Date.EditValue = DateTime.Now;
            dtpGP_Date.EditValue = DateTime.Now;
            Set_DataSource();
            gridView1.AddNewRow();
            Set_TrLevel();
        }
        private void Set_TrLevel()
        {
            if (lblTrLevel.Text == mSys_System.pTrLevel_Pending.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Pending_D;
                lblTrLevelD.ForeColor = Color.Red;

                btn_Under_Insp.Enabled = true;
                btn_Insp_Done.Enabled = false;
                btn_Rollback.Enabled = false;
                btn_Authorize.Enabled = false;
                btn_Cancel.Enabled = true;
            }
            else if (lblTrLevel.Text == mSys_System.pTrLevel_Under_Inspection.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Under_Inspection_D;
                lblTrLevelD.ForeColor = Color.Red;
                lblTrLevel.ForeColor = Color.Red;

                btn_Under_Insp.Enabled = false;
                btn_Insp_Done.Enabled = true;
                btn_Rollback.Enabled = true;
                btn_Authorize.Enabled = false;
                btn_Cancel.Enabled = true;
            }
            else if (lblTrLevel.Text == mSys_System.pTrLevel_Inspection_Done.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Inspection_Done_D;
                lblTrLevelD.ForeColor = Color.Red;
                lblTrLevel.ForeColor = Color.Red;

                btn_Under_Insp.Enabled = false;
                btn_Insp_Done.Enabled = false;
                btn_Rollback.Enabled = true;
                btn_Authorize.Enabled = true;
                btn_Cancel.Enabled = true;
            }
            else if (lblTrLevel.Text == mSys_System.pTrLevel_Cleared.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cleared_D;
                lblTrLevel.ForeColor = Color.Green;
                lblTrLevelD.ForeColor = Color.Green;

                btn_Under_Insp.Enabled = false;
                btn_Insp_Done.Enabled = false;
                btn_Rollback.Enabled = true;
                btn_Authorize.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            else if (lblTrLevel.Text == mSys_System.pTrLevel_Cancelled.ToString())
            {
                lblTrLevelD.Text = mSys_System.pTrLevel_Cancelled_D;
                lblTrLevel.ForeColor = Color.Red;
                lblTrLevelD.ForeColor = Color.Red;

                btn_Under_Insp.Enabled = false;
                btn_Insp_Done.Enabled = false;
                btn_Rollback.Enabled = false;
                btn_Authorize.Enabled = false;
                btn_Cancel.Enabled = false;
            }
            if (lblTrLevel.Text == "")
            {
                lblTrLevelD.Text = "";
                lblTrLevelD.ForeColor = Color.Red;

                btn_Under_Insp.Enabled = true;
                btn_Insp_Done.Enabled = false;
                btn_Rollback.Enabled = false;
                btn_Authorize.Enabled = false;
                btn_Cancel.Enabled = true;
            }
        }

        private DataTable Set_Grid()
        {
            DataTable dt_1 = new DataTable("tbl");

            dt_1.Columns.Add("SCat_ID", typeof(int)).DefaultValue = -1;
            dt_1.Columns.Add("Item_ID", typeof(int)).DefaultValue = -1;
            dt_1.Columns.Add("Unit_DD", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("R_Qty", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Rate", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("R_Rate_FCY", typeof(double)).DefaultValue = 0;
            //dt_1.Columns.Add("R_Rate_Min", typeof(double)).DefaultValue = 0;
            //dt_1.Columns.Add("R_Rate_Max", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Rate_1", typeof(double)).DefaultValue = 0;
            dt_1.Columns.Add("Ref4", typeof(string)).DefaultValue = "";
            return dt_1;
        }
        private void Find_Record(int ID)
        {
            database1 clsdatabase1 = new database1();
            INGRN clsINGRN = new INGRN();
            DataSet ds = new DataSet();
            ds = clsINGRN.Find_Record(mSys_System.pComp_ID, ID);
            if (clsINGRN.sErrorCode != "")
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
            Calculation();
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

            if (txtInv_No.Text == "")
            {
                clsHomeScreen.Display_Message("Please enter Invoice No.", false);
                txtInv_No.Focus();
                return false;
            }
            return true;
        }
        private void cmd0_Save_Click(object sender, EventArgs e)
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
            INGRN clsINGRN = new INGRN();
            int Ret_Value = 0;
            if (IsUpdate == 0)
            {
                //---alert
                //strAuth_D = mSys_IN.pcU_M_01_C07_S;
                if (MessageBox.Show(Msg_BeforeSave, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }

            }
            else if (IsUpdate == 1) //---update
            {
                //strAuth_D = mSys_IN.pcU_M_01_C07_U;
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
                    if (gridView1.GetRowCellValue(i, "Item_ID").ToString() != "-1")
                    {
                        row["Item_ID"] = gridView1.GetRowCellValue(i, "Item_ID");
                        row["SCat_ID"] = gridView1.GetRowCellValue(i, "SCat_ID");
                        row["R_Qty"] = gridView1.GetRowCellValue(i, "R_Qty");
                        row["R_Rate"] = gridView1.GetRowCellValue(i, "R_Rate");
                        row["R_Rate_FCY"] = gridView1.GetRowCellValue(i, "R_Rate_FCY");
                        row["Rate_1"] = gridView1.GetRowCellValue(i, "Rate_1");
                        row["Ref4"] = gridView1.GetRowCellValue(i, "Ref4");
                        //row["Item_ID"] = gridView1.GetRowCellValue(i, "Item_ID");
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
            TrType = lblPO_For.Text.Trim();

            double Amt_Cash = txtAmt_Cash.Text == "" ? 0 : Convert.ToDouble(txtAmt_Cash.Text);
            double Amt_CC = txtAmt_CC.Text == "" ? 0 : Convert.ToDouble(txtAmt_CC.Text);
            double Amt_Bal = txtAmt_Bal.Text == "" ? 0 : Convert.ToDouble(txtAmt_Bal.Text);
            double Amt_Item = txtAmt_Item.Text == "" ? 0 : Convert.ToDouble(txtAmt_Item.Text);
            double Amt_Total = txtAmt_Total.Text == "" ? 0 : Convert.ToDouble(txtAmt_Total.Text);
            double Amt_Dis = txtAmt_Dis.Text == "" ? 0 : Convert.ToDouble(txtAmt_Dis.Text);
            double Qty_Item = Convert.ToDouble(gridView1.Columns["R_Qty"].SummaryItem.SummaryValue);
            double Curr_Rate = txtCurr_Rate.Text == "" ? 1 : Convert.ToDouble(txtCurr_Rate.Text);
            //double GST_Total = txtAmt_R1.Text == "" ? 1 : Convert.ToDouble(txtAmt_R1.Text);
            double GST_Total = Convert.ToDouble(gridView1.Columns["Amt_R1"].SummaryItem.SummaryValue);

            if (cmbCC.EditValue != null && cmbCC.EditValue.ToString() != "") CC = Convert.ToInt32(cmbCC.EditValue.ToString());
            if (lookCredit_ID.EditValue != null && lookCredit_ID.EditValue.ToString() != "") Credit_ID = Convert.ToInt32(lookCredit_ID.EditValue.ToString());
            if (cmbDept_ID.EditValue != null && cmbDept_ID.EditValue.ToString() != "") Dept_ID = Convert.ToInt32(cmbDept_ID.EditValue.ToString());
            if (cmbDept_ID_Store.EditValue != null && cmbDept_ID_Store.EditValue.ToString() != "") Dept_ID_Store = Convert.ToInt32(cmbDept_ID_Store.EditValue.ToString());
            if (lblTrLevel.Text != "")
            {

                nTrLevel = Convert.ToInt32(lblTrLevel.Text);
            }

            Ret_Value = clsINGRN.Save_Master(lblInv_SqNo.Text, txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue),
                        lblCurrID.Text.Trim(), Curr_Rate, GST_Total, Qty_Item,
                        Convert.ToInt32(lookSub_ID.GetColumnValue("Detail_ID")), Convert.ToInt32(lookSub_ID.GetColumnValue("Detail_ID")), Dept_ID, Dept_ID_Store, mSys_System.pBranch_ID,
                        Credit_ID, TrType, txtInv_No.Text.Trim(), txtGP_No.Text.Trim(), Convert.ToDateTime(dtpGP_Date.EditValue), txtRef1.Text,
                        Amt_Cash, Amt_CC, Amt_Dis, Amt_Item, Amt_Total, Amt_Bal, CC, Child, mSys_System.pComp_ID,
                        mSys_System.pUserName, mSys_System.pUser_ID, nTrLevel, IsUpdate, strAuth_D
                        );
            if (clsINGRN.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINGRN.sErrorCode + "......", false);
                return false;
            }
            if (Ret_Value == -1)
            {
                clsHomeScreen.Display_Message(clsINGRN.strErr_Msg + "....................", false);
                return false;
            }
            if (Ret_Value == 0)
            {
                clsHomeScreen.Display_Message(Msg_ErrSaveUpdate + "....................", false);
                return false;
            }
            if (Ret_Value == 1)
            {
                txtTr_No.Text = clsINGRN.str_Code;
                lblInv_SqNo.Text = clsINGRN.str_ID.ToString();

                //lblU_S.Text = clsINGRN.strU_S;
                //lblPDate.Text = clsINGRN.strPDate;
                //lblU_U.Text = clsINGRN.strU_U;
                //lblU_UD.Text = clsINGRN.strU_UD;

                clsHomeScreen.Display_Message(Msg_SaveUpdateComplete + "....................", true);
            }

            return true;
        }

        private void cmd0_Under_Insp_Click(object sender, EventArgs e)
        {
            int nRet_Val = 0;
            INGRN clsINGRN = new INGRN();

            if (lblInv_SqNo.Text == "")
            {
                clsHomeScreen.Display_Message("Please select a record for Under Inspection...", false);
                return;
            }

            //---user authorizations
            //if (!(pUser_Auth(pcU_M_09_C03_D, 1, 1)))
            //{
            //    return;
            //}

            //---alert
            if (MessageBox.Show(cnMsg_Before_Under_Inspection, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //strAuth_D = mSys_IN.pcU_M_01_C07A_A;


            int nDept_ID = -1;
            int nDept_ID_Store = -1;
            int nBranch_ID = -1;

            double nQty_FOC = 0;
            double nQty_Accepted = 0;
            double nQty_Item = nQty_FOC + nQty_Accepted;



            nRet_Val = clsINGRN.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                nBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, txtRef1.Text, txtRef1.Text,
                mSys_System.pTrLevel_Under_Inspection, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsINGRN.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINGRN.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, true);
                lblTrLevel.Text = mSys_System.pTrLevel_Under_Inspection.ToString();
                Set_TrLevel();
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINGRN.strErr_Msg, false);
                return;
            }
        }

        private void cmd0_Insp_Done_Click(object sender, EventArgs e)
        {
            int nRet_Val = 0;
            INGRN clsINGRN = new INGRN();

            if (lblInv_SqNo.Text == "")
            {
                clsHomeScreen.Display_Message("Please select a record for Inspection Done...", false);
                return;
            }

            //---user authorizations
            //if (!(pUser_Auth(pcU_M_09_C03_D, 1, 1)))
            //{
            //    return;
            //}

            //---alert
            if (MessageBox.Show(cnMsg_Before_Inspection_Done, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //strAuth_D = mSys_IN.pcU_M_01_C07B_A;

            int nDept_ID = -1;
            int nDept_ID_Store = -1;
            int nBranch_ID = -1;

            //double nQty_FOC = Convert.ToDouble(gridView1.Columns["R_Qty_FOC"].SummaryItem.SummaryValue);
            //double nQty_Accepted = Convert.ToDouble(gridView1.Columns["R_Qty_Accepted"].SummaryItem.SummaryValue);
            double nQty_Item = 0;




            nRet_Val = clsINGRN.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                nBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, txtRef1.Text, txtRef1.Text,
                mSys_System.pTrLevel_Inspection_Done, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);


            if (clsINGRN.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINGRN.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, true);
                lblTrLevel.Text = mSys_System.pTrLevel_Inspection_Done.ToString();
                Set_TrLevel();
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINGRN.strErr_Msg, false);
                return;
            }
        }

        private void cmd0_Authorize_Click(object sender, EventArgs e)
        {
            INGRN clsINGRN = new INGRN();

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


            //strAuth_D = mSys_IN.pcU_M_01_C07C_A;
            nRet_Val = clsINGRN.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                nBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, txtRef1.Text, txtRef1.Text,
                mSys_System.pTrLevel_Cleared, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsINGRN.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINGRN.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, true);
                lblTrLevel.Text = mSys_System.pTrLevel_Approved.ToString();
                Set_TrLevel();
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINGRN.strErr_Msg, false);
                return;
            }
        }

        private void cmd0_Rollback_Click(object sender, EventArgs e)
        {
            int nRet_Val = 0;
            INGRN clsINGRN = new INGRN();

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
            //strAuth_D = mSys_IN.pcU_M_01_C07D_RB;
            nRet_Val = clsINGRN.Save_Rollback(Convert.ToInt32(lblInv_SqNo.Text), Convert.ToInt32(lblTrLevel.Text), mSys_System.pComp_ID, mSys_System.pBranch_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);
            if (clsINGRN.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINGRN.strErrorCode + "....................", false);
                return;
            }
            if (nRet_Val == 1)
            {
                clsHomeScreen.Display_Message(cnMsg_SaveUpdateComplete, true);
                if (lblTrLevel.Text == mSys_System.pTrLevel_Under_Inspection.ToString())
                    lblTrLevel.Text = mSys_System.pTrLevel_Pending.ToString();
                else if (lblTrLevel.Text == mSys_System.pTrLevel_Inspection_Done.ToString())
                    lblTrLevel.Text = mSys_System.pTrLevel_Under_Inspection.ToString();
                else if (lblTrLevel.Text == mSys_System.pTrLevel_Cleared.ToString())
                    lblTrLevel.Text = mSys_System.pTrLevel_Inspection_Done.ToString();

                Set_TrLevel();
                return;
            }
            else if (nRet_Val == -1)
            {
                clsHomeScreen.Display_Message(clsINGRN.strErr_Msg, false);
                return;
            }
        }

        private void cmd0_Cancel_Click(object sender, EventArgs e)
        {
            INGRN clsINGRN = new INGRN();

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


            //strAuth_D = mSys_IN.pcU_M_01_C07_C;
            nRet_Val = clsINGRN.Save_Authorize(Convert.ToInt32(lblInv_SqNo.Text), txtTr_No.Text.Trim(), Convert.ToDateTime(dtpTr_Date.EditValue), mSys_System.pFYSDate,
                nBranch_ID, nDept_ID, nDept_ID_Store, nQty_Item, txtRef1.Text, txtRef1.Text,
                mSys_System.pTrLevel_Cancelled, mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D, mSys_System.pFY_ID);

            if (clsINGRN.strErrorCode.Trim() != "")
            {
                clsHomeScreen.Display_Message(cnMsg_ErrSaveUpdate + clsINGRN.strErrorCode + "....................", false);
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
                clsHomeScreen.Display_Message(clsINGRN.strErr_Msg, false);
                return;
            }
        }

        private void txtAmt_CC_EditValueChanged(object sender, EventArgs e)
        {
            Calculation();
        }
        private void repositoryItemLookUpEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {


        }

        private void repositoryItemLookUpEdit2_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            DataRowView Look_Row = repositoryItemLookUpEdit2.GetDataSourceRowByKeyValue(e.Value) as DataRowView;
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Unit_DD", Look_Row.Row["Unit_DD"]);
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "R_Rate", Look_Row.Row["Item_Rate"]);
        }

        private void btn_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Set_Refresh();
        }

        private void repositoryItemLookUpEdit3_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            DataRowView Look_Row = repositoryItemLookUpEdit3.GetDataSourceRowByKeyValue(e.Value) as DataRowView;
            if (Look_Row != null)
            {
                Fill_Items(Convert.ToInt32(e.Value));
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "SCat_ID", Look_Row.Row["SCat_ID"]);
                gridView1.FocusedColumn = gridView1.Columns["Item_ID"];
            }
        }

        private void repositoryItemLookUpEdit3_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

        }

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
        //    rptParamDiscreteValue.EditValue = mSys_System.pComp_ID.ToString();
        //    rptParamField.CurrentValues.Add(rptParamDiscreteValue);
        //    rptParamFields.Add(rptParamField);

        //    rptParamField = new ParameterField();
        //    rptParamDiscreteValue = new ParameterDiscreteValue();
        //    rptParamField.Name = "@nInv_SqNo";
        //    rptParamDiscreteValue.EditValue = lblInv_SqNo.Text;
        //    rptParamField.CurrentValues.Add(rptParamDiscreteValue);
        //    rptParamFields.Add(rptParamField);

        //    try
        //    {
        //        strRpt = Application.StartupPath;
        //        strRpt = strRpt.Substring(0, strRpt.Length - 3) + "Reports\\rptIN0020.rpt";

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
        //    formulaList["Criteria1"].Text = "'Goods Receipt Notes'";
        //    formulaList["RPT"].Text = "'" + strRptNo + "'";
        //    formulaList["UserName"].Text = "'" + mSys_System.pUser_FullName + "'";

        //    //---Passing Selection formula
        //    rptDocument.DataDefinition.RecordSelectionFormula = "";

        //    //---Setting Report to view
        //    frmRptViewer.crv.ParameterFieldInfo = rptParamFields;
        //    frmRptViewer.crv.ReportSource = rptDocument;
        //    frmRptViewer.Show();
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

    }
}