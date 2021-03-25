using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace E04.Server
{
    class Client
    {
        private TcpClient client;
        private NetworkStream ns;
        private byte[] data = new byte[1024];

        public Client(TcpClient cln)
        {
            client = cln;
            ns = client.GetStream();

        }

        public void Start()
        {
            Thread t = new Thread(Run);
            t.Start();

        }
        private void Run()
        {
            while(true)
            {
                byte[] dataFromClient = new byte[1024];
                int bytesRead = ns.Read(dataFromClient, 0, dataFromClient.Length);

                if(bytesRead ==0)
                {
                    break;
                }
                string s = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                Console.WriteLine(s);

                byte[] dataToClient = Encoding.ASCII.GetBytes($"Returning {s}");
                ns.Write(dataToClient, 0, dataToClient.Length);

            }
            ns.Close();
            client.Close();
        }
    }
}
