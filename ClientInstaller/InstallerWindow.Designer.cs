
namespace ClientInstaller
{
    partial class InstallerWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupServerDetails = new System.Windows.Forms.GroupBox();
            this.labelConnection = new System.Windows.Forms.Label();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.textServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textDirectory = new System.Windows.Forms.TextBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.checkRun = new System.Windows.Forms.CheckBox();
            this.groupServerDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupServerDetails
            // 
            this.groupServerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupServerDetails.Controls.Add(this.labelConnection);
            this.groupServerDetails.Controls.Add(this.buttonTestConnection);
            this.groupServerDetails.Controls.Add(this.textServerPort);
            this.groupServerDetails.Controls.Add(this.label2);
            this.groupServerDetails.Controls.Add(this.textServerIP);
            this.groupServerDetails.Controls.Add(this.label1);
            this.groupServerDetails.Location = new System.Drawing.Point(13, 13);
            this.groupServerDetails.Name = "groupServerDetails";
            this.groupServerDetails.Size = new System.Drawing.Size(463, 81);
            this.groupServerDetails.TabIndex = 0;
            this.groupServerDetails.TabStop = false;
            this.groupServerDetails.Text = "Download Server";
            // 
            // labelConnection
            // 
            this.labelConnection.AutoSize = true;
            this.labelConnection.Location = new System.Drawing.Point(354, 28);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(65, 15);
            this.labelConnection.TabIndex = 5;
            this.labelConnection.Text = "Connected";
            this.labelConnection.Visible = false;
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTestConnection.Location = new System.Drawing.Point(354, 49);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(103, 23);
            this.buttonTestConnection.TabIndex = 4;
            this.buttonTestConnection.Text = "Test Connection";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // textServerPort
            // 
            this.textServerPort.Location = new System.Drawing.Point(110, 49);
            this.textServerPort.Name = "textServerPort";
            this.textServerPort.Size = new System.Drawing.Size(228, 23);
            this.textServerPort.TabIndex = 3;
            this.textServerPort.Text = "8080";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server Port";
            // 
            // textServerIP
            // 
            this.textServerIP.Location = new System.Drawing.Point(110, 20);
            this.textServerIP.Name = "textServerIP";
            this.textServerIP.Size = new System.Drawing.Size(228, 23);
            this.textServerIP.TabIndex = 1;
            this.textServerIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Install Directory";
            // 
            // textDirectory
            // 
            this.textDirectory.Location = new System.Drawing.Point(123, 100);
            this.textDirectory.Name = "textDirectory";
            this.textDirectory.Size = new System.Drawing.Size(347, 23);
            this.textDirectory.TabIndex = 2;
            this.textDirectory.Text = "C:/Programs/";
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.Location = new System.Drawing.Point(395, 134);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(75, 23);
            this.buttonInstall.TabIndex = 4;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // checkRun
            // 
            this.checkRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkRun.AutoSize = true;
            this.checkRun.Location = new System.Drawing.Point(262, 137);
            this.checkRun.Name = "checkRun";
            this.checkRun.Size = new System.Drawing.Size(127, 19);
            this.checkRun.TabIndex = 5;
            this.checkRun.Text = "Run after complete";
            this.checkRun.UseVisualStyleBackColor = true;
            // 
            // InstallerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 169);
            this.Controls.Add(this.checkRun);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.textDirectory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupServerDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InstallerWindow";
            this.Text = "KronosDMS Installer";
            this.groupServerDetails.ResumeLayout(false);
            this.groupServerDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupServerDetails;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.TextBox textServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelConnection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDirectory;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.CheckBox checkRun;
    }
}

