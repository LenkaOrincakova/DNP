using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace E07.Client
{
    class Client
    {
        private TcpClient client;
        private NetworkStream ns;
        private byte[] data = new byte[1024];
        private bool connected = false;

        public void Start()
        {
            Thread t = new Thread(Run);
            t.Start();
        }
        
        private void Run()
        {
            while(connected ==false)
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
                    Message message = JsonSerializer.Deserialize<Message>(Encoding.ASCII.GetString(data, 0, recv));
                    Console.WriteLine($"{message.Sender}, {message.TimeStamp}: {message.Body}");
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
            if (connected)
            {
                var message = new Message { Body = msg, TimeStamp = DateTime.Now, Sender = client.Client.RemoteEndPoint.ToString() };
                byte[] response = new byte[1024];
                response = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(message));
                ns.Write(response, 0, response.Length);
        }
    }
}
