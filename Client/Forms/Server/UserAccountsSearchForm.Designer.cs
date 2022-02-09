
namespace KronosDMS_Client.Forms.Server
{
    partial class UserAccountsSearchForm
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
            this.textLastname = new System.Windows.Forms.TextBox();
            this.labelLastname = new System.Windows.Forms.Label();
            this.textFirstname = new System.Windows.Forms.TextBox();
            this.labelFirstname = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textUserID = new System.Windows.Forms.TextBox();
            this.labelUserID = new System.Windows.Forms.Label();
            this.ListUserAccounts = new System.Windows.Forms.ListView();
            this.columnUsername = new System.Windows.Forms.ColumnHeader();
            this.columnID = new System.Windows.Forms.ColumnHeader();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textLastname
            // 
            this.textLastname.Location = new System.Drawing.Point(81, 99);
            this.textLastname.Name = "textLastname";
            this.textLastname.Size = new System.Drawing.Size(215, 23);
            this.textLastname.TabIndex = 43;
            // 
            // labelLastname
            // 
            this.labelLastname.AutoSize = true;
            this.labelLastname.Location = new System.Drawing.Point(11, 102);
            this.labelLastname.Name = "labelLastname";
            this.labelLastname.Size = new System.Drawing.Size(63, 15);
            this.labelLastname.TabIndex = 42;
            this.labelLastname.Text = "Last Name";
            // 
            // textFirstname
            // 
            this.textFirstname.Location = new System.Drawing.Point(81, 70);
            this.textFirstname.Name = "textFirstname";
            this.textFirstname.Size = new System.Drawing.Size(215, 23);
            this.textFirstname.TabIndex = 41;
            // 
            // labelFirstname
            // 
            this.labelFirstname.AutoSize = true;
            this.labelFirstname.Location = new System.Drawing.Point(11, 73);
            this.labelFirstname.Name = "labelFirstname";
            this.labelFirstname.Size = new System.Drawing.Size(64, 15);
            this.labelFirstname.TabIndex = 40;
            this.labelFirstname.Text = "First Name";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(81, 41);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(123, 23);
            this.textUsername.TabIndex = 39;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(11, 44);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(60, 15);
            this.labelUsername.TabIndex = 38;
            this.labelUsername.Text = "Username";
            // 
            // textUserID
            // 
            this.textUserID.Location = new System.Drawing.Point(81, 12);
            this.textUserID.Name = "textUserID";
            this.textUserID.Size = new System.Drawing.Size(123, 23);
            this.textUserID.TabIndex = 37;
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(11, 15);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(44, 15);
            this.labelUserID.TabIndex = 36;
            this.labelUserID.Text = "User ID";
            // 
            // ListUserAccounts
            // 
            this.ListUserAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListUserAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListUserAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUsername,
            this.columnID,
            this.columnName});
            this.ListUserAccounts.FullRowSelect = true;
            this.ListUserAccounts.GridLines = true;
            this.ListUserAccounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListUserAccounts.HideSelection = false;
            this.ListUserAccounts.Location = new System.Drawing.Point(11, 128);
            this.ListUserAccounts.MultiSelect = false;
            this.ListUserAccounts.Name = "ListUserAccounts";
            this.ListUserAccounts.Size = new System.Drawing.Size(366, 209);
            this.ListUserAccounts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListUserAccounts.TabIndex = 44;
            this.ListUserAccounts.UseCompatibleStateImageBehavior = false;
            this.ListUserAccounts.View = System.Windows.Forms.View.Details;
            this.ListUserAccounts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListUserAccounts_MouseDoubleClick);
            this.ListUserAccounts.Resize += new System.EventHandler(this.ListUserAccounts_Resize);
            // 
            // columnUsername
            // 
            this.columnUsername.Text = "Username";
            this.columnUsername.Width = 120;
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            this.columnID.Width = 40;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 200;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(302, 98);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 45;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // UserAccountsSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 349);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.ListUserAccounts);
            this.Controls.Add(this.textLastname);
            this.Controls.Add(this.labelLastname);
            this.Controls.Add(this.textFirstname);
            this.Controls.Add(this.labelFirstname);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textUserID);
            this.Controls.Add(this.labelUserID);
            this.Name = "UserAccountsSearchForm";
            this.Text = "UserAccountsSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textLastname;
        private System.Windows.Forms.Label labelLastname;
        private System.Windows.Forms.TextBox textFirstname;
        private System.Windows.Forms.Label labelFirstname;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textUserID;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.ListView ListUserAccounts;
        private System.Windows.Forms.ColumnHeader columnUsername;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.Button buttonSearch;
    }
}