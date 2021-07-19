
namespace KronosDMS_Client.Forms.Server
{
    partial class UserAccountsForm
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
            this.labelUserID = new System.Windows.Forms.Label();
            this.textUserID = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textFirstname = new System.Windows.Forms.TextBox();
            this.labelFirstname = new System.Windows.Forms.Label();
            this.textLastname = new System.Windows.Forms.TextBox();
            this.labelLastname = new System.Windows.Forms.Label();
            this.boxGroups = new System.Windows.Forms.ComboBox();
            this.labelGroup = new System.Windows.Forms.Label();
            this.buttonSearchID = new System.Windows.Forms.Button();
            this.buttonSearchUsername = new System.Windows.Forms.Button();
            this.Tools.SuspendLayout();
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
            this.Tools.Size = new System.Drawing.Size(296, 25);
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
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(13, 31);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(44, 15);
            this.labelUserID.TabIndex = 28;
            this.labelUserID.Text = "User ID";
            // 
            // textUserID
            // 
            this.textUserID.Location = new System.Drawing.Point(83, 28);
            this.textUserID.Name = "textUserID";
            this.textUserID.Size = new System.Drawing.Size(123, 23);
            this.textUserID.TabIndex = 29;
            this.textUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textUserID_KeyDown);
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(83, 57);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(123, 23);
            this.textUsername.TabIndex = 31;
            this.textUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textUsername_KeyDown);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(13, 60);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(60, 15);
            this.labelUsername.TabIndex = 30;
            this.labelUsername.Text = "Username";
            // 
            // textFirstname
            // 
            this.textFirstname.Location = new System.Drawing.Point(83, 86);
            this.textFirstname.Name = "textFirstname";
            this.textFirstname.Size = new System.Drawing.Size(201, 23);
            this.textFirstname.TabIndex = 33;
            // 
            // labelFirstname
            // 
            this.labelFirstname.AutoSize = true;
            this.labelFirstname.Location = new System.Drawing.Point(13, 89);
            this.labelFirstname.Name = "labelFirstname";
            this.labelFirstname.Size = new System.Drawing.Size(64, 15);
            this.labelFirstname.TabIndex = 32;
            this.labelFirstname.Text = "First Name";
            // 
            // textLastname
            // 
            this.textLastname.Location = new System.Drawing.Point(83, 115);
            this.textLastname.Name = "textLastname";
            this.textLastname.Size = new System.Drawing.Size(201, 23);
            this.textLastname.TabIndex = 35;
            // 
            // labelLastname
            // 
            this.labelLastname.AutoSize = true;
            this.labelLastname.Location = new System.Drawing.Point(13, 118);
            this.labelLastname.Name = "labelLastname";
            this.labelLastname.Size = new System.Drawing.Size(63, 15);
            this.labelLastname.TabIndex = 34;
            this.labelLastname.Text = "Last Name";
            // 
            // boxGroups
            // 
            this.boxGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxGroups.FormattingEnabled = true;
            this.boxGroups.Location = new System.Drawing.Point(83, 144);
            this.boxGroups.Name = "boxGroups";
            this.boxGroups.Size = new System.Drawing.Size(123, 23);
            this.boxGroups.TabIndex = 37;
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(13, 147);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(40, 15);
            this.labelGroup.TabIndex = 36;
            this.labelGroup.Text = "Group";
            // 
            // buttonSearchID
            // 
            this.buttonSearchID.Location = new System.Drawing.Point(205, 28);
            this.buttonSearchID.Name = "buttonSearchID";
            this.buttonSearchID.Size = new System.Drawing.Size(23, 23);
            this.buttonSearchID.TabIndex = 38;
            this.buttonSearchID.Text = "S";
            this.buttonSearchID.UseVisualStyleBackColor = true;
            this.buttonSearchID.Click += new System.EventHandler(this.buttonSearchID_Click);
            // 
            // buttonSearchUsername
            // 
            this.buttonSearchUsername.Location = new System.Drawing.Point(205, 57);
            this.buttonSearchUsername.Name = "buttonSearchUsername";
            this.buttonSearchUsername.Size = new System.Drawing.Size(23, 23);
            this.buttonSearchUsername.TabIndex = 39;
            this.buttonSearchUsername.Text = "S";
            this.buttonSearchUsername.UseVisualStyleBackColor = true;
            this.buttonSearchUsername.Click += new System.EventHandler(this.buttonSearchUsername_Click);
            // 
            // UserAccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 184);
            this.Controls.Add(this.buttonSearchUsername);
            this.Controls.Add(this.buttonSearchID);
            this.Controls.Add(this.boxGroups);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.textLastname);
            this.Controls.Add(this.labelLastname);
            this.Controls.Add(this.textFirstname);
            this.Controls.Add(this.labelFirstname);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textUserID);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.Tools);
            this.Name = "UserAccountsForm";
            this.Text = "User Accounts";
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.TextBox textUserID;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textFirstname;
        private System.Windows.Forms.Label labelFirstname;
        private System.Windows.Forms.TextBox textLastname;
        private System.Windows.Forms.Label labelLastname;
        private System.Windows.Forms.ComboBox boxGroups;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Button buttonSearchID;
        private System.Windows.Forms.Button buttonSearchUsername;
    }
}