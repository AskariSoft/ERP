namespace ERP.EPR_System
{
    partial class AdmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdmLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserPassword = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBranch_SName = new System.Windows.Forms.ComboBox();
            this.cmbDeptt = new System.Windows.Forms.ComboBox();
            this.cmbFY = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComp_Code = new DevExpress.XtraEditors.TextEdit();
            this.cmd0_OK = new DevExpress.XtraEditors.SimpleButton();
            this.cmd0_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmd1_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmd1_OK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tmProgress = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComp_Code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(95, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(94, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "USER LOGIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(31, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(31, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(93, 167);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(175, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(93, 189);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Properties.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(175, 20);
            this.txtUserPassword.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(30, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Location:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(20, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Department:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(10, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Financial Year:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBranch_SName
            // 
            this.cmbBranch_SName.FormattingEnabled = true;
            this.cmbBranch_SName.Location = new System.Drawing.Point(92, 27);
            this.cmbBranch_SName.Name = "cmbBranch_SName";
            this.cmbBranch_SName.Size = new System.Drawing.Size(175, 21);
            this.cmbBranch_SName.TabIndex = 9;
            // 
            // cmbDeptt
            // 
            this.cmbDeptt.FormattingEnabled = true;
            this.cmbDeptt.Location = new System.Drawing.Point(92, 49);
            this.cmbDeptt.Name = "cmbDeptt";
            this.cmbDeptt.Size = new System.Drawing.Size(175, 21);
            this.cmbDeptt.TabIndex = 10;
            // 
            // cmbFY
            // 
            this.cmbFY.FormattingEnabled = true;
            this.cmbFY.Location = new System.Drawing.Point(92, 71);
            this.cmbFY.Name = "cmbFY";
            this.cmbFY.Size = new System.Drawing.Size(175, 21);
            this.cmbFY.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(31, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Level:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComp_Code
            // 
            this.txtComp_Code.Location = new System.Drawing.Point(93, 211);
            this.txtComp_Code.Name = "txtComp_Code";
            this.txtComp_Code.Size = new System.Drawing.Size(175, 20);
            this.txtComp_Code.TabIndex = 13;
            // 
            // cmd0_OK
            // 
            this.cmd0_OK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmd0_OK.ImageOptions.Image")));
            this.cmd0_OK.Location = new System.Drawing.Point(144, 238);
            this.cmd0_OK.Name = "cmd0_OK";
            this.cmd0_OK.Size = new System.Drawing.Size(66, 23);
            this.cmd0_OK.TabIndex = 14;
            this.cmd0_OK.Text = "OK";
            this.cmd0_OK.Click += new System.EventHandler(this.cmd0_OK_Click);
            // 
            // cmd0_Cancel
            // 
            this.cmd0_Cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmd0_Cancel.ImageOptions.Image")));
            this.cmd0_Cancel.Location = new System.Drawing.Point(216, 238);
            this.cmd0_Cancel.Name = "cmd0_Cancel";
            this.cmd0_Cancel.Size = new System.Drawing.Size(79, 23);
            this.cmd0_Cancel.TabIndex = 15;
            this.cmd0_Cancel.Text = "Cancel";
            this.cmd0_Cancel.Click += new System.EventHandler(this.cmd0_Cancel_Click);
            // 
            // cmd1_Cancel
            // 
            this.cmd1_Cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmd1_Cancel.ImageOptions.Image")));
            this.cmd1_Cancel.Location = new System.Drawing.Point(214, 98);
            this.cmd1_Cancel.Name = "cmd1_Cancel";
            this.cmd1_Cancel.Size = new System.Drawing.Size(79, 23);
            this.cmd1_Cancel.TabIndex = 17;
            this.cmd1_Cancel.Text = "Cancel";
            this.cmd1_Cancel.Click += new System.EventHandler(this.cmd1_Cancel_Click);
            // 
            // cmd1_OK
            // 
            this.cmd1_OK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmd1_OK.ImageOptions.Image")));
            this.cmd1_OK.Location = new System.Drawing.Point(142, 98);
            this.cmd1_OK.Name = "cmd1_OK";
            this.cmd1_OK.Size = new System.Drawing.Size(66, 23);
            this.cmd1_OK.TabIndex = 16;
            this.cmd1_OK.Text = "OK";
            this.cmd1_OK.Click += new System.EventHandler(this.cmd1_OK_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.cmd1_OK);
            this.groupControl1.Controls.Add(this.cmd1_Cancel);
            this.groupControl1.Controls.Add(this.cmbFY);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.cmbDeptt);
            this.groupControl1.Controls.Add(this.cmbBranch_SName);
            this.groupControl1.Location = new System.Drawing.Point(0, 237);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(301, 129);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "Location Details";
            // 
            // tmProgress
            // 
            this.tmProgress.Tick += new System.EventHandler(this.tmProgress_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(6, 369);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(203, 19);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Username:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AdmLogin
            // 
            this.ActiveGlowColor = System.Drawing.Color.White;
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 412);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.cmd0_Cancel);
            this.Controls.Add(this.cmd0_OK);
            this.Controls.Add(this.txtComp_Code);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AdmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdmLogin";
            this.Load += new System.EventHandler(this.AdmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AdmLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComp_Code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtUserPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBranch_SName;
        private System.Windows.Forms.ComboBox cmbDeptt;
        private System.Windows.Forms.ComboBox cmbFY;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtComp_Code;
        private DevExpress.XtraEditors.SimpleButton cmd0_OK;
        private DevExpress.XtraEditors.SimpleButton cmd0_Cancel;
        private DevExpress.XtraEditors.SimpleButton cmd1_Cancel;
        private DevExpress.XtraEditors.SimpleButton cmd1_OK;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Timer tmProgress;
        private System.Windows.Forms.Label lblStatus;
    }
}