using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace E07.Server
{
    class Server
    {
        private byte[] adr = { 127, 0, 0, 1 };
        private IPAddress ipAdr;
        private TcpListener newsock;

        public List<Client> Client { get; set; } = new List<Client>();

        public bool Running { get; set; }
        public Server()
        {
            ipAdr = new IPAddress(adr);
            newsock = new TcpListener(ipAdr, 5000);
        }
        public void Start()
        {
            Running = true;
            newsock.Start();
            Thread t = new Thread(Run);
            t.Start();
            Console.WriteLine("Waiting for a client...");
        }
        private void Run()
        {
            while(Running)
            {
                TcpClient tcpclient = newsock.AcceptTcpClient();

                Client newClient = new Client(tcpclient, this);
                Clients.Add(newClient);
                newClient.Start();

                Console.WriteLine($"New Client connected local:{tcpclient.Client.LocalEndPoint.ToString()}, remote:{tcpclient.Client.RemoteEndPoint.ToString()}");

            }
        }

        public void SendMessage(Message msg)
        {
            foreach(var client in Clients)
            {
                client.SendMsg(msg);
            }
        }
        public void SendMessage(Message msg, EndPoint exclude)
        {
            foreach(var client in Clients)
            {
                if(client.Cln.Client.RemoteEndPoint == exclude)
                {
                    continue;
                }
                client.SendMsg(msg);
            }
        }
    }
}
