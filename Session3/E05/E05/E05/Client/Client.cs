using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace E05.Client
{
    class Client
    {
        private TcpClient client;
        private NetworkStream ns;
        private byte[] data = new byte[1024];
        private bool connected = false;

        public Client()
        { }

        public void Start()
        {
            Thread t = new Thread(Run);
            t.Start();
        }
        private void Run()
        {
            while(connected==false)
            {
                Console.WriteLine("Trying to connect");
                try
                {
                    client = new TcpClient("127.0.0.1", 5000);
                    ns = client.GetStream();
                    connected = true;

                }
                catch (SocketException)
                { 
                }
                Thread.Sleep(2000);
            }
            Console.WriteLine("Connected to server");
            Console.WriteLine("Type a message to the server or exit to stop");

            while(true)
            {
                try
                {
                    data = new byte[1024];
                    int recv = ns.Read(data, 0, data.Length);
                    string message = Encoding.ASCII.GetString(data, 0, recv);
                    Console.WriteLine(message);

                }
                catch (IOException)
                {
                    break;
                }

            }
            ns.Close();
            client.Close();
        }

        public void SendMsg(string msg)
        {
            if(connected)
            {
                byte[] response = new byte[1024];
                response = Encoding.ASCII.GetBytes(msg);
                ns.Write(response, 0, response.Length);
            }
        }
    }
}
