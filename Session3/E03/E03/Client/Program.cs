using System;
using System.Net.Sockets;
using System.Text;

namespace E03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client..");

            TcpClient client = new TcpClient("127.0.0.1", 5000);

            NetworkStream stream = client.GetStream();

            while (true)
            {
                string input = Console.ReadLine();

                byte[] dataToServer = Encoding.ASCII.GetBytes("Hello from client");
                stream.Write(dataToServer, 0, dataToServer.Length);

                byte[] dataFromServer = new byte[1024];
                int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
                string respone = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
                Console.WriteLine(respone);
                if(input == "exit")
                {
                    break;
                }
            }

            stream.Close();
            client.Close();

        }
    }
}
