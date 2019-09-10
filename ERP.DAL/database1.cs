using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;

namespace ERP.DAL
{
    public class database1
    {
        public const string pSecKey = "DunyaGoalHai";

        //UOL + BMA
        public const string pVer = "01.001.170619";
        
        public string pServerName = "";
        public string strType_Connection = "";
        public const string pApp_Name_1 = "SALES <br /> <span> MANAGEMENT </span><br /> SYSTEM </h1>";
        public string pApp_Name = "";
        public const string pUserPassKey = "1234";

        public string m_ConnectionString = "";
        public static string strServerName = "";
        public static string strDatabaseName = "";
        public static string strUserID = "";
        public static string strPassword = "";
        public static string strCnType = "1";

        public static string pSFUser;
        public static string pSFUserPassword;
        public string pSFUserPassKey;
        public string pSFUser_Company;
        public static string pSFUserCoCode;

        public const string pDBError_Prefix = "The system is unable to process the request, please check error: ";
        public const int pSQL_CommandTimeOut = 3600;
        SqlConnection SConnection = new SqlConnection();
        SqlCommand SCmd = new SqlCommand();
        SqlDataAdapter SDataAdapter = new SqlDataAdapter();
        DataSet SDataSet = new DataSet();
        DataTable SDataTable = new DataTable();

        private string strErrorCode = "";

        //public database1()
        //{
        //    SConnection.ConnectionString = m_ConnectionString;
        //}
        public string Getdatabase1()
        {
            DataSet tmpDs = new DataSet();
            string _Server = "";
            string strPath = "";
            strPath = Application.StartupPath;
            tmpDs.ReadXml(strPath.Substring(0, strPath.Length) + "\\Counter\\counter.xml");
            strType_Connection = tmpDs.Tables[0].Rows[0]["strType_Connection"].ToString();

            if (strType_Connection == "Local")   //Local
            {
                _Server = tmpDs.Tables[0].Rows[0]["Local"].ToString();
                strServerName = _Server;
                pServerName = _Server;

                m_ConnectionString = "data source=" + _Server + ";initial catalog=ERP_01;user id=sa;pwd=1234;";
                strServerName = _Server;
                strDatabaseName = "ERP_01";
                strUserID = "sa";
                strPassword = "1234";
                strCnType = "1";
                pSFUser_Company = "4";
                pApp_Name = pApp_Name_1;


                pSFUser = "";
                pSFUserPassword = "";
                pSFUserPassKey = "";
                pSFUserCoCode = "SMS";

            }
            if (strType_Connection == "LIVE")   //Local
            {
                _Server = tmpDs.Tables[0].Rows[0]["LIVE"].ToString();
                strServerName = _Server;
                pServerName = _Server;

                m_ConnectionString = "data source=" + _Server + ";initial catalog=ERP_01;user id=sa;pwd=1234;";
                strServerName = _Server;
                strDatabaseName = "ERP_01";
                strUserID = "sa";
                strPassword = "1234";
                strCnType = "1";
                pSFUser_Company = "4";
                pApp_Name = pApp_Name_1;


                pSFUser = "";
                pSFUserPassword = "";
                pSFUserPassKey = "";
                pSFUserCoCode = "SMS";

            }
            SConnection.ConnectionString = m_ConnectionString;
            return m_ConnectionString;
        }
        public string GetServerName()
        {
            DataSet tmpDs = new DataSet();
            string _Server = "";
            string strPath = "";
            strPath = Application.StartupPath;
            tmpDs.ReadXml(strPath.Substring(0, strPath.Length) + "\\Counter\\counter.xml");
            strType_Connection = tmpDs.Tables[0].Rows[0]["strType_Connection"].ToString();

            _Server = tmpDs.Tables[0].Rows[0][strType_Connection].ToString();
            strServerName = _Server;
            return _Server;
        }


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



        //---Fill DataRow By SQL Query
        public DataRow Get_DR_Qry(string vQuery)
        {
            DataRow dr_1 = null;
            try
            {
                SConnection.ConnectionString = Getdatabase1();
                SCmd.CommandText = vQuery;
                SCmd.CommandType = CommandType.Text;
                SCmd.Connection = SConnection;
                SCmd.CommandTimeout = pSQL_CommandTimeOut;
                SDataAdapter.SelectCommand = SCmd;
                SConnection.Open();
                SDataAdapter.Fill(SDataSet);
                if (SDataSet != null)
                {
                    if (SDataSet.Tables.Count > 0)
                    {
                        dr_1 = SDataSet.Tables[0].Rows[0];
                    }
                }
                strErrorCode = "";
            }
            catch (Exception ex)
            {
                strErrorCode = Get_ErrorString(ex.Message);
            }
            finally
            {
                SConnection.Close();
            }
            return dr_1;

        }

