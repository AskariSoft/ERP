using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using ERP.DAL;

namespace ERP.BLL.AC
{
    public class ACVoucher
    {
        database1 clsDatabase1 = new database1();
        public string Vr_No;
        public int Tr_SqNo;
        public string strErrorCode;
        public string strErr_Msg;
        private int strRet_Val;
        public string str_Code;
        public int str_ID;

        public DataSet Fill_Combo(int vComp_ID, int vUser_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 5));
            ds_1 = clsDatabase1.Get_DS_SP("stpAcc_Tr", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Accounts(int vComp_ID, int vBranch_ID, int vU_S, int vVrType)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@nVrType", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vVrType));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 6));
            ds_1 = clsDatabase1.Get_DS_SP("stpAcc_Tr", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Load_Accounts(int vComp_ID, int vBranch_ID, int vU_S)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 7));

            ds_1 = clsDatabase1.Get_DS_SP("stpAcc_Tr", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid(int vComp_ID, int vBranch_ID, int vVrType, int vTrLevel, object vFrom_Date, object vTo_Date, string vSearch, int vU_S)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nVrType", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vVrType));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vTrLevel));
            if(vFrom_Date == null || vTo_Date == null)
            {
                SCmd.Parameters.Add(new SqlParameter("@dBeg_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now.AddMonths(-5)));
                SCmd.Parameters.Add(new SqlParameter("@dEnd_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
            }
            else
            {
                SCmd.Parameters.Add(new SqlParameter("@dBeg_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(vFrom_Date).Date));
                SCmd.Parameters.Add(new SqlParameter("@dEnd_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(vTo_Date).Date));
            }
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 20));

            ds_1 = clsDatabase1.Get_DS_SP("stpAcc_Tr", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        
        public DataSet Find_Record(int vComp_ID, int vAcc_SqNo)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nAcc_SqNo", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vAcc_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsDatabase1.Get_DS_SP("stpAcc_Tr", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        
        public int Save_Update(string Acc_SqNo, string vTr_No, DateTime vTr_Date, int vComp_ID, int vVrType,
                          int vBank_ID, string vCNo, object vCDate,int vBranch_ID, double vAmt_Total, string vNarration, string vRef1, 
                          List<DataRow> vlstDetail, string vU_Name, int vU_S, int vIsUpdate, string vAuth_D,int vFY_ID
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
                //parameter
                if (vIsUpdate == 0)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nAcc_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nAcc_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, Acc_SqNo));

                }

                SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
                SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
                SCmd.Parameters.Add(new SqlParameter("@nVrType", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vVrType));
                SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 0));
                SCmd.Parameters.Add(new SqlParameter("@sVrNo", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vTr_No));
                SCmd.Parameters.Add(new SqlParameter("@dVrDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTr_Date.Date));
                SCmd.Parameters.Add(new SqlParameter("@nBank_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBank_ID));
                if (vCNo == "")
                {
                    SCmd.Parameters.Add(new SqlParameter("@sCheck_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    SCmd.Parameters.Add(new SqlParameter("@dCheck_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@sCheck_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vCNo));
                    SCmd.Parameters.Add(new SqlParameter("@dCheck_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(vCDate).Date));
                } 
                SCmd.Parameters.Add(new SqlParameter("@sNarration", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vNarration));
                SCmd.Parameters.Add(new SqlParameter("@nAmount_Net", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vAmt_Total));

                SCmd.Parameters.Add(new SqlParameter("@sRef1", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vRef1));

                SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
                SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vFY_ID));
            
                SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
                SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
                SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 500, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));

                strRecAffected = clsDatabase1.Exec_Int_SP("stpAcc_Tr", SCmd);
                strErrorCode = clsDatabase1.sErrorCode.Trim();
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
                strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);

                if (strRetValue != 1 || strErrorCode != "")
                {
                    blnTran = false;
                    Tran.Rollback();
                    Tran.Dispose();
                    SCmd.Dispose();
                    sqlcon.Close();
                    return strRetValue;
                }
                else if (strRetValue == 1)
                {
                    Vr_No = SCmd.Parameters["@sVrNo"].Value.ToString();
                    Tr_SqNo = Convert.ToInt32(SCmd.Parameters["@nAcc_SqNo"].Value);

                    if (vlstDetail.Count > 0)
                    {
                        foreach (DataRow row in vlstDetail)
                        {
                            SCmd.Parameters.Clear();
                            SCmd.Parameters.Add(new SqlParameter("@nAcc_SqNo", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, Tr_SqNo));
                            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
                            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
                            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 0));
                            SCmd.Parameters.Add(new SqlParameter("@sVrNo", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, Vr_No));
                            SCmd.Parameters.Add(new SqlParameter("@dVrDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTr_Date.Date));
            
                            SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["Detail_ID"])));
                            if (row["Sub_ID"] == null || row["Sub_ID"].ToString() == "")
                                SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                            else
                                SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["Sub_ID"])));
                            SCmd.Parameters.Add(new SqlParameter("@sNarration", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, row["Narration"]));
                            SCmd.Parameters.Add(new SqlParameter("@nDr", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["Dr"]));
                            SCmd.Parameters.Add(new SqlParameter("@nCr", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["Cr"]));
                            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));

                            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                            SCmd.Parameters.Add(new SqlParameter("@dU_UD", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

                            SCmd.Parameters.Add(new SqlParameter("@nIndx", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, vlstDetail.IndexOf(row) + 1));
                            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, 4));
                            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.Int, 9, ParameterDirection.ReturnValue, false, 18, 1, "", DataRowVersion.Proposed, 0));
                            strRecAffected = clsDatabase1.Exec_Int_Multi("stpAcc_Tr", SCmd, sqlcon, Tran);
                            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
                            if (strRetValue != 1)
                            {
                                blnTran = false;
                                Tran.Rollback();
                                Tran.Dispose();
                                SCmd.Dispose();
                                sqlcon.Close();
                                return strRetValue;
                            }

                        }
                    }
                    //else
                    //{
                    //    //strRetValue = 0;
                    //}
                }
                else
                {
                    blnTran = false;
                    Tran.Rollback();
                    Tran.Dispose();
                    SCmd.Dispose();
                    sqlcon.Close();
                    strRetValue = 0;
                }
            }
            catch (Exception ex)
            {
                blnTran = false;
                Tran.Rollback();
                Tran.Dispose();
                SCmd.Dispose();
                sqlcon.Close();
                strRetValue = 0;
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
        public int Save_Authorize(int vAcc_SqNo,string vVrNo,int vVrType,DateTime vDVrDate, int vTrLevel, 
             double vAmt_Total, int vComp_ID, int vBranch_ID,DateTime vFYSDate, 
            string vU_Name, int vU_S, string vAuth_D,int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int nRet_Val = 0;
            strErrorCode = "";

            SCmd.Parameters.Clear();
            SCmd.Parameters.Add(new SqlParameter("@nAcc_SqNo", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vAcc_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nVrType", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Default, vVrType));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 0, string.Empty, DataRowVersion.Proposed, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 14));
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 1, "", DataRowVersion.Proposed, 0));

            database1 clsdatabase1 = new database1();
            clsdatabase1.Exec_Int_SP("stpAcc_Tr", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
            try
            {
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch { strErr_Msg = ""; }
            return nRet_Val;
        }
        public int Save_Rollback(int vAcc_SqNo, int vTrLevel, int vVrType, int vComp_ID,
            int vBranch_ID, string vU_Name, int vU_S, string vAuth_D,int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int nRet_Val = 0;
            strErrorCode = "";

            SCmd.Parameters.Clear();
            SCmd.Parameters.Add(new SqlParameter("@nAcc_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vAcc_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 0, string.Empty, DataRowVersion.Proposed, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@nVrType", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 0, string.Empty, DataRowVersion.Proposed, vVrType));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 13));
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 1, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vFY_ID));
            
            database1 clsdatabase1 = new database1();
            clsdatabase1.Exec_Int_SP("stpAcc_Tr", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
            try
            {
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch { strErr_Msg = ""; }
            return nRet_Val;
        }

    }
}
