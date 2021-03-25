using System;
using System.Collections.Generic;
using System.Text;

namespace E05.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            Console.CancelKeyPress += (sender, e) =>
             {
                 Console.WriteLine("CTRL +C detected!\n");
                 running = false;
             };
            Server server = new Server();
            server.Start();
            while(running)
            {
                Console.WriteLine("Type a broadcast message to all clients, CTRL +C to stop");

                string input = Console.ReadLine();
                if (input == "exit")
                    break;

                server.SendMessage(input);


            }
        }
    }
}
