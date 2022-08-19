
namespace KronosDMS_Client.Forms.Parts
{
    partial class PartsSearchForm
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
            this.labelMake = new System.Windows.Forms.Label();
            this.boxMakes = new System.Windows.Forms.ComboBox();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.textPartNumber = new System.Windows.Forms.TextBox();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.ListParts = new System.Windows.Forms.ListView();
            this.columnPartNumber = new System.Windows.Forms.ColumnHeader();
            this.columnMake = new System.Windows.Forms.ColumnHeader();
            this.columnDescription = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // labelMake
            // 
            this.labelMake.AutoSize = true;
            this.labelMake.Location = new System.Drawing.Point(12, 13);
            this.labelMake.Name = "labelMake";
            this.labelMake.Size = new System.Drawing.Size(36, 15);
            this.labelMake.TabIndex = 0;
            this.labelMake.Text = "Make";
            // 
            // boxMakes
            // 
            this.boxMakes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxMakes.FormattingEnabled = true;
            this.boxMakes.Location = new System.Drawing.Point(93, 10);
            this.boxMakes.Name = "boxMakes";
            this.boxMakes.Size = new System.Drawing.Size(146, 23);
            this.boxMakes.TabIndex = 1;
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.AutoSize = true;
            this.labelPartNumber.Location = new System.Drawing.Point(12, 43);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(75, 15);
            this.labelPartNumber.TabIndex = 2;
            this.labelPartNumber.Text = "Part Number";
            // 
            // textPartNumber
            // 
            this.textPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textPartNumber.Location = new System.Drawing.Point(93, 40);
            this.textPartNumber.Name = "textPartNumber";
            this.textPartNumber.Size = new System.Drawing.Size(146, 23);
            this.textPartNumber.TabIndex = 3;
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(93, 69);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(256, 23);
            this.textDescription.TabIndex = 5;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 72);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(67, 15);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Description";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(355, 69);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // ListParts
            // 
            this.ListParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPartNumber,
            this.columnMake,
            this.columnDescription});
            this.ListParts.FullRowSelect = true;
            this.ListParts.GridLines = true;
            this.ListParts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListParts.HideSelection = false;
            this.ListParts.Location = new System.Drawing.Point(12, 98);
            this.ListParts.MultiSelect = false;
            this.ListParts.Name = "ListParts";
            this.ListParts.Size = new System.Drawing.Size(418, 248);
            this.ListParts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListParts.TabIndex = 7;
            this.ListParts.UseCompatibleStateImageBehavior = false;
            this.ListParts.View = System.Windows.Forms.View.Details;
            this.ListParts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListParts_MouseDoubleClick);
            this.ListParts.Resize += new System.EventHandler(this.ListParts_Resize);
            // 
            // columnPartNumber
            // 
            this.columnPartNumber.Text = "Part Number";
            this.columnPartNumber.Width = 120;
            // 
            // columnMake
            // 
            this.columnMake.Text = "Make";
            this.columnMake.Width = 80;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 200;
            // 
            // PartsSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 358);
            this.Controls.Add(this.ListParts);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textPartNumber);
            this.Controls.Add(this.labelPartNumber);
            this.Controls.Add(this.boxMakes);
            this.Controls.Add(this.labelMake);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(458, 278);
            this.Name = "PartsSearchForm";
            this.Text = "Parts Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMake;
        private System.Windows.Forms.ComboBox boxMakes;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.TextBox textPartNumber;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListView ListParts;
        private System.Windows.Forms.ColumnHeader columnPartNumber;
        private System.Windows.Forms.ColumnHeader columnMake;
        private System.Windows.Forms.ColumnHeader columnDescription;
    }
}