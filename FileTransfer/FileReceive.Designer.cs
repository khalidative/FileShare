namespace fileServer
{
    partial class FileServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileServer));
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnRecv = new System.Windows.Forms.Button();
            this.fileBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.chkbxAvailable = new System.Windows.Forms.CheckBox();
            this.BroadCastTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(25, 36);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(252, 20);
            this.txtFile.TabIndex = 5;
            this.txtFile.Text = "Set Path";
            // 
            // btnRecv
            // 
            this.btnRecv.Location = new System.Drawing.Point(183, 76);
            this.btnRecv.Name = "btnRecv";
            this.btnRecv.Size = new System.Drawing.Size(94, 23);
            this.btnRecv.TabIndex = 3;
            this.btnRecv.Text = "Receive";
            this.btnRecv.UseVisualStyleBackColor = true;
            this.btnRecv.Click += new System.EventHandler(this.btnRecv_Click);
            // 
            // chkbxAvailable
            // 
            this.chkbxAvailable.AutoSize = true;
            this.chkbxAvailable.Checked = true;
            this.chkbxAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxAvailable.Location = new System.Drawing.Point(25, 80);
            this.chkbxAvailable.Name = "chkbxAvailable";
            this.chkbxAvailable.Size = new System.Drawing.Size(99, 17);
            this.chkbxAvailable.TabIndex = 7;
            this.chkbxAvailable.Text = "Show Available";
            this.chkbxAvailable.UseVisualStyleBackColor = true;
            this.chkbxAvailable.CheckedChanged += new System.EventHandler(this.chkbxAvailable_CheckedChanged);
            // 
            // BroadCastTimer
            // 
            this.BroadCastTimer.Enabled = true;
            this.BroadCastTimer.Interval = 7000;
            this.BroadCastTimer.Tick += new System.EventHandler(this.BroadCastTimer_Tick);
            // 
            // FileServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 132);
            this.Controls.Add(this.chkbxAvailable);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnRecv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileServer";
            this.Text = "FileReceive";
            this.Load += new System.EventHandler(this.FileServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnRecv;
        private System.Windows.Forms.FolderBrowserDialog fileBrowser;
        private System.Windows.Forms.CheckBox chkbxAvailable;
        private System.Windows.Forms.Timer BroadCastTimer;
    }
}

