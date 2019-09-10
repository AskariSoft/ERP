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
    public class INGRN
    {
        database1 clsDatabase1 = new database1();

        public int str_ID;
        public string str_Code;

        public string sErrorCode;
        public string strErr_Msg;

        public string strUser_ID = "";
        public string strU_U = "";
        public string strPDate = "";
        public string strU_UD = "";
        public string strErrorCode;

        public DataSet Fill_Combo(int vComp_ID, int vUser_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 3));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_GRN", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Combo(int vComp_ID, int vUser_ID,int vBranch_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 9));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_GRN", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_SCat(int vComp_ID, int vUser_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 5));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_GRN", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Items(int vComp_ID, int vUser_ID, int vSCat_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nSCat_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSCat_ID));
            SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 10));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_GRN", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid(int vTrLevel, int vBranch, int vDept_ID, int nDept_ID_Store_1, string strSearch_1, string strSearch_2, string strSearch_3, string dtpBegDate, string dtpEndDate, int vComp_ID, int vUser_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vTrLevel));
            //SCmd.Parameters.Add(new SqlParameter("@sSub_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_CodeD));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, strSearch_1));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch));
            SCmd.Parameters.Add(new SqlParameter("@dBeg_Date", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, dtpBegDate));
            SCmd.Parameters.Add(new SqlParameter("@dEnd_Date", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, dtpEndDate));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 11));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_GRN", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_Record(int vComp_ID, int vItem_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vItem_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_GRN", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public int Save_Delete(string Inv_SqNo, int vComp_ID,
            string vU_Name, int vUser_ID, string vAuth_D)
        {
            int strRowAffected = 0;
            int strRetValue = 0;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, Inv_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
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
        public int Save_Master(string Inv_SqNo, string vTr_No, DateTime vTr_Date,
                               string vCurrID, double vCurr_Rate, double vAmt_R1, double vQty_Total,
                               int vDetail_ID, int vSub_ID,
                               int vDept_ID, int vDept_ID_Store, int vBranch_ID,
                               int vCredit_ID, string vTrType, string vInv_No, string vGP_No, DateTime vGP_Date, string vRef1,
                               double vAmt_Cash, double vAmt_CC, double vAmt_Dis, double vTotal_Value, double vAmt_Total,
                               double vAmt_Bal, int vCC, List<DataRow> vChild_List,
                               int vComp_ID, string vU_Name, int vUser_ID, int vTrLevel,
                               int vIsUpdate, string vAuth_D
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
                if (vIsUpdate == 0)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, Inv_SqNo));

                }
                SCmd.Parameters.Add(new SqlParameter("@sTr_No", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vTr_No));
                SCmd.Parameters.Add(new SqlParameter("@dTr_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTr_Date.Date));
                SCmd.Parameters.Add(new SqlParameter("@sGP_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vGP_No));
                SCmd.Parameters.Add(new SqlParameter("@dGP_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vGP_Date.Date));
                SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
                if (vDept_ID == 0)
                    SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                else
                    SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID));

                if (vDept_ID_Store == 0)
                    SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                else
                    SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID_Store));

                if (vCC == 0)
                    SCmd.Parameters.Add(new SqlParameter("@nCC", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                else
                    SCmd.Parameters.Add(new SqlParameter("@nCC", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vCC));

                if (vCredit_ID == 0)
                    SCmd.Parameters.Add(new SqlParameter("@nCredit_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                else
                    SCmd.Parameters.Add(new SqlParameter("@nCredit_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vCredit_ID));

                SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSub_ID));
                SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDetail_ID));

                SCmd.Parameters.Add(new SqlParameter("@sCurrID", SqlDbType.VarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vCurrID));
                if (vCurr_Rate <= 0)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nCurr_Rate", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, 1));
                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nCurr_Rate", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vCurr_Rate));

                }
                SCmd.Parameters.Add(new SqlParameter("@sTrType_ID", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTrType));
                SCmd.Parameters.Add(new SqlParameter("@sFile_No", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 4, "", DataRowVersion.Proposed, vInv_No));
                SCmd.Parameters.Add(new SqlParameter("@sRef1", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 4, "", DataRowVersion.Proposed, vRef1));

                SCmd.Parameters.Add(new SqlParameter("@nQty_Total", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vQty_Total));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Cash", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vAmt_Cash));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_CC", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vAmt_CC));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Bal", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vAmt_Bal));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Dis", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vAmt_Dis));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_R1", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vAmt_R1));
                SCmd.Parameters.Add(new SqlParameter("@nTotal_Value", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vTotal_Value));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Total", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 4, "", DataRowVersion.Proposed, vAmt_Total));

                SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
                SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, Convert.ToInt32(vTrLevel)));
                SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
                SCmd.Parameters.Add(new SqlParameter("@sU_U", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                SCmd.Parameters.Add(new SqlParameter("@dU_UD", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

                SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
                SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
                SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));

                strRecAffected = clsDatabase1.Exec_Int_Multi("stpInv_Tr_GRN", SCmd, sqlcon, Tran);
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
                else if (strRetValue == 1 && sErrorCode == "")
                {
                    str_Code = SCmd.Parameters["@sTr_No"].Value.ToString();
                    str_ID = Convert.ToInt32(SCmd.Parameters["@nInv_SqNo"].Value);
                    
                }
                if (vChild_List.Count > 0)
                {
                    foreach (DataRow row in vChild_List)
                    {
                        SCmd.Parameters.Clear();
                        SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, str_ID));
                        SCmd.Parameters.Add(new SqlParameter("@sTr_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, str_Code));
                        SCmd.Parameters.Add(new SqlParameter("@dTr_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTr_Date.Date));
                        SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
                        SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
                        SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID_Store));
                        //SCmd.Parameters.Add(new SqlParameter("@bGST_Cost", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vGST_Cost));

                        //if (row["Doc_Inv_SqNo"].ToString() != "")
                        //{
                        //    SCmd.Parameters.Add(new SqlParameter("@nDoc_Inv_SqNo", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["Doc_Inv_SqNo"].ToString())));
                        //    SCmd.Parameters.Add(new SqlParameter("@sDoc_Tr_No", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, row["Doc_Tr_No"]));
                        //}
                        //else
                        //{
                        //    SCmd.Parameters.Add(new SqlParameter("@nDoc_Inv_SqNo", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        //    SCmd.Parameters.Add(new SqlParameter("@sDoc_Tr_No", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        //}
                        SCmd.Parameters.Add(new SqlParameter("@nSCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["SCat_ID"])));
                        SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, Convert.ToInt32(row["Item_ID"])));
                        SCmd.Parameters.Add(new SqlParameter("@nR_Qty", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, row["R_Qty"]));
                        SCmd.Parameters.Add(new SqlParameter("@nR_Rate_FCY", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, row["R_Rate_FCY"]));
                        SCmd.Parameters.Add(new SqlParameter("@nRate_1", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 2, "", DataRowVersion.Proposed, row["Rate_1"]));
                        //SCmd.Parameters.Add(new SqlParameter("@nAmt_R1", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 2, "", DataRowVersion.Proposed, row["Amt_R1"]));
                        SCmd.Parameters.Add(new SqlParameter("@nR_Rate", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 2, "", DataRowVersion.Proposed, row["R_Rate"]));
                        SCmd.Parameters.Add(new SqlParameter("@sRef4", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, row["Ref4"]));
                        SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
                        SCmd.Parameters.Add(new SqlParameter("@nIndx", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vChild_List.IndexOf(row) + 1));

                        SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 4));
                        SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
                        strRecAffected = clsDatabase1.Exec_Int_Multi("stpInv_Tr_GRN", SCmd, sqlcon, Tran);
                        sErrorCode = clsDatabase1.sErrorCode.Trim();
                        strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);

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
                }
                else
                {
                    strRetValue = 0;
                }
                return strRetValue;
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
        }
        public int Save_Authorize(int vInv_SqNo, string vTr_No, DateTime vTr_Date, DateTime vFYSDate, int vBranch_ID, int vDept_ID,
         int vDept_ID_Store, double vQty_Total, string vRef1, string vRef2, int vTrLevel,
         int vComp_ID, string vU_Name, int vUser_ID, string vAuth_D, int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int nRet_Val = 0;
            strErrorCode = "";

            SCmd.Parameters.Clear();
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 1, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vInv_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@sTr_No", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vTr_No));
            SCmd.Parameters.Add(new SqlParameter("@dTr_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTr_Date.Date));
            SCmd.Parameters.Add(new SqlParameter("@dFYSDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vFYSDate.Date));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID_Store));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 0, string.Empty, DataRowVersion.Proposed, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nQty_Total", SqlDbType.Money, 9, ParameterDirection.Input, false, 18, 2, "", DataRowVersion.Proposed, vQty_Total));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sRef1", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vRef1));
            SCmd.Parameters.Add(new SqlParameter("@sRef2", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vRef2));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 28));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nApp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 9));

            database1 clsdatabase1 = new database1();
            clsdatabase1.Exec_Int_SP_S("stpInv_Tr_GRN", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
            try
            {
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch { strErr_Msg = ""; }

            return nRet_Val;
        }

        public int Save_Rollback(int vInv_SqNo, int vTrLevel, int vComp_ID, int vBranch_ID, string vU_Name, int vUser_ID, string vAuth_D, int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int nRet_Val = 0;
            strErrorCode = "";

            SCmd.Parameters.Clear();
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 1, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vInv_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 0, string.Empty, DataRowVersion.Proposed, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 33));

            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nApp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 9));

            database1 clsdatabase1 = new database1();
            clsdatabase1.Exec_Int_SP("stpInv_Tr_GRN", SCmd);
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
