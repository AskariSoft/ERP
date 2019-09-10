using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ERP;

namespace ERP.SYS
{
    public class Gutil
    {
        Timer timer2 = new Timer();
        private static BarStaticItem lblMsg = new BarStaticItem();
        private static int nVisible_Time = 0;
        private static int nCurr_Time = 0;
        public Gutil() 
        {
            timer2.Interval = 1000;
            timer2.Enabled = true;
            timer2.Tick += new EventHandler(timer2_Tick);
        }
        
        public void Display_Message(BarStaticItem lblMessage,string Msg, bool MessageType)
        {
            
            lblMsg = lblMessage;
            lblMsg.Visibility = BarItemVisibility.Never;
            lblMsg = lblMessage;
            if (MessageType == true)
            {
                lblMsg.ItemAppearance.Normal.ForeColor = Color.Green;
                nVisible_Time = 5;
            }
            else
            {
                lblMsg.ItemAppearance.Normal.ForeColor = Color.Red;

                nVisible_Time = 10;
            }
            lblMsg.Caption = Msg;
            lblMsg.Visibility = BarItemVisibility.Always;
            nCurr_Time = 0;
            timer2.Start();
        }
        
        public void Display_Msg(Form myFrm, string Msg, bool MessageType)
        {
            if (MessageType == true)
            {
                lblMsg.ItemAppearance.Normal.ForeColor = Color.Green;
                nVisible_Time = 5;
            }
            else
            {
                lblMsg.ItemAppearance.Normal.ForeColor = Color.Red;

                nVisible_Time = 10;
            }
            lblMsg.Caption = Msg;
            nCurr_Time = 0;
            timer2.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            nCurr_Time++;
            if (nCurr_Time == nVisible_Time)
            {
                lblMsg.Visibility = BarItemVisibility.Never;
                timer2.Stop();
            }
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
    }
}
