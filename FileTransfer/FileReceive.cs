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
        int udpPort;

        //Thread BroadCaster;

        string fileName;
        long fileSize;

        public delegate void Caller(string str);

        public FileServer()
        {
            InitializeComponent();

            //BroadCaster = new Thread(new ThreadStart(broadcast));

            hostName = Dns.GetHostName();
            port = 2112;
            udpPort = 2113;
        }

        private void FileServer_Load(object sender, EventArgs e)
        {

        }

        public void broadcast()
        {
            Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcastAddress = IPAddress.Parse("192.168.255.255");

            IPEndPoint EP = new IPEndPoint(broadcastAddress, udpPort);
            
            byte[] bName = Encoding.ASCII.GetBytes(hostName);

            soc.SendTo(bName, EP);

            soc.Close();

        }

        public void receiverMode()
        {
           
               
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

            MessageBox.Show("Your file was received ");

            Invoke(new Caller(disable_btnRecv), new object[] { "" });

        }

        private void btnRecv_Click(object sender, EventArgs e)
        {

            btnRecv.Enabled = false;

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {

                txtFile.Text = fileBrowser.SelectedPath.ToString();

                Thread t = new Thread(new ThreadStart(receiverMode));
                t.Start();
            }
        }

        public void disable_btnRecv(string dummy)//to be called by delegate Caller
        {
            btnRecv.Enabled = true;
        }

        private void chkbxAvailable_CheckedChanged(object sender, EventArgs e)
        {
            //if(chkbxAvailable.Checked == true)
            //{
            //    BroadCaster.Start();
            //}
            //else
            //{
            //    BroadCaster.Abort();
            //}
            
        }

        private void BroadCastTimer_Tick(object sender, EventArgs e)
        {
            if(chkbxAvailable.Checked == true)
            {
                broadcast();
                //MessageBox.Show("broadcasted");
            }
        }
    }
}
