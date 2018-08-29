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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnRecv = new System.Windows.Forms.Button();
            this.fileBrowser = new System.Windows.Forms.FolderBrowserDialog();
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
            this.btnRecv.Location = new System.Drawing.Point(121, 76);
            this.btnRecv.Name = "btnRecv";
            this.btnRecv.Size = new System.Drawing.Size(156, 23);
            this.btnRecv.TabIndex = 3;
            this.btnRecv.Text = "Receive";
            this.btnRecv.UseVisualStyleBackColor = true;
            this.btnRecv.Click += new System.EventHandler(this.btnRecv_Click);
            // 
            // FileServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 132);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnRecv);
            this.Name = "FileServer";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.FileServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnRecv;
        private System.Windows.Forms.FolderBrowserDialog fileBrowser;
    }
}

