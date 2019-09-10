using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using ERP.DAL;
using ERP.BLL.Accounts.RPT;
using ERP.BLL.SYS;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;

namespace ERP.Accounts.RPT
{
    public partial class AC01 : RibbonForm
    {
        ReportDocument rptDocument = new ReportDocument();
        ParameterField rptParamField = new ParameterField();
        ParameterFields rptParamFields = new ParameterFields();
        ParameterDiscreteValue rptParamDiscreteValue = new ParameterDiscreteValue();
        TableLogOnInfo crLogonInfo;
        public AC01()
        {
            InitializeComponent();
        }
        database1 clsdatabase1 = new database1();
        string strErrorCode;
        string strS = "";
        public void init_cmm()
        {
            SCmd = new SqlCommand();
        }
        SqlCommand SCmd = new SqlCommand();
        System.Data.SqlClient.SqlConnection gCn = new System.Data.SqlClient.SqlConnection();

        #region Data Members
        private string strReport;
        private string strVrNo;
        private string strType;
        private string strFromTo;
        private string strSql;
        private string strSubSqNo;
        //private object strReport;
        public int pBranchID;

        private SqlDataReader sqlDReader;
        private SqlTransaction Tran;

        private bool blnNOU;
        private bool blnSqNo;
        private bool blnSubLedger;


        private DateTime dtSDate;
        private DateTime dtEDate;
        private DataSet dsRpt;
        private string[,] strParaArray;
        private SqlDataAdapter sqlDAdapter;

        #endregion
        #region  Messages on This form
        private const string cnMsg_ErrSaveUpdate = "The system is unable to process the request. Please check error: ";
        #endregion
        private void EM26_Load(object sender, EventArgs e)
        {
            Fill_Combo();
        }

        private void Fill_Combo()
        {
            rptAC01 clsrptAC01 = new rptAC01();
            DataSet ds_1;

            ds_1 = clsrptAC01.Fill_Combo(mSys_System.pComp_ID, mSys_System.pUser_ID);
            if (clsrptAC01.sErrorCode.Trim() != "")
            {
                MessageBox.Show(cnMsg_ErrSaveUpdate + " '" + clsrptAC01.sErrorCode + "'", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Set_Combo(lookBranch_ID, ds_1.Tables[3], "Branch_SName", "Branch_ID", true);
        }

        private void Set_Combo(LookUpEdit cmdToFill, DataTable dt_Source, string DisplayField, string ValueField, bool All)
        {
            DataTable dt_1 = new DataTable();
            if (dt_Source == null)
            {
                return;
            }

            dt_1 = dt_Source.Copy();

            if (DisplayField.Trim() == "" || ValueField.Trim() == "")
            {
                return;
            }
            cmdToFill.Properties.DataSource = null;

            cmdToFill.Properties.DisplayMember = DisplayField.Trim();
            cmdToFill.Properties.ValueMember = ValueField.Trim();

            if (All)
            {
                DataRow row = dt_1.NewRow();
                row[0] = "";
                row[1] = -1;
                dt_1.Rows.InsertAt(row, 0);
            }
            cmdToFill.Properties.DataSource = dt_1;
        }
        public void Call_S(int vVal, Label vLab = null)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (vVal == 1)
            {
                vLab.Visible = true;
                vLab.Text = "Please wait...";
                Application.DoEvents();
            }
        }
        public void Call_E(int vVal, Label vLab = null)
        {
            Cursor.Current = Cursors.Default;
            if (vVal == 1)
            {
                vLab.Visible = false;
                Application.DoEvents();
            }
        }

        private void cmd0_Print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print_EM26();
        }

        private void Print_EM26()
        {
            string strRptPath = "";
            string strU_RptNo = "";
            string strRptNo = "";
            string strRType = lookRType.Text.Trim();
            int strBranch_ID = -1;
            if (lookBranch_ID.Text != "")
            {
                strBranch_ID = Convert.ToInt32(lookBranch_ID.EditValue);
            }

            RptViewer frmRptViewer = new RptViewer();

            ParameterField rptParamField = new ParameterField();
            ParameterFields rptParamFields = new ParameterFields();
            ParameterDiscreteValue rptParamDiscreteValue = new ParameterDiscreteValue();

            ReportDocument rptDocument = new ReportDocument();

            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@nComp_ID";
            rptParamDiscreteValue.Value = mSys_System.pComp_ID;
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);

            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@nBranch_ID";
            rptParamDiscreteValue.Value = strBranch_ID.ToString();
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);

            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@dBegDate";
            rptParamDiscreteValue.Value = dtpBegDate.EditValue;
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);


            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@dEndDate";
            rptParamDiscreteValue.Value = dtpEndDate.EditValue;
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);

            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@dFYSDate";
            rptParamDiscreteValue.Value = mSys_System.pFYSDate.ToShortDateString();
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);

            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@sMainCode";
            rptParamDiscreteValue.Value = lookUpEdit1.GetColumnValue("Code");
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);

            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@nU_S";
            rptParamDiscreteValue.Value = mSys_System.pUser_ID;
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);

            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@sU_Name";
            rptParamDiscreteValue.Value = mSys_System.pUserName;
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);

            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@sU_RptName";
            rptParamDiscreteValue.Value = strRType;
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);

            rptParamField = new ParameterField();
            rptParamDiscreteValue = new ParameterDiscreteValue();
            rptParamField.Name = "@sU_Event";
            rptParamDiscreteValue.Value = "";
            rptParamField.CurrentValues.Add(rptParamDiscreteValue);
            rptParamFields.Add(rptParamField);


            if (strRType == "Complete Account Balance")
            {
                rptParamField = new ParameterField();
                rptParamDiscreteValue = new ParameterDiscreteValue();
                rptParamField.Name = "@sU_RptNo";
                rptParamDiscreteValue.Value = "EM26.01";
                rptParamField.CurrentValues.Add(rptParamDiscreteValue);
                rptParamFields.Add(rptParamField);

                frmRptViewer.Text = lookRType.Text + "...........";
                try
                {
                    strRptPath = Application.StartupPath;
                    strRptPath = strRptPath.Substring(0, strRptPath.Length - 3) + "Reports\\rptAC0101.rpt";

                    rptDocument.Load(strRptPath);
                    frmRptViewer.Set_ReportConnection(rptDocument);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //---Passing Report Formula's
                FormulaFieldDefinitions formulaList;
                formulaList = rptDocument.DataDefinition.FormulaFields;
                formulaList["CN"].Text = "'" + mSys_System.pCN.ToString().ToUpper() + "'";
                formulaList["BranchSName"].Text = "'" + lookBranch_ID.Text + "'";
                formulaList["Criteria1"].Text = "'" + strRType + "'";
                formulaList["Criteria2"].Text = "'Reporting From " + dtpBegDate.EditValue + " to " + dtpEndDate.EditValue + "'";
                formulaList["RPT"].Text = "'EM26.01'";
                formulaList["UserName"].Text = "'" + mSys_System.pUserName + "'";

                //---Passing Selection formula
                rptDocument.DataDefinition.RecordSelectionFormula = "";

                //---Setting Report to view
                frmRptViewer.crv.ParameterFieldInfo = rptParamFields;
                frmRptViewer.crv.ReportSource = rptDocument;
                frmRptViewer.Show();
                return;
            }

        }
     
        private void cmd0_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
