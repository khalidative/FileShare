using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace TcpSend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string hostName = txtHost.Text;
            int port = Int32.Parse(txtPort.Text);

            //create tcp client
            TcpClient tc = new TcpClient(hostName, port);
            //get the TCP connection's network stream
            NetworkStream ns = tc.GetStream();
            //create a filestream for the specified file
            FileStream fs = File.Open(txtFile.Text, FileMode.Open);
            //readbyte
            int data = fs.ReadByte();
            //send data
            while(data != -1)
            {
                ns.WriteByte((byte)data);
                data = fs.ReadByte();

            }
            //release the resources
            tc.Close();
            ns.Close();
            fs.Close();

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
        }

        private void ofd_FileOk(object sender, CancelEventArgs e)
        {
            txtFile.Text = ofd.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
