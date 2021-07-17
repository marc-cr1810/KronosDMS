
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
            this.PartsMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceKitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsMenuKitsRecalls = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowView = new System.Windows.Forms.Panel();
            this.PartsMenuMaintenance = new System.Windows.Forms.ToolStripMenuItem();
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
            this.PartsMenuSearch,
            this.serviceKitsToolStripMenuItem,
            this.PartsMenuMaintenance});
            this.PartsMenu.Name = "PartsMenu";
            this.PartsMenu.Size = new System.Drawing.Size(45, 20);
            this.PartsMenu.Text = "Parts";
            // 
            // PartsMenuSearch
            // 
            this.PartsMenuSearch.Name = "PartsMenuSearch";
            this.PartsMenuSearch.Size = new System.Drawing.Size(180, 22);
            this.PartsMenuSearch.Text = "Parts Search";
            this.PartsMenuSearch.Click += new System.EventHandler(this.PartsMenuSearch_Click);
            // 
            // serviceKitsToolStripMenuItem
            // 
            this.serviceKitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.PartsMenuKitsRecalls});
            this.serviceKitsToolStripMenuItem.Name = "serviceKitsToolStripMenuItem";
            this.serviceKitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serviceKitsToolStripMenuItem.Text = "Service Kits";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generalToolStripMenuItem.Text = "General";
            // 
            // PartsMenuKitsRecalls
            // 
            this.PartsMenuKitsRecalls.Name = "PartsMenuKitsRecalls";
            this.PartsMenuKitsRecalls.Size = new System.Drawing.Size(180, 22);
            this.PartsMenuKitsRecalls.Text = "Recalls";
            this.PartsMenuKitsRecalls.Click += new System.EventHandler(this.PartsMenuKitsRecalls_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // WindowView
            // 
            this.WindowView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowView.Location = new System.Drawing.Point(0, 24);
            this.WindowView.Name = "WindowView";
            this.WindowView.Size = new System.Drawing.Size(952, 525);
            this.WindowView.TabIndex = 2;
            // 
            // PartsMenuMaintenance
            // 
            this.PartsMenuMaintenance.Name = "PartsMenuMaintenance";
            this.PartsMenuMaintenance.Size = new System.Drawing.Size(180, 22);
            this.PartsMenuMaintenance.Text = "Parts Maintenance";
            this.PartsMenuMaintenance.Click += new System.EventHandler(this.PartsMenuMaintenance_Click);
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
        private System.Windows.Forms.ToolStripMenuItem PartsMenuSearch;
        private System.Windows.Forms.Panel WindowView;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceKitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuKitsRecalls;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PartsMenuMaintenance;
    }
}