        //---Fill DataSet By SQL Query
        public DataSet Get_DS_Qry(string vQuery)
        {
            try
            {
                SConnection.ConnectionString = Getdatabase1();
                SCmd.CommandText = vQuery;
                SCmd.CommandType = CommandType.Text;
                SCmd.Connection = SConnection;
                SCmd.CommandTimeout = pSQL_CommandTimeOut;
                SDataAdapter.SelectCommand = SCmd;
                SConnection.Open();
                SDataAdapter.Fill(SDataSet);
                strErrorCode = "";
            }
            catch (Exception ex)
            {
                strErrorCode = Get_ErrorString(ex.Message);

            }
            finally
            {
                SConnection.Close();
            }
            return SDataSet;
        }

        //---Fill DataTable By SQL Query
        public DataTable Get_DT_Qry(string vQuery)
        {
            SDataTable = new DataTable();
            try
            {
                SConnection.ConnectionString = Getdatabase1();
                SCmd.CommandText = vQuery;
                SCmd.CommandType = CommandType.Text;
                SCmd.Connection = SConnection;
                SCmd.CommandTimeout = pSQL_CommandTimeOut;
                SDataAdapter.SelectCommand = SCmd;
                SConnection.Open();
                SDataAdapter.Fill(SDataTable);
                strErrorCode = "";
            }
            catch (Exception ex)
            {
                strErrorCode = Get_ErrorString(ex.Message);
            }
            finally
            {
                SConnection.Close();
            }
            return SDataTable;
        }

        //---Fill DataSet By Stored Procedure New
        public DataTable Get_DT_SP(string vSPName, SqlCommand SCmd)
        {
            DataTable dt_1 = new DataTable();

            try
            {
                SConnection.ConnectionString = Getdatabase1();
                SConnection.Open();
                SCmd.Connection = SConnection;
                SCmd.CommandText = vSPName;
                SCmd.CommandTimeout = pSQL_CommandTimeOut;
                SCmd.CommandType = CommandType.StoredProcedure;
                SDataAdapter.SelectCommand = SCmd;
                SDataAdapter.Fill(dt_1);
                strErrorCode = "";
            }
            catch (Exception ex)
            {
                strErrorCode = Get_ErrorString(ex.Message);
            }
            finally
            {
                SConnection.Close();
            }

            return dt_1;
        }

        //---Fill DataSet By Stored Procedure New
        public DataSet Get_DS_SP(string vSPName, SqlCommand SCmd)
        {
            DataSet ds_1 = new DataSet();

            try
            {
                SConnection.ConnectionString = Getdatabase1();
                SConnection.Open();
                SCmd.Connection = SConnection;
                SCmd.CommandText = vSPName;
                SCmd.CommandTimeout = pSQL_CommandTimeOut;
                SCmd.CommandType = CommandType.StoredProcedure;
                SDataAdapter.SelectCommand = SCmd;
                SDataAdapter.Fill(ds_1);
                strErrorCode = "";
            }
            catch (Exception ex)
            {
                strErrorCode = Get_ErrorString(ex.Message);
            }
            finally
            {
                SConnection.Close();
            }
            return ds_1;
        }

        //---Execute Parametered Stored Procedure 
        public int Exec_Int_SP(string vSPName, SqlCommand SCmd)
        {
            SqlTransaction Tran = null;
            bool blnTran = true;
            int strRecAffected = 0;

            try
            {//
                SConnection.ConnectionString = Getdatabase1();
                SConnection.Open();
                Tran = SConnection.BeginTransaction();
                SCmd.Connection = SConnection;
                SCmd.CommandTimeout = pSQL_CommandTimeOut;
                SCmd.Transaction = Tran;
                SCmd.CommandText = vSPName;
                SCmd.CommandType = CommandType.StoredProcedure;
                strRecAffected = SCmd.ExecuteNonQuery();
                strErrorCode = "";
            }
            catch (Exception ex)
            {
                blnTran = false;
                if (Tran != null)
                {
                    Tran.Rollback();
                    Tran.Dispose();
                }
                SConnection.Close();
                strErrorCode = Get_ErrorString(ex.Message);
            }
            finally
            {
                if (blnTran == true)
                {
                    Tran.Commit();
                    Tran.Dispose();
                    SConnection.Close();
                    strErrorCode = "";
                }
            }

            return strRecAffected;

        }

        //---Execute Parametered Stored Procedure with in BLL New
        public int Exec_Int_Multi(string vSPName, SqlCommand SCmd, SqlConnection sqlCon, SqlTransaction Tran)
        {
            int strRecAffected = 0;
            SCmd.Connection = sqlCon;
            SCmd.Transaction = Tran;
            SCmd.CommandText = vSPName;
            SCmd.CommandTimeout = pSQL_CommandTimeOut;
            SCmd.CommandType = CommandType.StoredProcedure;
            strRecAffected = SCmd.ExecuteNonQuery();
            return strRecAffected;
        }

