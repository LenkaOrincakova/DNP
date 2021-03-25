using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace E05.Server
{
    class Client
    {
        public TcpClient Cln { get; set; }
        private NetworkStream ns;
        private byte[] data = new byte[1024];
        private Server server;

        public Client(TcpClient cln, Server server)
        {
            Cln = cln;
            ns = Cln.GetStream();
            this.server = server;
        }
        public void Start()
        {
            Thread t = new Thread(Run);
            t.Start();
        }

        public void Run()
        {
            SendMsg("Welcome to the DNPI1 test server");
            int recv;

            while(true)
            {
                data = new byte[1024];
                try
                {
                    recv = ns.Read(data, 0, data.Length);
                }
                catch (IOException)
                {

                }
                if (recv == 0)
                    break;
                Console.WriteLine($"Message from {Cln.Client.RemoteEndPoint.ToString()}; {Encoding.ASCII.GetString(data, 0, recv)}");
                server.SendMessage(Encoding.ASCII.GetString(data, 0, recv), Cln.Client.RemoteEndPoint);

            }
            ns.Close();
            Cln.Close();
        }
        public void SendMsg(string msg)
        {
            byte[] response = new byte[1024];
            response = Encoding.ASCII.GetBytes(msg);
            ns.Write(response, 0, response.Length);
        }
    }
}
