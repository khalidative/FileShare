using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace TcpReceive
{
    public partial class Form1 : Form
    {
        public delegate void testDelegate(string str);
        public Form1()
        {
            InitializeComponent();
            Thread t = new Thread(new ThreadStart(ListenData));
            t.Start();
        }

        public void test(string str)
        {
            txtRecv.Text = str;
        }

        public void ListenData()
        {
            //Create and start TcpListener
            IPAddress ipad = IPAddress.Parse("127.0.0.1");
            Int32 prt = 2112;
            TcpListener tl = new TcpListener(ipad, prt);
            tl.Start();


            TcpClient tc = tl.AcceptTcpClient();

            NetworkStream ns = tc.GetStream();
            StreamReader sr = new StreamReader(ns);

            string result = sr.ReadToEnd();
            Invoke(new testDelegate(test), new object[] { result });
            //test(result);
            //txtRecv.Text = result;


            tc.Close();
            tl.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
//https://khalidmohamed.visualstudio.com/DefaultCollection/_git/P2PFileTransfer