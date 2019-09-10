using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;

namespace ERP
{
    public partial class RptViewer : Form
    {
        public RptViewer()
        {
            InitializeComponent();
        }
        public void Set_ReportConnection(ReportDocument rptDocument)
        {
            TableLogOnInfo crLogonInfo;
            database1 clsDatabase1 = new database1();

            crLogonInfo = rptDocument.Database.Tables[0].LogOnInfo;
            crLogonInfo.ConnectionInfo.ServerName = database1.strServerName;
            crLogonInfo.ConnectionInfo.DatabaseName = database1.strDatabaseName;
            crLogonInfo.ConnectionInfo.UserID = database1.strUserID;
            crLogonInfo.ConnectionInfo.Password = database1.strPassword;
            rptDocument.Database.Tables[0].ApplyLogOnInfo(crLogonInfo);
        }
    }
}
