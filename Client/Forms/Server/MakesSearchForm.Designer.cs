
namespace KronosDMS_Client.Forms.Server
{
    partial class MakesSearchForm
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
            this.labelMakeID = new System.Windows.Forms.Label();
            this.labelMakeName = new System.Windows.Forms.Label();
            this.textMakeName = new System.Windows.Forms.TextBox();
            this.ListMakes = new System.Windows.Forms.ListView();
            this.columnID = new System.Windows.Forms.ColumnHeader();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.textMakeID = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMakeID
            // 
            this.labelMakeID.AutoSize = true;
            this.labelMakeID.Location = new System.Drawing.Point(12, 13);
            this.labelMakeID.Name = "labelMakeID";
            this.labelMakeID.Size = new System.Drawing.Size(50, 15);
            this.labelMakeID.TabIndex = 0;
            this.labelMakeID.Text = "Make ID";
            // 
            // labelMakeName
            // 
            this.labelMakeName.AutoSize = true;
            this.labelMakeName.Location = new System.Drawing.Point(12, 43);
            this.labelMakeName.Name = "labelMakeName";
            this.labelMakeName.Size = new System.Drawing.Size(39, 15);
            this.labelMakeName.TabIndex = 2;
            this.labelMakeName.Text = "Name";
            // 
            // textMakeName
            // 
            this.textMakeName.Location = new System.Drawing.Point(93, 40);
            this.textMakeName.Name = "textMakeName";
            this.textMakeName.Size = new System.Drawing.Size(146, 23);
            this.textMakeName.TabIndex = 3;
            // 
            // ListMakes
            // 
            this.ListMakes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListMakes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListMakes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnName});
            this.ListMakes.FullRowSelect = true;
            this.ListMakes.GridLines = true;
            this.ListMakes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListMakes.HideSelection = false;
            this.ListMakes.Location = new System.Drawing.Point(12, 69);
            this.ListMakes.MultiSelect = false;
            this.ListMakes.Name = "ListMakes";
            this.ListMakes.Size = new System.Drawing.Size(418, 234);
            this.ListMakes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListMakes.TabIndex = 7;
            this.ListMakes.UseCompatibleStateImageBehavior = false;
            this.ListMakes.View = System.Windows.Forms.View.Details;
            this.ListMakes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListMakes_MouseDoubleClick);
            this.ListMakes.Resize += new System.EventHandler(this.ListMakes_Resize);
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            this.columnID.Width = 80;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 200;
            // 
            // textMakeID
            // 
            this.textMakeID.Location = new System.Drawing.Point(93, 10);
            this.textMakeID.Name = "textMakeID";
            this.textMakeID.Size = new System.Drawing.Size(146, 23);
            this.textMakeID.TabIndex = 8;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(355, 40);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // MakesSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 315);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textMakeID);
            this.Controls.Add(this.ListMakes);
            this.Controls.Add(this.textMakeName);
            this.Controls.Add(this.labelMakeName);
            this.Controls.Add(this.labelMakeID);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(458, 278);
            this.Name = "MakesSearchForm";
            this.Text = "Makes Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMakeID;
        private System.Windows.Forms.Label labelMakeName;
        private System.Windows.Forms.TextBox textMakeName;
        private System.Windows.Forms.ListView ListMakes;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.TextBox textMakeID;
        private System.Windows.Forms.Button buttonSearch;
    }
}