namespace ERP.Accounts
{
    partial class Acc_OB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acc_OB));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Acc_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Acc_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Acc_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OB_Dr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OB_Cr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_New = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Save = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Print = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtOB_Ref1 = new DevExpress.XtraEditors.MemoEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOB_ID = new DevExpress.XtraEditors.LabelControl();
            this.chkSub_Ledger = new DevExpress.XtraEditors.CheckEdit();
            this.lookAccounts = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookBranch_ID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtOB_Cr = new DevExpress.XtraEditors.TextEdit();
            this.txtOB_Dr = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOB_Ref1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSub_Ledger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookAccounts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBranch_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOB_Cr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOB_Dr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Acc_ID,
            this.Acc_Code,
            this.Acc_Name,
            this.OB_Dr,
            this.OB_Cr});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // Acc_ID
            // 
            this.Acc_ID.Caption = "Acc_ID";
            this.Acc_ID.FieldName = "Acc_ID";
            this.Acc_ID.Name = "Acc_ID";
            // 
            // Acc_Code
            // 
            this.Acc_Code.Caption = "ACCOUNT CODE";
            this.Acc_Code.FieldName = "Acc_Code";
            this.Acc_Code.MaxWidth = 100;
            this.Acc_Code.MinWidth = 100;
            this.Acc_Code.Name = "Acc_Code";
            this.Acc_Code.Visible = true;
            this.Acc_Code.VisibleIndex = 0;
            this.Acc_Code.Width = 100;
            // 
            // Acc_Name
            // 
            this.Acc_Name.Caption = "ACCOUNT DESCRIPTION";
            this.Acc_Name.FieldName = "Acc_Name";
            this.Acc_Name.Name = "Acc_Name";
            this.Acc_Name.Visible = true;
            this.Acc_Name.VisibleIndex = 1;
            // 
            // OB_Dr
            // 
            this.OB_Dr.Caption = "DEBIT AMOUNT";
            this.OB_Dr.FieldName = "Dr";
            this.OB_Dr.MaxWidth = 120;
            this.OB_Dr.MinWidth = 120;
            this.OB_Dr.Name = "OB_Dr";
            this.OB_Dr.Visible = true;
            this.OB_Dr.VisibleIndex = 2;
            this.OB_Dr.Width = 120;
            // 
            // OB_Cr
            // 
            this.OB_Cr.Caption = "CREDIT AMOUNT";
            this.OB_Cr.FieldName = "Cr";
            this.OB_Cr.MaxWidth = 120;
            this.OB_Cr.MinWidth = 120;
            this.OB_Cr.Name = "OB_Cr";
            this.OB_Cr.Visible = true;
            this.OB_Cr.VisibleIndex = 3;
            this.OB_Cr.Width = 120;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(810, 234);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btn_New,
            this.btn_Save,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.btn_Print});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(811, 143);
            // 
            // btn_New
            // 
            this.btn_New.Caption = "NEW";
            this.btn_New.Id = 1;
            this.btn_New.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_New.ImageOptions.SvgImage")));
            this.btn_New.Name = "btn_New";
            this.btn_New.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_New_ItemClick);
            // 
            // btn_Save
            // 
            this.btn_Save.Caption = "SAVE";
            this.btn_Save.Id = 2;
            this.btn_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Save.ImageOptions.SvgImage")));
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Save_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "AUTHORIZE";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "CANCEL";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "ROLLBACK";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // btn_Print
            // 
            this.btn_Print.Caption = "PRINT";
            this.btn_Print.Id = 6;
            this.btn_Print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Print.ImageOptions.SvgImage")));
            this.btn_Print.Name = "btn_Print";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Main";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_New);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_Save);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "CREATE";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.btn_Print);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "PRINT";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Location = new System.Drawing.Point(-1, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 234);
            this.panel2.TabIndex = 6;
            // 
            // txtOB_Ref1
            // 
            this.txtOB_Ref1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOB_Ref1.Location = new System.Drawing.Point(494, 59);
            this.txtOB_Ref1.MenuManager = this.ribbon;
            this.txtOB_Ref1.Name = "txtOB_Ref1";
            this.txtOB_Ref1.Size = new System.Drawing.Size(297, 48);
            this.txtOB_Ref1.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblOB_ID);
            this.panel1.Controls.Add(this.chkSub_Ledger);
            this.panel1.Controls.Add(this.lookAccounts);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.lookBranch_ID);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txtOB_Cr);
            this.panel1.Controls.Add(this.txtOB_Dr);
            this.panel1.Controls.Add(this.txtOB_Ref1);
            this.panel1.Controls.Add(this.labelControl10);
            this.panel1.Controls.Add(this.labelControl8);
            this.panel1.Controls.Add(this.labelControl6);
            this.panel1.Controls.Add(this.labelControl7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 116);
            this.panel1.TabIndex = 5;
            // 
            // lblOB_ID
            // 
            this.lblOB_ID.Appearance.Options.UseTextOptions = true;
            this.lblOB_ID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOB_ID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOB_ID.Location = new System.Drawing.Point(296, 11);
            this.lblOB_ID.Name = "lblOB_ID";
            this.lblOB_ID.Size = new System.Drawing.Size(35, 18);
            this.lblOB_ID.TabIndex = 36;
            this.lblOB_ID.Text = "ID";
            // 
            // chkSub_Ledger
            // 
            this.chkSub_Ledger.Location = new System.Drawing.Point(235, 88);
            this.chkSub_Ledger.MenuManager = this.ribbon;
            this.chkSub_Ledger.Name = "chkSub_Ledger";
            this.chkSub_Ledger.Properties.Caption = "Sub Account";
            this.chkSub_Ledger.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSub_Ledger.Size = new System.Drawing.Size(83, 19);
            this.chkSub_Ledger.TabIndex = 35;
            this.chkSub_Ledger.CheckedChanged += new System.EventHandler(this.chkSub_Acc_CheckedChanged);
            // 
            // lookAccounts
            // 
            this.lookAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lookAccounts.Location = new System.Drawing.Point(494, 12);
            this.lookAccounts.MenuManager = this.ribbon;
            this.lookAccounts.Name = "lookAccounts";
            this.lookAccounts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookAccounts.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Acc_ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Acc_Name", "")});
            this.lookAccounts.Properties.NullText = "";
            this.lookAccounts.Size = new System.Drawing.Size(297, 20);
            this.lookAccounts.TabIndex = 34;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(401, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 18);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "ACCOUNT NAME:";
            // 
            // lookBranch_ID
            // 
            this.lookBranch_ID.Location = new System.Drawing.Point(117, 62);
            this.lookBranch_ID.MenuManager = this.ribbon;
            this.lookBranch_ID.Name = "lookBranch_ID";
            this.lookBranch_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookBranch_ID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Branch_ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Branch_FName", "")});
            this.lookBranch_ID.Properties.NullText = "";
            this.lookBranch_ID.Size = new System.Drawing.Size(201, 20);
            this.lookBranch_ID.TabIndex = 32;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(9, 62);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 18);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "LOCATION:";
            // 
            // txtOB_Cr
            // 
            this.txtOB_Cr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOB_Cr.Location = new System.Drawing.Point(701, 36);
            this.txtOB_Cr.MenuManager = this.ribbon;
            this.txtOB_Cr.Name = "txtOB_Cr";
            this.txtOB_Cr.Size = new System.Drawing.Size(90, 20);
            this.txtOB_Cr.TabIndex = 29;
            // 
            // txtOB_Dr
            // 
            this.txtOB_Dr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOB_Dr.Location = new System.Drawing.Point(494, 36);
            this.txtOB_Dr.MenuManager = this.ribbon;
            this.txtOB_Dr.Name = "txtOB_Dr";
            this.txtOB_Dr.Size = new System.Drawing.Size(104, 20);
            this.txtOB_Dr.TabIndex = 28;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl10.Appearance.Options.UseTextOptions = true;
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.Location = new System.Drawing.Point(418, 57);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(74, 18);
            this.labelControl10.TabIndex = 22;
            this.labelControl10.Text = "REMARKS:";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(403, 34);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(89, 18);
            this.labelControl8.TabIndex = 20;
            this.labelControl8.Text = "DEBIT:";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(606, 37);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(89, 18);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "CREDIT:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(13, 3);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(266, 43);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "Opening Balance";
            // 
            // Acc_OB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 493);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbon);
            this.Name = "Acc_OB";
            this.Ribbon = this.ribbon;
            this.Text = "ACCOUNTS | ACCOUNT OPENING BALANCE";
            this.Load += new System.EventHandler(this.Acc_OB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOB_Ref1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSub_Ledger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookAccounts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBranch_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOB_Cr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOB_Dr.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btn_New;
        private DevExpress.XtraBars.BarButtonItem btn_Save;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem btn_Print;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.MemoEdit txtOB_Ref1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtOB_Cr;
        private DevExpress.XtraEditors.TextEdit txtOB_Dr;
        private DevExpress.XtraEditors.LookUpEdit lookBranch_ID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookAccounts;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkSub_Ledger;
        private DevExpress.XtraEditors.LabelControl lblOB_ID;
        private DevExpress.XtraGrid.Columns.GridColumn Acc_ID;
        private DevExpress.XtraGrid.Columns.GridColumn Acc_Name;
        private DevExpress.XtraGrid.Columns.GridColumn OB_Cr;
        private DevExpress.XtraGrid.Columns.GridColumn OB_Dr;
        private DevExpress.XtraGrid.Columns.GridColumn Acc_Code;
    }
}