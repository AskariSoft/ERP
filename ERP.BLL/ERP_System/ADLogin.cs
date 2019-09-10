using ERP.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BLL
{
    public class ADLogin

    {
        private int strUser_ID;
        private string strUser_Name;
        private string strUser_FName;
        private Int32 strUser_SrNo;
        private Int32 strUser_Branch_ID;
        private Int32 strUser_Dept_ID;
        //private int strBranch_ID;
        private int strBranch_BrID;
        private string strBranch_Code;
        private string strBranch_FName;
        private string strBranch_SName;
        private bool strBranch_Bal;
        private string strBranch_MTI;
        private bool strBranch_Comm;
        private int strUser_DaysLeft;
        private int strUser_LoginAttempts;
        private DateTime dtUser_LoginDate;
        private DateTime dtUser_LastLoginDate;
        private string strComp_FName;
        private string strComp_SName;
        private string strComp_Img_1;
        private string strComp_Img_2;
        private string strComp_Img_3;
        private string strComp_Img_Path;
        private string strComp_PassKey;
        private string strImg_Path_Logo;
        private int strComp_ID;
        private string strErrorCode;
        private string strAccActivity_1_ID;
        private string strUser_LastLoginIP;

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

        public int UserID
        {
            get { return strUser_ID; }
            set { strUser_ID = value; }
        }

        public string UserName
        {
            get { return strUser_Name; }
            set { strUser_Name = value; }
        }

        public string UserFullName
        {
            get { return strUser_FName; }
            set { strUser_FName = value; }
        }

        public string AccActivity_1_ID
        {
            get { return strAccActivity_1_ID; }
            set { strAccActivity_1_ID = value; }
        }

        public int UserSrNo
        {
            get { return strUser_SrNo; }
            set { strUser_SrNo = value; }
        }

        //public int BranchID 
        //{
        //    get { return strBranch_ID; }
        //    set { strBranch_ID = value; }
        //}

        public int User_Branch_ID
        {
            get { return strUser_Branch_ID; }
            set { strUser_Branch_ID = value; }
        }

        public int User_Dept_ID
        {
            get { return strUser_Dept_ID; }
            set { strUser_Dept_ID = value; }
        }

        public int Branch_BrID
        {
            get { return strBranch_BrID; }
            set { strBranch_BrID = value; }
        }

        public string BranchCode
        {
            get { return strBranch_Code; }
            set { strBranch_Code = value; }
        }

        public string BranchFName
        {
            get { return strBranch_FName; }
            set { strBranch_FName = value; }
        }

        public string BranchSName
        {
            get { return strBranch_SName; }
            set { strBranch_SName = value; }
        }

        public bool Branch_Bal
        {
            get { return strBranch_Bal; }
            set { strBranch_Bal = value; }
        }

        //public string Branch_MTI
        //{
        //    get { return strBranch_MTI; }
        //    set { strBranch_MTI = value; }
        //}

        //public bool Comm
        //{
        //    get { return strBranch_Comm; }
        //    set { strBranch_Comm = value; }
        //}

        public int DaysLeft
        {
            get { return strUser_DaysLeft; }
            set { strUser_DaysLeft = value; }
        }

        public int LoginAttempts
        {
            get { return strUser_LoginAttempts; }
            set { strUser_LoginAttempts = value; }
        }

        public DateTime LoginDate
        {
            get { return dtUser_LoginDate; }
        }
        public DateTime LastLoginDate
        {
            get { return dtUser_LastLoginDate; }
        }
        public string Comp_PassKey
        {
            get { return strComp_PassKey; }
            set { strComp_PassKey = value; }
        }
        public string Comp_FName
        {
            get { return strComp_FName; }
            set { strComp_FName = value; }
        }
        public string Comp_SName
        {
            get { return strComp_SName; }
            set { strComp_SName = value; }
        }
        public string Comp_Img_1
        { get { return strComp_Img_1; } }
        public string Comp_Img_2
        { get { return strComp_Img_2; } }
        public string Comp_Img_3
        { get { return strComp_Img_3; } }
        public string Comp_Img_Path
        { get { return strComp_Img_Path; } }

        public int Comp_ID
        {
            get { return strComp_ID; }
            set { strComp_ID = value; }
        }
        public string Img_Path_Logo
        { get { return strImg_Path_Logo; } }


        public string Last_IPAddress
        {
            get { return strUser_LastLoginIP; }
            set { strUser_LastLoginIP = value; }
        }

        public int Get_UserLogin(string vUserName, string vUserPassword, string vComp_Passkey, string vComp_Code, string vIP, string vMacAdd, int vLoginAttempt, string vUser_Mac)      //,string vUser_Brs
        {
            database1 clsdatabase1 = new database1();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, "", DataRowVersion.Default, 0));
            SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
            SCmd.Parameters.Add(new SqlParameter("@sUser_Name", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vUserName.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@sUser_Password", SqlDbType.VarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vUserPassword.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@sComp_Code", SqlDbType.VarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_Code));
            SCmd.Parameters.Add(new SqlParameter("@sUser_IP", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vIP.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@sUser_Mac_Add", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vMacAdd.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@sUser_LastLoginIP", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vIP.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@nUser_Branch_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nUser_Dept_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nUser_SrNo", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sUser_FName", SqlDbType.VarChar, 50, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nUser_DaysLeft", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, 0));
            SCmd.Parameters.Add(new SqlParameter("@dUser_LogInDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@dUser_LastLoginDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nUser_LoginAttempts", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vLoginAttempt));
            SCmd.Parameters.Add(new SqlParameter("@sBranch_Code", SqlDbType.VarChar, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sBranch_SName", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sBranch_FName", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_BrID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            // SCmd.Parameters.Add(new SqlParameter("@bBranch_Bal", SqlDbType.Bit, 1, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 2));
            SCmd.Parameters.Add(new SqlParameter("@sComp_PassKey", SqlDbType.VarChar, 2000, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, vComp_Passkey.Trim()));
            SCmd.Parameters.Add(new SqlParameter("@sComp_FName", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sComp_SName", SqlDbType.VarChar, 20, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sComp_Img_1", SqlDbType.VarChar, 50, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sComp_Img_2", SqlDbType.VarChar, 50, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sComp_Img_3", SqlDbType.VarChar, 50, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sComp_Img_Path", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sImg_Path_Logo", SqlDbType.VarChar, 500, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));

            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            //SCmd.Parameters.Add(new SqlParameter("@sUser_Brs", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vUser_Brs));
            //SCmd.Parameters.Add(new SqlParameter("@sMac", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vUser_Mac));
            clsdatabase1.Exec_Int_SP("stpAdm_Login", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();

            if (Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value) == 1)
            {
                strUser_Name = SCmd.Parameters["@sUser_Name"].Value.ToString();

                strUser_ID = Convert.ToInt32(SCmd.Parameters["@nUser_ID"].Value);
                try
                {
                    strUser_Branch_ID = Convert.ToInt32(SCmd.Parameters["@nUser_Branch_ID"].Value);
                }
                catch { strUser_Branch_ID = 1; }
                try
                {
                    strUser_Dept_ID = Convert.ToInt32(SCmd.Parameters["@nUser_Dept_ID"].Value);
                }
                catch { strUser_Dept_ID = 2; }
                //strUser_SrNo = Convert.ToInt32(SCmd.Parameters["@nUser_SrNo"].Value);
                strUser_FName = SCmd.Parameters["@sUser_FName"].Value.ToString();
                strUser_DaysLeft = Convert.ToInt16(SCmd.Parameters["@nUser_DaysLeft"].Value);
                strBranch_Code = SCmd.Parameters["@sBranch_Code"].Value.ToString();
                strBranch_SName = SCmd.Parameters["@sBranch_SName"].Value.ToString();
                strBranch_FName = SCmd.Parameters["@sBranch_FName"].Value.ToString();
                try
                {
                    strBranch_BrID = Convert.ToInt32(SCmd.Parameters["@nBranch_BrID"].Value);
                }
                catch { strBranch_BrID = 1; }
                //strBranch_Bal = Convert.ToBoolean(SCmd.Parameters["@bBranch_Bal"].Value);
                strComp_PassKey = SCmd.Parameters["@sComp_PassKey"].Value.ToString();
                strComp_FName = SCmd.Parameters["@sComp_FName"].Value.ToString();
                strComp_SName = SCmd.Parameters["@sComp_SName"].Value.ToString();
                strComp_Img_1 = SCmd.Parameters["@sComp_Img_1"].Value.ToString();
                strComp_Img_2 = SCmd.Parameters["@sComp_Img_2"].Value.ToString();
                strComp_Img_3 = SCmd.Parameters["@sComp_Img_3"].Value.ToString();
                strComp_Img_Path = SCmd.Parameters["@sComp_Img_Path"].Value.ToString();
                strImg_Path_Logo = SCmd.Parameters["@sImg_Path_Logo"].Value.ToString();

                strComp_ID = Convert.ToInt32(SCmd.Parameters["@nComp_ID"].Value);
                dtUser_LoginDate = Convert.ToDateTime(SCmd.Parameters["@dUser_LogInDate"].Value);
                try
                {
                    dtUser_LastLoginDate = Convert.ToDateTime(SCmd.Parameters["@dUser_LastLoginDate"].Value);
                }
                catch { }
                strUser_LoginAttempts = Convert.ToInt32(SCmd.Parameters["@nUser_LoginAttempts"].Value);
                strUser_LastLoginIP = SCmd.Parameters["@sUser_LastLoginIP"].Value.ToString();

            }
            return Convert.ToInt32(SCmd.Parameters["@nRetValue"].Value);
        }


        public int Get_UserLogOut(Int32 vSrNo)
        {
            database1 clsdatabase1 = new database1();
            // SqlParameter[] param = new SqlParameter[15];
            SqlCommand SCmd = new SqlCommand();

            SCmd.Parameters.Add(new SqlParameter("@nRetValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, "", DataRowVersion.Default, 0));
            SCmd.Parameters.Add(new SqlParameter("@nUser_ID", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
            SCmd.Parameters.Add(new SqlParameter("@nUser_Branch_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nUser_SrNo", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, vSrNo));
            SCmd.Parameters.Add(new SqlParameter("@sUser_FName", SqlDbType.VarChar, 50, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            // SCmd.Parameters.Add(new SqlParameter("@nUser_Dept_ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nUser_DaysLeft", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, 0));
            SCmd.Parameters.Add(new SqlParameter("@sBranch_Code", SqlDbType.VarChar, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sBranch_SName", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sBranch_FName", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nBranch_BrID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@bBranch_Bal", SqlDbType.Bit, 1, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            // SCmd.Parameters.Add(new SqlParameter("@sBranch_MTI", SqlDbType.VarChar, 15, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            //SCmd.Parameters.Add(new SqlParameter("@bBranch_Comm", SqlDbType.Bit, 1, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@dUser_LogInDate", SqlDbType.DateTime, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sComp_PassKey", SqlDbType.VarChar, 2000, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@sComp_FName", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, DBNull.Value));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, 3));

            clsdatabase1.Exec_Int_SP("stpAdm_Login", SCmd);
            strErrorCode = clsdatabase1.sErrorCode;
            return 0;

        }

    }
}
