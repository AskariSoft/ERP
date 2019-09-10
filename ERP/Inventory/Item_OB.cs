using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using ERP.DAL;
using ERP.BLL.SYS;
using ERP.BLL.Inventory;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace ERP.Inventory
{
    public partial class Item_OB : RibbonForm
    {
        
        #region Date Members
        HomeScreen clsHomeScreen;
        private string strAuth_D = "";
        #endregion

        public Item_OB()
        {
            InitializeComponent();
            Set_Refresh();
            Fill_Combo();
        }
        private void Item_OB_Load(object sender, EventArgs e)
        {
            clsHomeScreen = (HomeScreen)this.MdiParent;
        }
        private void Fill_Combo()
        {
            database1 clsdatabase1 = new database1();
            INItem_OB clsINItem_OB = new INItem_OB();
            DataSet ds = new DataSet();
            ds = clsINItem_OB.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINItem_OB.sErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }

            Set_Combo(lookBranch_ID, ds.Tables[0], "Branch_SName", "Branch_ID", true);
            Set_Combo(lookDept_ID_Store, ds.Tables[1], "Dept_DD", "Dept_ID", true);
            Set_Combo(lookGrade_ID, ds.Tables[2], "Grade_ID", "Grade_ID", false);
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

        private void Set_Refresh()
        {
            lookBranch_ID.EditValue = null;
            lookDept_ID_Store.EditValue = null;
            lookGrade_ID.EditValue = null;

            Fill_Grid();
        }
        private void Fill_Grid()
        {
            gridControl1.DataSource = Set_Grid();
            gridView1.AddNewRow();
            Fill_Items();
        }
        private void Fill_Items()
        {
            database1 clsdatabase1 = new database1();
            INItem_OB clsINItem_OB = new INItem_OB();
            DataSet ds = new DataSet();
            ds = clsINItem_OB.Fill_Items(mSys_System.pComp_ID, mSys_System.pUser_ID, lookGrade_ID.Text);
            if (clsINItem_OB.sErrorCode != "")
            {
                clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsdatabase1.sErrorCode + "'", false);
                return;
            }
            DataTable dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row["Item_DD"] = string.Empty;
            row["Item_ID"] = 0;
            dt.Rows.InsertAt(row, 0);
            repositoryItemLookUpEdit1.DataSource = dt;
            repositoryItemLookUpEdit1.ValueMember = "Item_ID";
            repositoryItemLookUpEdit1.DisplayMember = "Item_DD";
            gridView1.Columns["Item_DD"].ColumnEdit = repositoryItemLookUpEdit1;

        }
        private DataTable Set_Grid()
        {
            DataTable dt_1 = new DataTable("tbl");

            dt_1.Columns.Add("Item_DD", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("OB_Qty", typeof(string)).DefaultValue = "";
            dt_1.Columns.Add("OB_Rate", typeof(string)).DefaultValue = "";
            return dt_1;
        }
        private bool Save_Validate()
        {
            bool check = false;
            if (lookBranch_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please select Location",false);
                lookBranch_ID.Focus();
                return false;
            }
            if (lookDept_ID_Store.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please select Department", false);
                lookDept_ID_Store.Focus();
                return false;
            }
            if (lookGrade_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please select Grade", false);
                lookGrade_ID.Focus();
                return false;
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                object vItem_ID = gridView1.GetRowCellValue(i, "Item_DD");
                if (vItem_ID != null && vItem_ID.ToString() != "")
                {
                    object vOB_Qty = gridView1.GetRowCellValue(i, "OB_Qty");
                    if (vOB_Qty == null || vOB_Qty.ToString() == "" || Convert.ToDouble(vOB_Qty) == 0D)
                    {
                        clsHomeScreen.Display_Message("Item Quantity cannot be 0/empty at row " + (i + 1) + ", please check............", false);
                        return false;
                    }
                    check = true;
                }
            }

            if (gridView1.DataRowCount >= 0 && !check)
            {
                clsHomeScreen.Display_Message("please enter some data into grid to proceed............",false);
                gridView1.Focus();
                return false;
            }
            return true;
        }
        private bool Save_Update()
        {
            INItem_OB clsINItem_OB = new INItem_OB();
            int Ret_Value = 0;
            //strAuth_D = mSys_IN.pcU_M_01_C03_S;

            //---alert
            //if (MessageBox.Show(Msg_BeforeSave, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return false;
            //}


            int Branch_ID = 0;
            int Dept_ID = 0;

            if (lookBranch_ID.EditValue != null && lookBranch_ID.EditValue.ToString() != "") Branch_ID = Convert.ToInt32(lookBranch_ID.EditValue.ToString());
            if (lookDept_ID_Store.EditValue != null && lookDept_ID_Store.EditValue.ToString() != "") Dept_ID = Convert.ToInt32(lookDept_ID_Store.EditValue.ToString());

            DataTable dt = gridControl1.DataSource as DataTable;
            foreach (DataRow dRow in dt.Rows)
            {
                object vItem_ID = dRow["Item_ID"];
                if (vItem_ID == null && vItem_ID.ToString() != "")
                {
                    dt.Rows.Remove(dRow);
                }
            }
            List<DataRow> Grid_Data = new List<DataRow>(dt.Select());

            Ret_Value = clsINItem_OB.Save_Master(Branch_ID, Dept_ID, Grid_Data, mSys_System.pFYSDate, lookGrade_ID.Text,
                        mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D
                        );
            if (clsINItem_OB.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINItem_OB.sErrorCode + "......", false);
                return false;
            }
            if (Ret_Value == -1)
            {
                clsHomeScreen.Display_Message(clsINItem_OB.strErr_Msg + "....................", false);
                return false;
            }
            if (Ret_Value == 0)
            {
                clsHomeScreen.Display_Message("ERROR SAVING/UPDATING RECORDS....................", false);
                return false;
            }
            if (Ret_Value == 1)
            {
                clsHomeScreen.Display_Message("RECORDS SAVED/UPDATED SUCCESSFULLY....................", false);
                Fill_Grid();
            }

            return true;
        }
        
        private void repositoryItemLookUpEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            GridView view = gridView1;

            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            DataRow lookupRow = gridLookUpEdit.Properties.View.GetFocusedDataRow();
            if (lookupRow != null)
            {
                string Description = lookupRow["Item_DD"].ToString();
                int ID = Convert.ToInt32(lookupRow["Item_ID"]);
                string Code = lookupRow["Item_D"].ToString();
                string Qty = lookupRow["OB_Qty"].ToString();
                string Rate = lookupRow["OB_Rate"].ToString();

                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_DD"], Description);
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_ID"], ID);
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Item_D"], Code);
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["OB_Qty"], Qty);
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["OB_Rate"], Rate);
                gridView1.FocusedColumn = gridView1.Columns["OB_Qty"];

            }
            gridView1.ShowEditor();
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            int row = gridView1.FocusedRowHandle;
            if (e.KeyCode == Keys.Enter && gridView1.IsLastRow && gridView1.FocusedColumn.Name == "OB_Rate")
            {
                if (gridView1.GetRowCellValue(row, "Item_ID").ToString() != "" && !(gridView1.HasColumnErrors))
                {
                    gridView1.CloseEditor();
                    gridView1.AddNewRow();
                }
            }
            if (e.KeyCode == Keys.Enter && gridView1.FocusedColumn.Name == "OB_Rate")
            {
                if (gridView1.GetRowCellValue(row, "Item_DD").ToString() == "")
                    gridView1.FocusedColumn = gridView1.Columns["Item_DD"];
            }
            if (e.KeyCode == Keys.Tab)
            {
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            int row = gridView1.FocusedRowHandle;
            if (e.KeyCode == Keys.Down && row == gridView1.RowCount - 1)
            {
                if (gridView1.GetRowCellValue(row, "Item_ID").ToString() != "" && !(gridView1.HasColumnErrors))
                {
                    gridView1.CloseEditor();
                    gridView1.AddNewRow();
                }
            }
            if (e.Shift && e.KeyCode == Keys.Delete)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }

        private void cmbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Grid();
        }
        
        private void btnNew_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Set_Refresh();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Save_Validate())
            {
                return;
            }

            if (Save_Update())
            {
                Fill_Grid();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                INItem_OB clsINItem_OB = new INItem_OB();
                object vItem_ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Item_ID").ToString();
                //strAuth_D = mSys_IN.pcU_M_01_C03_D;
                int Ret_Value = clsINItem_OB.Save_Delete(Convert.ToInt32(vItem_ID), lookGrade_ID.Text, mSys_System.pComp_ID, mSys_System.pBranch_ID, Convert.ToInt32(lookDept_ID_Store.EditValue), mSys_System.pUser_ID, 3, strAuth_D);
                if (clsINItem_OB.sErrorCode != "")
                {
                    clsHomeScreen.Display_Message("MsgDBError : " + " '" + clsINItem_OB.sErrorCode + "'", false);
                    return;
                }
                if (Ret_Value == 1)
                {
                    clsHomeScreen.Display_Message("RECORDS DELETED SUCCESSFULLY....................", false);
                    Fill_Grid();
                }
                if (Ret_Value == -4)
                {
                    clsHomeScreen.Display_Message("Please select a valid record to delete....................", false);
                    Fill_Grid();
                }


            }

        private void repositoryItemLookUpEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            object vID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Item_DD");
            object LRow = repositoryItemLookUpEdit1.GetDataSourceRowByKeyValue(vID);
        }
    }
}