﻿
namespace KronosDMS_Client.Forms.Parts
{
    partial class RecallForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecallForm));
            this.textRecallNumber = new System.Windows.Forms.TextBox();
            this.labelRecallNumber = new System.Windows.Forms.Label();
            this.buttonRecallSearch = new System.Windows.Forms.Button();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.textNote = new System.Windows.Forms.TextBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.boxModel = new System.Windows.Forms.ComboBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.boxMakes = new System.Windows.Forms.ComboBox();
            this.labelMake = new System.Windows.Forms.Label();
            this.ListParts = new KronosDMS_Client.UserControls.KListView();
            this.columnPartNumber = new System.Windows.Forms.ColumnHeader();
            this.columnQuantity = new System.Windows.Forms.ColumnHeader();
            this.columnMake = new System.Windows.Forms.ColumnHeader();
            this.columnDescription = new System.Windows.Forms.ColumnHeader();
            this.columnNote = new System.Windows.Forms.ColumnHeader();
            this.PartsListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PartsListMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsListMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PartsListMenuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsListMenuImportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsListMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.PartsListMenuExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.textPartNumber = new System.Windows.Forms.TextBox();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.ButtonPartAdd = new System.Windows.Forms.Button();
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.LockUnlockButton = new System.Windows.Forms.ToolStripButton();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.boxOptions = new System.Windows.Forms.ComboBox();
            this.buttonAddOption = new System.Windows.Forms.Button();
            this.groupDetails.SuspendLayout();
            this.PartsListMenu.SuspendLayout();
            this.Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // textRecallNumber
            // 
            this.textRecallNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textRecallNumber.Location = new System.Drawing.Point(103, 28);
            this.textRecallNumber.Name = "textRecallNumber";
            this.textRecallNumber.Size = new System.Drawing.Size(152, 23);
            this.textRecallNumber.TabIndex = 12;
            this.textRecallNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRecallNumber_KeyDown);
            this.textRecallNumber.Leave += new System.EventHandler(this.buttonRecallSearch_Leave);
            // 
            // labelRecallNumber
            // 
            this.labelRecallNumber.AutoSize = true;
            this.labelRecallNumber.Location = new System.Drawing.Point(12, 31);
            this.labelRecallNumber.Name = "labelRecallNumber";
            this.labelRecallNumber.Size = new System.Drawing.Size(85, 15);
            this.labelRecallNumber.TabIndex = 11;
            this.labelRecallNumber.Text = "Recall Number";
            // 
            // buttonRecallSearch
            // 
            this.buttonRecallSearch.Location = new System.Drawing.Point(254, 29);
            this.buttonRecallSearch.Name = "buttonRecallSearch";
            this.buttonRecallSearch.Size = new System.Drawing.Size(22, 23);
            this.buttonRecallSearch.TabIndex = 13;
            this.buttonRecallSearch.Text = "S";
            this.buttonRecallSearch.UseVisualStyleBackColor = true;
            this.buttonRecallSearch.Click += new System.EventHandler(this.buttonRecallSearch_Click);
            // 
            // groupDetails
            // 
            this.groupDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDetails.Controls.Add(this.textNote);
            this.groupDetails.Controls.Add(this.labelNote);
            this.groupDetails.Controls.Add(this.textDescription);
            this.groupDetails.Controls.Add(this.labelDescription);
            this.groupDetails.Controls.Add(this.boxModel);
            this.groupDetails.Controls.Add(this.labelModel);
            this.groupDetails.Controls.Add(this.boxMakes);
            this.groupDetails.Controls.Add(this.labelMake);
            this.groupDetails.Location = new System.Drawing.Point(12, 57);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(592, 80);
            this.groupDetails.TabIndex = 14;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Details";
            // 
            // textNote
            // 
            this.textNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textNote.Location = new System.Drawing.Point(288, 45);
            this.textNote.Name = "textNote";
            this.textNote.Size = new System.Drawing.Size(298, 23);
            this.textNote.TabIndex = 24;
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(249, 48);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(33, 15);
            this.labelNote.TabIndex = 23;
            this.labelNote.Text = "Note";
            // 
            // textDescription
            // 
            this.textDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDescription.Location = new System.Drawing.Point(322, 16);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(264, 23);
            this.textDescription.TabIndex = 22;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(249, 19);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(67, 15);
            this.labelDescription.TabIndex = 21;
            this.labelDescription.Text = "Description";
            // 
            // boxModel
            // 
            this.boxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxModel.FormattingEnabled = true;
            this.boxModel.Location = new System.Drawing.Point(97, 45);
            this.boxModel.Name = "boxModel";
            this.boxModel.Size = new System.Drawing.Size(146, 23);
            this.boxModel.TabIndex = 20;
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(6, 48);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(41, 15);
            this.labelModel.TabIndex = 19;
            this.labelModel.Text = "Model";
            // 
            // boxMakes
            // 
            this.boxMakes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxMakes.FormattingEnabled = true;
            this.boxMakes.Location = new System.Drawing.Point(97, 16);
            this.boxMakes.Name = "boxMakes";
            this.boxMakes.Size = new System.Drawing.Size(146, 23);
            this.boxMakes.TabIndex = 18;
            this.boxMakes.SelectedIndexChanged += new System.EventHandler(this.boxMakes_TextUpdate);
            this.boxMakes.TextUpdate += new System.EventHandler(this.boxMakes_TextUpdate);
            // 
            // labelMake
            // 
            this.labelMake.AutoSize = true;
            this.labelMake.Location = new System.Drawing.Point(6, 19);
            this.labelMake.Name = "labelMake";
            this.labelMake.Size = new System.Drawing.Size(36, 15);
            this.labelMake.TabIndex = 17;
            this.labelMake.Text = "Make";
            // 
            // ListParts
            // 
            this.ListParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPartNumber,
            this.columnQuantity,
            this.columnMake,
            this.columnDescription,
            this.columnNote});
            this.ListParts.ContextMenuStrip = this.PartsListMenu;
            this.ListParts.FullRowSelect = true;
            this.ListParts.GridLines = true;
            this.ListParts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListParts.HideSelection = false;
            this.ListParts.Location = new System.Drawing.Point(12, 143);
            this.ListParts.MultiSelect = false;
            this.ListParts.Name = "ListParts";
            this.ListParts.Size = new System.Drawing.Size(592, 302);
            this.ListParts.TabIndex = 16;
            this.ListParts.UseCompatibleStateImageBehavior = false;
            this.ListParts.View = System.Windows.Forms.View.Details;
            this.ListParts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListParts_KeyUp);
            // 
            // columnPartNumber
            // 
            this.columnPartNumber.Text = "Part Number";
            this.columnPartNumber.Width = 120;
            // 
            // columnQuantity
            // 
            this.columnQuantity.Text = "Qty";
            this.columnQuantity.Width = 32;
            // 
            // columnMake
            // 
            this.columnMake.Text = "Make";
            this.columnMake.Width = 100;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 150;
            // 
            // columnNote
            // 
            this.columnNote.Text = "Note";
            this.columnNote.Width = 150;
            // 
            // PartsListMenu
            // 
            this.PartsListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PartsListMenuCopy,
            this.PartsListMenuDelete,
            this.toolStripSeparator2,
            this.PartsListMenuImport,
            this.PartsListMenuExport});
            this.PartsListMenu.Name = "PartsListMenu";
            this.PartsListMenu.Size = new System.Drawing.Size(112, 98);
            this.PartsListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.PartsListMenu_Opening);
            // 
            // PartsListMenuCopy
            // 
            this.PartsListMenuCopy.Name = "PartsListMenuCopy";
            this.PartsListMenuCopy.Size = new System.Drawing.Size(111, 22);
            this.PartsListMenuCopy.Text = "Copy";
            this.PartsListMenuCopy.Click += new System.EventHandler(this.PartsListMenuCopy_Click);
            // 
            // PartsListMenuDelete
            // 
            this.PartsListMenuDelete.Name = "PartsListMenuDelete";
            this.PartsListMenuDelete.Size = new System.Drawing.Size(111, 22);
            this.PartsListMenuDelete.Text = "Delete";
            this.PartsListMenuDelete.Click += new System.EventHandler(this.PastListMenuDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(108, 6);
            // 
            // PartsListMenuImport
            // 
            this.PartsListMenuImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PartsListMenuImportCSV});
            this.PartsListMenuImport.Name = "PartsListMenuImport";
            this.PartsListMenuImport.Size = new System.Drawing.Size(111, 22);
            this.PartsListMenuImport.Text = "Import";
            // 
            // PartsListMenuImportCSV
            // 
            this.PartsListMenuImportCSV.Name = "PartsListMenuImportCSV";
            this.PartsListMenuImportCSV.Size = new System.Drawing.Size(126, 22);
            this.PartsListMenuImportCSV.Text = "From CSV";
            this.PartsListMenuImportCSV.Click += new System.EventHandler(this.PartsListMenuImportCSV_Click);
            // 
            // PartsListMenuExport
            // 
            this.PartsListMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PartsListMenuExportCSV});
            this.PartsListMenuExport.Name = "PartsListMenuExport";
            this.PartsListMenuExport.Size = new System.Drawing.Size(111, 22);
            this.PartsListMenuExport.Text = "Export ";
            // 
            // PartsListMenuExportCSV
            // 
            this.PartsListMenuExportCSV.Name = "PartsListMenuExportCSV";
            this.PartsListMenuExportCSV.Size = new System.Drawing.Size(110, 22);
            this.PartsListMenuExportCSV.Text = "To CSV";
            // 
            // textPartNumber
            // 
            this.textPartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textPartNumber.Location = new System.Drawing.Point(93, 451);
            this.textPartNumber.Name = "textPartNumber";
            this.textPartNumber.Size = new System.Drawing.Size(264, 23);
            this.textPartNumber.TabIndex = 24;
            this.textPartNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textPartNumber_KeyDown);
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPartNumber.AutoSize = true;
            this.labelPartNumber.Location = new System.Drawing.Point(12, 454);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(75, 15);
            this.labelPartNumber.TabIndex = 23;
            this.labelPartNumber.Text = "Part Number";
            // 
            // ButtonPartAdd
            // 
            this.ButtonPartAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonPartAdd.Location = new System.Drawing.Point(364, 451);
            this.ButtonPartAdd.Name = "ButtonPartAdd";
            this.ButtonPartAdd.Size = new System.Drawing.Size(45, 23);
            this.ButtonPartAdd.TabIndex = 25;
            this.ButtonPartAdd.Text = "Add";
            this.ButtonPartAdd.UseVisualStyleBackColor = true;
            this.ButtonPartAdd.Click += new System.EventHandler(this.ButtonPartAdd_Click);
            // 
            // Tools
            // 
            this.Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.refreshToolStripButton,
            this.deleteToolStripButton,
            this.LockUnlockButton});
            this.Tools.Location = new System.Drawing.Point(0, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(616, 25);
            this.Tools.TabIndex = 26;
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
            this.refreshToolStripButton.Text = "Refresh";
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
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.ToolTipText = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // LockUnlockButton
            // 
            this.LockUnlockButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LockUnlockButton.Image = ((System.Drawing.Image)(resources.GetObject("LockUnlockButton.Image")));
            this.LockUnlockButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LockUnlockButton.Name = "LockUnlockButton";
            this.LockUnlockButton.Size = new System.Drawing.Size(23, 22);
            this.LockUnlockButton.Text = "Lock";
            this.LockUnlockButton.Click += new System.EventHandler(this.LockUnlockButton_Click);
            // 
            // ImportFileDialog
            // 
            this.ImportFileDialog.DefaultExt = "csv";
            this.ImportFileDialog.Filter = "CSV Files|*.csv";
            this.ImportFileDialog.InitialDirectory = "C:/Users/";
            this.ImportFileDialog.Title = "Import CSV File";
            // 
            // boxOptions
            // 
            this.boxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxOptions.FormattingEnabled = true;
            this.boxOptions.Location = new System.Drawing.Point(310, 30);
            this.boxOptions.MaximumSize = new System.Drawing.Size(320, 0);
            this.boxOptions.Name = "boxOptions";
            this.boxOptions.Size = new System.Drawing.Size(150, 23);
            this.boxOptions.TabIndex = 27;
            this.boxOptions.SelectedIndexChanged += new System.EventHandler(this.boxOptions_SelectedIndexChanged);
            this.boxOptions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxOptions_KeyPress);
            this.boxOptions.Leave += new System.EventHandler(this.boxOptions_Leave);
            // 
            // buttonAddOption
            // 
            this.buttonAddOption.Location = new System.Drawing.Point(288, 30);
            this.buttonAddOption.Name = "buttonAddOption";
            this.buttonAddOption.Size = new System.Drawing.Size(22, 23);
            this.buttonAddOption.TabIndex = 28;
            this.buttonAddOption.Text = "+";
            this.buttonAddOption.UseVisualStyleBackColor = true;
            this.buttonAddOption.Click += new System.EventHandler(this.buttonAddOption_Click);
            // 
            // RecallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 489);
            this.Controls.Add(this.buttonAddOption);
            this.Controls.Add(this.boxOptions);
            this.Controls.Add(this.Tools);
            this.Controls.Add(this.ButtonPartAdd);
            this.Controls.Add(this.textPartNumber);
            this.Controls.Add(this.labelPartNumber);
            this.Controls.Add(this.ListParts);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.buttonRecallSearch);
            this.Controls.Add(this.textRecallNumber);
            this.Controls.Add(this.labelRecallNumber);
            this.MinimumSize = new System.Drawing.Size(632, 395);
            this.Name = "RecallForm";
            this.Text = "Recall";
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.PartsListMenu.ResumeLayout(false);
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textRecallNumber;
        private System.Windows.Forms.Label labelRecallNumber;
        private System.Windows.Forms.Button buttonRecallSearch;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.ComboBox boxModel;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.ComboBox boxMakes;
        private System.Windows.Forms.Label labelMake;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label labelDescription;
        private UserControls.KListView ListParts;
        private System.Windows.Forms.ColumnHeader columnPartNumber;
        private System.Windows.Forms.ColumnHeader columnQuantity;
        private System.Windows.Forms.ColumnHeader columnMake;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.TextBox textPartNumber;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.Button ButtonPartAdd;
        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ContextMenuStrip PartsListMenu;
        private System.Windows.Forms.ToolStripMenuItem PartsListMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem PartsListMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem PartsListMenuImport;
        private System.Windows.Forms.ToolStripMenuItem PartsListMenuImportCSV;
        private System.Windows.Forms.ToolStripMenuItem PartsListMenuExport;
        private System.Windows.Forms.ToolStripMenuItem PartsListMenuExportCSV;
        private System.Windows.Forms.OpenFileDialog ImportFileDialog;
        private System.Windows.Forms.ToolStripButton LockUnlockButton;
        private System.Windows.Forms.TextBox textNote;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.ColumnHeader columnNote;
        private System.Windows.Forms.ComboBox boxOptions;
        private System.Windows.Forms.Button buttonAddOption;
    }
}