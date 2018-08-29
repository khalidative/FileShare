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

namespace fileServer
{
    public partial class FileServer : Form
    {
        string hostName;
        int port;

        string fileName;
        long fileSize;

        public FileServer()
        {
            InitializeComponent();

            hostName = Dns.GetHostName();
            port = 2112;
        }

        private void FileServer_Load(object sender, EventArgs e)
        {

        }

        private void btnRecv_Click(object sender, EventArgs e)
        {
            
            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {

                txtFile.Text = fileBrowser.SelectedPath.ToString();
               
                IPHostEntry ipHost = Dns.GetHostEntry(hostName);
                IPAddress ipAddr = ipHost.AddressList[1];
                TcpListener listener = new TcpListener(ipAddr, port);
                listener.Start();

                Socket soc = listener.AcceptSocket();

                Stream s = new NetworkStream(soc);
                StreamReader sr = new StreamReader(s);

                string[] info = sr.ReadLine().Split('.');

                fileName = info[0] + "." + info[1];
                fileSize = long.Parse(info[2]);


               

                listener.Stop();
                soc.Close();

                listener.Start();
                soc = listener.AcceptSocket();
                s = new NetworkStream(soc);


                byte[] bFile = new byte[Convert.ToInt32(fileSize)];

                s.Read(bFile, 0, bFile.Length);

                File.WriteAllBytes(txtFile.Text + "\\" + fileName, bFile);

                s.Close();
                soc.Close();
                listener.Stop();
            }
            
        }
        
    }
}
