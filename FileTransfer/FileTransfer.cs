using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using fileClient;
using fileServer;

namespace FileTransfer
{
    public partial class FileTransfer : Form
    {
        public FileTransfer()
        {
            InitializeComponent();
        }
        
        private void FileTransfer_Load(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName();

            IPHostEntry iphost = Dns.GetHostEntry(hostName);
            IPAddress ipAddr = iphost.AddressList[1];

            lblHostName.Text += hostName;
            lblHostIP.Text += ipAddr.ToString();

        }

        private void btnSendMode_Click(object sender, EventArgs e)
        {

            FileClient fc = new FileClient();
            fc.Show();           
        }

        private void btnRecvMode_Click(object sender, EventArgs e)
        {
            FileServer fr = new FileServer();
            fr.Show();
        }
    }
}
