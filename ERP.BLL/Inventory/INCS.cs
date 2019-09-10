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
    public class INCS
    {
        database1 clsDatabase1 = new database1();

        public string strErrorCode;
        public string strErr_Msg;
        public double vS_Rate;

        private int strRet_Val;
        public string sErrorCode { get; set; }
        public int Ret_Val { get; set; }
        public string str_Tr_No;
        public int str_Inv_SqNo;
        
        //public int Auth_GST(int vComp_ID, int vU_ID, string vAuth_D)
        //{
        //    int strRetValue = 0;
        //    SqlCommand SCmd = new SqlCommand();
        //    SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
        //    SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 13));
        //    SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
        //    clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
        //    strErrorCode = clsDatabase1.sErrorCode.Trim();
        //    strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
        //    return strRetValue;
        //}
        //public int Auth_Print(int vInv_SqNo,int vComp_ID, int vU_ID, string vAuth_D)
        //{
        //    int strRetValue = 0;
        //    SqlCommand SCmd = new SqlCommand();
        //    SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vInv_SqNo));
        //    SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
        //    SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
        //    SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 14));
        //    SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
            
        //    clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
        //    strErrorCode = clsDatabase1.sErrorCode.Trim();
        //    strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
        //    strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
        //    return strRetValue;
        //}
        //public DataSet Get_Balances(int vComp_ID, int vItem_ID, DateTime vTr_Date, DateTime vFYSDate, DateTime vFYEDate,int vDept_ID)
        //{
        //    DataSet ds_1;
        //    SqlCommand SCmd = new SqlCommand();

        //    SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vItem_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@dTr_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTr_Date.Date));
        //    SCmd.Parameters.Add(new SqlParameter("@dFYSdate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vFYSDate.Date));
        //    SCmd.Parameters.Add(new SqlParameter("@dFYEdate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vFYEDate.Date));
        //    SCmd.Parameters.Add(new SqlParameter("@nInv_Bal_Qty", SqlDbType.Money, 9, ParameterDirection.Output, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
        //    SCmd.Parameters.Add(new SqlParameter("@nInv_Bal_Rate", SqlDbType.Money, 9, ParameterDirection.Output, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));
        //    SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 6));
        //    ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
        //    strErrorCode = clsDatabase1.sErrorCode.Trim();
        //    vS_Rate = Convert.ToDouble(SCmd.Parameters["@nInv_Bal_Rate"].Value);
        //    return ds_1;
        //}
        //public DataSet Get_Balance(int vComp_ID, int vU_ID, int vBranch_ID, int vDetail_ID, int vSub_ID, DateTime vFYSDate, DateTime vTr_Date)
        //{
        //    DataSet ds_1;
        //    SqlCommand SCmd = new SqlCommand();

        //    SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@dTr_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTr_Date.Date));
        //    SCmd.Parameters.Add(new SqlParameter("@dFYSdate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vFYSDate.Date));
        //    SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vBranch_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vDetail_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_ID));
        //    SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 15));

        //    ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
        //    strErrorCode = clsDatabase1.sErrorCode.Trim();
        //    return ds_1;
        //}
        public DataSet Fill_Combo(int vComp_ID, int vU_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 3));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Combo(int vComp_ID, int vU_ID,int vBranch_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 15));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
            sErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Items(int vComp_ID,int vU_ID, int vSCat_ID,int vDept_ID_Store)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nSCat_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vSCat_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID_Store));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 10));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_SCat(int vComp_ID,int vU_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 9));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_Record(int vComp_ID, int vInvSqNo)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vInvSqNo));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Find_RecordBy_ItemD(string vItem_D, string vU_Name, int vU_ID, int vComp_ID)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@sItem_D", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vItem_D));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 11));
            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        public DataSet Fill_Grid(int vComp_ID, int vTrLevel, string vSub_Code, string vSearch, int vBranch, int vDept, int vDept_Store, DateTime vFrom_Date, DateTime vTo_Date, int vPageNo)
        {
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Code", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Code));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@nPageNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vPageNo));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_Store));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch));
            SCmd.Parameters.Add(new SqlParameter("@dBeg_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vFrom_Date.Date));
            SCmd.Parameters.Add(new SqlParameter("@dEnd_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTo_Date.Date));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 12));

            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }

        public DataSet Fill_cfgS(int vComp_ID, int vU_ID, int vBranch_ID, string vSearch, string vDetail_Code, string vSub_Code)
        {
            DataSet ds_1; 
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSearch));
            SCmd.Parameters.Add(new SqlParameter("@sDetail_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vDetail_Code));
            SCmd.Parameters.Add(new SqlParameter("@sSub_Code", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_Code));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 8));

            ds_1 = clsDatabase1.Get_DS_SP("stpInv_Tr_CS", SCmd);
            strErrorCode = clsDatabase1.sErrorCode.Trim();
            return ds_1;
        }
        
        
        public int Save_Authorize(int vInv_SqNo, string vTr_No, DateTime vTr_Date, DateTime vFYSDate, int vBranch_ID, int vDept_ID,
           int vDept_ID_Store, double vQty_Total, double vQty_FOC, string vRef1, string vRef2, int vTrLevel,
            int vComp_ID, string vU_Name, int vU_ID, string vAuth_D,int vFY_ID)
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
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 0, string.Empty, DataRowVersion.Proposed, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@nQty_Total", SqlDbType.Money, 9, ParameterDirection.Input, false, 18, 2, "", DataRowVersion.Proposed, vQty_Total));
            SCmd.Parameters.Add(new SqlParameter("@nQty_FOC", SqlDbType.Money, 9, ParameterDirection.Input, false, 18, 2, "", DataRowVersion.Proposed, vQty_FOC));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sRef1", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vRef1));
            SCmd.Parameters.Add(new SqlParameter("@sRef2", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vRef2));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 5));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nApp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 9));
            
            database1 clsdatabase1 = new database1();
            clsdatabase1.Exec_Int_SP_S("stpInv_Tr_CS", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
            try
            {
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch { strErr_Msg = ""; }

            return nRet_Val;
        }
        public int Save_Rollback(int vInv_SqNo, int vTrLevel, int vComp_ID, int vBranch_ID, string vU_Name, 
            int vU_ID, string vAuth_D,int vFY_ID)
        {
            SqlCommand SCmd = new SqlCommand();
            int nRet_Val = 0;
            strErrorCode = "";

            SCmd.Parameters.Clear();
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 1, "", DataRowVersion.Proposed, 0));
            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vInv_SqNo));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vBranch_ID));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 0, string.Empty, DataRowVersion.Proposed, vTrLevel));
            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 18, 0, string.Empty, DataRowVersion.Proposed, vU_ID));
            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Proposed, vU_Name));
            SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 4000, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, false, 0, 0, string.Empty, DataRowVersion.Proposed, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 7));
            SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
            SCmd.Parameters.Add(new SqlParameter("@nApp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 9));
            
            database1 clsdatabase1 = new database1();
            clsdatabase1.Exec_Int_SP("stpInv_Tr_CS", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            nRet_Val = Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
            try
            {
                strErr_Msg = SCmd.Parameters["@sErr_Msg"].Value.ToString();
            }
            catch { strErr_Msg = ""; }
            return nRet_Val;
        }

        public int Save_Master(string vInv_SqNo, string vTr_No, DateTime vTr_Date, int vComp_ID, int vDetail_ID, int vSub_ID, int vDept_ID, int vDept_ID_Store, int vBranch_ID, string vAddress1, string vAddress2,
            string vCity, string vContact_Person, string vCell, int vDType_ID, string vCurr_ID, double vCurr_Rate, int vCCType_ID, int vTrType_ID, bool vGSTCost,
            string vRef1, string vRef2, double vCredit_Bal, double vCredit_Days,
            double vQty_Total, double vQty_FOC, double vAmt_Value, double vAmt_Dis, double vAmt_Total, double vAmt_Bal, double vAmt_Cash, double vAmt_CC, double vAmt_R1, List<DataRow> vlstDetail,
            int vTrLevel, string vU_Name, int vU_ID, int vIsUpdate, string vAuth_D, int vFY_ID
             )
        {

            SqlConnection sqlcon = new SqlConnection();
            SqlCommand SCmd = new SqlCommand();
            SqlTransaction Tran = null;
            bool blnTran = true;
            double vFCY_Rate = 0;
            sErrorCode = "";
            // Ret_Val = 0;

            //SqlCommand SCmd = new SqlCommand();
            int strRecAffected = 0;
            int strRetValue = 0;
            int nRet_Val = 0;
            try
            {
                sqlcon.ConnectionString = clsDatabase1.Getdatabase1();
                sqlcon.Open();
                Tran = sqlcon.BeginTransaction();
                SCmd.Parameters.Clear();
                //parameter
                if (vIsUpdate == 0)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Proposed, vInv_SqNo));

                }
                SCmd.Parameters.Add(new SqlParameter("@sTr_No", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, vTr_No));
                SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTrLevel));
                SCmd.Parameters.Add(new SqlParameter("@nTrType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTrType_ID));
                SCmd.Parameters.Add(new SqlParameter("@dTr_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTr_Date.Date));
                SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
                SCmd.Parameters.Add(new SqlParameter("@nDetail_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vDetail_ID));
                SCmd.Parameters.Add(new SqlParameter("@nSub_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vSub_ID));
                SCmd.Parameters.Add(new SqlParameter("@sAddress1", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAddress1));
                SCmd.Parameters.Add(new SqlParameter("@sAddress2", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAddress2));
                SCmd.Parameters.Add(new SqlParameter("@sContact_Person", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vContact_Person));
                SCmd.Parameters.Add(new SqlParameter("@sCell", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vCell));
                SCmd.Parameters.Add(new SqlParameter("@nCredit_Bal", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vCredit_Bal));
                SCmd.Parameters.Add(new SqlParameter("@nCredit_Days", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vCredit_Days));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Bal", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAmt_Bal));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_CC", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAmt_CC));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Cash", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAmt_Cash));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_R1", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAmt_R1));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Value", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAmt_Value));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Dis", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAmt_Dis));
                SCmd.Parameters.Add(new SqlParameter("@nAmt_Total", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAmt_Total));
                SCmd.Parameters.Add(new SqlParameter("@nQty_Total", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vQty_Total));
                SCmd.Parameters.Add(new SqlParameter("@nQty_FOC", SqlDbType.Float, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vQty_FOC));
                SCmd.Parameters.Add(new SqlParameter("@bGST_Cost", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vGSTCost));
                SCmd.Parameters.Add(new SqlParameter("@nCurr_Rate", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 6, "", DataRowVersion.Proposed, vCurr_Rate));
                SCmd.Parameters.Add(new SqlParameter("@sCurr_ID", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vCurr_ID));


                if (vCCType_ID == -1)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nCCType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nCCType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vCCType_ID));

                }

                if (vBranch_ID == -1)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));

                }

                if (vDept_ID == -1)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID));

                }

                if (vDept_ID_Store == -1)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID_Store));

                }

                if (vDType_ID == -1)
                {
                    SCmd.Parameters.Add(new SqlParameter("@nDType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, DBNull.Value));

                }
                else
                {
                    SCmd.Parameters.Add(new SqlParameter("@nDType_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDType_ID));

                }

                SCmd.Parameters.Add(new SqlParameter("@sRef1", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vRef1));
                SCmd.Parameters.Add(new SqlParameter("@sRef2", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vRef2));

                SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
                SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                SCmd.Parameters.Add(new SqlParameter("@nFY_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vFY_ID));
                SCmd.Parameters.Add(new SqlParameter("@nApp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 9));

                SCmd.Parameters.Add(new SqlParameter("@sAuth_D", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vAuth_D));
                SCmd.Parameters.Add(new SqlParameter("@sErr_Msg", SqlDbType.VarChar, 200, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
                SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vIsUpdate));

                strRecAffected = clsDatabase1.Exec_Int_Multi("stpInv_Tr_CS", SCmd, sqlcon, Tran);
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
                    str_Tr_No = SCmd.Parameters["@sTr_No"].Value.ToString();
                    str_Inv_SqNo = Convert.ToInt32(SCmd.Parameters["@nInv_SqNo"].Value);

                    if (vlstDetail.Count > 0)
                    {
                        foreach (DataRow row in vlstDetail)
                        {

                            SCmd.Parameters.Clear();
                            SCmd.Parameters.Add(new SqlParameter("@nInv_SqNo", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, str_Inv_SqNo));
                            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vComp_ID));
                            SCmd.Parameters.Add(new SqlParameter("@nDept_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID));
                            SCmd.Parameters.Add(new SqlParameter("@nDept_ID_Store", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vDept_ID_Store));
                            SCmd.Parameters.Add(new SqlParameter("@nTrLevel", SqlDbType.Int, 9, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTrLevel));
                            SCmd.Parameters.Add(new SqlParameter("@sTr_No", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, str_Tr_No));
                            SCmd.Parameters.Add(new SqlParameter("@dTr_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vTr_Date.Date));
                            SCmd.Parameters.Add(new SqlParameter("@nBranch_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vBranch_ID));
                            SCmd.Parameters.Add(new SqlParameter("@nSCat_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, row["SCat_ID"]));
                            SCmd.Parameters.Add(new SqlParameter("@nItem_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, row["Item_ID"]));
                            SCmd.Parameters.Add(new SqlParameter("@nS_Rate", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["S_Rate"]));
                            SCmd.Parameters.Add(new SqlParameter("@nI_Rate", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["I_Rate"]));
                            //SCmd.Parameters.Add(new SqlParameter("@nI_Rate_FCY", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["I_Rate_FCY"]));
                            SCmd.Parameters.Add(new SqlParameter("@nRate_1", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["Rate_1"]));
                            SCmd.Parameters.Add(new SqlParameter("@nI_Qty", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["I_Qty"]));
                            SCmd.Parameters.Add(new SqlParameter("@nI_Qty_FOC", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["I_Qty_FOC"]));
                            SCmd.Parameters.Add(new SqlParameter("@sRef4", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, row["Ref4"]));
                            SCmd.Parameters.Add(new SqlParameter("@nItem_Rate_Max", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["Item_Rate_Max"]));
                            SCmd.Parameters.Add(new SqlParameter("@nItem_Rate_Min", SqlDbType.Float, 9, ParameterDirection.Input, false, 18, 3, "", DataRowVersion.Proposed, row["Item_Rate_Min"]));
                            SCmd.Parameters.Add(new SqlParameter("@sU_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vU_Name));
                            SCmd.Parameters.Add(new SqlParameter("@nU_ID", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vU_ID));
                            SCmd.Parameters.Add(new SqlParameter("@nIndx", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, vlstDetail.IndexOf(row) + 1));

                            SCmd.Parameters.Add(new SqlParameter("@dPDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                            SCmd.Parameters.Add(new SqlParameter("@nReturn", SqlDbType.BigInt, 9, ParameterDirection.ReturnValue, false, 18, 0, "", DataRowVersion.Proposed, 0));
                            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 9, ParameterDirection.Input, false, 18, 0, "", DataRowVersion.Proposed, 4));

                            strRecAffected = clsDatabase1.Exec_Int_Multi("stpInv_Tr_CS", SCmd, sqlcon, Tran);
                            strRetValue = Convert.ToInt32(SCmd.Parameters["@nReturn"].Value);
                        }
                    }
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
                if (Tran.Connection != null)
                {
                    Tran.Commit();
                    Tran.Dispose();
                    SCmd.Dispose();
                    sqlcon.Close();
                }
            }
        }
    }
}
