using System;
using System.Data;
using System.Data.SqlClient;
using ERP.DAL;

namespace ERP.BLL.Accounts.RPT
{
    public class rptAC01
    {

        private string strErrorCode;
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
        public rptAC01()
        {
        }

        public DataSet Fill_Combo(int vComp_ID, int vUser_ID)
        {
            database1 clsdatabase1 = new database1();
            DataSet ds_1;
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, vUser_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = clsdatabase1.Get_DS_SP("stpSys_Combo", SCmd);
            strErrorCode = clsdatabase1.sErrorCode.Trim();
            return ds_1;
        }
    }
}
