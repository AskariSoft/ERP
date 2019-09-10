using ERP.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BLL.IN
{
    public class IN_TO
    {
        public int nInv_SqNo { get; set; }
        public string sTrNo { get; set; }
        public string strErrorCode;
        private const int cn_VrType = 58;
        public string sErrorCode
        {
            get
            {
                return strErrorCode;
            }
            set
            {
                strErrorCode = value;
            }
        }
        private string strErr_Msg;
        public string vItem_ID;
        public string sErr_Msg
        {
            get
            {
                return strErr_Msg;
            }
            set
            {
                strErr_Msg = value;
            }
        }
        private string strPDate;
        public string PDate
        {
            get
            {
                return strPDate;
            }
            set
            {
                strPDate = value;
            }
        }
        private int nRet_Val { get; set; }

        public DataSet Fill_Combo(int vComp_ID, int vBranch_ID, int vU_S, string Auth1, string Auth2)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            database1 clsdatabase1 = new database1();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 3));
            ds_1 = clsdatabase1.Get_DS_SP("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Combo_1(int vComp_ID, int vBranch_ID, int vU_S, int vDept_ID_Store, string Auth)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            database1 clsdatabase1 = new database1();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID_Store));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 14));
            ds_1 = clsdatabase1.Get_DS_SP("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public int Save_Master(string vInv_SqNo, string vTr_No, DateTime vTr_Date, int vE_ID, string vRef1, int vTrLevel, List<DataRow> lst_Items,
                                int vBranch_ID, int vDept_ID_Store, int vDept_ID_Store_2, int vComp_ID, int vU_S, string vU_Name, int vIsUpdate, double vAmt_Item)
        {
            database1 clsdatabase1 = new database1();
            SqlCommand SCmd = new SqlCommand();
            SqlConnection sqlcon = new SqlConnection();
            SqlTransaction Tran = null;
            bool blnTran = true;
            int strRecAffected = 0;


            try
            {
                sqlcon.ConnectionString = clsdatabase1.Getdatabase1();
                sqlcon.Open();

                Tran = sqlcon.BeginTransaction();

                SCmd = new SqlCommand();
                if (vIsUpdate == 0)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vInv_SqNo));

                }
                SCmd.Parameters.Add(new SqlParameter("@sTr_No", SqlDbType.VarChar, 15, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, vTr_No));
                SCmd.Parameters.Add(new SqlParameter("@dTr_Date", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vTr_Date));
                SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vTrLevel));
                SCmd.Parameters.Add(new SqlParameter("@sRef1", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vRef1));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Item", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vAmt_Item));

                SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
                SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDept_ID_Store));
                SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store_2", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDept_ID_Store_2));
                //SCmd.Parameters.Add(new SqlParameter("@sBranch_Code", SqlDbType.VarChar, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_Code));
                SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
                SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vU_S));
                SCmd.Parameters.Add(new SqlParameter("@sU_S", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));

                SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 1, "", DataRowVersion.Proposed, 0));
                SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
                SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));

                strRecAffected = clsdatabase1.Exec_Int_Multi("stpInv_Tr_Transfer", SCmd, sqlcon, Tran);
                strErrorCode = clsdatabase1.sErrorCode.Trim();
                nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);

                nInv_SqNo = Convert.ToInt32(SCmd.Parameters["@nInv_SqNo"].Value);
                sTrNo = Convert.ToString(SCmd.Parameters["@sTr_No"].Value);



                //---If SP return validation check
                if (nRet_Val == -1 || nRet_Val == 0)
                {
                    blnTran = false;
                    Tran.Rollback();
                    Tran.Dispose();
                    SCmd.Dispose();
                    sqlcon.Close();
                    return nRet_Val;
                }
                //add details
                if (nRet_Val == 1)
                {
                    //vIsUpdate = 4; //save detail data

                    for (int i = 0; i < lst_Items.Count; i++)
                    {
                        SCmd.Parameters.Clear();
                        SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, nInv_SqNo));
                        SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, lst_Items.ElementAt(i)["Item_ID"].ToString().Trim()));
                        SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTrLevel));
                        SCmd.Parameters.Add(new SqlParameter("@nR_Qty", SqlDbType.Decimal, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, lst_Items.ElementAt(i)["I_Qty"].ToString()));
                        SCmd.Parameters.Add(new SqlParameter("@nR_Rate", SqlDbType.Decimal, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, lst_Items.ElementAt(i)["I_Rate"].ToString()));
                        SCmd.Parameters.Add(new SqlParameter("@dTr_Date", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vTr_Date));
                        SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDept_ID_Store));

                        SCmd.Parameters.Add(new SqlParameter("@nIndx", SqlDbType.Float, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, i + 1));

                        SCmd.Parameters.Add(new SqlParameter("@sRef4", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, lst_Items.ElementAt(i)["Ref4"].ToString()));
                        SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
                        SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
                        SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vU_S));
                        SCmd.Parameters.Add(new SqlParameter("@sU_S", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                        SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 1, "", DataRowVersion.Proposed, 0));
                        SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
                        SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 4));

                        strRecAffected = clsdatabase1.Exec_Int_Multi("stpInv_Tr_Transfer", SCmd, sqlcon, Tran);
                        strErrorCode = clsdatabase1.sErrorCode.Trim();
                        nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
                        sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();

                        if (nRet_Val == -1 || nRet_Val == 0)
                        {
                            blnTran = false;
                            Tran.Rollback();
                            Tran.Dispose();
                            SCmd.Dispose();
                            sqlcon.Close();
                            return nRet_Val;
                        }
                        else
                        {
                            if (vIsUpdate == 0)
                            {
                                nInv_SqNo = Convert.ToInt32(SCmd.Parameters["@nInv_SqNo"].Value);


                            }
                            // strPDate = SCmd.Parameters["@dPDate"].Value.ToString();
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                blnTran = false;
                if (Tran != null)
                {
                    Tran.Rollback();
                    Tran.Dispose();
                }

                SCmd.Dispose();
                sqlcon.Close();
                strErrorCode = clsdatabase1.Get_ErrorString(ex.Message);
                return nRet_Val;
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
            return nRet_Val;
        }

        public DataSet Fill_SCat(int vComp_ID, int vUser_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            database1 clsdatabase1 = new database1();

            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 5));
            ds_1 = clsdatabase1.Get_DS_SP("stpInv_Tr_Transfer", SCmd);
            sErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public int Save_App_Level_1(DateTime vTr_Date, string vFYSDate, int vDept_ID_Store, int vBranch_ID, Int32 vInvSqNo, string vVrNo, int vVrType,
                     string vRef4, int vFY_ID, int vU_S, string vU_Name, int vComp_ID)
        {
            database1 clsdatabase1 = new database1();
            DataSet ds_1 = new DataSet();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, "", DataRowVersion.Default, 0));

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, vDept_ID_Store));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));

            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, vInvSqNo));
            SCmd.Parameters.Add(new SqlParameter("@sTr_No", SqlDbType.VarChar, 15, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, vVrNo));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 58));
            SCmd.Parameters.Add(new SqlParameter("@nVrType", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vVrType));
            SCmd.Parameters.Add(new SqlParameter("@nItem_ID1", SqlDbType.Int, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, 0));

            SCmd.Parameters.Add(new SqlParameter("@dFYSDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vFYSDate));
            //SCmd.Parameters.Add(new SqlParameter("@sErrorMessage", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));

            SCmd.Parameters.Add(new SqlParameter("@sRef4", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vRef4.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vU_Name.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 28));
            clsdatabase1.Exec_Int_SP_S("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();

            if (strErrorCode == "")
            {
                strErrorCode = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            try
            {
                vItem_ID = SCmd.Parameters["@nItem_ID1"].Value.ToString();
            }
            catch { vItem_ID = ""; }
            sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            return Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
        }

        public int Save_Cancel(int nInv_SqNo, int vBranch_ID, int vComp_ID, int vU_S, string vU_Name)
        {
            database1 clsdatabase1 = new database1();
            SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, nInv_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 11));

            strRecAffected = clsdatabase1.Exec_Int_SP("[stpInv_Tr_DP]", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
            return nRet_Val;
        }

        public DataTable Load_List(string vSearch, DateTime vDateFrom, DateTime vDateTo, int vBranch_ID, int vComp_ID)
        {
            database1 clsdatabase1 = new database1();
            DataSet ds_1 = new DataSet();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@sSearchText", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vSearch));
            //SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@dBegDate", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDateFrom));
            SCmd.Parameters.Add(new SqlParameter("@dEndDate", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDateTo));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
            ds_1 = clsdatabase1.Get_DS_SP("[stpInv_Tr_Transfer]", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1.Tables[0];
        }
        public DataSet Fill_Grid(string vSearch, int vTrLevel, string vDateFrom, string vDateTo, int vBranch_ID, int vDept_ID_Store, int vComp_ID, int vPageNo)
        {
            database1 clsdatabase1 = new database1();
            DataSet ds_1 = new DataSet();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@dBeg_Date", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDateFrom));
            SCmd.Parameters.Add(new SqlParameter("@dEnd_Date", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDateTo));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDept_ID_Store));

            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nPageNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vPageNo));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 13));
            ds_1 = clsdatabase1.Get_DS_SP("[stpInv_Tr_Transfer]", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }

        public DataSet Find_Record(int vIsUpdate, int vInv_SqNo, int pComp_ID)
        {
            database1 clsdatabase1 = new database1();
            DataSet ds_1=new DataSet();
            DataTable dt = new DataTable();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, string.Empty, DataRowVersion.Proposed, vInv_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, pComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
            ds_1 = clsdatabase1.Get_DS_SP("[stpInv_Tr_Transfer]", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            //dt = ds_1.Tables[0];
            return ds_1;
        }
        public DataTable Get_Emp(int vIsUpdate, string vE_IDNo, int vComp_ID)
        {
            database1 clsdatabase1 = new database1();
            DataSet ds_1;
            DataTable dt = new DataTable();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@sE_IDNo", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, string.Empty, DataRowVersion.Proposed, vE_IDNo));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));
            ds_1 = clsdatabase1.Get_DS_SP("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            dt = ds_1.Tables[0];
            return dt;
        }
        public int Save_Rollback(int vInv_SqNo, string vFYS_Date, string vFYE_Date, int vDept_ID_Store, int vTrLevel, int vComp_ID, int vBranch_ID, string vU_Name, int vU_S, string vAuth_D,int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int nRet_Val;
            strErrorCode = "";

            SCmd.Parameters.Clear();
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 1, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vInv_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@dFYSDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Convert.ToDateTime (vFYS_Date)));
            SCmd.Parameters.Add(new SqlParameter("@dFYEDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Convert.ToDateTime(vFYE_Date)));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, vFY_ID));

            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 0, string.Empty, DataRowVersion.Proposed, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@sU_S", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDept_ID_Store));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 16));

            database1 clsdatabase1 = new database1();
            clsdatabase1.Exec_Int_SP("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
            try
            {
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch { strErr_Msg = ""; }
            return nRet_Val;
        }
        public DataSet Fill_cfgP(int nComp_ID, int nBranch_ID)
        {
            DataTable dt = new DataTable();
            DataSet ds_1;
            database1 clsdatabase1 = new database1();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, nComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, nBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 0));
            ds_1 = clsdatabase1.Get_DS_SP("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();

            return ds_1;
        }
        public int Save_Authorize(int vInv_SqNo, int vTrLevel, int vComp_ID, int vBranch_ID, string vU_Name, int vU_S, string vAuth_D)
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
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@sU_S", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 8));

            database1 clsdatabase1 = new database1();
            clsdatabase1.Exec_Int_SP("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
            try
            {
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch { strErr_Msg = ""; }
            return nRet_Val;
        }
        public int Save_Cancelled(int vInv_SqNo, int vTrLevel, int vComp_ID, int vBranch_ID, string vU_Name, int vU_S, string vAuth_D)
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
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@sU_S", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 15));

            database1 clsdatabase1 = new database1();
            clsdatabase1.Exec_Int_SP("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
            try
            {
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch { strErr_Msg = ""; }
            return nRet_Val;
        }
        public DataTable Get_ItemD(string vSearch, int vBranch_ID, int So_ID, int vComp_ID, int vDept_ID_Store)
        {
            database1 clsdatabase1 = new database1();
            DataSet ds_1 = new DataSet();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nSO_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, So_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vDept_ID_Store));

            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 7));
            ds_1 = clsdatabase1.Get_DS_SP("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1.Tables[0];
        }


        public int Save_Cancelled(int vBranch_ID, Int32 vInvSqNo, string vRef4, int vFY_ID, int vU_S, string vU_Name, int vComp_ID)
        {
            database1 clsdatabase1 = new database1();
            DataSet ds_1 = new DataSet();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, "", DataRowVersion.Default, 0));
            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, vInvSqNo));
            SCmd.Parameters.Add(new SqlParameter("@nVrType", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, cn_VrType));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@sRef4", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vRef4.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vU_Name.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 29));
            clsdatabase1.Exec_Int_SP("stpInv_Tr_Transfer", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            sErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            return Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);

        }
    }
}
