﻿using System;

namespace MiniChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Start();

            Console.ReadLine();
        }
    }
}
