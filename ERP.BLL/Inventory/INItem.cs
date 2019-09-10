using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace ERP.BLL.IN
{
    public class INItem
    {
        database1 clsDatabase1 = new database1();

        public int str_ID;
        public string str_Code;

        public string sErrorCode;
        public string strErr_Msg;

        public DataSet Fill_Combo(int vComp_ID, int vUser_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 4));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Item", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }

        public DataSet Fill_SCat(int vComp_ID, int vUser_ID, int vCat_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nCat_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vCat_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 5));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Item", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid(int vComp_ID, int vUser_ID,string vSearch)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 6));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Item", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_Record(int vComp_ID, int vItem_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vItem_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Item", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public int Save_Delete(string vID, int vComp_ID,
            string vU_Name, int vU_ID, string vAuth_D)
        {
            int strRowAffected = 0;
            int strRetValue = 0;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vID));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 3));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 2000, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            strRowAffected = clsDatabase1.Exec_Int_SP("stpInv_Item", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            try
            {
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();

            }
            catch
            {
                strErr_Msg = "";
            }
            return strRetValue;
        }
        public int Save_Master(string vID, string vCode, string vName,int vCat_ID, int vSCat_ID, int vIType_ID,
                       int vSize_ID,int vUnit_ID, int vA_Unit_ID, string vBarCode, string vItem_SrNo,
                       double vMin_Level, double vMax_Level, double vA_UnitFactor, bool vActive, bool vA1, 
                       bool vA2, bool vA3, bool vA4, bool vA5, bool vIsA_Unit, int vComp_ID, int vBranch_ID, int vDept_ID,
                       string vU_Name, int vU_ID,int vIsUpdate, string vAuth_D
             )
        {

            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;
            try
            {
                SCmd.Parameters.Clear();
                if (vIsUpdate == 0)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vID));
                }
                SCmd.Parameters.Add(new SqlParameter("@sItem_D", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vCode));
                SCmd.Parameters.Add(new SqlParameter("@sItem_DD", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vName));
                
                if (vCat_ID == 0)
                    SCmd.Parameters.Add(new SqlParameter("@nCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                else
                    SCmd.Parameters.Add(new SqlParameter("@nCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vCat_ID));

                if (vSCat_ID == 0)
                    SCmd.Parameters.Add(new SqlParameter("@nSCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                else
                    SCmd.Parameters.Add(new SqlParameter("@nSCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSCat_ID));

                if (vSize_ID == 0)
                    SCmd.Parameters.Add(new SqlParameter("@nSize_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                else
                    SCmd.Parameters.Add(new SqlParameter("@nSize_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSize_ID));

                if (vIType_ID == 0)
                    SCmd.Parameters.Add(new SqlParameter("@nIType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                else
                    SCmd.Parameters.Add(new SqlParameter("@nIType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIType_ID));

                if (vUnit_ID == 0)
                    SCmd.Parameters.Add(new SqlParameter("@nUnit_ID", SqlDbType.VarChar, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                else
                    SCmd.Parameters.Add(new SqlParameter("@nUnit_ID", SqlDbType.VarChar, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUnit_ID));
                if (vIsA_Unit)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nA_Unit_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vA_Unit_ID));
                    SCmd.Parameters.Add(new SqlParameter("@nA_UnitFactor", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vA_UnitFactor));
                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nA_Unit_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    SCmd.Parameters.Add(new SqlParameter("@nA_UnitFactor", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                
                SCmd.Parameters.Add(new SqlParameter("@nMin_Level", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vMin_Level));
                SCmd.Parameters.Add(new SqlParameter("@nMax_Level", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vMax_Level));
                //SCmd.Parameters.Add(new SqlParameter("@nItem_Rate", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vItem_Rate));

                SCmd.Parameters.Add(new SqlParameter("@bItem_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vActive));
                SCmd.Parameters.Add(new SqlParameter("@bItem_A1", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vA1));
                SCmd.Parameters.Add(new SqlParameter("@bItem_A2", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vA2));
                SCmd.Parameters.Add(new SqlParameter("@bItem_A3", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vA3));
                SCmd.Parameters.Add(new SqlParameter("@bItem_A4", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vA4));
                SCmd.Parameters.Add(new SqlParameter("@bItem_A5", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vA5));
                SCmd.Parameters.Add(new SqlParameter("@bIsA_Unit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vIsA_Unit));

                SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
                SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID));
                SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));

                SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
                SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
                SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));

                strRecAffected = clsDatabase1.Exec_Int_SP("stpInv_Item", SCmd);
                sErrorCode = clsDatabase1.sErrorCode;
                strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
                try
                {
                    strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();

                }
                catch
                {
                    strErr_Msg = "";
                }
                if (strRetValue == 1 && sErrorCode == "")
                {
                    str_Code = SCmd.Parameters["@sItem_D"].Value.ToString();
                    str_ID = Convert.ToInt32(SCmd.Parameters["@nItem_ID"].Value);
                }
                return strRetValue;
            }
            catch (Exception ex)
            {
                sErrorCode = ex.Message;
                return strRetValue = 0;
            }
        }
    }
}
