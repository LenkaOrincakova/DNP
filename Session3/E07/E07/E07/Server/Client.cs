using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace E07.Server
{
    class Client
    {
        private TcpClient Cln {get; set;}
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

        private void Run()
        {
            SendMsg(new Message { Body = "Welcome to the DNPI1 test server", TimeStamp = DateTime.Now, Sender = "Server" });
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
                    break;
                }
                if (recv == 0)
                {
                    break;
                }

                var message = JsonSerializer.Deserialize<Message>(Encoding.ASCII.GetString(data, 0, recv));
                Console.WriteLine($"Message from {Cln.Client.RemoteEndPoint.ToString()} : {message.Body} ({message.TimeStamp})");
                server.SendMessage(message, Cln.Client.RemoteEndPoint);
            }
            ns.Close();
            Cln.Close();
            server.Clients.Remove(this);
        }
        public void SendMsg(Message msg)
        {
            byte[] response = new byte[1024];
            response = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(msg));
            ns.Write(response, 0, response.Length);
        }

       
    }
}
