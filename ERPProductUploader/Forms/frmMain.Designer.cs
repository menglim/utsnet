
namespace ERPClientTools.Forms
{
    partial class frmMain
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
            this.fILEToolStripMenuItem = new Components.MToolStriptMenuItem();
            this.cONFIGUREToolStripMenuItem = new Components.MToolStriptMenuItem();
            this.logOutToolStripMenuItem = new Components.MToolStriptMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.eXITToolStripMenuItem = new Components.MToolStriptMenuItem();
            this.rEPORTSToolStripMenuItem = new Components.MToolStriptMenuItem();
            this.reportsToolStripMenuItem1 = new Components.MToolStriptMenuItem();
            this.tOOLSToolStripMenuItem = new Components.MToolStriptMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wINDOWSToolStripMenuItem = new Components.MToolStriptMenuItem();
            this.hELPToolStripMenuItem = new Components.MToolStriptMenuItem();
            this.hELPToolStripMenuItem1 = new Components.MToolStriptMenuItem();
            this.aBOUTToolStripMenuItem = new Components.MToolStriptMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbDatabasePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelLoginAs = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatusVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new MdiTabControl.TabControl();
            this.tbStatus = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cONFIGUREToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.eXITToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.PermissionCode = "010000";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(45, 26);
            this.fILEToolStripMenuItem.Text = "&FILE";
            // 
            // cONFIGUREToolStripMenuItem
            // 
            this.cONFIGUREToolStripMenuItem.Name = "cONFIGUREToolStripMenuItem";
            this.cONFIGUREToolStripMenuItem.PermissionCode = "010100";
            this.cONFIGUREToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.cONFIGUREToolStripMenuItem.Text = "&Settings";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.PermissionCode = "010200";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.logOutToolStripMenuItem.Text = "&Log Out";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 6);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.PermissionCode = null;
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.eXITToolStripMenuItem.Text = "E&xit";
            // 
            // rEPORTSToolStripMenuItem
            // 
            this.rEPORTSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem1});
            this.rEPORTSToolStripMenuItem.Name = "rEPORTSToolStripMenuItem";
            this.rEPORTSToolStripMenuItem.PermissionCode = "050000";
            this.rEPORTSToolStripMenuItem.Size = new System.Drawing.Size(78, 26);
            this.rEPORTSToolStripMenuItem.Text = "&REPORTS";
            // 
            // reportsToolStripMenuItem1
            // 
            this.reportsToolStripMenuItem1.Name = "reportsToolStripMenuItem1";
            this.reportsToolStripMenuItem1.PermissionCode = "";
            this.reportsToolStripMenuItem1.Size = new System.Drawing.Size(129, 26);
            this.reportsToolStripMenuItem1.Text = "Reports";
            // 
            // tOOLSToolStripMenuItem
            // 
            this.tOOLSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.uploadProductToolStripMenuItem});
            this.tOOLSToolStripMenuItem.Name = "tOOLSToolStripMenuItem";
            this.tOOLSToolStripMenuItem.PermissionCode = null;
            this.tOOLSToolStripMenuItem.Size = new System.Drawing.Size(63, 26);
            this.tOOLSToolStripMenuItem.Text = "&TOOLS";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.productToolStripMenuItem.Text = "Product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // uploadProductToolStripMenuItem
            // 
            this.uploadProductToolStripMenuItem.Name = "uploadProductToolStripMenuItem";
            this.uploadProductToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.uploadProductToolStripMenuItem.Text = "Upload &Product";
            this.uploadProductToolStripMenuItem.Click += new System.EventHandler(this.uploadProductToolStripMenuItem_Click);
            // 
            // wINDOWSToolStripMenuItem
            // 
            this.wINDOWSToolStripMenuItem.Name = "wINDOWSToolStripMenuItem";
            this.wINDOWSToolStripMenuItem.PermissionCode = null;
            this.wINDOWSToolStripMenuItem.Size = new System.Drawing.Size(77, 26);
            this.wINDOWSToolStripMenuItem.Text = "&WINDOW";
            this.wINDOWSToolStripMenuItem.DropDownOpening += new System.EventHandler(this.wINDOWSToolStripMenuItem_DropDownOpening);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hELPToolStripMenuItem1,
            this.aBOUTToolStripMenuItem});
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.PermissionCode = null;
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(52, 26);
            this.hELPToolStripMenuItem.Text = "&HELP";
            // 
            // hELPToolStripMenuItem1
            // 
            this.hELPToolStripMenuItem1.Name = "hELPToolStripMenuItem1";
            this.hELPToolStripMenuItem1.PermissionCode = null;
            this.hELPToolStripMenuItem1.Size = new System.Drawing.Size(137, 26);
            this.hELPToolStripMenuItem1.Text = "&View Help";
            // 
            // aBOUTToolStripMenuItem
            // 
            this.aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            this.aBOUTToolStripMenuItem.PermissionCode = null;
            this.aBOUTToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.aBOUTToolStripMenuItem.Text = "&About";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Kh MPS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.tOOLSToolStripMenuItem,
            this.rEPORTSToolStripMenuItem,
            this.wINDOWSToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1119, 30);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = false;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(300, 20);
            this.lbStatus.Text = "Ready";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDatabasePath
            // 
            this.lbDatabasePath.AutoSize = false;
            this.lbDatabasePath.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lbDatabasePath.Name = "lbDatabasePath";
            this.lbDatabasePath.Size = new System.Drawing.Size(300, 20);
            this.lbDatabasePath.Text = "toolStripStatusLabel2";
            this.lbDatabasePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDate
            // 
            this.lbDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(148, 20);
            this.lbDate.Text = "toolStripStatusLabel3";
            // 
            // labelLoginAs
            // 
            this.labelLoginAs.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelLoginAs.Name = "labelLoginAs";
            this.labelLoginAs.Size = new System.Drawing.Size(63, 20);
            this.labelLoginAs.Text = "Login as";
            // 
            // lbStatusVersion
            // 
            this.lbStatusVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lbStatusVersion.Name = "lbStatusVersion";
            this.lbStatusVersion.Size = new System.Drawing.Size(148, 20);
            this.lbStatusVersion.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new System.Drawing.Font("Kh MPS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus,
            this.lbDatabasePath,
            this.lbDate,
            this.labelLoginAs,
            this.lbStatusVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1119, 25);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // tabControl1
            // 
            this.tabControl1.BorderColor = System.Drawing.SystemColors.Control;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.MenuRenderer = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tabControl1.Size = new System.Drawing.Size(1119, 495);
            this.tabControl1.TabCloseButtonImage = null;
            this.tabControl1.TabCloseButtonImageDisabled = null;
            this.tabControl1.TabCloseButtonImageHot = null;
            this.tabControl1.TabIndex = 9;
            // 
            // tbStatus
            // 
            this.tbStatus.Interval = 1000;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Kh MPS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP Client Tools";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.MToolStriptMenuItem fILEToolStripMenuItem;
        private Components.MToolStriptMenuItem cONFIGUREToolStripMenuItem;
        private Components.MToolStriptMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private Components.MToolStriptMenuItem eXITToolStripMenuItem;
        private Components.MToolStriptMenuItem rEPORTSToolStripMenuItem;
        private Components.MToolStriptMenuItem reportsToolStripMenuItem1;
        private Components.MToolStriptMenuItem tOOLSToolStripMenuItem;
        private Components.MToolStriptMenuItem wINDOWSToolStripMenuItem;
        private Components.MToolStriptMenuItem hELPToolStripMenuItem;
        private Components.MToolStriptMenuItem hELPToolStripMenuItem1;
        private Components.MToolStriptMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripStatusLabel lbDatabasePath;
        private System.Windows.Forms.ToolStripStatusLabel lbDate;
        private System.Windows.Forms.ToolStripStatusLabel labelLoginAs;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusVersion;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private MdiTabControl.TabControl tabControl1;
        private System.Windows.Forms.Timer tbStatus;
        private System.Windows.Forms.ToolStripMenuItem uploadProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
    }
}