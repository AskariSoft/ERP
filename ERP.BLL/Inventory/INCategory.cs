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
    public class INCategory
    {
        database1 clsDatabase1 = new database1();

        public int str_ID = -1;
        public string str_Code = "";

        public string sErrorCode = "";
        public string strErr_Msg = "";
        public DataSet Fill_Combo(int vComp_ID, int vUser_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 4));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Category", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }

        public DataSet Find_Record(int vComp_ID, int vID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Category", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid(int vComp_ID, int vUser_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 5));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Category", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public int Save_Delete(string vID,int vComp_ID,
            string vU_Name, int vU_S, string vAuth_D)
        {
            int strRowAffected = 0;
            int strRetValue = 0;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nCat_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vID));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 3));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 2000, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));

            strRowAffected = clsDatabase1.Exec_Int_SP("stpInv_Category", SCmd);
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
        public int Save_Master(string vID, string vCode, string vName, int vComp_ID,
            string vU_Name, int vU_ID, int vIsUpdate, string vAuth_D
             )
        {

            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;
            if (vIsUpdate == 0)
            {
                SCmd.Parameters.Add(new SqlParameter("@nCat_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nCat_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vID));

            }
            SCmd.Parameters.Add(new SqlParameter("@sCat_D", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vCode));
            SCmd.Parameters.Add(new SqlParameter("@sCat_DD", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vName));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));

            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));

            strRecAffected = clsDatabase1.Exec_Int_SP("stpInv_Category", SCmd);
            sErrorCode = clsDatabase1.sErrorCode;
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            str_ID = Convert.ToInt32(SCmd.Parameters["@nCat_ID"].Value);
            str_Code = SCmd.Parameters["@sCat_D"].Value.ToString();
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
    }
}
