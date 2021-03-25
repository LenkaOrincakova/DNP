using System;
using System.Collections.Generic;
using System.Text;

namespace E07.Server
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
            Server server = new Server();
            server.Start();
            while (running)
            {
                Console.WriteLine("Type a broadcast message to all clients, ctrl+c to stop");
                string input = Console.ReadLine();
                if (input == "exit")
                    break;
                server.SendMessage(new Message { Body = input, TimeStamp = DateTime.Now, Sender = "Server" });
            }
        }
    }
}
