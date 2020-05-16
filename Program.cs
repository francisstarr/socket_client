using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketClientStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Parse(Server.ipAddr);
            try {
                client.Connect(Server.ipAddr, Server.portNum);
                Console.ReadKey();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            
            
    
        }
    }
}
