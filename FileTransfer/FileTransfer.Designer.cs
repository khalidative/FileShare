namespace FileTransfer
{
    partial class FileTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTransfer));
            this.btnSendMode = new System.Windows.Forms.Button();
            this.btnRecvMode = new System.Windows.Forms.Button();
            this.lblHostName = new System.Windows.Forms.Label();
            this.lblHostIP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSendMode
            // 
            this.btnSendMode.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSendMode.Location = new System.Drawing.Point(72, 145);
            this.btnSendMode.Name = "btnSendMode";
            this.btnSendMode.Size = new System.Drawing.Size(170, 56);
            this.btnSendMode.TabIndex = 0;
            this.btnSendMode.Text = "Send";
            this.btnSendMode.UseVisualStyleBackColor = true;
            this.btnSendMode.Click += new System.EventHandler(this.btnSendMode_Click);
            // 
            // btnRecvMode
            // 
            this.btnRecvMode.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecvMode.Location = new System.Drawing.Point(72, 228);
            this.btnRecvMode.Name = "btnRecvMode";
            this.btnRecvMode.Size = new System.Drawing.Size(170, 55);
            this.btnRecvMode.TabIndex = 1;
            this.btnRecvMode.Text = "Receive";
            this.btnRecvMode.UseVisualStyleBackColor = true;
            this.btnRecvMode.Click += new System.EventHandler(this.btnRecvMode_Click);
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.lblHostName.Location = new System.Drawing.Point(12, 27);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(81, 17);
            this.lblHostName.TabIndex = 2;
            this.lblHostName.Text = "PC Name     :  ";
            // 
            // lblHostIP
            // 
            this.lblHostIP.AutoSize = true;
            this.lblHostIP.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.lblHostIP.Location = new System.Drawing.Point(12, 71);
            this.lblHostIP.Name = "lblHostIP";
            this.lblHostIP.Size = new System.Drawing.Size(82, 17);
            this.lblHostIP.TabIndex = 3;
            this.lblHostIP.Text = "IP Address  :  ";
            // 
            // FileTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 334);
            this.Controls.Add(this.lblHostIP);
            this.Controls.Add(this.lblHostName);
            this.Controls.Add(this.btnRecvMode);
            this.Controls.Add(this.btnSendMode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileTransfer";
            this.Text = "FileTransfer";
            this.Load += new System.EventHandler(this.FileTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMode;
        private System.Windows.Forms.Button btnRecvMode;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.Label lblHostIP;
    }
}

