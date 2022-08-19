namespace KronosDMS_Client.Forms.Parts
{
    partial class ROCheckedSubmitForm
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
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ROList = new System.Windows.Forms.ListView();
            this.columnRONumber = new System.Windows.Forms.ColumnHeader();
            this.columnAddedDate = new System.Windows.Forms.ColumnHeader();
            this.labelRONumber = new System.Windows.Forms.Label();
            this.textRONumber = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tools
            // 
            this.Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.deleteToolStripButton});
            this.Tools.Location = new System.Drawing.Point(0, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(408, 25);
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
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = global::KronosDMS_Client.Properties.Resources.delete_file_icon;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "toolStripButton2";
            this.deleteToolStripButton.ToolTipText = "Delete";
            // 
            // ROList
            // 
            this.ROList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRONumber,
            this.columnAddedDate});
            this.ROList.GridLines = true;
            this.ROList.HideSelection = false;
            this.ROList.Location = new System.Drawing.Point(12, 28);
            this.ROList.Name = "ROList";
            this.ROList.Size = new System.Drawing.Size(384, 373);
            this.ROList.TabIndex = 29;
            this.ROList.UseCompatibleStateImageBehavior = false;
            this.ROList.View = System.Windows.Forms.View.Details;
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
            // labelRONumber
            // 
            this.labelRONumber.AutoSize = true;
            this.labelRONumber.Location = new System.Drawing.Point(12, 410);
            this.labelRONumber.Name = "labelRONumber";
            this.labelRONumber.Size = new System.Drawing.Size(70, 15);
            this.labelRONumber.TabIndex = 30;
            this.labelRONumber.Text = "RO Number";
            // 
            // textRONumber
            // 
            this.textRONumber.Location = new System.Drawing.Point(88, 407);
            this.textRONumber.Name = "textRONumber";
            this.textRONumber.Size = new System.Drawing.Size(208, 23);
            this.textRONumber.TabIndex = 31;
            this.textRONumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textRONumber_KeyDown);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(12, 442);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(31, 15);
            this.labelDate.TabIndex = 33;
            this.labelDate.Text = "Date";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(88, 436);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(208, 23);
            this.datePicker.TabIndex = 32;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(321, 439);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 34;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // ROCheckedSubmitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 469);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.textRONumber);
            this.Controls.Add(this.labelRONumber);
            this.Controls.Add(this.ROList);
            this.Controls.Add(this.Tools);
            this.MinimumSize = new System.Drawing.Size(424, 508);
            this.Name = "ROCheckedSubmitForm";
            this.Text = "Submit Checked RO\'s";
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ListView ROList;
        private System.Windows.Forms.ColumnHeader columnRONumber;
        private System.Windows.Forms.ColumnHeader columnAddedDate;
        private System.Windows.Forms.Label labelRONumber;
        private System.Windows.Forms.TextBox textRONumber;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button buttonAdd;
    }
}