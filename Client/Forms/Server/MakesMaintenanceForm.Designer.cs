
namespace KronosDMS_Client.Forms.Server
{
    partial class MakesMaintenanceForm
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
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.textMakeID = new System.Windows.Forms.TextBox();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.ListModels = new System.Windows.Forms.ListView();
            this.columnModel = new System.Windows.Forms.ColumnHeader();
            this.columnSubModelCount = new System.Windows.Forms.ColumnHeader();
            this.textMakeName = new System.Windows.Forms.TextBox();
            this.labelMakeName = new System.Windows.Forms.Label();
            this.buttonMakeSearch = new System.Windows.Forms.Button();
            this.Tools.SuspendLayout();
            this.groupDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tools
            // 
            this.Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.refreshToolStripButton,
            this.deleteToolStripButton});
            this.Tools.Location = new System.Drawing.Point(0, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(553, 25);
            this.Tools.TabIndex = 27;
            this.Tools.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::KronosDMS_Client.Properties.Resources.floppy_icon;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
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
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = global::KronosDMS_Client.Properties.Resources.delete_file_icon;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "toolStripButton2";
            this.deleteToolStripButton.ToolTipText = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // textMakeID
            // 
            this.textMakeID.Location = new System.Drawing.Point(68, 28);
            this.textMakeID.Name = "textMakeID";
            this.textMakeID.Size = new System.Drawing.Size(154, 23);
            this.textMakeID.TabIndex = 29;
            this.textMakeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textMakeIDSearch);
            this.textMakeID.Leave += new System.EventHandler(this.textMakeID_Leave);
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.AutoSize = true;
            this.labelPartNumber.Location = new System.Drawing.Point(12, 31);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(50, 15);
            this.labelPartNumber.TabIndex = 28;
            this.labelPartNumber.Text = "Make ID";
            // 
            // groupDetails
            // 
            this.groupDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDetails.Controls.Add(this.ListModels);
            this.groupDetails.Controls.Add(this.textMakeName);
            this.groupDetails.Controls.Add(this.labelMakeName);
            this.groupDetails.Location = new System.Drawing.Point(12, 57);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(529, 243);
            this.groupDetails.TabIndex = 30;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Details";
            // 
            // ListModels
            // 
            this.ListModels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListModels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListModels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnModel,
            this.columnSubModelCount});
            this.ListModels.FullRowSelect = true;
            this.ListModels.GridLines = true;
            this.ListModels.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListModels.HideSelection = false;
            this.ListModels.Location = new System.Drawing.Point(6, 54);
            this.ListModels.MultiSelect = false;
            this.ListModels.Name = "ListModels";
            this.ListModels.Size = new System.Drawing.Size(517, 183);
            this.ListModels.TabIndex = 34;
            this.ListModels.UseCompatibleStateImageBehavior = false;
            this.ListModels.View = System.Windows.Forms.View.Details;
            // 
            // columnModel
            // 
            this.columnModel.Text = "Model";
            this.columnModel.Width = 120;
            // 
            // columnSubModelCount
            // 
            this.columnSubModelCount.Text = "Sub Model Count";
            this.columnSubModelCount.Width = 200;
            // 
            // textMakeName
            // 
            this.textMakeName.Enabled = false;
            this.textMakeName.Location = new System.Drawing.Point(56, 25);
            this.textMakeName.Name = "textMakeName";
            this.textMakeName.Size = new System.Drawing.Size(160, 23);
            this.textMakeName.TabIndex = 33;
            // 
            // labelMakeName
            // 
            this.labelMakeName.AutoSize = true;
            this.labelMakeName.Location = new System.Drawing.Point(6, 28);
            this.labelMakeName.Name = "labelMakeName";
            this.labelMakeName.Size = new System.Drawing.Size(39, 15);
            this.labelMakeName.TabIndex = 32;
            this.labelMakeName.Text = "Name";
            // 
            // buttonMakeSearch
            // 
            this.buttonMakeSearch.Location = new System.Drawing.Point(220, 28);
            this.buttonMakeSearch.Name = "buttonMakeSearch";
            this.buttonMakeSearch.Size = new System.Drawing.Size(22, 23);
            this.buttonMakeSearch.TabIndex = 31;
            this.buttonMakeSearch.Text = "S";
            this.buttonMakeSearch.UseVisualStyleBackColor = true;
            this.buttonMakeSearch.Click += new System.EventHandler(this.buttonMakeIDSearch_Click);
            // 
            // MakesMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 312);
            this.Controls.Add(this.buttonMakeSearch);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.textMakeID);
            this.Controls.Add(this.labelPartNumber);
            this.Controls.Add(this.Tools);
            this.MinimumSize = new System.Drawing.Size(440, 270);
            this.Name = "MakesMaintenanceForm";
            this.Text = "Makes Maintenance";
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.TextBox textMakeID;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.Button buttonMakeSearch;
        private System.Windows.Forms.TextBox textMakeName;
        private System.Windows.Forms.Label labelMakeName;
        private System.Windows.Forms.ListView ListModels;
        private System.Windows.Forms.ColumnHeader columnModel;
        private System.Windows.Forms.ColumnHeader columnSubModelCount;
    }
}