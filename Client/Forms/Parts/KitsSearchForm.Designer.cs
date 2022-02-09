
namespace KronosDMS_Client.Forms.Parts
{
    partial class KitsSearchForm
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textKitNumber = new System.Windows.Forms.TextBox();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.boxMakes = new System.Windows.Forms.ComboBox();
            this.labelMake = new System.Windows.Forms.Label();
            this.ListParts = new System.Windows.Forms.ListView();
            this.columnKitNumber = new System.Windows.Forms.ColumnHeader();
            this.columnMake = new System.Windows.Forms.ColumnHeader();
            this.columnModel = new System.Windows.Forms.ColumnHeader();
            this.columnDescription = new System.Windows.Forms.ColumnHeader();
            this.boxModel = new System.Windows.Forms.ComboBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(481, 99);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 13;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(101, 99);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(374, 23);
            this.textDescription.TabIndex = 12;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(10, 102);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(67, 15);
            this.labelDescription.TabIndex = 11;
            this.labelDescription.Text = "Description";
            // 
            // textKitNumber
            // 
            this.textKitNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textKitNumber.Location = new System.Drawing.Point(101, 70);
            this.textKitNumber.Name = "textKitNumber";
            this.textKitNumber.Size = new System.Drawing.Size(146, 23);
            this.textKitNumber.TabIndex = 10;
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.AutoSize = true;
            this.labelPartNumber.Location = new System.Drawing.Point(10, 73);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(68, 15);
            this.labelPartNumber.TabIndex = 9;
            this.labelPartNumber.Text = "Kit Number";
            // 
            // boxMakes
            // 
            this.boxMakes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxMakes.FormattingEnabled = true;
            this.boxMakes.Location = new System.Drawing.Point(101, 12);
            this.boxMakes.Name = "boxMakes";
            this.boxMakes.Size = new System.Drawing.Size(146, 23);
            this.boxMakes.TabIndex = 8;
            this.boxMakes.SelectedIndexChanged += new System.EventHandler(this.boxMakes_TextUpdate);
            this.boxMakes.TextUpdate += new System.EventHandler(this.boxMakes_TextUpdate);
            // 
            // labelMake
            // 
            this.labelMake.AutoSize = true;
            this.labelMake.Location = new System.Drawing.Point(10, 15);
            this.labelMake.Name = "labelMake";
            this.labelMake.Size = new System.Drawing.Size(36, 15);
            this.labelMake.TabIndex = 7;
            this.labelMake.Text = "Make";
            // 
            // ListParts
            // 
            this.ListParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnKitNumber,
            this.columnMake,
            this.columnModel,
            this.columnDescription});
            this.ListParts.FullRowSelect = true;
            this.ListParts.GridLines = true;
            this.ListParts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListParts.HideSelection = false;
            this.ListParts.Location = new System.Drawing.Point(10, 128);
            this.ListParts.MultiSelect = false;
            this.ListParts.Name = "ListParts";
            this.ListParts.Size = new System.Drawing.Size(546, 293);
            this.ListParts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListParts.TabIndex = 14;
            this.ListParts.UseCompatibleStateImageBehavior = false;
            this.ListParts.View = System.Windows.Forms.View.Details;
            this.ListParts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListParts_MouseDoubleClick);
            this.ListParts.Resize += new System.EventHandler(this.ListParts_Resize);
            // 
            // columnKitNumber
            // 
            this.columnKitNumber.Text = "Kit Number";
            this.columnKitNumber.Width = 120;
            // 
            // columnMake
            // 
            this.columnMake.Text = "Make";
            this.columnMake.Width = 80;
            // 
            // columnModel
            // 
            this.columnModel.Text = "Model";
            this.columnModel.Width = 100;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 200;
            // 
            // boxModel
            // 
            this.boxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxModel.FormattingEnabled = true;
            this.boxModel.Location = new System.Drawing.Point(101, 41);
            this.boxModel.Name = "boxModel";
            this.boxModel.Size = new System.Drawing.Size(146, 23);
            this.boxModel.TabIndex = 16;
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(10, 44);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(41, 15);
            this.labelModel.TabIndex = 15;
            this.labelModel.Text = "Model";
            // 
            // KitsSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 433);
            this.Controls.Add(this.boxModel);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.ListParts);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textKitNumber);
            this.Controls.Add(this.labelPartNumber);
            this.Controls.Add(this.boxMakes);
            this.Controls.Add(this.labelMake);
            this.MinimumSize = new System.Drawing.Size(584, 338);
            this.Name = "KitsSearchForm";
            this.Text = "Kits Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textKitNumber;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.ComboBox boxMakes;
        private System.Windows.Forms.Label labelMake;
        private System.Windows.Forms.ListView ListParts;
        private System.Windows.Forms.ColumnHeader columnKitNumber;
        private System.Windows.Forms.ColumnHeader columnMake;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.ComboBox boxModel;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.ColumnHeader columnModel;
    }
}