using System;
using ERP.DAL;
using System.Data.SqlClient;
using System.Data;

namespace ERP.BLL
{
    public class AC_Accounts
    {
        database1 clsdatabase1 = new database1();
        public string sErrorCode = "";
        public string sErr_Msg = "";
        public string sMain_ID = "";
        public string sCType_ID = "";
        public string sGroup_ID = "";
        public string sDetail_ID = "";
        public string sSub_ID = "";

        public DataSet Fill_Combo(int vComp_ID, int vU_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 6));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_SubCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_CType_ID(int vComp_ID, int vU_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_Accounts", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Main_ID(int vComp_ID, int vU_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 5));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_GroupCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Group_ID(int vComp_ID, int vU_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 5));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_DetailCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Detail(int vComp_ID, int vU_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,7));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_SubCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
       
        public DataSet Fill_Grid(int vComp_ID, int vU_ID,string vSearch)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 4));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_Accounts", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid_1(int vComp_ID, int vU_ID, string vSearch)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 4));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_MainCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid_2(int vComp_ID, int vU_ID, string vSearch)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 4));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_GroupCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid_3(int vComp_ID, int vU_ID, string vSearch)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 4));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_DetailCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid_4(int vComp_ID, int vU_ID, string vSearch)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 4));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_SubCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_Record(int vComp_ID, int vU_ID, int vID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nCType_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 5));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_Accounts", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_Record_1(int vComp_ID, int vU_ID, int vID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nMain_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_MainCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_Record_2(int vComp_ID, int vU_ID, int vID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nGroup_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_GroupCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_Record_3(int vComp_ID, int vU_ID, int vID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_DetailCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_Record_4(int vComp_ID, int vU_ID, int vID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsdatabase1.Get_DS_SP("stpAcc_SubCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public int Save_Update_0(string vCType_ID, string vsCType_D, string vsCType_DD, int vpComp_ID, int vU_ID, string vU_Name,
            int vIsUpdate, string vAuth_D, int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;
            SCmd.Parameters.Clear();

            if (vIsUpdate == 0)
            {
                SCmd.Parameters.Add(new SqlParameter("@nCType_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nCType_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vCType_ID));

            }
            SCmd.Parameters.Add(new SqlParameter("@sCType_D", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vsCType_D));
            SCmd.Parameters.Add(new SqlParameter("@sCType_DD", SqlDbType.VarChar, 70, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vsCType_DD));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            strRecAffected = clsdatabase1.Exec_Int_SP("stpAcc_Accounts", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            if (strRetValue == 1)
            {
                sCType_ID = SCmd.Parameters["@nCType_ID"].ToString();
            }
            return strRetValue;
        }

        public int Save_Update_1(string vMain_ID, string vMain_Code, string vMain_CodeD, string vMain_CodeDD, int vAType_ID,
            //int vCType_ID,
            int vpComp_ID, int vIsUpdate, string vU_Name, int vU_ID, string vAuth_D, int vFY_ID)
        {

            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;

            SCmd.Parameters.Clear();

            if (vIsUpdate == 0)
            {
                SCmd.Parameters.Add(new SqlParameter("@nMain_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nMain_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vMain_ID));

            }

            SCmd.Parameters.Add(new SqlParameter("@sMain_Code", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vMain_Code));
            SCmd.Parameters.Add(new SqlParameter("@sMain_CodeD", SqlDbType.VarChar, 70, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vMain_CodeD));
            SCmd.Parameters.Add(new SqlParameter("@sMain_CodeDD", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vMain_CodeDD));
            if (vAType_ID == -1)
            {
                SCmd.Parameters.Add(new SqlParameter("@nAType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 0));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nAType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vAType_ID));

            }
            //if (vCType_ID == -1)
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nCType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 0));

            //}
            //else
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nCType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vCType_ID));

            //}
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));

            strRecAffected = clsdatabase1.Exec_Int_SP("stpAcc_MainCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            if (strRetValue == 1)
            {
                sMain_ID = SCmd.Parameters["@nMain_ID"].ToString();

            }
            return strRetValue;
        }
        public int Save_Update_2(string vGroup_ID, string vGroup_Code, string vGroup_CodeD, 
            int vMain_ID, int vpComp_ID,bool vGroup_NoDetail,
            int vIsUpdate, string vU_Name, int vU_ID, string vAuth_D, int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;

            SCmd.Parameters.Clear();

            if (vIsUpdate == 0)
            {
                SCmd.Parameters.Add(new SqlParameter("@nGroup_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, 0));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nGroup_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vGroup_ID));

            }
            SCmd.Parameters.Add(new SqlParameter("@sGroup_Code", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vGroup_Code));
            SCmd.Parameters.Add(new SqlParameter("@sGroup_CodeD", SqlDbType.VarChar, 70, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vGroup_CodeD));
            if (vMain_ID == -1)
            {
                SCmd.Parameters.Add(new SqlParameter("@nMain_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 0));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nMain_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vMain_ID));

            }
            SCmd.Parameters.Add(new SqlParameter("@bGroup_NoDetail", SqlDbType.Bit, 1, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vGroup_NoDetail));
            //SCmd.Parameters.Add(new SqlParameter("@bGroup_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vGroup_Active));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            
            strRecAffected = clsdatabase1.Exec_Int_SP("stpAcc_GroupCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            if (strRetValue == 1)
            {
                sGroup_ID = SCmd.Parameters["@nGroup_ID"].ToString();
            }
            return strRetValue;
        }
        public int Save_Update_3(string vDetail_ID, string vDetail_Code, string vDetail_CodeD, int vGroup_ID, int vAccType_ID, string vDetail_CurrID, bool vbDetail_FCY, bool vDetail_Active,
            bool vDetail_SubLedger, 
            //bool vbDetail_AC_1, bool vbDetail_AC_2, bool vbDetail_AC_3,bool vbDetail_AC_4, bool vbDetail_AC_5, bool vbDetail_AC_6, bool vbDetail_AC_7,
            // bool vbDetail_AC_8, bool vDetail_Sub_AZ, 
             int vpComp_ID,
            int vpBranch_ID, int vIsUpdate, string vU_Name, int vU_ID, string vAuth_D, int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;

            SCmd.Parameters.Clear();

            if (vIsUpdate == 0)
            {
                SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vDetail_ID));
            }

            SCmd.Parameters.Add(new SqlParameter("@sDetail_Code", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDetail_Code));
            SCmd.Parameters.Add(new SqlParameter("@sDetail_CodeD", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDetail_CodeD));
            if (vGroup_ID == -1)
            {
                SCmd.Parameters.Add(new SqlParameter("@nGroup_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 0));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nGroup_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vGroup_ID));

            }
            if (vAccType_ID == -1)
            {
                SCmd.Parameters.Add(new SqlParameter("@nAccType_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 0));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nAccType_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vAccType_ID));

            }
            SCmd.Parameters.Add(new SqlParameter("@sDetail_CurrID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDetail_CurrID));
            SCmd.Parameters.Add(new SqlParameter("@bDetail_FCY", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vbDetail_FCY)); //FCY'
            SCmd.Parameters.Add(new SqlParameter("@bDetail_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vDetail_Active)); //active'
            SCmd.Parameters.Add(new SqlParameter("@bDetail_SubLedger", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vDetail_SubLedger)); //active'
            //SCmd.Parameters.Add(new SqlParameter("@bDetail_AC_1", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vbDetail_AC_1)); //active'
            //SCmd.Parameters.Add(new SqlParameter("@bDetail_AC_2", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vbDetail_AC_2)); //active'
            //SCmd.Parameters.Add(new SqlParameter("@bDetail_AC_3", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vbDetail_AC_3)); //active'
            //SCmd.Parameters.Add(new SqlParameter("@bDetail_AC_4", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vbDetail_AC_4)); //active'
            //SCmd.Parameters.Add(new SqlParameter("@bDetail_AC_5", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vbDetail_AC_5)); //active'
            //SCmd.Parameters.Add(new SqlParameter("@bDetail_AC_6", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vbDetail_AC_6)); //active'
            //SCmd.Parameters.Add(new SqlParameter("@bDetail_AC_7", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vbDetail_AC_7)); //active'
            //SCmd.Parameters.Add(new SqlParameter("@bDetail_AC_8 ", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vbDetail_AC_8)); //detial all'
            //SCmd.Parameters.Add(new SqlParameter("@bDetail_Sub_AZ", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vDetail_Sub_AZ)); //detial Sub A-Z'
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            
            strRecAffected = clsdatabase1.Exec_Int_SP("stpAcc_DetailCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            if (strRetValue == 1)
            {
                sDetail_ID = SCmd.Parameters["@nDetail_ID"].Value.ToString();
            }
            return strRetValue;
        }
        public int Save_Update_4(string vSub_ID, string vSub_Code, string vSub_CodeD, bool vSub_Active, int vComp_ID, int vBranch_ID, int vDetail_ID, int vAccType_ID, 
            //int vRgn_ID,int vSCat_ID, int vGCat_ID, 
            string vSub_CurrID, 
            //int vSub_SE, 
            bool vSub_FCY, 
            //int vTType_ID, double vTType_Rate, 
            string vSub_Address1, string vSub_Address2, string vSub_City, string vSub_Province, string vSub_Country, string vSub_Zip, string vSub_Tel,
            //string vSub_Tel_2,  
            string vSub_Email, 
            //string vSub_Ref, 
            string vSub_Contact,
                  string vSub_Contact_Desig, 
                  string vSub_Contact_Tel, 
                  //string vSub_Contact_Tel2, 
                  string vSub_GST, 
                  string vSub_NTN, string vSub_CNIC,
                  //bool vSub_NOU,
                  //bool vSub_GST_Reg,
                  bool vSub_Credit, string vU_Name, int vU_S, int vIsUpdate, string vAuth_D, int vFY_ID
          )
        {
            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;
            int nRet_Val = 0;
            SCmd.Parameters.Clear();
            //parameter
            if (vIsUpdate == 0)
            {
                SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vSub_ID));

            }
            SCmd.Parameters.Add(new SqlParameter("@sSub_Code", SqlDbType.VarChar, 15, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vSub_Code));
            SCmd.Parameters.Add(new SqlParameter("@sSub_CodeD", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_CodeD));
            SCmd.Parameters.Add(new SqlParameter("@bSub_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Active));

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            if (vDetail_ID == -1)
            {
                SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDetail_ID));

            }
            if (vAccType_ID == -1)
            {
                SCmd.Parameters.Add(new SqlParameter("@nAccType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nAccType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vAccType_ID));

            }
            //if (vRgn_ID == -1)
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nRgn_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            //}
            //else
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nRgn_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vRgn_ID));

            //}
            //if (vSCat_ID == -1)
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nSCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            //}
            //else
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nSCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSCat_ID));

            //}
            //if (vGCat_ID == -1)
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nGCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            //}
            //else
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nGCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vGCat_ID));

            //}
            //if (vSub_SE == -1)
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nSub_SE", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            //}
            //else
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nSub_SE", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSub_SE));

            //}
                SCmd.Parameters.Add(new SqlParameter("@sSub_CurrID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_CurrID));
                SCmd.Parameters.Add(new SqlParameter("@bSub_FCY", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_FCY));
            //if (vTType_ID == -1)
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nTType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            //}
            //else
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nTType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vTType_ID));

            //}

            //SCmd.Parameters.Add(new SqlParameter("@nTType_Rate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 2, "", DataRowVersion.Proposed, vTType_Rate));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Address1", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Address1));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Address2", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Address2));
            SCmd.Parameters.Add(new SqlParameter("@sSub_City", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_City));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Province", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Province));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Country", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Country));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Zip", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Zip));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Tel", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Tel));
            //SCmd.Parameters.Add(new SqlParameter("@sSub_Tel_2", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Tel_2));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Email", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Email));
            //SCmd.Parameters.Add(new SqlParameter("@sSub_Ref", SqlDbType.VarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Ref));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Contact", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Contact));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Contact_Desig", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Contact_Desig));
            SCmd.Parameters.Add(new SqlParameter("@sSub_ContactTel", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Contact_Tel));
            //SCmd.Parameters.Add(new SqlParameter("@sSub_Contact_Tel2", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Contact_Tel2));
            SCmd.Parameters.Add(new SqlParameter("@sSub_NTN", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_NTN));
            SCmd.Parameters.Add(new SqlParameter("@sSub_CNIC", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_CNIC));
            //SCmd.Parameters.Add(new SqlParameter("@bSub_GST_Reg", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_GST_Reg));
            SCmd.Parameters.Add(new SqlParameter("@sSub_GST", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_GST));
            //SCmd.Parameters.Add(new SqlParameter("@sSub_D1", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_D1));
            //SCmd.Parameters.Add(new SqlParameter("@sSub_D2", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_D2));
            //SCmd.Parameters.Add(new SqlParameter("@sSub_D3", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_D3));
            //SCmd.Parameters.Add(new SqlParameter("@bSub_NOU", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_NOU));
            SCmd.Parameters.Add(new SqlParameter("@bSub_Credit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Credit));
            //SCmd.Parameters.Add(new SqlParameter("@bSub_AC_1", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_AC_1));
            //SCmd.Parameters.Add(new SqlParameter("@bSub_AC_2", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_AC_2));
            //SCmd.Parameters.Add(new SqlParameter("@bSub_AC_3", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_AC_3));
            //SCmd.Parameters.Add(new SqlParameter("@bSub_AC_4", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_AC_4));
            //SCmd.Parameters.Add(new SqlParameter("@bSub_AC_5", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_AC_5));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));

            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));

            strRecAffected = clsdatabase1.Exec_Int_SP("stpAcc_SubCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            if (strRetValue == 1 && sErrorCode == "")
            {
                sDetail_ID = SCmd.Parameters["@nDetail_ID"].Value.ToString();
            }
            return strRetValue;
        }
        public int Save_Sub_Location(string vSub_ID,int vpComp_ID, int vpBranch_ID, string vU_Name, int vU_ID, string vAuth_D,int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;

            SCmd.Parameters.Clear();
            SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vSub_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 5));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            
            strRecAffected = clsdatabase1.Exec_Int_SP("stpAcc_Accounts_Code_Detail", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            //if (strRetValue == 1)
            //{
            //    str_Detail_ID = SCmd.Parameters["@nDetail_ID"].ToString();
            //}
            return strRetValue;
        }
        public int Save_Deatil_Location(string vDetail_ID,int vpComp_ID, int vpBranch_ID, string vU_Name, int vU_ID, string vAuth_D,int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;

            SCmd.Parameters.Clear();
            SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vDetail_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 5));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            
            strRecAffected = clsdatabase1.Exec_Int_SP("stpAcc_Accounts", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            //if (strRetValue == 1)
            //{
            //    str_Detail_ID = SCmd.Parameters["@nDetail_ID"].ToString();
            //}
            return strRetValue;
        }
        public int Save_Delete_0(int vCType_ID, string vCType_D, int vComp_ID, string vU_Name, int vU_ID, string vAuth_D, int vFY_ID)
        {

            SqlCommand SCmd = new SqlCommand();
            int strRetValue = 0;

            SCmd.Parameters.Add(new SqlParameter("@nCType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vCType_ID));
            SCmd.Parameters.Add(new SqlParameter("@sCType_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vCType_D));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, 6));

            database1 clsDatabase1 = new database1();
            clsDatabase1.Exec_Int_SP("stpAcc_Accounts", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            return strRetValue;
        }
        public int Save_Delete_1(int vMain_ID, string vMain_Code, int vComp_ID, string vU_Name, int vU_ID, string vAuth_D, int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRetValue = 0;
            SCmd.Parameters.Clear();
            SCmd.Parameters.Add(new SqlParameter("@nMain_ID", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vMain_ID));
            SCmd.Parameters.Add(new SqlParameter("@sMain_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vMain_Code));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, 3));
            database1 clsDatabase1 = new database1();
            clsDatabase1.Exec_Int_SP("stpAcc_MainCode", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            return strRetValue;
        }
        public int Save_Delete_2(int vGroup_ID, string vGroup_Code, int vComp_ID, string vU_Name, int vU_ID, string vAuth_D, int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRetValue = 0;

            SCmd.Parameters.Add(new SqlParameter("@nGroup_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vGroup_ID));
            SCmd.Parameters.Add(new SqlParameter("@sGroup_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vGroup_Code));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, 3));
            database1 clsDatabase1 = new database1();
            clsDatabase1.Exec_Int_SP("stpAcc_GroupCode", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            return strRetValue;
        }
        public int Save_Delete_4(int vSub_ID, string vSub_Code, int vpComp_ID, string vU_Name, int vU_ID, string vAuth_D,int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRetValue = 0;

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nSub_ID ", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vSub_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Code));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, 3));
            database1 clsDatabase1 = new database1();
            clsDatabase1.Exec_Int_SP("stpAcc_SubCode", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            return strRetValue;
        }
        public int Save_Delete_3(int vDetial_ID, string vDetail_Code, int vpComp_ID, string vU_Name, int vU_ID, string vAuth_D,int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRetValue = 0;

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDetail_ID ", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDetial_ID));
            SCmd.Parameters.Add(new SqlParameter("@sDetail_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vDetail_Code));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, 3));
            database1 clsDatabase1 = new database1();
            clsDatabase1.Exec_Int_SP("stpAcc_DetailCode", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            return strRetValue;
        }
        public int DeleteSub_Location(int vSub_ID, int vpComp_ID,int vBranch_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRetValue = 0;

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nSub_ID ", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vSub_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 7));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

            database1 clsDatabase1 = new database1();
            clsDatabase1.Exec_Int_SP("stpAcc_SubCode", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            return strRetValue;
        }
        public int DeleteDetail_Location(int vDetial_ID, int vpComp_ID,int vBranch_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int strRetValue = 0;

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDetail_ID ", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDetial_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 7));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

            database1 clsDatabase1 = new database1();
            clsDatabase1.Exec_Int_SP("stpAcc_DetailCode", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            return strRetValue;
        }
        public int Save_Update_Credit(string vSub_ID, int vSub_Credit_S_ID, object vCredit_Date, bool vSub_Credit_Limit, double vSub_Credit_Amt,
            double vSub_Credit_Bal, int vSub_Credit_Days,
            string vU_Name, int vU_S, int vIsUpdate, string vAuth_D, int vFY_ID, DateTime vFYSDate, int vComp_ID
           )
        {
            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;
            int nRet_Val = 0;
            SCmd.Parameters.Clear();
            //parameter
            //if (vIsUpdate == 0)
            //{
            //    SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

            //}
            //else
            {
                SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vSub_ID));

            }
            if (vSub_Credit_S_ID == -1)
            {
                SCmd.Parameters.Add(new SqlParameter("@nSub_Credit_S_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                SCmd.Parameters.Add(new SqlParameter("@dSub_Credit_U_SD", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@nSub_Credit_S_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSub_Credit_S_ID));
                if (vCredit_Date == null)
                {
                    SCmd.Parameters.Add(new SqlParameter("@dSub_Credit_U_SD", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@dSub_Credit_U_SD", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vCredit_Date));
                }
            }

            SCmd.Parameters.Add(new SqlParameter("@bSub_Credit_Limit", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Credit_Limit));
            SCmd.Parameters.Add(new SqlParameter("@nSub_Credit_Amt", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSub_Credit_Amt));
            SCmd.Parameters.Add(new SqlParameter("@nSub_Credit_Bal", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSub_Credit_Bal));
            SCmd.Parameters.Add(new SqlParameter("@nSub_Credit_Days", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSub_Credit_Days));
            //SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 9));
            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@dFYSDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vFYSDate.Date));

            strRecAffected = clsdatabase1.Exec_Int_SP("stpAcc_SubCode", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            try
            {
                sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch
            {

            }
            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
            return strRetValue;
        }

    }
}
