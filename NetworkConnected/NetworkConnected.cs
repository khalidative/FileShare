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
using System.Collections;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;


namespace NetworkConnected
{
    public partial class NetworkConnected : Form
    {

        NetworkBrowser nb;

        public NetworkConnected()
        {
            InitializeComponent();

            nb = new NetworkBrowser();
        }

        private void NetworkConnected_Load(object sender, EventArgs e)
        {
            ArrayList list = nb.getNetworkComputers();

            foreach (Object obj in list)
            {
                txtIPs.Text += obj.ToString();
            }
               
        }

    }
    
}
