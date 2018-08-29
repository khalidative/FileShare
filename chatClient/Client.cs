using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace chatClient
{
    public partial class Client : Form
    {
        public string hostName;


        public delegate void Caller(string msg);


        public Client()
        {
            InitializeComponent();
            Thread t = new Thread(new ThreadStart(ListenData));
            t.Start();
        }

        public void readMsg(string msg)
        {
            txtMsg.Text += "- " + msg + "\r\n";
        }

        public void ListenData()
        {
            while (true)
            {
                //get the IPAddress of the local host
                IPAddress ipad = IPAddress.Parse("192.168.0.107");
                //create TcpListener and start it
                TcpListener listener = new TcpListener(ipad, 2113);
                listener.Start();

                //Accept the incoming client request and create a socket
                Socket soc = listener.AcceptSocket();

                //create a network stream from that socket
                NetworkStream s = new NetworkStream(soc);

                StreamReader sr = new StreamReader(s);
                //StreamWriter sw = new StreamWriter(s);

                string msg = sr.ReadLine();

                Invoke(new Caller(readMsg), new object[] { msg });
                //test(result);
                //txtRecv.Text = result;

                listener.Stop();
                soc.Close();
                s.Close();
            }

        }

        private void Client_Load(object sender, EventArgs e)
        {
            //txtSend.Text = Dns.GetHostName();
            //IPHostEntry iphost = Dns.GetHostEntry(Dns.GetHostName());
            //IPAddress ipAddr = iphost.AddressList[1];
            //txtSend.Text += ipAddr.ToString();
        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                hostName = "192.168.0.107";
                TcpClient client = new TcpClient(hostName, 2112);

                NetworkStream s = client.GetStream();

                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true;
                string msg = txtSend.Text;
                sw.WriteLine(msg);

                txtSend.Text = "";

                client.Close();
                s.Close();
            }
            catch(Exception ex)
            {

            }
            

        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                hostName = "192.168.0.107";
                //IPHostEntry ipHost = Dns.GetHostEntry(hostName);
                //IPAddress ipAddr = ipHost.AddressList[1];
                //IPEndPoint endPoint = new IPEndPoint(ipAddr, 2020);

                TcpClient client = new TcpClient(hostName, 2112);

                lblCheck.Text = "Connected";

                NetworkStream s = client.GetStream();

                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);


                //txtMsg.Text += sr.ReadLine();

                client.Close();
                s.Close();
                
            }
            catch(SocketException se)
            {
                MessageBox.Show(se.Message);
            }
           
        }
    }
}
