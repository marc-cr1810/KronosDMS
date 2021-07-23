
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
            this.OpenedWindowsPanel = new System.Windows.Forms.Panel();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceKitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenuKitsGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenuKitsRecalls = new System.Windows.Forms.ToolStripMenuItem();
            this.queriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.RecallsMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenuMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupUserAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupUserGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowView = new System.Windows.Forms.Panel();
            this.KitsMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenedWindowsPanel
            // 
            this.OpenedWindowsPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OpenedWindowsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OpenedWindowsPanel.Location = new System.Drawing.Point(0, 549);
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
            this.FileMenuExit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // FileMenuExit
            // 
            this.FileMenuExit.Name = "FileMenuExit";
            this.FileMenuExit.Size = new System.Drawing.Size(93, 22);
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
            this.serviceKitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serviceKitsToolStripMenuItem.Text = "Service Kits";
            // 
            // PartsMenuKitsGeneral
            // 
            this.PartsMenuKitsGeneral.Name = "PartsMenuKitsGeneral";
            this.PartsMenuKitsGeneral.Size = new System.Drawing.Size(180, 22);
            this.PartsMenuKitsGeneral.Text = "General";
            this.PartsMenuKitsGeneral.Click += new System.EventHandler(this.PartsMenuKitsGeneral_Click);
            // 
            // PartsMenuKitsRecalls
            // 
            this.PartsMenuKitsRecalls.Name = "PartsMenuKitsRecalls";
            this.PartsMenuKitsRecalls.Size = new System.Drawing.Size(180, 22);
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
            this.queriesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.queriesToolStripMenuItem.Text = "Queries";
            // 
            // PartsMenuSearch
            // 
            this.PartsMenuSearch.Name = "PartsMenuSearch";
            this.PartsMenuSearch.Size = new System.Drawing.Size(180, 22);
            this.PartsMenuSearch.Text = "Parts Search";
            this.PartsMenuSearch.Click += new System.EventHandler(this.PartsMenuSearch_Click);
            // 
            // RecallsMenuSearch
            // 
            this.RecallsMenuSearch.Name = "RecallsMenuSearch";
            this.RecallsMenuSearch.Size = new System.Drawing.Size(180, 22);
            this.RecallsMenuSearch.Text = "Recalls Search";
            this.RecallsMenuSearch.Click += new System.EventHandler(this.RecallsMenuSearch_Click);
            // 
            // PartsMenuMaintenance
            // 
            this.PartsMenuMaintenance.Name = "PartsMenuMaintenance";
            this.PartsMenuMaintenance.Size = new System.Drawing.Size(180, 22);
            this.PartsMenuMaintenance.Text = "Parts Maintenance";
            this.PartsMenuMaintenance.Click += new System.EventHandler(this.PartsMenuMaintenance_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.serverToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetupUserAccounts,
            this.SetupUserGroups});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.serverToolStripMenuItem.Text = "Server";
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
            // WindowView
            // 
            this.WindowView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowView.Location = new System.Drawing.Point(0, 24);
            this.WindowView.Name = "WindowView";
            this.WindowView.Size = new System.Drawing.Size(952, 525);
            this.WindowView.TabIndex = 2;
            // 
            // KitsMenuSearch
            // 
            this.KitsMenuSearch.Name = "KitsMenuSearch";
            this.KitsMenuSearch.Size = new System.Drawing.Size(180, 22);
            this.KitsMenuSearch.Text = "Kits Search";
            this.KitsMenuSearch.Click += new System.EventHandler(this.KitsMenuSearch_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(952, 587);
            this.Controls.Add(this.WindowView);
            this.Controls.Add(this.OpenedWindowsPanel);
            this.Controls.Add(this.Menu);
            this.DoubleBuffered = true;
            this.Name = "MainWindow";
            this.Text = "Form1";
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
        private System.Windows.Forms.Panel WindowView;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceKitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuKitsGeneral;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuKitsRecalls;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuMaintenance;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetupUserAccounts;
        private System.Windows.Forms.ToolStripMenuItem SetupUserGroups;
        private System.Windows.Forms.ToolStripMenuItem queriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuSearch;
        private System.Windows.Forms.ToolStripMenuItem RecallsMenuSearch;
        private System.Windows.Forms.ToolStripMenuItem KitsMenuSearch;
    }
}

