using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ERP.Accounts;
using DevExpress.XtraEditors;
using ERP.Inventory;

namespace ERP
{
    public partial class HomeScreen : DevExpress.XtraEditors.XtraForm
    {
        private static int nVisible_Time = 0;
        private static int nCurr_Time = 0;

        public HomeScreen()
        {
            InitializeComponent();
            lblMessage.Caption = "";
            timer1.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            nCurr_Time++;
            if (nCurr_Time == nVisible_Time)
            {
                lblMessage.Caption = "";
                timer1.Stop();
            }
        }
        public void Display_Message(string lblMsg, bool MsgType)
        {
            lblMessage.Caption = lblMsg;
            if (MsgType)
            {
                lblMessage.ItemAppearance.Normal.ForeColor = Color.Green;
                lblMessage.ItemAppearance.Normal.Image = imageCollection1.Images["ok.png"];
                nVisible_Time = 5;
            }
            else
            {
                lblMessage.ItemAppearance.Normal.ForeColor = Color.Red;
                lblMessage.ItemAppearance.Normal.Image = imageCollection1.Images["error.png"];
                nVisible_Time = 10;
            }
            nCurr_Time = 0;
            timer1.Start();
        }
        private bool IsFormOpen(Form frm)
        {
            bool IsOpened = false;
            if(MdiChildren.Count() > 0)
            {
                foreach (var frmChild in MdiChildren)
                {
                    if(frm.Name == frmChild.Name)
                    {
                        IsOpened = true;
                    }
                }
            }
            return IsOpened;
        }
        private void btnAccounts_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAccounts ObjfrmAccounts = new frmAccounts();
            ObjfrmAccounts.MdiParent = this;
            ObjfrmAccounts.Show();
            ObjfrmAccounts.BringToFront();
        }

        private void btnAc_OB_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Acc_OB ObjAcc_OB = new Acc_OB();
            ObjAcc_OB.MdiParent = this;
            ObjAcc_OB.Show();
            ObjAcc_OB.BringToFront();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Vouchers ObjVouchers = new Vouchers();
            ObjVouchers.MdiParent = this;
            ObjVouchers.Show();
            ObjVouchers.BringToFront();
        }

        private void HomeScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Inv_Setup ObjInv_Setup = new Inv_Setup();
            ObjInv_Setup.MdiParent = this;
            ObjInv_Setup.Show();
            ObjInv_Setup.BringToFront();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Item_OB ObjItem_OB = new Item_OB();
            ObjItem_OB.MdiParent = this;
            ObjItem_OB.Show();
            ObjItem_OB.BringToFront();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GRN ObjGRN = new GRN();
            ObjGRN.MdiParent = this;
            ObjGRN.Show();
            ObjGRN.BringToFront();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PR ObjPR = new PR();
            ObjPR.MdiParent = this;
            ObjPR.Show();
            ObjPR.BringToFront();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Sales ObjSales = new Sales();
            ObjSales.MdiParent = this;
            ObjSales.Show();
            ObjSales.BringToFront();
        }
        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SR ObjSR = new SR();
            ObjSR.MdiParent = this;
            ObjSR.Show();
            ObjSR.BringToFront();
        }

    }
}