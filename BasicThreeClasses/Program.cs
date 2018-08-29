using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicThreeClasses
{
    class Program
    {

        static void Main(string[] args)
        {
            foreach (String arg in args)
            {
                Console.WriteLine("\n Testing for  " + arg);
                GetHostInfo(arg);
            }
            Console.ReadLine(); 
        }//Main method

        static void GetHostInfo(string host)
        {
            try
            {
                // Attempt to resolve DNS for given host or address  
                IPHostEntry hostInfo = Dns.GetHostEntry(host);

                // Display host name  
                Console.WriteLine("\t Host Name: " + hostInfo.HostName);

                // Display list of IP addresses for this host  
                Console.Write("\t IP Addresses: ");

                foreach (IPAddress ipaddr in hostInfo.AddressList)
                {
                    Console.Write(ipaddr.ToString() + " ");
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("\t Unable to resolve host: " + host + "\n");
            }
        }//GetHostInfo method

        
    }//Program class
}//BasicThreeClasses namespace
