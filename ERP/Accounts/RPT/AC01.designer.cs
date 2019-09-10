namespace ERP.Accounts.RPT
{
    partial class AC01
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AC01));
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.dtpEndDate = new DevExpress.XtraEditors.DateEdit();
            this.dtpBegDate = new DevExpress.XtraEditors.DateEdit();
            this.lookRType = new DevExpress.XtraEditors.LookUpEdit();
            this.lookBranch_ID = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lbl01RType = new System.Windows.Forms.Label();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.cmd0_Print = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBegDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBegDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookRType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBranch_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(141, 151);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Branch_ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Branch_DD", "")});
            this.lookUpEdit1.Properties.NullText = "";
            this.lookUpEdit1.Size = new System.Drawing.Size(247, 20);
            this.lookUpEdit1.TabIndex = 757699;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.EditValue = null;
            this.dtpEndDate.Location = new System.Drawing.Point(288, 125);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEndDate.Size = new System.Drawing.Size(100, 20);
            this.dtpEndDate.TabIndex = 757698;
            // 
            // dtpBegDate
            // 
            this.dtpBegDate.EditValue = null;
            this.dtpBegDate.Location = new System.Drawing.Point(141, 127);
            this.dtpBegDate.Name = "dtpBegDate";
            this.dtpBegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBegDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBegDate.Size = new System.Drawing.Size(100, 20);
            this.dtpBegDate.TabIndex = 757697;
            // 
            // lookRType
            // 
            this.lookRType.Location = new System.Drawing.Point(141, 104);
            this.lookRType.Name = "lookRType";
            this.lookRType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookRType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Branch_ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Branch_DD", "")});
            this.lookRType.Properties.NullText = "";
            this.lookRType.Size = new System.Drawing.Size(167, 20);
            this.lookRType.TabIndex = 757696;
            // 
            // lookBranch_ID
            // 
            this.lookBranch_ID.Location = new System.Drawing.Point(140, 82);
            this.lookBranch_ID.Name = "lookBranch_ID";
            this.lookBranch_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookBranch_ID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Branch_ID", "", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Branch_DD", "")});
            this.lookBranch_ID.Properties.NullText = "";
            this.lookBranch_ID.Size = new System.Drawing.Size(167, 20);
            this.lookBranch_ID.TabIndex = 757695;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 757690;
            this.label1.Text = "Date From:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(246, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 18);
            this.label2.TabIndex = 757692;
            this.label2.Text = "To:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 757687;
            this.label4.Text = "Main Code:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // lblBranch
            // 
            this.lblBranch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.Location = new System.Drawing.Point(41, 82);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(92, 18);
            this.lblBranch.TabIndex = 757674;
            this.lblBranch.Text = "Location:";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl01RType
            // 
            this.lbl01RType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl01RType.Location = new System.Drawing.Point(41, 107);
            this.lbl01RType.Name = "lbl01RType";
            this.lbl01RType.Size = new System.Drawing.Size(92, 18);
            this.lbl01RType.TabIndex = 757667;
            this.lbl01RType.Text = "Report Type:";
            this.lbl01RType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "");
            this.ImageList1.Images.SetKeyName(1, "");
            this.ImageList1.Images.SetKeyName(2, "");
            this.ImageList1.Images.SetKeyName(3, "");
            this.ImageList1.Images.SetKeyName(4, "");
            this.ImageList1.Images.SetKeyName(5, "");
            this.ImageList1.Images.SetKeyName(6, "");
            this.ImageList1.Images.SetKeyName(7, "");
            this.ImageList1.Images.SetKeyName(8, "");
            this.ImageList1.Images.SetKeyName(9, "");
            this.ImageList1.Images.SetKeyName(10, "");
            this.ImageList1.Images.SetKeyName(11, "");
            this.ImageList1.Images.SetKeyName(12, "");
            this.ImageList1.Images.SetKeyName(13, "");
            this.ImageList1.Images.SetKeyName(14, "");
            this.ImageList1.Images.SetKeyName(15, "Icon_search.png");
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "");
            this.imgLst.Images.SetKeyName(1, "");
            this.imgLst.Images.SetKeyName(2, "");
            this.imgLst.Images.SetKeyName(3, "");
            this.imgLst.Images.SetKeyName(4, "");
            this.imgLst.Images.SetKeyName(5, "");
            this.imgLst.Images.SetKeyName(6, "");
            this.imgLst.Images.SetKeyName(7, "");
            this.imgLst.Images.SetKeyName(8, "");
            this.imgLst.Images.SetKeyName(9, "");
            this.imgLst.Images.SetKeyName(10, "");
            this.imgLst.Images.SetKeyName(11, "");
            this.imgLst.Images.SetKeyName(12, "");
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.cmd0_Print});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.Size = new System.Drawing.Size(462, 79);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "CONTROL PANEL";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.cmd0_Print);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "REFRESH";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "REFRESH";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // cmd0_Print
            // 
            this.cmd0_Print.Caption = "PRINT";
            this.cmd0_Print.Id = 2;
            this.cmd0_Print.Name = "cmd0_Print";
            this.cmd0_Print.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmd0_Print_ItemClick);
            // 
            // AC01
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 224);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.dtpBegDate);
            this.Controls.Add(this.lbl01RType);
            this.Controls.Add(this.lookRType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookBranch_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "AC01";
            this.Ribbon = this.ribbonControl1;
            this.Text = "ACCOUNTS | REPORTING";
            this.Load += new System.EventHandler(this.EM26_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBegDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBegDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookRType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBranch_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ImageList ImageList1;
        internal System.Windows.Forms.ImageList imgLst;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.Label lblBranch;
        internal System.Windows.Forms.Label lbl01RType;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookBranch_ID;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.DateEdit dtpEndDate;
        private DevExpress.XtraEditors.DateEdit dtpBegDate;
        private DevExpress.XtraEditors.LookUpEdit lookRType;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem cmd0_Print;
    }
}