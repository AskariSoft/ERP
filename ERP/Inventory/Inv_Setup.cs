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
using ERP.DAL;
using ERP.BLL.SYS;
using DevExpress.XtraEditors;
using ERP.BLL.IN;

namespace ERP.Inventory
{
    public partial class Inv_Setup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HomeScreen clsHomeScreen;
        string strAuth_D = "";
        public Inv_Setup()
        {
            InitializeComponent();
            Set_Refresh_0();
            Set_Refresh_1();
            Set_Refresh_2();
            Fill_Grid_0();
            Fill_Grid_1();
            Fill_Grid_2();
            Fill_Combo();
        }
        private void Inv_Setup_Load(object sender, EventArgs e)
        {
            clsHomeScreen = (HomeScreen)this.MdiParent;
        }
        private void Fill_Combo()
        {
            database1 clsdatabase1 = new database1();
            INItem clsINItem = new INItem();
            DataSet ds = new DataSet();
            ds = clsINItem.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINItem.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsdatabase1.sErrorCode ,false);
                return;
            }

            Fill_Cat();
            Fill_SCat();
            Set_Combo(lookIType_ID, ds.Tables[0], "IType_DD", "IType_ID", true);
            Set_Combo(lookSize_ID, ds.Tables[1], "Size_DD", "Size_ID", true);
            Set_Combo(lookUnit_ID, ds.Tables[2], "Unit_DD", "Unit_ID", true);
            Set_Combo(lookA_Unit_ID, ds.Tables[2], "Unit_DD", "Unit_ID", true);

        }
        private void Fill_Cat()
        {
            database1 clsdatabase1 = new database1();
            INCategory clsINCategory = new INCategory();
            DataSet ds = new DataSet();
            ds = clsINCategory.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINCategory.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsdatabase1.sErrorCode, false);
                return;
            }

            Set_Combo(lookCat_ID, ds.Tables[0], "Cat_DD", "Cat_ID", true);
            Set_Combo(lookSub_Cat_ID, ds.Tables[0], "Cat_DD", "Cat_ID", true);

        }
        private void Fill_ByCategory(int vCat_ID)
        {
            database1 clsdatabase1 = new database1();
            INSub_Category clsINSub_Category = new INSub_Category();
            DataSet ds = new DataSet();
            ds = clsINSub_Category.Fill_ByCategory(mSys_System.pComp_ID, mSys_System.pUser_ID, vCat_ID);
            if (clsINSub_Category.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsdatabase1.sErrorCode, false);
                return;
            }

            Set_Combo(lookSCat_ID, ds.Tables[0], "SCat_DD", "SCat_ID", true);

        }
        private void Fill_SCat()
        {
            database1 clsdatabase1 = new database1();
            INSub_Category clsINSub_Category = new INSub_Category();
            DataSet ds = new DataSet();
            ds = clsINSub_Category.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINSub_Category.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsdatabase1.sErrorCode, false);
                return;
            }

            Set_Combo(lookSCat_ID, ds.Tables[0], "SCat_DD", "SCat_ID", true);

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

        private void Set_Refresh_0()
        {
            lblCat_ID.Text = "";
            txtCat_D.Text = "";
            txtCat_DD.Text = "";
        }
        private void Set_Refresh_1()
        {
            lblSCat_ID.Text = "";
            txtSCat_D.Text = "";
            txtSCat_DD.Text = "";
            lookSub_Cat_ID.EditValue = null;
            lookSub_Cat_ID.Text = "";

        }
        private void Set_Refresh_2()
        {
            lblItem_ID.Text = "";
            txtItem_D.Text = "";
            txtItem_DD.Text = "";
            txtItem_BarCode.Text = "";
            txtItem_SrNo.Text = "";
            txtMin_Level.Text = "0";
            txtMax_Level.Text = "0";
            txtItem_Rate.Text = "0";

            lookCat_ID.EditValue = null;
            lookCat_ID.Text = "";
            lookSCat_ID.EditValue = null;
            lookSCat_ID.Text = "";
            lookIType_ID.EditValue = null;
            lookIType_ID.Text = "";
            lookSize_ID.EditValue = null;
            lookSize_ID.Text = "";
            lookUnit_ID.EditValue = null;
            lookUnit_ID.Text = "";
            lookA_Unit_ID.EditValue = null;
            lookA_Unit_ID.Text = "";

            chkIsA_Unit.Checked = false;
            chkItem_Active.Checked = false;
            chkItem_A1.Checked = false;
            chkItem_A2.Checked = false;
            chkItem_A3.Checked = false;
            chkItem_A4.Checked = false;
            chkItem_A5.Checked = false;

        }
        
        private void Fill_Grid_0()
        {
            database1 clsdatabase1 = new database1();
            INCategory clsINCategory = new INCategory();
            DataSet ds = new DataSet();
            ds = clsINCategory.Fill_Grid(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINCategory.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsdatabase1.sErrorCode ,false);
                return;
            }
            DataTable dt = ds.Tables[0];
            gridControl_Cat.DataSource = dt;
        }
        private void Fill_Grid_1()
        {
            database1 clsdatabase1 = new database1();
            INSub_Category clsINSub_Category = new INSub_Category();
            DataSet ds = new DataSet();
            ds = clsINSub_Category.Fill_Grid(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsINSub_Category.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsdatabase1.sErrorCode ,false);
                return;
            }
            DataTable dt = ds.Tables[0];
            gridControl_SCat.DataSource = dt;
        }
        private void Fill_Grid_2()
        {
            database1 clsdatabase1 = new database1();
            INItem clsINItem = new INItem();
            DataSet ds = new DataSet();
            ds = clsINItem.Fill_Grid(mSys_System.pComp_ID, mSys_System.pUser_ID,"");
            if (clsINItem.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsdatabase1.sErrorCode ,false);
                return;
            }
            DataTable dt = ds.Tables[0];
            gridControl_Item.DataSource = dt;
        }
        private void Find_Record(int ID)
        {
            database1 clsdatabase1 = new database1();
            INCategory clsINCategory = new INCategory();
            DataSet ds = new DataSet();
            ds = clsINCategory.Find_Record(mSys_System.pComp_ID, ID);
            if (clsINCategory.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsdatabase1.sErrorCode ,false);
                return;
            }
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lblCat_ID.Text = dt.Rows[i]["Cat_ID"].ToString();
                txtCat_D.Text = dt.Rows[i]["Cat_D"].ToString();
                txtCat_DD.Text = dt.Rows[i]["Cat_DD"].ToString();
            }
        }
        private void Find_Record_1(int ID)
        {
            database1 clsdatabase1 = new database1();
            INSub_Category clsINSub_Category = new INSub_Category();
            DataSet ds = new DataSet();
            ds = clsINSub_Category.Find_Record(mSys_System.pComp_ID, ID);
            if (clsINSub_Category.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINSub_Category.sErrorCode ,false);
                return;
            }

            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lblSCat_ID.Text = dt.Rows[i]["SCat_ID"].ToString();
                txtSCat_D.Text = dt.Rows[i]["SCat_D"].ToString();
                txtSCat_DD.Text = dt.Rows[i]["SCat_DD"].ToString();
                lookSub_Cat_ID.EditValue = (dt.Rows[i]["Cat_ID"] == null || dt.Rows[i]["Cat_ID"].ToString() == "") ? null : dt.Rows[i]["Cat_ID"];
            }
        }
        private void Find_Record_2(int ID)
        {
            database1 clsdatabase1 = new database1();
            INItem clsINItem = new INItem();
            DataSet ds = new DataSet();
            ds = clsINItem.Find_Record(mSys_System.pComp_ID, ID);
            if (clsINItem.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsdatabase1.sErrorCode ,false);
                return;
            }

            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lblItem_ID.Text = dt.Rows[i]["Item_ID"].ToString();
                txtItem_D.Text = dt.Rows[i]["Item_D"].ToString();
                txtItem_DD.Text = dt.Rows[i]["Item_DD"].ToString();
                txtItem_Rate.Text = dt.Rows[i]["Item_Rate"].ToString();
                txtItem_SrNo.Text = dt.Rows[i]["Item_SrNo"].ToString();
                txtMax_Level.Text = dt.Rows[i]["Max_Level"].ToString();
                txtMin_Level.Text = dt.Rows[i]["Min_Level"].ToString();
                txtA_UnitFactor.Text = dt.Rows[i]["A_UnitFactor"].ToString();
                txtItem_BarCode.Text = dt.Rows[i]["Item_BarCode"].ToString();

                lookUnit_ID.EditValue = (dt.Rows[i]["Unit_ID"] == null || dt.Rows[i]["Unit_ID"].ToString() == "") ? null : dt.Rows[i]["Unit_ID"];
                lookA_Unit_ID.EditValue = (dt.Rows[i]["A_Unit_ID"] == null || dt.Rows[i]["A_Unit_ID"].ToString() == "") ? null : dt.Rows[i]["A_Unit_ID"];
                lookCat_ID.EditValue = (dt.Rows[i]["Cat_ID"] == null || dt.Rows[i]["Cat_ID"].ToString() == "") ? null : dt.Rows[i]["Cat_ID"];
                lookSCat_ID.EditValue = (dt.Rows[i]["SCat_ID"] == null || dt.Rows[i]["SCat_ID"].ToString() == "") ? null : dt.Rows[i]["SCat_ID"];
                lookIType_ID.EditValue = (dt.Rows[i]["IType_ID"] == null || dt.Rows[i]["IType_ID"].ToString() == "") ? null : dt.Rows[i]["IType_ID"];
                lookSize_ID.EditValue = (dt.Rows[i]["Size_ID"] == null || dt.Rows[i]["Size_ID"].ToString() == "") ? null : dt.Rows[i]["Size_ID"];

                chkItem_Active.Checked = Convert.ToBoolean(dt.Rows[i]["Item_Active"]);
                chkIsA_Unit.Checked = Convert.ToBoolean(dt.Rows[i]["IsA_Unit"]);
                chkItem_A1.Checked = Convert.ToBoolean(dt.Rows[i]["Item_A1"]);
                chkItem_A2.Checked = Convert.ToBoolean(dt.Rows[i]["Item_A2"]);
                chkItem_A3.Checked = Convert.ToBoolean(dt.Rows[i]["Item_A3"]);
                chkItem_A4.Checked = Convert.ToBoolean(dt.Rows[i]["Item_A4"]);
                chkItem_A5.Checked = Convert.ToBoolean(dt.Rows[i]["Item_A5"]);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
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
        }

        private void Save_Category()
        {
            int IsUpdate = 0;
            if (lblCat_ID.Text != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate(IsUpdate))
            {
                return;
            }
            if (Save_Update(IsUpdate))
            {
                Fill_Grid_0();
                Fill_Cat();
            }
        }
        private bool Save_Validate(int IsUpdate)
        {
            if (IsUpdate == 1)
            {
                if (lblCat_ID.Text == "")
                {
                    clsHomeScreen.Display_Message("Please select record to Update",false);
                    txtCat_D.Focus();
                    return false;
                }
            }
            //if (txtCat_D.Text == "")
            //{
            //    clsHomeScreen.Display_Message("Please enter Category Code", false);
            //    txtCat_D.Focus();
            //    return false;
            //}
            if (txtCat_DD.Text == "")
            {
                clsHomeScreen.Display_Message("Please enter Category Description", false);
                txtCat_DD.Focus();
                return false;
            }

            return true;
        }
        private bool Save_Update(int IsUpdate)
        {
            INCategory clsINCategory = new INCategory();
            int Ret_Value = 0;

            if (IsUpdate == 0)
            {
                //---alert
                //strAuth_D = mSys_IN.pcU_M_01_C01_S;

                //if (MessageBox.Show(Msg_BeforeSave, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return false;
                //}

            }
            else if (IsUpdate == 1) //---update
            {
                //strAuth_D = mSys_IN.pcU_M_01_C01_U;

                ////---alert
                //if (MessageBox.Show(Msg_BeforeUpdate, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return false;
                //}
            }
            Ret_Value = clsINCategory.Save_Master(lblCat_ID.Text, txtCat_D.Text.Trim(), txtCat_DD.Text.Trim(),
                mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, IsUpdate, strAuth_D);
            if (clsINCategory.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINCategory.sErrorCode + "......",false);
                return false;
            }
            if (Ret_Value == -1)
            {
                clsHomeScreen.Display_Message(clsINCategory.strErr_Msg + "....................",false);
                return false;
            }
            if (Ret_Value == 0)
            {
                clsHomeScreen.Display_Message("ERROR SAVING/UPDATION RECORDS....................",false);
                return false;
            }
            if (Ret_Value == 1)
            {
                txtCat_D.Text = clsINCategory.str_Code;
                lblCat_ID.Text = clsINCategory.str_ID.ToString();
                clsHomeScreen.Display_Message("RECORDS SAVED/UPDATED SUCCESSFULLY....................",true);
                Set_Refresh_0();
            }
            return true;
        }

        private void cmd0_Delete_Click(object sender, EventArgs e)
        {
            INCategory clsINCategory = new INCategory();
            int Ret_Value = 0;
            if (lblCat_ID.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please select a record first to delete....................",false);
                return;
            }
            //if (MessageBox.Show(Msg_BeforeDelete_1, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}

            //if (MessageBox.Show(Msg_BeforeDelete_2, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}
            //strAuth_D = mSys_IN.pcU_M_01_C01_D;
            Ret_Value = clsINCategory.Save_Delete(lblCat_ID.Text,
                mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D);
            if (clsINCategory.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINCategory.sErrorCode + "......",false);
                return;
            }
            if (Ret_Value == -1)
            {
                clsHomeScreen.Display_Message(clsINCategory.strErr_Msg + "....................",false);
                return;
            }
            if (Ret_Value == 0)
            {
                clsHomeScreen.Display_Message("ERROR SAVING/UPDATING RECORD....................",false);
                return;
            }
            if (Ret_Value == 1)
            {
                clsHomeScreen.Display_Message("RECOD HAVE BEEN SAVED/UPDATED SUCCESSFULLT....................",false);
                Set_Refresh_0();
                Fill_Grid_0();
                Fill_Cat();
                return;
            }

        }
        private void cmd0_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridControl_Cat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gridView_Cat.DataRowCount > 0)
            {
                object vID = gridView_Cat.GetRowCellValue(gridView_Cat.FocusedRowHandle, "Cat_ID");
                if (vID != null && vID.ToString() != "")
                    Find_Record(Convert.ToInt32(vID));
            }
        }
        
        private void Save_SCat()
        {
            int IsUpdate = 0;
            if (lblSCat_ID.Text != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate_1(IsUpdate))
            {
                return;
            }
            if (Save_Update_1(IsUpdate))
            {
                Fill_Grid_1();
            }
        }
        private bool Save_Validate_1(int IsUpdate)
        {
            if (IsUpdate == 1)
            {
                if (lblSCat_ID.Text == "")
                {
                    clsHomeScreen.Display_Message("Please select record to Update",false);
                    txtSCat_DD.Focus();
                    return false;
                }
            }
            if (txtSCat_DD.Text == "")
            {
                clsHomeScreen.Display_Message("Please enter Sub category",false);
                txtSCat_DD.Focus();
                txtSCat_DD.SelectAll();
                return false;
            }
            if (lookSub_Cat_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please select category",false);
                lookSub_Cat_ID.Focus();
                return false;
            }

            return true;
        }
        private bool Save_Update_1(int IsUpdate)

        {
            INSub_Category clsINSub_Category = new INSub_Category();
            int Ret_Value = 0;

            if (IsUpdate == 0)
            {
                //---alert
                //strAuth_D = mSys_IN.pcU_M_01_C01_S;

                //if (MessageBox.Show(Msg_BeforeSave, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return false;
                //}

            }
            else if (IsUpdate == 1) //---update
            {
                //strAuth_D = mSys_IN.pcU_M_01_C01_U;

                ////---alert
                //if (MessageBox.Show(Msg_BeforeUpdate, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{

                //    return false;
                //}
            }

            int Cat_ID = 0;
            if (lookSub_Cat_ID.EditValue != null && lookSub_Cat_ID.EditValue.ToString() != "") Cat_ID = Convert.ToInt32(lookSub_Cat_ID.EditValue);

            Ret_Value = clsINSub_Category.Save_Master(lblSCat_ID.Text, txtSCat_D.Text.Trim(), txtSCat_DD.Text.Trim(), Cat_ID,
                mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, IsUpdate, strAuth_D);
            if (clsINSub_Category.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINSub_Category.sErrorCode + "......",false);
                return false;
            }
            if (Ret_Value == -1)
            {
                clsHomeScreen.Display_Message(clsINSub_Category.strErr_Msg + "....................",false);
                return true;
            }
            if (Ret_Value == 0)
            {
                clsHomeScreen.Display_Message("ERROR SAVING/UPDATING RECORDS....................",false);
                return true;
            }
            if (Ret_Value == 1)
            {
                txtSCat_D.Text = clsINSub_Category.str_Code;
                lblSCat_ID.Text = clsINSub_Category.str_ID.ToString();
                clsHomeScreen.Display_Message("SAVED/UPDATED SUCCESSFULLY....................", false);
                Set_Refresh_1();
                Fill_SCat();
                return true;
            }

            return true;
        }
        private void cmd1_Delete_Click(object sender, EventArgs e)
        {
            INSub_Category clsINSub_Category = new INSub_Category();
            int Ret_Value = 0;
            if (lblSCat_ID.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please select a record first to delete....................",false);
                return;
            }
            //if (MessageBox.Show(Msg_BeforeDelete_1, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}

            //if (MessageBox.Show(Msg_BeforeDelete_2, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}
            //strAuth_D = mSys_IN.pcU_M_01_C01_D;


            Ret_Value = clsINSub_Category.Save_Delete(lblSCat_ID.Text,
                mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D);
            if (clsINSub_Category.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINSub_Category.sErrorCode + "......",false);
                return;
            }
            if (Ret_Value == -1)
            {
                clsHomeScreen.Display_Message(clsINSub_Category.strErr_Msg + "....................",false);
                return;
            }
            if (Ret_Value == 0)
            {
                clsHomeScreen.Display_Message("ERROR SAVING/UPDATING RECORDS....................",false);
                return;
            }
            if (Ret_Value == 1)
            {
                clsHomeScreen.Display_Message("SAVED/UPDATED SUCCESSFULLY....................",false);
                Set_Refresh_1();
                Fill_Grid_1();
                Fill_SCat();
                return;
            }

        }
        
        private void gridControl_SCat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gridView_SCat.DataRowCount > 0)
            {
                object vID = gridView_SCat.GetRowCellValue(gridView_SCat.FocusedRowHandle, "SCat_ID").ToString();
                if (vID != null && vID.ToString() != "")
                    Find_Record_1(Convert.ToInt32(vID));
            }
        }
        
        private void Save_Item()
        {
            int IsUpdate = 0;
            if (lblItem_ID.Text != "")
            {
                IsUpdate = 1;
            }
            if (!Save_Validate_3(IsUpdate))
            {
                return;
            }
            if (Save_Update_2(IsUpdate))
            {
                Fill_Grid_2();
            }
        }
        private bool Save_Validate_2(int IsUpdate)
        {
            if (IsUpdate == 1)
            {
                if (lblItem_ID.Text == "")
                {
                    clsHomeScreen.Display_Message("Please select record to Update",false);
                    return false;
                }
            }
            if (txtItem_DD.Text == "")
            {
                clsHomeScreen.Display_Message("Please enter Item Name",false);
                return false;
            }

            return true;
        }
        private bool Save_Validate_3(int IsUpdate)
        {
            if (IsUpdate == 1)
            {
                if (lblItem_ID.Text == "")
                {
                    clsHomeScreen.Display_Message("Please select record to Update",false);
                    txtItem_DD.Focus();
                    return false;
                }
            }
            if(lookCat_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please enter Category", false);
                lookCat_ID.Focus();
                return false;
            }
            if (lookSCat_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please enter Sub Category", false);
                lookSCat_ID.Focus();
                return false;
            }
            if (txtItem_DD.Text == "")
            {
                clsHomeScreen.Display_Message("Please enter Item Name",false);
                txtItem_DD.Focus();
                return false;
            }
            if (lookIType_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please enter Item Type", false);
                lookIType_ID.Focus();
                return false;
            }
            //if (lookSize_ID.EditValue == null)
            //{
            //    clsHomeScreen.Display_Message("Please enter Item Size", false);
            //lookSize_ID.Focus();
            //    return false;
            //}
            if (lookUnit_ID.EditValue == null)
            {
                clsHomeScreen.Display_Message("Please enter Item Unit", false);
                lookUnit_ID.Focus();
                return false;
            }
            if(chkIsA_Unit.Checked)
            {
                if (lookA_Unit_ID.EditValue == null)
                {
                    clsHomeScreen.Display_Message("Please enter Item Alternative Unit", false);
                    lookA_Unit_ID.Focus();
                    return false;
                }
                if (txtA_UnitFactor.Text == "")
                {
                    clsHomeScreen.Display_Message("Please Enter Unit Factor", false);
                    txtA_UnitFactor.Focus();
                    return false;
                }
            }
            return true;
        }
        private bool Save_Update_2(int IsUpdate)

        {
            INItem clsINItem = new INItem();
            int Ret_Value = 0;

            if (IsUpdate == 0)
            {
                //---alert
                //strAuth_D = mSys_IN.pcU_M_01_C01_S;

                //if (MessageBox.Show(Msg_BeforeSave, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return false;
                //}

            }
            else if (IsUpdate == 1) //---update
            {
                //strAuth_D = mSys_IN.pcU_M_01_C01_U;

                ////---alert
                //if (MessageBox.Show(Msg_BeforeUpdate, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return false;
                //}
            }
            int vCat_ID = 0;
            int vSCat_ID = 0;
            int vIType_ID = 0;
            int vSize_ID = 0;
            int vUnit_ID = 0;
            int vA_Unit_ID = 0;
            double vA_UnitFactor = 0;
            double vMin_Level = 0;
            double vMax_Level = 0;


            if (lookCat_ID.EditValue != null && lookCat_ID.EditValue.ToString() != "") vCat_ID = Convert.ToInt32(lookCat_ID.EditValue);
            if (lookSCat_ID.EditValue != null && lookSCat_ID.EditValue.ToString() != "") vSCat_ID = Convert.ToInt32(lookSCat_ID.EditValue);
            if (lookIType_ID.EditValue != null && lookIType_ID.EditValue.ToString() != "") vIType_ID = Convert.ToInt32(lookIType_ID.EditValue);
            if (lookSize_ID.EditValue != null && lookSize_ID.EditValue.ToString() != "") vSize_ID = Convert.ToInt32(lookSize_ID.EditValue);
            if (lookUnit_ID.EditValue != null && lookUnit_ID.EditValue.ToString() != "") vUnit_ID = Convert.ToInt32(lookUnit_ID.EditValue);
            if (lookA_Unit_ID.EditValue != null && lookA_Unit_ID.EditValue.ToString() != "") vA_Unit_ID = Convert.ToInt32(lookA_Unit_ID.EditValue);
            if (txtA_UnitFactor.Text.Trim() != "") vA_UnitFactor = Convert.ToDouble(txtA_UnitFactor.Text.Trim());
            if (txtMin_Level.Text.Trim() != "") vMin_Level = Convert.ToDouble(txtMin_Level.Text.Trim());
            if (txtMax_Level.Text.Trim() != "") vMax_Level = Convert.ToDouble(txtMax_Level.Text.Trim());

            Ret_Value = clsINItem.Save_Master(lblItem_ID.Text, txtItem_D.Text.Trim(), txtItem_DD.Text.Trim(),
                vCat_ID,vSCat_ID,vIType_ID,vSize_ID,vUnit_ID,vA_Unit_ID,txtItem_BarCode.Text.Trim(),txtItem_SrNo.Text.Trim(),
                vMin_Level,vMax_Level,vA_UnitFactor, chkItem_Active.Checked,
                chkItem_A1.Checked, chkItem_A2.Checked, chkItem_A3.Checked, chkItem_A4.Checked, chkItem_A5.Checked,
                chkIsA_Unit.Checked,mSys_System.pComp_ID, mSys_System.pBranch_ID, mSys_System.pUser_Dept_ID, mSys_System.pUserName, mSys_System.pUser_ID, 
                IsUpdate, strAuth_D);
            if (clsINItem.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINItem.sErrorCode + "......",false);
                return false;
            }
            if (Ret_Value == -1)
            {
                clsHomeScreen.Display_Message(clsINItem.strErr_Msg + "....................",false);
                return true;
            }
            if (Ret_Value == 0)
            {
                clsHomeScreen.Display_Message("ERROR SAVING/UPDATING RECORDS....................",false);
                return true;
            }
            if (Ret_Value == 1)
            {
                txtItem_D.Text = clsINItem.str_Code;
                lblItem_ID.Text = clsINItem.str_ID.ToString();
                Set_Refresh_2();
                clsHomeScreen.Display_Message("RECORDS SAVED SUCCESSFULLY....................",true);
                return true;
            }

            return true;
        }
        private void cmb2_Delete_Click(object sender, EventArgs e)
        {
            INItem clsINItem = new INItem();
            int Ret_Value = 0;
            if (lblItem_ID.Text.Trim() == "")
            {
                clsHomeScreen.Display_Message("Please select a record first to delete....................",false);
                return;
            }
            //if (MessageBox.Show(Msg_BeforeDelete_1, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}

            //if (MessageBox.Show(Msg_BeforeDelete_2, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}
            //strAuth_D = mSys_IN.pcU_M_01_C01_D;

            Ret_Value = clsINItem.Save_Delete(lblItem_ID.Text,
                mSys_System.pComp_ID, mSys_System.pUserName, mSys_System.pUser_ID, strAuth_D);
            if (clsINItem.sErrorCode != "")
            {
                clsHomeScreen.Display_Message(clsINItem.sErrorCode + "......",false);
                return;
            }
            if (Ret_Value == -1)
            {
                clsHomeScreen.Display_Message(clsINItem.strErr_Msg + "....................",false);
                return;
            }
            if (Ret_Value == 0)
            {
                clsHomeScreen.Display_Message("ERROR SAVEING/UPDATIN RECORDS....................",false);
                return;
            }
            if (Ret_Value == 1)
            {
                clsHomeScreen.Display_Message("RECORDS SAVED SUCCESSFULLY....................",false);
                Set_Refresh_2();
                Fill_Grid_2();
                return;
            }

        }
        
        private void InvSetup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        
        private void gridView_Item_DoubleClick(object sender, EventArgs e)
        {
            if (gridView_Item.DataRowCount > 0)
            {
                object vID = gridView_Item.GetRowCellValue(gridView_Item.FocusedRowHandle, "Item_ID");
                if (vID != null && vID.ToString() != "")
                    Find_Record_2(Convert.ToInt32(vID));
            }
        }

        private void btnNew_Click(object sender, ItemClickEventArgs e)
        {
            if(Tab_Main.SelectedPage == Tab_P1)
            {
                Set_Refresh_0();
            }
            if (Tab_Main.SelectedPage == Tab_P2)
            {
                Set_Refresh_0();
            }
            if (Tab_Main.SelectedPage == Tab_P3)
            {
                Set_Refresh_0();
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Tab_Main.SelectedPage == Tab_P1)
            {
                Save_Category();
            }
            if (Tab_Main.SelectedPage == Tab_P2)
            {
                Save_SCat();
            }
            if (Tab_Main.SelectedPage == Tab_P3)
            {
                Save_Item();
            }
        }

        private void lookCat_ID_EditValueChanged(object sender, EventArgs e)
        {
            if(lookCat_ID.EditValue != null)
            {
                Fill_ByCategory(Convert.ToInt32(lookCat_ID.EditValue));
            }
        }
    }
}