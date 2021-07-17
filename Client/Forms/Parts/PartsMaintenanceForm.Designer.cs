
namespace KronosDMS_Client.Forms.Parts
{
    partial class PartsMaintenanceForm
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
            this.textPartNumber = new System.Windows.Forms.TextBox();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.textBin = new System.Windows.Forms.TextBox();
            this.labelBin = new System.Windows.Forms.Label();
            this.buttonSuccessorSearch = new System.Windows.Forms.Button();
            this.textSuccessor = new System.Windows.Forms.TextBox();
            this.labelSuccessor = new System.Windows.Forms.Label();
            this.buttonPredecessorSearch = new System.Windows.Forms.Button();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.textPredecessor = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelPredecessor = new System.Windows.Forms.Label();
            this.boxMakes = new System.Windows.Forms.ComboBox();
            this.labelMake = new System.Windows.Forms.Label();
            this.buttonPartSearch = new System.Windows.Forms.Button();
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
            this.Tools.Size = new System.Drawing.Size(423, 25);
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
            // textPartNumber
            // 
            this.textPartNumber.Location = new System.Drawing.Point(93, 28);
            this.textPartNumber.Name = "textPartNumber";
            this.textPartNumber.Size = new System.Drawing.Size(146, 23);
            this.textPartNumber.TabIndex = 29;
            this.textPartNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textPartNumberSearch);
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.AutoSize = true;
            this.labelPartNumber.Location = new System.Drawing.Point(12, 31);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(75, 15);
            this.labelPartNumber.TabIndex = 28;
            this.labelPartNumber.Text = "Part Number";
            // 
            // groupDetails
            // 
            this.groupDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDetails.Controls.Add(this.textBin);
            this.groupDetails.Controls.Add(this.labelBin);
            this.groupDetails.Controls.Add(this.buttonSuccessorSearch);
            this.groupDetails.Controls.Add(this.textSuccessor);
            this.groupDetails.Controls.Add(this.labelSuccessor);
            this.groupDetails.Controls.Add(this.buttonPredecessorSearch);
            this.groupDetails.Controls.Add(this.textDescription);
            this.groupDetails.Controls.Add(this.textPredecessor);
            this.groupDetails.Controls.Add(this.labelDescription);
            this.groupDetails.Controls.Add(this.labelPredecessor);
            this.groupDetails.Controls.Add(this.boxMakes);
            this.groupDetails.Controls.Add(this.labelMake);
            this.groupDetails.Location = new System.Drawing.Point(12, 57);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(399, 163);
            this.groupDetails.TabIndex = 30;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Details";
            // 
            // textBin
            // 
            this.textBin.Location = new System.Drawing.Point(87, 74);
            this.textBin.Name = "textBin";
            this.textBin.Size = new System.Drawing.Size(146, 23);
            this.textBin.TabIndex = 39;
            // 
            // labelBin
            // 
            this.labelBin.AutoSize = true;
            this.labelBin.Location = new System.Drawing.Point(6, 77);
            this.labelBin.Name = "labelBin";
            this.labelBin.Size = new System.Drawing.Size(24, 15);
            this.labelBin.TabIndex = 38;
            this.labelBin.Text = "Bin";
            // 
            // buttonSuccessorSearch
            // 
            this.buttonSuccessorSearch.Location = new System.Drawing.Point(233, 132);
            this.buttonSuccessorSearch.Name = "buttonSuccessorSearch";
            this.buttonSuccessorSearch.Size = new System.Drawing.Size(22, 23);
            this.buttonSuccessorSearch.TabIndex = 37;
            this.buttonSuccessorSearch.Text = "S";
            this.buttonSuccessorSearch.UseVisualStyleBackColor = true;
            this.buttonSuccessorSearch.Click += new System.EventHandler(this.buttonSuccessorSearch_Click);
            // 
            // textSuccessor
            // 
            this.textSuccessor.Location = new System.Drawing.Point(87, 132);
            this.textSuccessor.Name = "textSuccessor";
            this.textSuccessor.Size = new System.Drawing.Size(146, 23);
            this.textSuccessor.TabIndex = 36;
            // 
            // labelSuccessor
            // 
            this.labelSuccessor.AutoSize = true;
            this.labelSuccessor.Location = new System.Drawing.Point(6, 135);
            this.labelSuccessor.Name = "labelSuccessor";
            this.labelSuccessor.Size = new System.Drawing.Size(59, 15);
            this.labelSuccessor.TabIndex = 35;
            this.labelSuccessor.Text = "Successor";
            // 
            // buttonPredecessorSearch
            // 
            this.buttonPredecessorSearch.Location = new System.Drawing.Point(233, 103);
            this.buttonPredecessorSearch.Name = "buttonPredecessorSearch";
            this.buttonPredecessorSearch.Size = new System.Drawing.Size(22, 23);
            this.buttonPredecessorSearch.TabIndex = 34;
            this.buttonPredecessorSearch.Text = "S";
            this.buttonPredecessorSearch.UseVisualStyleBackColor = true;
            this.buttonPredecessorSearch.Click += new System.EventHandler(this.buttonPredecessorSearch_Click);
            // 
            // textDescription
            // 
            this.textDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDescription.Location = new System.Drawing.Point(87, 45);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(306, 23);
            this.textDescription.TabIndex = 22;
            // 
            // textPredecessor
            // 
            this.textPredecessor.Location = new System.Drawing.Point(87, 103);
            this.textPredecessor.Name = "textPredecessor";
            this.textPredecessor.Size = new System.Drawing.Size(146, 23);
            this.textPredecessor.TabIndex = 33;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(6, 48);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(67, 15);
            this.labelDescription.TabIndex = 21;
            this.labelDescription.Text = "Description";
            // 
            // labelPredecessor
            // 
            this.labelPredecessor.AutoSize = true;
            this.labelPredecessor.Location = new System.Drawing.Point(6, 106);
            this.labelPredecessor.Name = "labelPredecessor";
            this.labelPredecessor.Size = new System.Drawing.Size(70, 15);
            this.labelPredecessor.TabIndex = 32;
            this.labelPredecessor.Text = "Predecessor";
            // 
            // boxMakes
            // 
            this.boxMakes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxMakes.FormattingEnabled = true;
            this.boxMakes.Location = new System.Drawing.Point(87, 16);
            this.boxMakes.Name = "boxMakes";
            this.boxMakes.Size = new System.Drawing.Size(146, 23);
            this.boxMakes.TabIndex = 18;
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
            // buttonPartSearch
            // 
            this.buttonPartSearch.Location = new System.Drawing.Point(239, 28);
            this.buttonPartSearch.Name = "buttonPartSearch";
            this.buttonPartSearch.Size = new System.Drawing.Size(22, 23);
            this.buttonPartSearch.TabIndex = 31;
            this.buttonPartSearch.Text = "S";
            this.buttonPartSearch.UseVisualStyleBackColor = true;
            this.buttonPartSearch.Click += new System.EventHandler(this.buttonPartSearch_Click);
            // 
            // PartsMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 232);
            this.Controls.Add(this.buttonPartSearch);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.textPartNumber);
            this.Controls.Add(this.labelPartNumber);
            this.Controls.Add(this.Tools);
            this.Name = "PartsMaintenanceForm";
            this.Text = "Parts Maintenance";
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
        private System.Windows.Forms.TextBox textPartNumber;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.ComboBox boxMakes;
        private System.Windows.Forms.Label labelMake;
        private System.Windows.Forms.Button buttonPartSearch;
        private System.Windows.Forms.Button buttonPredecessorSearch;
        private System.Windows.Forms.TextBox textPredecessor;
        private System.Windows.Forms.Label labelPredecessor;
        private System.Windows.Forms.Button buttonSuccessorSearch;
        private System.Windows.Forms.TextBox textSuccessor;
        private System.Windows.Forms.Label labelSuccessor;
        private System.Windows.Forms.TextBox textBin;
        private System.Windows.Forms.Label labelBin;
    }
}