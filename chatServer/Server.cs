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

namespace chatServer
{
    public partial class Server : Form
    {
        public string hostName;

        public delegate void Caller(string msg);

        public Server()
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
                TcpListener listener = new TcpListener(ipad, 2112);
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


        private void Server_Load(object sender, EventArgs e)
        {
            
           

        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                hostName = "192.168.0.107";
                TcpClient client = new TcpClient(hostName, 2113);

                NetworkStream s = client.GetStream();

                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true;
                string msg = txtSend.Text;
                sw.WriteLine(msg);

                txtSend.Text = "";

                client.Close();
                s.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            //s.Close();
            //soc.Close();
            //listener.Stop();
        }
    }
}
