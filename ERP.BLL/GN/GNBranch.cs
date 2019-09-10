using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ERP.DAL;

namespace ERP.BLL
{
    public class GNBranch
    {
        database1 objdatabase1 = new database1();

        private string strErrorCode;
        private int strRet_Val;

        //public GN_Branch();
        public string sErrorCode { get; set; }
        public int Ret_Val { get; set; }


        public DataSet Fill_Combo(int vU_S, int vComp_ID)
        {
            DataSet ds_1 = new DataSet();
            SqlCommand SCmd = new SqlCommand();
            SCmd.Parameters.Add(new SqlParameter("@nU_S", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vU_S));
            SCmd.Parameters.Add(new SqlParameter("@nComp_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, vComp_ID));
            SCmd.Parameters.Add(new SqlParameter("@nIsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
            ds_1 = objdatabase1.Get_DS_SP("stpGN_Branch", SCmd);
            strErrorCode = objdatabase1.sErrorCode.Trim();
            return ds_1;
        }
    }
}
