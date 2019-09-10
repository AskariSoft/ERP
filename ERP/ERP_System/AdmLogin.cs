using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.NetworkInformation;
using System.Security;
using System.Net;
using ERP;
using ERP.BLL;
using ERP.DAL;
using ERP.BLL.SYS;

namespace ERP.EPR_System
{
    public partial class AdmLogin : XtraForm
    {
        HomeScreen frmHome = new HomeScreen();
        database1 objdatabase1 = new database1();
        ADLogin objclsADLogin = new ADLogin();

        private DataSet ds_1 = null;
        private bool flag;
        private string strFY_ID;
        int I;


        public AdmLogin()
        {
            InitializeComponent();
        }

        private void AdmLogin_Load(object sender, EventArgs e)
        {
            if (flag == true)
            {
                cmbBranch_SName.SelectedValue = mSys_System.pUser_Branch_ID.ToString();
                cmbDeptt.SelectedValue = mSys_System.pUser_Dept_ID.ToString();
                cmbFY.SelectedValue = mSys_System.pFY_ID.ToString();
            }
            Security.ADSecurity clsSecurity = new Security.ADSecurity();
            groupControl1.Visible = false;
            mSys_System.Set_pIP_Address(Get_IP());
            mSys_System.Set_pMac_Address(Get_Mac());
            Set_Option_1();
            if (database1.strCnType == "1")
            {
                txtUserName.Text = "Admin";
                txtUserPassword.Text = "123";
                txtComp_Code.Text = "ABC";

            }
        }
        private void cmd0_OK_Click(object sender, EventArgs e)
        {
            string strComp_PassKey = "";
            mSys_System.Set_pUserName(txtUserName.Text.Trim());
            mSys_System.Set_pBranch_SName(cmbBranch_SName.Text);
            Security.ADSecurity clsSecurity = new Security.ADSecurity();
            mSys_System.Set_pUser_Pwd(clsSecurity.Set_Encrypt(txtUserPassword.Text.Trim(), database1.pSecKey));
            mSys_System.Set_pUserComp_Code(txtComp_Code.Text.Trim());
            strComp_PassKey = clsSecurity.Set_Encrypt(database1.pUserPassKey, database1.pSecKey);   //txtComp_Code.Text.Trim();


            int strLoginAttempt = 0;
            int strRetValue;
            strRetValue = objclsADLogin.Get_UserLogin(Convert.ToString(mSys_System.pUserName), Convert.ToString(mSys_System.pUser_Pwd), Convert.ToString(strComp_PassKey), Convert.ToString(mSys_System.pUserComp_Code), Convert.ToString(mSys_System.pIP_Address), Convert.ToString(mSys_System.pMac_Address), strLoginAttempt, Convert.ToString(mSys_System.pMac_Address));

            if (objclsADLogin.sErrorCode.Trim() != "")
            {
               XtraMessageBox.Show("MsgDBError : " + " '" + objclsADLogin.sErrorCode + "'", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (strRetValue == -1)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                this.lblStatus.Text = "Server not accessible...";
                this.lblStatus.ForeColor =Color.Red;
                return;
            }
            else if (strRetValue == -2)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                lblStatus.Visible = true;
                this.lblStatus.ForeColor =Color.Red;
                this.lblStatus.Text = "Invalid User ID...";
                return;
            }
            else if (strRetValue == -3)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                this.lblStatus.ForeColor =Color.Red;
                this.lblStatus.Text = "Access Denied..."; //lblMsg_1
                return;
            }
            else if (strRetValue == -4)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                this.lblStatus.ForeColor =Color.Red;
                this.lblStatus.Text = "Incorrect Password...";
                //ViewState["strAttempts"] = Convert.ToInt32(ViewState["strAttempts"]) + 1;
                return;
            }
            else if (strRetValue == -5)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                this.lblStatus.ForeColor =Color.Red;
                this.lblStatus.Text = "Invalid IP...";
                return;
            }
            else if (strRetValue == -6)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                lblStatus.Text = "";
                this.lblStatus.ForeColor =Color.Red;
               XtraMessageBox.Show("The User ID \"" + mSys_System.pUserName + "\" has been blocked by the system. The user has not changed the password in the specified period. Please contact your system administrator to activate the login........................", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (strRetValue == -7)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                lblStatus.Text = "";
                this.lblStatus.ForeColor =Color.Red;
               XtraMessageBox.Show("The User ID \"" + mSys_System.pUserName + "\" has been blocked by the system due to multiple incorrect password attempts. Please contact your system administrator to activate the login........................", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (strRetValue == -8)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                lblStatus.Text = "";
                this.lblStatus.ForeColor =Color.Red;
               XtraMessageBox.Show("The User ID \"" + mSys_System.pUserName + "\" has been blocked by the system due to multiple incorrect password attempts. Please contact your system administrator to activate the login........................", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //else if (strRetValue == -9)
            //{
            //    this.txtUserName.Text = "";
            //    this.txtUserPassword.Text = "";
            //    lblMsg_1.Text = "";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "AfterLogin", "alert('Your password shall expire after " + strDayDiff + " days, you are required to change the password.......................');", true);
            //    return;
            //}
            else if (strRetValue == -11)
            {

                lblStatus.Text = "Invalid Level...";
                lblStatus.ForeColor =Color.Red;
                return;
            }
            else if (strRetValue == -10)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                lblStatus.Text = "";
               XtraMessageBox.Show("The User ID \"" + mSys_System.pUserName + "\" has been blocked by the system. The user has not changed the password in the specified period. Please contact your system administrator to activate the login........................", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (strRetValue == -122)
            {
                this.txtUserName.Text = "";
                this.txtUserPassword.Text = "";
                lblStatus.Text = "";
               XtraMessageBox.Show("The User ID \"" + mSys_System.pUserName + "\" has IP/Mac Restriction by the system. Please contact your system administrator ........................", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (strRetValue == 1)
            {

                mSys_System.Set_pUser_ID(objclsADLogin.UserID);
                mSys_System.Set_pComp_ID(objclsADLogin.Comp_ID);
                mSys_System.Set_pUserName(objclsADLogin.UserName);
                mSys_System.Set_pUser_FullName(objclsADLogin.UserFullName);
                mSys_System.Set_pUser_Pwd(txtUserPassword.Text.Trim());
                mSys_System.Set_pUser_SrNo(objclsADLogin.UserSrNo);
                mSys_System.Set_pUser_Branch_ID(objclsADLogin.User_Branch_ID);
                mSys_System.Set_pUser_Dept_ID(objclsADLogin.User_Dept_ID);
                mSys_System.Set_pUser_LoginDate(objclsADLogin.LoginDate);
                mSys_System.Set_pCN(objclsADLogin.Comp_FName);
                mSys_System.Set_pComp_ID(objclsADLogin.Comp_ID);
                mSys_System.Set_pComp_PassKey(txtComp_Code.Text.Trim());
                mSys_System.Set_pComp_FName(objclsADLogin.Comp_FName);
                mSys_System.Set_pComp_SName(objclsADLogin.Comp_SName);
                mSys_System.Set_pComp_Img_1(objclsADLogin.Comp_Img_1);
                mSys_System.Set_pComp_Img_2(objclsADLogin.Comp_Img_2);
                mSys_System.Set_pComp_Img_3(objclsADLogin.Comp_Img_3);
                mSys_System.Set_pComp_Img_Path(objclsADLogin.Comp_Img_Path);
                mSys_System.Set_pImg_Path_Logo(objclsADLogin.Img_Path_Logo);

                mSys_System.Set_pBranch_ID(objclsADLogin.User_Branch_ID);
                mSys_System.Set_pBranchCode(objclsADLogin.BranchCode);
                mSys_System.Set_pBranch_BrID(objclsADLogin.Branch_BrID);
                mSys_System.Set_pBranch_FName(objclsADLogin.BranchFName);
                mSys_System.Set_pBranch_SName(objclsADLogin.BranchSName);
                mSys_System.Set_pBranch_Bal(objclsADLogin.Branch_Bal);

                mSys_System.Set_pPass_DaysLeft(objclsADLogin.DaysLeft);
                mSys_System.Set_pLast_IPAddress("");

                mSys_System.Set_pTrLevel_Pending_All_Under_Process();
                mSys_System.Set_pTrLevel_PendingApp_L1();
                mSys_System.Set_pTrLevel_PendingApp_L1_D();
                mSys_System.Set_pTrLevel_PendingApp_L2();
                mSys_System.Set_pTrLevel_PendingApp_L2_D();
                mSys_System.Set_pTrLevel_Under_Inspection();
                mSys_System.Set_pTrLevel_Under_Inspection_D();
                mSys_System.Set_pTrLevel_Inspection_Done();
                mSys_System.Set_pTrLevel_Inspection_Done_D();
                mSys_System.Set_pTrLevel_Approved();
                mSys_System.Set_pTrLevel_Approved_D();
                mSys_System.Set_pTrLevel_Cancelled();
                mSys_System.Set_pTrLevel_Cancelled_D();
                mSys_System.Set_pTrLevel_Pending();
                mSys_System.Set_pTrLevel_Pending_D();
                mSys_System.Set_pTrLevel_Cleared();
                mSys_System.Set_pTrLevel_Cleared_D();

                mSys_System.Set_pLast_LoginDateTime(Convert.ToDateTime("01/01/1900"));
                //mSys_System.Set_pFYSDate_System(objdatabase1.)
                if (objclsADLogin.Last_IPAddress != null)
                {
                    if (objclsADLogin.Last_IPAddress != "")
                    {
                        try
                        {
                            mSys_System.Set_pLast_IPAddress(objclsADLogin.Last_IPAddress);
                            mSys_System.Set_pLast_LoginDateTime(objclsADLogin.LastLoginDate);
                        }
                        catch
                        {
                            mSys_System.Set_pLast_IPAddress("");
                            mSys_System.Set_pLast_LoginDateTime(Convert.ToDateTime("01/01/1900"));
                        }
                    }
                }

                mSys_System.Set_pDateFormat_Long("dd-MMM-yyyy");
                mSys_System.Set_pDateTimeFormat_Long("dd-MMM-yyyy hh:mm tt");
                mSys_System.Set_pDateFormat("dd/MM/yyyy");
                mSys_System.Set_pDateTimeFormat("dd/MM/yyyy hh:mm tt");


                //---------------------------


                Fill_Combo(mSys_System.pUser_ID, mSys_System.pComp_ID);

                cmd0_OK.Visible = false;
                cmd1_OK.Visible = true;
                txtUserName.Enabled = false;
                txtUserPassword.Enabled = false;
                txtComp_Code.Enabled = false;

                groupControl1.Visible = true;

                //lblPwd_DaysLeft.Text = "Expire Password Days Left: " + " " + mSys_System.pPass_DaysLeft.ToString();
                //lblLastLoginID.Text = "Last IP Address: " + " " + mSys_System.pLast_IPAddress;
                //lblLastLoginDate.Text = "Last Login Date: " + " " + mSys_System.pLast_LoginDateTime.ToString("dd-MMM-yyyy hh:mm tt");
                //lblPwd_DaysLeft.Visible = true;
                //lblLastLoginID.Visible = true;
                //lblLastLoginDate.Visible = true;

                Set_Option_2();

                //------------------

                //}
            }
        }

        private void cmd0_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmProgress_Tick(object sender, EventArgs e)
        {
            I += 5;

            try
            {

                if (I >= 100)
                {
                    mSys_System.Set_blnLoginOk(true);
                    tmProgress.Stop();
                    this.Hide();
                    frmHome.lblUsername.Caption = mSys_System.pUserName;
                    frmHome.lblBranch_SName.Caption = mSys_System.pBranch_SName;
                    frmHome.Show();
                }

               // pBar.Value = I;

                if (I >= 100)
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

        private void cmd1_OK_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = true;
            lblStatus.Text = "Please wait...";
            this.Refresh();

            if (cmbBranch_SName.Text == "")
            {
               XtraMessageBox.Show("Please select a valid Location, and then try again...", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbBranch_SName.Select();
                cmbBranch_SName.Focus();
                return;
            }
            if (cmbDeptt.Text == "")
            {
               XtraMessageBox.Show("Please select a valid Department, and then try again...", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDeptt.Select();
                cmbDeptt.Focus();
                return;
            }
            if (cmbFY.Text == "")
            {
               XtraMessageBox.Show("Please select a valid Financial-Year, and then try again...", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFY.Select();
                cmbFY.Focus();
                return;
            }
            //' '''''''''''''''''''''''''''''''

            cmd0_OK.Enabled = false;
            cmd0_Cancel.Enabled = false;
            /*Branch values*/
            mSys_System.Set_pBranch_ID(Convert.ToInt32(cmbBranch_SName.SelectedValue.ToString().Split('|')[0].ToString()));
            mSys_System.Set_pBranchCode(cmbBranch_SName.SelectedValue.ToString().Split('|')[1].ToString());
            mSys_System.Set_pBranch_SName(cmbBranch_SName.Text.Trim());
            mSys_System.Set_pBranch_FName(cmbBranch_SName.Text.Trim());
            frmHome.lblBranch_SName.Caption = mSys_System.pBranch_SName;
            mSys_System.Set_pUser_Branch_ID(Convert.ToInt32(cmbBranch_SName.SelectedValue.ToString().Split('|')[0].ToString()));

            /*Dept values*/
            mSys_System.Set_pUser_Dept_ID(Convert.ToInt32(cmbDeptt.SelectedValue.ToString().Split('|')[0].ToString()));
            mSys_System.Set_pUser_Dept(cmbDeptt.Text.Trim());

            /*FY values*/
            mSys_System.Set_pFY_ID(Convert.ToInt32(cmbFY.SelectedValue.ToString().Split('|')[0].ToString()));
            mSys_System.Set_pFY(cmbFY.Text);
            mSys_System.Set_pFYSDate(Convert.ToDateTime(Convert.ToDateTime(cmbFY.SelectedValue.ToString().Split('|')[1].ToString())));
            mSys_System.Set_pFYEDate(Convert.ToDateTime(Convert.ToDateTime(cmbFY.SelectedValue.ToString().Split('|')[2].ToString())));
            mSys_System.Set_pFYNDate(mSys_System.pFYEDate.AddDays(1));
            strFY_ID = mSys_System.pFY_ID.ToString();

            mSys_System.Set_pServerName(objdatabase1.GetServerName());
            //----------------
            //strFY_ID = mSys_System.pFY_ID.ToString();
            //DataRow[] dr = ds_1.Tables[1].Select("FY_ID=" + strFY_ID);
            //for (int i = 0; i <= ds_1.Tables[1].Rows.Count - 1; i++)
            //{
            //    if (ds_1.Tables[1].Rows[I]["FY_ID"].ToString() == strFY_ID)
            //    {
            //        mSys_System.Set_pFY(ds_1.Tables[1].Rows[I]["FY"].ToString());
            //        mSys_System.Set_pFYSDate(Convert.ToDateTime(Convert.ToDateTime(ds_1.Tables[1].Rows[I]["SDate"]).ToString("MM/dd/yyyy")));
            //        mSys_System.Set_pFYEDate(Convert.ToDateTime(Convert.ToDateTime(ds_1.Tables[1].Rows[I]["EDate"]).ToString("MM/dd/yyyy")));
            //        break;
            //    }
            //}
          //  pBar.Visible = true;
            //----------------
            if (flag == false)
            {

                mSys_System.Set_pUserName(txtUserName.Text.Trim());
                Security.ADSecurity clsSecurity = new Security.ADSecurity();
                mSys_System.Set_pUser_Pwd(clsSecurity.Set_Encrypt(txtUserPassword.Text.Trim(), database1.pSecKey));
                mSys_System.Set_pUserComp_Code(txtComp_Code.Text.Trim());

                tmProgress.Start();

            }
            else
            {
                flag = false;
                this.Hide();
                //SetpVals1();
            }

        }

        public void Fill_Combo(int vUser_ID, int vComp_ID)
        {
            GNBranch clsGNBranch = new GNBranch();
            ds_1 = clsGNBranch.Fill_Combo(vUser_ID, vComp_ID);
            if (clsGNBranch.sErrorCode != null)
            {
               XtraMessageBox.Show("MsgDBError : " + " '" + clsGNBranch.sErrorCode + "'", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Set_Combo(cmbBranch_SName, ds_1.Tables[0], "Branch_SName", "Branch_ID", false);
            Set_Combo(cmbDeptt, ds_1.Tables[1], "Dept_DD", "Dept_ID", false);
            Set_Combo(cmbFY, ds_1.Tables[2], "FY", "FY_ID", false);

        }

        public void Set_Combo(System.Windows.Forms.ComboBox cmdToFill, DataTable dt_Source, string DisplayField, string ValueField, bool All)
        {
            DataTable dt_1 = new DataTable();
            if (dt_Source == null)
            {
                cmdToFill.Items.Insert(0, "");
                return;
            }

            dt_1 = dt_Source.Copy();

            if (DisplayField.Trim() == "" || ValueField.Trim() == "")
            {
                return;
            }

            cmdToFill.Items.Clear();
            cmdToFill.DisplayMember = DisplayField.Trim();
            cmdToFill.ValueMember = ValueField.Trim();

            cmdToFill.DataSource = dt_1;
            cmdToFill.SelectedIndex = -1;

            if (All == true)
            {
                cmdToFill.Items.Insert(0, "");
            }
            // cmdToFill.SelectedIndex = cmdToFill.Items.Count -1;
        }
        public void Set_Option_1()
        {
            lblStatus.Text = "";
            groupControl1.Visible = false;
            lblStatus.Location = new Point(0,265);
            this.Size = new Size(301,300);
        }

        public void Set_Option_2()
        {
            groupControl1.Visible = true;
            lblStatus.Location = new Point(6, 369);
            this.Size = new Size(301, 412);

            try
            {
                cmbBranch_SName.SelectedValue = ds_1.Tables[0].Rows[0]["Branch_ID"].ToString().Trim();
            }
            catch
            { }
            try
            {
                cmbDeptt.SelectedValue = ds_1.Tables[1].Rows[0]["Dept_ID"].ToString().Trim();
            }
            catch
            { }
            try
            {
                cmbFY.SelectedValue = ds_1.Tables[2].Rows[0]["FY_ID"].ToString().Trim();
            }
            catch
            {
                cmbFY.SelectedValue = 0;
            }

            cmbBranch_SName.Focus();
        }

        public void Set_Option_3()
        {
            
            this.Size = new Size(352, 180);
            groupControl1.Visible = true;
            flag = true;
        }

        private string Get_IP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();
        }

        public string Get_Mac()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            return nics[1].GetPhysicalAddress().ToString();
        }

        private void cmd1_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }
}