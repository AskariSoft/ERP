using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace ERP.BLL.Inventory
{
    public class INItem_OB
    {
        database1 clsDatabase1 = new database1();

        public int str_ID;
        public string str_Code;

        public string sErrorCode;
        public string strErr_Msg;

        public string strU_S = "";
        public string strU_U = "";
        public string strPDate = "";
        public string strU_UD = "";

        public DataSet Fill_Combo(int vComp_ID, int vUser_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Item_OB", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Items(int vComp_ID, int vUser_ID, string vGrade_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@sGrade_ID", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vGrade_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 1));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Item_OB", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public int Save_Master(int vBranch_ID, int vDept_ID, List<DataRow> vGrid_Data, DateTime vVrDate, string vGrade_ID,
                        int vComp_ID, string vU_Name, int vU_S, string vAuth_D
             )
        {

            SqlConnection sqlcon = new SqlConnection();
            SqlCommand SCmd = new SqlCommand();
            SqlTransaction Tran = null;
            bool blnTran = true;

            int strRecAffected = 0;
            int strRetValue = 0;
            try
            {
                sqlcon.ConnectionString = clsDatabase1.Getdatabase1();
                sqlcon.Open();
                Tran = sqlcon.BeginTransaction();
                SCmd.Parameters.Clear();

                if (vGrid_Data.Count > 0)
                {
                    foreach (DataRow row in vGrid_Data)
                    {
                        SCmd.Parameters.Clear();
                        if (vBranch_ID == 0)
                            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        else
                            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
                        if (vDept_ID == 0)
                            SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        else
                            SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID));

                        SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, row["Item_ID"]));
                        SCmd.Parameters.Add(new SqlParameter("@dVrDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vVrDate.Date));
                        SCmd.Parameters.Add(new SqlParameter("@sGrade_ID", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vGrade_ID));

                        SCmd.Parameters.Add(new SqlParameter("@nOB_Qty", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, row["OB_Qty"]));
                        SCmd.Parameters.Add(new SqlParameter("@nOB_Rate", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, row["OB_Rate"]));

                        SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
                        SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                        SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
                        SCmd.Parameters.Add(new SqlParameter("@sU_U", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                        SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        SCmd.Parameters.Add(new SqlParameter("@dU_UD", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

                        SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 0));
                        SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
                        SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));

                        strRecAffected = clsDatabase1.Exec_Int_Multi("stpInv_Item_OB", SCmd, sqlcon, Tran);
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
                        if (strRetValue != 1 || sErrorCode != "")
                        {
                            blnTran = false;
                            Tran.Rollback();
                            Tran.Dispose();
                            SCmd.Dispose();
                            sqlcon.Close();
                            return strRetValue;
                        }
                    }
                    if (strRetValue == 1 && sErrorCode == "")
                    {
                        //str_Code = SCmd.Parameters["@sItem_D"].Value.ToString();
                        //str_ID = Convert.ToInt32(SCmd.Parameters["@nItem_ID"].Value);

                        strU_S = SCmd.Parameters["@sU_Name"].Value.ToString();
                        strPDate = SCmd.Parameters["@dPDate"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                blnTran = false;
                Tran.Rollback();
                Tran.Dispose();
                SCmd.Dispose();
                sqlcon.Close();
                sErrorCode = ex.Message;
                return strRetValue = 0;
            }
            finally
            {
                if (blnTran == true)
                {
                    Tran.Commit();
                    Tran.Dispose();
                    SCmd.Dispose();
                    sqlcon.Close();
                }
            }
            return strRetValue;
        }
        public int Save_Delete(int vItem_ID, string sGrade_ID, int vpComp_ID, int vBranch_ID, int vDept_ID_Store, int vU_S, int vIsUpdate,string vAuth_D)
        {

            database1 clsdatabase1 = new database1();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection SConnection = new SqlConnection();
            SConnection.ConnectionString = clsdatabase1.Getdatabase1();
            SConnection.Open();
            SqlCommand Cmm = new SqlCommand("stpInv_Item_OB", SConnection);

            try
            {

                Cmm.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vItem_ID));
                Cmm.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vpComp_ID));
                Cmm.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
                Cmm.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID_Store));
                Cmm.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_S));
                Cmm.Parameters.Add(new SqlParameter("@sGrade_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sGrade_ID));
                Cmm.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
                Cmm.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
                Cmm.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
                Cmm.CommandType = CommandType.StoredProcedure;

                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
            try
            {

                sErrorCode = clsDatabase1.sErrorCode;
            }
            catch (Exception)
            {

                sErrorCode = "";
            }
            int strRetValue = Convert.ToInt32(Cmm.Parameters["@nReturn"].Value);

            return strRetValue;
        }
    }
}
