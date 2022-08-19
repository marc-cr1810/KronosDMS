namespace KronosDMS_Client.Forms.Parts
{
    partial class ROCheckedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ROCheckedForm));
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textRONumber = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelRONumber = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.columnRONumber = new System.Windows.Forms.ColumnHeader();
            this.columnAddedDate = new System.Windows.Forms.ColumnHeader();
            this.ROList = new System.Windows.Forms.ListView();
            this.Tools.SuspendLayout();
            this.groupSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tools
            // 
            this.Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.toolStripSeparator1,
            this.refreshToolStripButton});
            this.Tools.Location = new System.Drawing.Point(0, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(408, 25);
            this.Tools.TabIndex = 27;
            this.Tools.Text = "toolStrip1";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addToolStripButton.Text = "&Add";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::KronosDMS_Client.Properties.Resources.refresh_icon;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "toolStripButton1";
            this.refreshToolStripButton.ToolTipText = "Refresh";
            // 
            // groupSearch
            // 
            this.groupSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSearch.Controls.Add(this.buttonSearch);
            this.groupSearch.Controls.Add(this.textRONumber);
            this.groupSearch.Controls.Add(this.labelDate);
            this.groupSearch.Controls.Add(this.labelRONumber);
            this.groupSearch.Controls.Add(this.datePicker);
            this.groupSearch.Location = new System.Drawing.Point(12, 28);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(384, 74);
            this.groupSearch.TabIndex = 29;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "Search";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(303, 42);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textRONumber
            // 
            this.textRONumber.Location = new System.Drawing.Point(82, 16);
            this.textRONumber.Name = "textRONumber";
            this.textRONumber.Size = new System.Drawing.Size(208, 23);
            this.textRONumber.TabIndex = 3;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(6, 48);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(31, 15);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "Date";
            // 
            // labelRONumber
            // 
            this.labelRONumber.AutoSize = true;
            this.labelRONumber.Location = new System.Drawing.Point(6, 19);
            this.labelRONumber.Name = "labelRONumber";
            this.labelRONumber.Size = new System.Drawing.Size(70, 15);
            this.labelRONumber.TabIndex = 1;
            this.labelRONumber.Text = "RO Number";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(82, 42);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(208, 23);
            this.datePicker.TabIndex = 0;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // columnRONumber
            // 
            this.columnRONumber.Text = "RO Number";
            this.columnRONumber.Width = 250;
            // 
            // columnAddedDate
            // 
            this.columnAddedDate.Text = "Checked Date";
            this.columnAddedDate.Width = 120;
            // 
            // ROList
            // 
            this.ROList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ROList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRONumber,
            this.columnAddedDate});
            this.ROList.GridLines = true;
            this.ROList.HideSelection = false;
            this.ROList.Location = new System.Drawing.Point(12, 108);
            this.ROList.Name = "ROList";
            this.ROList.Size = new System.Drawing.Size(384, 331);
            this.ROList.TabIndex = 28;
            this.ROList.UseCompatibleStateImageBehavior = false;
            this.ROList.View = System.Windows.Forms.View.Details;
            // 
            // ROCheckedForm
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 451);
            this.Controls.Add(this.groupSearch);
            this.Controls.Add(this.ROList);
            this.Controls.Add(this.Tools);
            this.MinimumSize = new System.Drawing.Size(424, 490);
            this.Name = "ROCheckedForm";
            this.Text = "RO\'s Checked";
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.TextBox textRONumber;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelRONumber;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ColumnHeader columnRONumber;
        private System.Windows.Forms.ColumnHeader columnAddedDate;
        private System.Windows.Forms.ListView ROList;
        private System.Windows.Forms.Button buttonSearch;
    }
}