        //---Excel Read Method 
        public DataTable GetRead_Excel(string strExcelFile)
        {

            System.Data.OleDb.OleDbConnection OledbCon = new System.Data.OleDb.OleDbConnection();
            System.Data.OleDb.OleDbCommand OledbCmd = new System.Data.OleDb.OleDbCommand();
            System.Data.OleDb.OleDbDataAdapter OledbDAdapter = new System.Data.OleDb.OleDbDataAdapter();
            DataTable dt_1 = new DataTable();
            OledbCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + strExcelFile.Trim() + " ;Extended Properties=\"Excel 8.0;HDR=NO\"";


            if (System.IO.File.Exists(strExcelFile.Trim()) == false)
            {
                strErrorCode = "Invalid Excel Data file / File dose not exists";
                return null;
            }

            try
            {
                OledbCon.Open();

                OledbCmd.Connection = OledbCon;
                OledbCmd.CommandTimeout = pSQL_CommandTimeOut;
                OledbCmd.CommandType = CommandType.Text;
                OledbCmd.CommandText = "SELECT * FROM [Sheet1$]";
                OledbDAdapter.SelectCommand = OledbCmd;
                OledbDAdapter.Fill(dt_1);
                OledbDAdapter.Dispose();
                OledbCmd.Dispose();
                OledbCon.Close();

            }
            catch (Exception ex)
            {
                strErrorCode = Get_ErrorString(ex.Message);
                return null;
            }

            return dt_1;
        }

        public string Get_ErrorString(string vError)
        {
            return pDBError_Prefix + vError.Replace("'", "`").Replace("(", "[").Replace(")", "]").Replace('\r', '-').Replace('\n', '-');
        }

        public int Exec_Int_SP_S(string vSPName, SqlCommand SCmd)
        {
            SqlTransaction Tran = null;
            bool blnTran = true;
            int strRecAffected = 0;

            try
            {
                SConnection.ConnectionString = Getdatabase1();
                SConnection.Open();
                // Tran = SConnection.BeginTransaction();
                SCmd.Connection = SConnection;
                SCmd.CommandTimeout = pSQL_CommandTimeOut;
                // SCmd.Transaction = Tran;
                SCmd.CommandText = vSPName;
                SCmd.CommandType = CommandType.StoredProcedure;
                strRecAffected = SCmd.ExecuteNonQuery();
                strErrorCode = "";
            }
            catch (Exception ex)
            {

                SConnection.Close();
                strErrorCode = Get_ErrorString(ex.Message);
            }
            finally
            {
                SConnection.Close();
            }

            return strRecAffected;

        }
        
        //---Fill DataSet By Stored Procedure
        public DataSet GetDataSet_BySP(string vSPName, SqlParameter[] param)
        {
            DataSet ds_1 = new DataSet();

            try
            {
                SCmd = new SqlCommand();
                SConnection.ConnectionString = Getdatabase1();
                SConnection.Open();
                SCmd.Connection = SConnection;
                SCmd.CommandText = vSPName;
                SCmd.CommandTimeout = pSQL_CommandTimeOut;
                SCmd.CommandType = CommandType.StoredProcedure;
                SCmd.Parameters.AddRange(param);
                SDataAdapter.SelectCommand = SCmd;
                SDataAdapter.Fill(ds_1);
                strErrorCode = "";
            }
            catch (Exception ex)
            {
                strErrorCode = Get_ErrorString(ex.Message);
            }
            finally
            {
                SConnection.Close();
            }
            return ds_1;
        }

        //---Execute Parametered Stored Procedure 
        public int GetExecute_Paramater_SP(string vSPName, SqlParameter[] param)
        {
            SCmd = new SqlCommand();
            SqlTransaction Tran = null;
            bool blnTran = true;
            int strRecAffected = 0;

            try
            {
                SConnection.ConnectionString = Getdatabase1();
                SConnection.Open();
                Tran = SConnection.BeginTransaction();
                SCmd.Connection = SConnection;
                SCmd.CommandTimeout = pSQL_CommandTimeOut;
                SCmd.Transaction = Tran;
                SCmd.CommandText = vSPName;
                SCmd.CommandType = CommandType.StoredProcedure;
                SCmd.Parameters.AddRange(param);
                strRecAffected = SCmd.ExecuteNonQuery();
                strErrorCode = "";
            }
            catch (Exception ex)
            {
                blnTran = false;
                if (Tran != null)
                {
                    Tran.Rollback();
                    Tran.Dispose();
                }
                SConnection.Close();
                strErrorCode = Get_ErrorString(ex.Message);
            }
            finally
            {
                if (blnTran == true)
                {
                    Tran.Commit();
                    Tran.Dispose();
                    SConnection.Close();
                    strErrorCode = "";
                }
            }

            return strRecAffected;

        }

        //---Execute Parametered Stored Procedure with in BLL 
        public int GetExecute_BLL_SP(string vSPName, SqlParameter[] param, SqlConnection sqlCon, SqlTransaction Tran)
        {
            int strRecAffected = 0;
            SCmd.Connection = sqlCon;
            SCmd.Transaction = Tran;
            SCmd.CommandText = vSPName;
            SCmd.CommandTimeout = pSQL_CommandTimeOut;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.Parameters.Clear();
            SCmd.Parameters.AddRange(param);
            strRecAffected = SCmd.ExecuteNonQuery();
            return strRecAffected;
        }


    }
}
















