namespace NetworkConnected
{
    partial class NetworkConnected
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
            this.txtIPs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtIPs
            // 
            this.txtIPs.Location = new System.Drawing.Point(12, 12);
            this.txtIPs.Multiline = true;
            this.txtIPs.Name = "txtIPs";
            this.txtIPs.Size = new System.Drawing.Size(406, 251);
            this.txtIPs.TabIndex = 0;
            // 
            // NetworkConnected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 300);
            this.Controls.Add(this.txtIPs);
            this.Name = "NetworkConnected";
            this.Text = "Network Connected";
            this.Load += new System.EventHandler(this.NetworkConnected_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIPs;
    }
}

