using System;
using System.IO;
using System.Net.Sockets;

namespace MiniChatClient
{
    internal class Client
    {
        public void Start()
        {
            TcpClient socket = new TcpClient("localhost", 7070);

            Stream ns = socket.GetStream();
            
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {

                sw.WriteLine(Console.ReadLine());
                sw.Flush();

                string line = sr.ReadLine();
                Console.WriteLine(line);

                //string str = Console.ReadLine();

                //sw.WriteLine(str);
                //sw.Flush();

                //string strin = sr.ReadLine();
                //Console.WriteLine(strin);
            }
        }
    }
}