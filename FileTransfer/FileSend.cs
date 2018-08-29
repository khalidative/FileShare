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
        int udpPort;
        List<string> remotehosts = new List<string>();

        public delegate void Caller(string str); 

        public FileClient()
        {
            InitializeComponent();

            Thread t = new Thread(new ThreadStart(ListenData));
            t.Start();

            receiverName = Dns.GetHostName();
            cmbRemoteHost.Items.Add(receiverName);
            cmbRemoteHost.Items.Add("E45");
            cmbRemoteHost.Items.Add("LMNtrix");
            cmbRemoteHost.Items.Add("ub-home");
            cmbRemoteHost.Items.Add("UTC-top");

            port = 2112;
            udpPort = 2113;
        }

        public void readMsg(string msg)
        {
            string Name = msg;
            
            if(remotehosts.Count() == 0)
            {
                remotehosts.Add(Name);
                cmbRemoteHost.Items.Add(Name);
                
            }
            else
            {
                for (int i = 0; i < remotehosts.Count(); i++)
                {
                    if(remotehosts[i] == Name)
                    {
                        break;
                    }
                    if((i + 1) == remotehosts.Count())
                    {
                        remotehosts.Add(Name);
                        cmbRemoteHost.Items.Add(Name);
                    }
                }
            }
            
        }

        public void ListenData()
        {
            
            string hostName = Dns.GetHostName();
            IPHostEntry iphost = Dns.GetHostEntry(hostName);
            IPAddress ipAddr = iphost.AddressList[1];

            UdpClient uClient = new UdpClient(udpPort);
            IPEndPoint EP = new IPEndPoint(ipAddr, udpPort);

            while (true)
            {
                byte[] bMsg = uClient.Receive(ref EP);

                string msg = Encoding.ASCII.GetString(bMsg, 0, bMsg.Length);

                Invoke(new Caller(readMsg), new object[] { msg });
                
            }

        }

        private void FileClient_Load(object sender, EventArgs e)
        {
            //Device hello = new Device("hi", "hello");
            //cmbRemoteHost.Items.Add(hello.devName,hello.DevIP);
            //txtFile.Text = cmbRemoteHost.SelectedText;
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
                    IPAddress ipAddr = ipHost.AddressList[0];
                    TcpClient client = new TcpClient(receiverName, port);

                    Stream s = client.GetStream();

                    StreamWriter sw = new StreamWriter(s);
                    sw.AutoFlush = true;

                    sw.WriteLine(fileInfo);

                    btnSend.Enabled = true;

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
            btnSend.Enabled = false;

            try
            {

                IPHostEntry ipHost = Dns.GetHostEntry(receiverName);
                IPAddress ipAddr = ipHost.AddressList[0];
                TcpClient client = new TcpClient(receiverName, port);
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

        private void cmbRemoteHost_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;

            string Name = cmbRemoteHost.SelectedItem.ToString();
            receiverName = Name;
        }

        
    }

    
    
}
