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

namespace fileClient
{
    public partial class FileClient : Form
    {

        string receiverName;
        int port;

        public FileClient()
        {
            InitializeComponent();

            receiverName = Dns.GetHostName();
            port = 2112;
        }

        private void FileClient_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(ofd.FileName);
                    txtFile.Text = ofd.FileName;

                    string fileInfo = info.Name + "." + info.Length;

                    IPHostEntry ipHost = Dns.GetHostEntry(receiverName);
                    IPAddress ipAddr = ipHost.AddressList[1];
                    TcpClient client = new TcpClient(receiverName, port);

                    Stream s = client.GetStream();

                    StreamWriter sw = new StreamWriter(s);
                    sw.AutoFlush = true;

                    sw.WriteLine(fileInfo);

                    s.Close();
                    client.Close();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }   

        private void btnSend_Click(object sender, EventArgs e)
        {
           
            try
            {
                string hostName = "192.168.0.107";

                TcpClient client = new TcpClient(hostName, 2112);
                Stream s = client.GetStream();

                byte[] bFile = File.ReadAllBytes(ofd.FileName);

                s.Write(bFile, 0, bFile.Length);

                s.Close();
                client.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
