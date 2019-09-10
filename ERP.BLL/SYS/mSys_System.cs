using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BLL.SYS
{
    public static class mSys_System
    {
        // parameterless constructor required for static class
        //static mSys_System() { pCN = "Company Name"; } // default value

        // public get, and private set for strict access control

        // public string pCN;
        public static int pInv_Detail_ID;
        public static string pInv_DetailCodeD;
        public static string pInv_Unit;
        public static double pInv_Bal_Qty;
        public static double pInv_Bal_Rate;
        public static string pInv_Rec_Unit;
        public static double pInv_Rec_Factor;
        public static double pInv_Bal_SRate;
        public static bool pInv_Bal_Books;
        public static string pBranchSName { get; private set; }
        public static int pBranchID { get; private set; }
        public static int pTrLevel_Pending_All_Under_Process { get; private set; }
        public static int pTrLevel_PendingApp_L1 { get; private set; }
        public static string pTrLevel_PendingApp_L1_D { get; private set; }
        public static int pTrLevel_PendingApp_L2 { get; private set; }
        public static string pTrLevel_PendingApp_L2_D { get; private set; }
        public static int pTrLevel_Approved { get; private set; }
        public static string pTrLevel_Approved_D { get; private set; }

        public static int pTrLevel_Under_Inspection { get; private set; }
        public static string pTrLevel_Under_Inspection_D { get; private set; }
        public static int pTrLevel_Inspection_Done { get; private set; }
        public static string pTrLevel_Inspection_Done_D { get; private set; }


        public static int pTrLevel_Pending { get; private set; }
        public static string pTrLevel_Pending_D { get; private set; }
        public static int pTrLevel_Cleared { get; private set; }
        public static string pTrLevel_Cleared_D { get; private set; }
        public static int pTrLevel_Cancelled { get; private set; }
        public static string pTrLevel_Cancelled_D { get; private set; }
        public static string pCN { get; private set; }
        public static string pCNAdd { get; private set; }
        public static string pPFName { get; private set; }
        public static string pPSName { get; private set; }
        public static bool blnLoginOk { get; private set; }

        public static string pIP_Address { get; private set; }
        public static string pMac_Address { get; private set; }
        public static DateTime pFYNDate { get; private set; }
        public static DateTime pFYEDate { get; private set; }
        public static int pCnType { get; private set; }
        public static DateTime pFYSDate { get; private set; }
        public static DateTime pFYSDate_System { get; private set; }
        public static DateTime pSrvDate { get; private set; }
        public static DateTime pSrvDateTime { get; private set; }
        public static string pConnStr { get; private set; }
        public static string pFY { get; private set; }
        public static int pFY_ID { get; private set; }
        public static string pBranchCode { get; private set; }
        public static string pBranch_SName { get; private set; }
        public static string pUser_FullName { get; private set; }
        public static string pUser_Dept { get; private set; }
        public static string pUserName { get; private set; }
        public static string pUser_Pwd { get; private set; }
        public static string pUserComp_Code { get; private set; }
        public static string pDateFormat { get; private set; }
        public static string pDateTimeFormat { get; private set; }
        public static int pUser_ID { get; private set; }
        public static int pComp_ID { get; private set; }
        public static string pDateTimeFormat_Long { get; private set; }
        public static string pDateFormat_Long { get; private set; }
        public static string pDateTimeMask { get; private set; }
        public static string pDateMask { get; private set; }
        public static string pTimeFormat { get; private set; }
        public static string pBranchSName_Con { get; private set; }
        public static int pUser_SrNo { get; private set; }
        public static int pUser_Branch_ID { get; private set; }
        public static int pUser_Dept_ID { get; private set; }
        public static DateTime pUser_LoginDate { get; private set; }
        public static string pComp_PassKey { get; private set; }
        public static string pComp_FName { get; private set; }
        public static string pComp_SName { get; private set; }
        public static string pComp_Img_1 { get; private set; }
        public static string pComp_Img_2 { get; private set; }
        public static string pComp_Img_3 { get; private set; }
        public static string pComp_Img_Path { get; private set; }
        public static string pImg_Path_Logo { get; private set; }
        public static int pBranch_ID { get; private set; }
        public static int pBranch_BrID { get; private set; }
        public static string pBranch_FName { get; private set; }
        public static bool pBranch_Bal { get; private set; }
        public static int pPass_DaysLeft { get; private set; }
        public static string pLast_IPAddress { get; private set; }
        public static DateTime pLast_LoginDateTime { get; private set; }
        public static string pServerName { get; private set; }


        // GlobalInt can be changed only via this method
        public static void Set_pBranchSName(string newInt)
        {
            pBranchSName = newInt;
        }
        public static void Set_pCN(string newInt)
        {
            pCN = newInt;
        }
        public static void Set_pCNAdd(string newInt)
        {
            pCNAdd = newInt;
        }
        public static void Set_pPFName(string newInt)
        {
            pPFName = newInt;
        }
        public static void Set_pPSName(string newInt)
        {
            pPSName = newInt;
        }
        public static void Set_blnLoginOk(bool newInt)
        {
            blnLoginOk = newInt;
        }
        public static void Set_pIP_Address(string newInt)
        {
            pIP_Address = newInt;
        }
        public static void Set_pMac_Address(string newInt)
        {
            pMac_Address = newInt;
        }
        public static void Set_pCnType(int newInt)
        {
            pCnType = newInt;
        }
        public static void Set_pFYSDate(DateTime newInt)
        {
            pFYSDate = newInt;
        }
        public static void Set_pFYEDate(DateTime newInt)
        {
            pFYEDate = newInt;
        }
        public static void Set_pFYNDate(DateTime newInt)
        {
            pFYNDate = newInt;
        }
        public static void Set_pFYSDate_System(DateTime newInt)
        {
            pFYSDate_System = newInt;
        }
        public static void Set_pSrvDate(DateTime newInt)
        {
            pSrvDate = newInt;
        }
        public static void Set_pSrvDateTime(DateTime newInt)
        {
            pSrvDateTime = newInt;
        }
        public static void Set_pConnStr(string newInt)
        {
            pConnStr = newInt;
        }
        public static void Set_pFY(string newInt)
        {
            pFY = newInt;
        }
        public static void Set_pFY_ID(int newInt)
        {
            pFY_ID = newInt;
        }
        public static void Set_pBranchCode(string newInt)
        {
            pBranchCode = newInt;
        }
        public static void Set_pBranch_SName(string newInt)
        {
            pBranch_SName = newInt;
        }
        public static void Set_pUser_FullName(string newInt)
        {
            pUser_FullName = newInt;
        }
        public static void Set_pUser_Dept(string newInt)
        {
            pUser_Dept = newInt;
        }
        public static void Set_pUserName(string newInt)
        {
            pUserName = newInt;
        }
        public static void Set_pUser_Pwd(string newInt)
        {
            pUser_Pwd = newInt;
        }
        public static void Set_pTrLevel_Pending()
        {
            pTrLevel_Pending = 0;
        }
        public static void Set_pTrLevel_Pending_D()
        {
            pTrLevel_Pending_D = "Pending";
        }
        public static void Set_pTrLevel_Cleared()
        {
            pTrLevel_Cleared = 1;
        }
        public static void Set_pTrLevel_Cleared_D()
        {
            pTrLevel_Cleared_D = "Cleared";
        }
        public static void Set_pTrLevel_Cancelled()
        {
            pTrLevel_Cancelled = 2;
        }
        public static void Set_pTrLevel_Cancelled_D()
        {
            pTrLevel_Cancelled_D = "Cancelled";
        }

        public static void Set_pTrLevel_Pending_All_Under_Process()
        {
            pTrLevel_Pending_All_Under_Process = 100;
        }
        public static void Set_pTrLevel_PendingApp_L1()
        {
            pTrLevel_PendingApp_L1 = 102;
        }
        public static void Set_pTrLevel_PendingApp_L1_D()
        {
            pTrLevel_PendingApp_L1_D = "Pending App.(L1)";
        }
        public static void Set_pTrLevel_PendingApp_L2()
        {
            pTrLevel_PendingApp_L2 = 103;
        }
        public static void Set_pTrLevel_PendingApp_L2_D()
        {
            pTrLevel_PendingApp_L2_D = "Pending App.(L2)";
        }
        public static void Set_pTrLevel_Under_Inspection()
        {
            pTrLevel_Under_Inspection = 106;
        }
        public static void Set_pTrLevel_Under_Inspection_D()
        {
            pTrLevel_Under_Inspection_D = "Under Inspection";
        }
        public static void Set_pTrLevel_Inspection_Done()
        {
            pTrLevel_Inspection_Done = 107;
        }
        public static void Set_pTrLevel_Inspection_Done_D()
        {
            pTrLevel_Inspection_Done_D = "Inspection Done";
        }
        public static void Set_pTrLevel_Approved()
        {
            pTrLevel_Approved = 1;
        }
        public static void Set_pTrLevel_Approved_D()
        {
            pTrLevel_Approved_D = "Approved";
        }
        public static void Set_pUserComp_Code(string newInt)
        {
            pUserComp_Code = newInt;
        }
        public static void Set_pDateFormat(string newInt)
        {
            pDateFormat = newInt;
        }
        public static void Set_pDateTimeFormat(string newInt)
        {
            pDateTimeFormat = newInt;
        }
        public static void Set_pUser_ID(int newInt)
        {
            pUser_ID = newInt;
        }
        public static void Set_pComp_ID(int newInt)
        {
            pComp_ID = newInt;
        }
        public static void Set_pDateTimeFormat_Long(string newInt)
        {
            pDateTimeFormat_Long = newInt;
        }
        public static void Set_pDateFormat_Long(string newInt)
        {
            pDateFormat_Long = newInt;
        }
        public static void Set_pDateTimeMask(string newInt)
        {
            pDateTimeMask = newInt;
        }
        public static void Set_pDateMask(string newInt)
        {
            pDateMask = newInt;
        }
        public static void Set_pTimeFormat(string newInt)
        {
            pTimeFormat = newInt;
        }
        public static void Set_pBranchSName_Con(string newInt)
        {
            pBranchSName_Con = newInt;
        }
        public static void Set_pUser_SrNo(int newInt)
        {
            pUser_SrNo = newInt;
        }
        public static void Set_pUser_Branch_ID(int newInt)
        {
            pUser_Branch_ID = newInt;
        }
        public static void Set_pUser_Dept_ID(int newInt)
        {
            pUser_Dept_ID = newInt;
        }
        public static void Set_pUser_LoginDate(DateTime newInt)
        {
            pUser_LoginDate = newInt;
        }
        public static void Set_pComp_PassKey(string newInt)
        {
            pComp_PassKey = newInt;
        }
        public static void Set_pComp_FName(string newInt)
        {
            pComp_FName = newInt;
        }
        public static void Set_pComp_SName(string newInt)
        {
            pComp_SName = newInt;
        }
        public static void Set_pComp_Img_1(string newInt)
        {
            pComp_Img_1 = newInt;
        }
        public static void Set_pComp_Img_2(string newInt)
        {
            pComp_Img_2 = newInt;
        }
        public static void Set_pComp_Img_3(string newInt)
        {
            pComp_Img_3 = newInt;
        }
        public static void Set_pComp_Img_Path(string newInt)
        {
            pComp_Img_Path = newInt;
        }
        public static void Set_pImg_Path_Logo(string newInt)
        {
            pImg_Path_Logo = newInt;
        }
        public static void Set_pBranch_ID(int newInt)
        {
            pBranch_ID = newInt;
        }
        public static void Set_pBranch_BrID(int newInt)
        {
            pBranch_BrID = newInt;
        }
        public static void Set_pBranch_FName(string newInt)
        {
            pBranch_FName = newInt;
        }
        public static void Set_pBranch_Bal(bool newInt)
        {
            pBranch_Bal = newInt;
        }
        public static void Set_pPass_DaysLeft(int newInt)
        {
            pPass_DaysLeft = newInt;
        }
        public static void Set_pLast_IPAddress(string newInt)
        {
            pLast_IPAddress = newInt;
        }
        public static void Set_pLast_LoginDateTime(DateTime newInt)
        {
            pLast_LoginDateTime = newInt;
        }
        public static void Set_pServerName(string newInt)
        {
            pServerName = newInt;
        }

    }
}
