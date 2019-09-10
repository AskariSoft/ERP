using System;
using ERP.DAL;
using System.Data.SqlClient;
using System.Data;

namespace ERP.BLL
{
    public class AC_OB
    {
        database1 clsdatabase1 = new database1();
        public string sErrorCode = "";
        public string sErr_Msg = "";
        public string sDetail_ID = "";
        public string sSub_ID = "";

        public DataSet Fill_Combo(int vComp_ID, int vU_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 3));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_OB", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Account(int vComp_ID, int vBranch_ID, int vU_ID, bool IsSub_Acc)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vBranch_ID));
            if(IsSub_Acc)
            {
                SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 5));
            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 4));
            }
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_OB", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid(int vComp_ID, int vU_ID,string vSearch, bool IsSub_Acc)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 6));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_OB", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_Record(int vComp_ID, int vU_ID, int vID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nOB_SrNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_OB", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public int Save_Update(int vDetail_ID, string vSub_ID, double vDr,double vCr,bool vSubLedger,int vComp_ID, 
            int vBranch_ID, int vU_ID, string vU_Name, int vIsUpdate, DateTime vFYSDate,DateTime vFYEDate,
            string vAuth_D, int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;
            SCmd.Parameters.Clear();

            SCmd.Parameters.Add(new SqlParameter("@nOB_SrNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@dFYSDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFYSDate.Date));
            SCmd.Parameters.Add(new SqlParameter("@dFYEDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFYEDate.Date));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            if (vSub_ID == "")
                SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
            else
                SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, Convert.ToInt32(vSub_ID)));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@bSubLedger", SqlDbType.Bit, 1, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vSubLedger));
            SCmd.Parameters.Add(new SqlParameter("@nDr", SqlDbType.Money, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vDr));
            SCmd.Parameters.Add(new SqlParameter("@nCr", SqlDbType.Money, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vCr));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));

            strRecAffected = clsdatabase1.Exec_Int_SP("stpAcc_OB", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch{ sErr_Msg = ""; }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            return strRetValue;
        }
        
    }
}
