using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using ERP.EPR_System;
using ERP.DAL;
using DevExpress.XtraEditors;
using ERP.BLL.SYS;

namespace ERP
{
    public partial class Splash : SplashScreen
    {
        private AdmLogin frmAdmLogin = new AdmLogin();
        database1 clsdatabase1 = new database1();
        int I;
        public Splash()
        {
            InitializeComponent();
            //---project details
            //pCN = "Road Prince Automotive (Pvt) Ltd"
            mSys_System.Set_pCN("BMS Lahore");
            mSys_System.Set_pCNAdd("Address 1 ");
            mSys_System.Set_pPFName("Business Management System");
            mSys_System.Set_pPSName("BMS");
            mSys_System.Set_pBranchSName_Con("BMS - Consolidated Level");

            //---ver
            //pPVer1 = "01"
            //pPVer2 = "001"
            //pPVer3 = "071315"

            //lblName.Text = "ERP solution" ' especially designed for " & pCN
            lblName.Text = "Business Management System";
            //lblVer.Text = obj_mConnect.pPVer1 + "." + obj_mConnect.pPVer2 + "." + obj_mConnect.pPVer3;
            //lblPFName.Text = mSys_System.pPFName;
            tmProgress.Start();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void tmProgress_Tick(object sender, EventArgs e)
        {
            I += 10;

            try
            {

                if (I >= 1000)
                {
                    frmAdmLogin.Show();
                    this.Hide();
                    mSys_System.Set_blnLoginOk(true);
                    tmProgress.Stop();
                    this.Hide();
                }
                if (I >= 1000)
                {
                    tmProgress.Stop();
                }

            }
            catch (Exception ex)
            {
                tmProgress.Stop();
                this.Hide();
               XtraMessageBox.Show("The application is unable to load. Please start application again.........................", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            lblVer.Text = database1.pVer;
            clsdatabase1.Getdatabase1();
            lblSer.Text = database1.strServerName + " - " + database1.strDatabaseName;
        }
    }
}