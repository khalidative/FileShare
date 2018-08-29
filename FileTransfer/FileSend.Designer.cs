namespace fileClient
{
    partial class FileClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileClient));
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.cmbRemoteHost = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(203, 124);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(122, 124);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(26, 80);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(252, 20);
            this.txtFile.TabIndex = 2;
            this.txtFile.Text = "Select a File";
            // 
            // cmbRemoteHost
            // 
            this.cmbRemoteHost.FormattingEnabled = true;
            this.cmbRemoteHost.Location = new System.Drawing.Point(26, 33);
            this.cmbRemoteHost.Name = "cmbRemoteHost";
            this.cmbRemoteHost.Size = new System.Drawing.Size(252, 21);
            this.cmbRemoteHost.TabIndex = 3;
            this.cmbRemoteHost.SelectedIndexChanged += new System.EventHandler(this.cmbRemoteHost_SelectedIndexChanged);
            // 
            // FileClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 174);
            this.Controls.Add(this.cmbRemoteHost);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileClient";
            this.Text = "FileSend";
            this.Load += new System.EventHandler(this.FileClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ComboBox cmbRemoteHost;
    }
}

