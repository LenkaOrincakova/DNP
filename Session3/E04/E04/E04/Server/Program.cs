using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace E04.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server..");

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 5000);
            listener.Start();

            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                Client client = new Client(tcpClient);
                client.Start();
                Console.WriteLine("Client connected");
                
            }
        }
    }
}
