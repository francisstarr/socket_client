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
                Console.WriteLine("COnnection to server is a success!");
                Console.WriteLine("Socket= " + Server.ipAddr + ":"+ Server.portNum);
                Console.WriteLine("Type text you want to send to the server. The <ENTER>");
                string inputCommand = string.Empty;
                while (true)
                {
                    inputCommand = Console.ReadLine();
                    if (inputCommand.Equals("<EXIT>"))
                    {
                        break;
                    }
                    byte[] buffSend = Encoding.ASCII.GetBytes(inputCommand);
                    client.Send(buffSend);

                    byte[] buffReceived = new byte[128];
                    int nRecv = client.Receive(buffReceived);
                    Console.WriteLine("Data received: {0}", Encoding.ASCII.GetString(buffReceived, 0, nRecv));
                }
          
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client.Dispose();
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
    
        }
    }
}
