using System;
using System.Net.Sockets;
using System.Threading;

namespace E07.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("CTRL+C detected!\n");
                running = false;
            };

            Client client = new Client();
            client.Start();
            while(true)
            {
                try
                {
                    while(running)
                    {
                        string input = Console.ReadLine();
                        if (input == "exit")
                            break;

                        client.SendMsg(input);
                    }
                    Console.WriteLine("Disconnecting from server...");

                }
                catch (SocketException)
                {
                    Console.WriteLine("Unable to connect to server");
                    Thread.Sleep(5000);
                }

            }
        }
    }
}
