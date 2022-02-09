
namespace KronosDMS_Client
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OpenedWindowsPanel = new System.Windows.Forms.Panel();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.FileMenuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuImportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileMenuWindowMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuWindowMaximize = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuWindowClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FileMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceKitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenuKitsGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenuKitsRecalls = new System.Windows.Forms.ToolStripMenuItem();
            this.queriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.RecallsMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.KitsMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenuMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupMenuAccountChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupMenuAccountRelogin = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupMenuMakesMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupUserAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupUserGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupMenuServerReload = new System.Windows.Forms.ToolStripMenuItem();
            this.PingServerTimer = new System.Windows.Forms.Timer(this.components);
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenedWindowsPanel
            // 
            this.OpenedWindowsPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OpenedWindowsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OpenedWindowsPanel.Location = new System.Drawing.Point(0, 618);
            this.OpenedWindowsPanel.Name = "OpenedWindowsPanel";
            this.OpenedWindowsPanel.Size = new System.Drawing.Size(952, 38);
            this.OpenedWindowsPanel.TabIndex = 0;
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.PartsMenu,
            this.setupToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Menu.Size = new System.Drawing.Size(952, 24);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuSave,
            this.FileMenuDelete,
            this.toolStripSeparator3,
            this.FileMenuImport,
            this.FileMenuExport,
            this.toolStripSeparator1,
            this.FileMenuWindowMinimize,
            this.FileMenuWindowMaximize,
            this.FileMenuWindowClose,
            this.toolStripSeparator2,
            this.FileMenuExit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            this.FileMenu.DropDownOpening += new System.EventHandler(this.FileMenu_DropDownOpening);
            // 
            // FileMenuSave
            // 
            this.FileMenuSave.Enabled = false;
            this.FileMenuSave.Name = "FileMenuSave";
            this.FileMenuSave.Size = new System.Drawing.Size(180, 22);
            this.FileMenuSave.Text = "Save";
            this.FileMenuSave.Click += new System.EventHandler(this.FileMenuSave_Click);
            // 
            // FileMenuDelete
            // 
            this.FileMenuDelete.Enabled = false;
            this.FileMenuDelete.Name = "FileMenuDelete";
            this.FileMenuDelete.Size = new System.Drawing.Size(180, 22);
            this.FileMenuDelete.Text = "Delete";
            this.FileMenuDelete.Click += new System.EventHandler(this.FileMenuDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // FileMenuImport
            // 
            this.FileMenuImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuImportCSV});
            this.FileMenuImport.Enabled = false;
            this.FileMenuImport.Name = "FileMenuImport";
            this.FileMenuImport.Size = new System.Drawing.Size(180, 22);
            this.FileMenuImport.Text = "Import";
            // 
            // FileMenuImportCSV
            // 
            this.FileMenuImportCSV.Name = "FileMenuImportCSV";
            this.FileMenuImportCSV.Size = new System.Drawing.Size(126, 22);
            this.FileMenuImportCSV.Text = "From CSV";
            this.FileMenuImportCSV.Click += new System.EventHandler(this.FileMenuImportCSV_Click);
            // 
            // FileMenuExport
            // 
            this.FileMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuExportCSV});
            this.FileMenuExport.Enabled = false;
            this.FileMenuExport.Name = "FileMenuExport";
            this.FileMenuExport.Size = new System.Drawing.Size(180, 22);
            this.FileMenuExport.Text = "Export";
            // 
            // FileMenuExportCSV
            // 
            this.FileMenuExportCSV.Name = "FileMenuExportCSV";
            this.FileMenuExportCSV.Size = new System.Drawing.Size(110, 22);
            this.FileMenuExportCSV.Text = "To CSV";
            this.FileMenuExportCSV.Click += new System.EventHandler(this.FileMenuExportCSV_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // FileMenuWindowMinimize
            // 
            this.FileMenuWindowMinimize.Enabled = false;
            this.FileMenuWindowMinimize.Name = "FileMenuWindowMinimize";
            this.FileMenuWindowMinimize.Size = new System.Drawing.Size(180, 22);
            this.FileMenuWindowMinimize.Text = "Minimize";
            this.FileMenuWindowMinimize.Click += new System.EventHandler(this.FileMenuWindowMinimize_Click);
            // 
            // FileMenuWindowMaximize
            // 
            this.FileMenuWindowMaximize.Enabled = false;
            this.FileMenuWindowMaximize.Name = "FileMenuWindowMaximize";
            this.FileMenuWindowMaximize.Size = new System.Drawing.Size(180, 22);
            this.FileMenuWindowMaximize.Text = "Maximize";
            this.FileMenuWindowMaximize.Click += new System.EventHandler(this.FileMenuWindowMaximize_Click);
            // 
            // FileMenuWindowClose
            // 
            this.FileMenuWindowClose.Enabled = false;
            this.FileMenuWindowClose.Name = "FileMenuWindowClose";
            this.FileMenuWindowClose.Size = new System.Drawing.Size(180, 22);
            this.FileMenuWindowClose.Text = "Close";
            this.FileMenuWindowClose.Click += new System.EventHandler(this.FileMenuWindowClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // FileMenuExit
            // 
            this.FileMenuExit.Name = "FileMenuExit";
            this.FileMenuExit.Size = new System.Drawing.Size(180, 22);
            this.FileMenuExit.Text = "Exit";
            this.FileMenuExit.Click += new System.EventHandler(this.FileMenuExit_Click);
            // 
            // PartsMenu
            // 
            this.PartsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceKitsToolStripMenuItem,
            this.queriesToolStripMenuItem,
            this.PartsMenuMaintenance});
            this.PartsMenu.Name = "PartsMenu";
            this.PartsMenu.Size = new System.Drawing.Size(45, 20);
            this.PartsMenu.Text = "Parts";
            // 
            // serviceKitsToolStripMenuItem
            // 
            this.serviceKitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PartsMenuKitsGeneral,
            this.PartsMenuKitsRecalls});
            this.serviceKitsToolStripMenuItem.Name = "serviceKitsToolStripMenuItem";
            this.serviceKitsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.serviceKitsToolStripMenuItem.Text = "Service Kits";
            // 
            // PartsMenuKitsGeneral
            // 
            this.PartsMenuKitsGeneral.Name = "PartsMenuKitsGeneral";
            this.PartsMenuKitsGeneral.Size = new System.Drawing.Size(114, 22);
            this.PartsMenuKitsGeneral.Text = "General";
            this.PartsMenuKitsGeneral.Click += new System.EventHandler(this.PartsMenuKitsGeneral_Click);
            // 
            // PartsMenuKitsRecalls
            // 
            this.PartsMenuKitsRecalls.Name = "PartsMenuKitsRecalls";
            this.PartsMenuKitsRecalls.Size = new System.Drawing.Size(114, 22);
            this.PartsMenuKitsRecalls.Text = "Recalls";
            this.PartsMenuKitsRecalls.Click += new System.EventHandler(this.PartsMenuKitsRecalls_Click);
            // 
            // queriesToolStripMenuItem
            // 
            this.queriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PartsMenuSearch,
            this.RecallsMenuSearch,
            this.KitsMenuSearch});
            this.queriesToolStripMenuItem.Name = "queriesToolStripMenuItem";
            this.queriesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.queriesToolStripMenuItem.Text = "Queries";
            // 
            // PartsMenuSearch
            // 
            this.PartsMenuSearch.Name = "PartsMenuSearch";
            this.PartsMenuSearch.Size = new System.Drawing.Size(148, 22);
            this.PartsMenuSearch.Text = "Parts Search";
            this.PartsMenuSearch.Click += new System.EventHandler(this.PartsMenuSearch_Click);
            // 
            // RecallsMenuSearch
            // 
            this.RecallsMenuSearch.Name = "RecallsMenuSearch";
            this.RecallsMenuSearch.Size = new System.Drawing.Size(148, 22);
            this.RecallsMenuSearch.Text = "Recalls Search";
            this.RecallsMenuSearch.Click += new System.EventHandler(this.RecallsMenuSearch_Click);
            // 
            // KitsMenuSearch
            // 
            this.KitsMenuSearch.Name = "KitsMenuSearch";
            this.KitsMenuSearch.Size = new System.Drawing.Size(148, 22);
            this.KitsMenuSearch.Text = "Kits Search";
            this.KitsMenuSearch.Click += new System.EventHandler(this.KitsMenuSearch_Click);
            // 
            // PartsMenuMaintenance
            // 
            this.PartsMenuMaintenance.Name = "PartsMenuMaintenance";
            this.PartsMenuMaintenance.Size = new System.Drawing.Size(172, 22);
            this.PartsMenuMaintenance.Text = "Parts Maintenance";
            this.PartsMenuMaintenance.Click += new System.EventHandler(this.PartsMenuMaintenance_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.vehiclesToolStripMenuItem,
            this.serverToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetupMenuAccountChangePassword,
            this.SetupMenuAccountRelogin});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // SetupMenuAccountChangePassword
            // 
            this.SetupMenuAccountChangePassword.Name = "SetupMenuAccountChangePassword";
            this.SetupMenuAccountChangePassword.Size = new System.Drawing.Size(168, 22);
            this.SetupMenuAccountChangePassword.Text = "Change Password";
            this.SetupMenuAccountChangePassword.Click += new System.EventHandler(this.SetupMenuAccountChangePassword_Click);
            // 
            // SetupMenuAccountRelogin
            // 
            this.SetupMenuAccountRelogin.Name = "SetupMenuAccountRelogin";
            this.SetupMenuAccountRelogin.Size = new System.Drawing.Size(168, 22);
            this.SetupMenuAccountRelogin.Text = "Relogin";
            this.SetupMenuAccountRelogin.Click += new System.EventHandler(this.SetupMenuAccountRelogin_Click);
            // 
            // vehiclesToolStripMenuItem
            // 
            this.vehiclesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetupMenuMakesMaintenance});
            this.vehiclesToolStripMenuItem.Name = "vehiclesToolStripMenuItem";
            this.vehiclesToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.vehiclesToolStripMenuItem.Text = "Vehicles";
            // 
            // SetupMenuMakesMaintenance
            // 
            this.SetupMenuMakesMaintenance.Name = "SetupMenuMakesMaintenance";
            this.SetupMenuMakesMaintenance.Size = new System.Drawing.Size(180, 22);
            this.SetupMenuMakesMaintenance.Text = "Makes Maintenance";
            this.SetupMenuMakesMaintenance.Click += new System.EventHandler(this.SetupMenuMakesMaintenance_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem,
            this.SetupMenuServerReload});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetupUserAccounts,
            this.SetupUserGroups});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // SetupUserAccounts
            // 
            this.SetupUserAccounts.Name = "SetupUserAccounts";
            this.SetupUserAccounts.Size = new System.Drawing.Size(150, 22);
            this.SetupUserAccounts.Text = "User Accounts";
            this.SetupUserAccounts.Click += new System.EventHandler(this.SetupUserAccounts_Click);
            // 
            // SetupUserGroups
            // 
            this.SetupUserGroups.Name = "SetupUserGroups";
            this.SetupUserGroups.Size = new System.Drawing.Size(150, 22);
            this.SetupUserGroups.Text = "User Groups";
            this.SetupUserGroups.Click += new System.EventHandler(this.SetupUserGroups_Click);
            // 
            // SetupMenuServerReload
            // 
            this.SetupMenuServerReload.Name = "SetupMenuServerReload";
            this.SetupMenuServerReload.Size = new System.Drawing.Size(124, 22);
            this.SetupMenuServerReload.Text = "Reload";
            this.SetupMenuServerReload.Click += new System.EventHandler(this.SetupMenuServerReload_Click);
            // 
            // PingServerTimer
            // 
            this.PingServerTimer.Enabled = true;
            this.PingServerTimer.Interval = 15000;
            this.PingServerTimer.Tick += new System.EventHandler(this.PingServerTimer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(952, 656);
            this.Controls.Add(this.OpenedWindowsPanel);
            this.Controls.Add(this.Menu);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Menu;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel OpenedWindowsPanel;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuExit;
        private System.Windows.Forms.ToolStripMenuItem PartsMenu;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceKitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuKitsGeneral;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuKitsRecalls;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuMaintenance;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuSearch;
        private System.Windows.Forms.ToolStripMenuItem RecallsMenuSearch;
        private System.Windows.Forms.ToolStripMenuItem KitsMenuSearch;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetupUserAccounts;
        private System.Windows.Forms.ToolStripMenuItem SetupUserGroups;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSave;
        private System.Windows.Forms.ToolStripMenuItem FileMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SetupMenuServerReload;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetupMenuAccountChangePassword;
        private System.Windows.Forms.ToolStripMenuItem SetupMenuAccountRelogin;
        private System.Windows.Forms.Timer PingServerTimer;
        private System.Windows.Forms.ToolStripMenuItem vehiclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetupMenuMakesMaintenance;
        private System.Windows.Forms.ToolStripMenuItem FileMenuWindowClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem FileMenuWindowMinimize;
        private System.Windows.Forms.ToolStripMenuItem FileMenuWindowMaximize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem FileMenuImport;
        private System.Windows.Forms.ToolStripMenuItem FileMenuImportCSV;
        private System.Windows.Forms.ToolStripMenuItem FileMenuExport;
        private System.Windows.Forms.ToolStripMenuItem FileMenuExportCSV;
    }
}

