using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MiniChatServer
{
    class Server
    {
        
        public void Start()
        {
            TcpListener sever = new TcpListener(IPAddress.Loopback, 7070);
            sever.Start();

            while (true)
            {
                TcpClient socket = sever.AcceptTcpClient();

                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }
        }
        
        private void DoClient(TcpClient Socket)
        {
            bool go = true;
            Stream ns = Socket.GetStream();
            using (StreamReader Sr = new StreamReader(ns))
            using (StreamWriter Sw = new StreamWriter(ns))
            {
                while (go)
                {
                    string line = Sr.ReadLine();
                    Console.WriteLine(line);

                    if (line != null)
                    {
                       if (line.ToLower() == "stop")
                    {
                        go = false;
                        break;
                    } 
                    }
                    

                    string myLine = Console.ReadLine();
                    Sw.WriteLine(myLine);
                    Sw.Flush();
                    
                    
                    if ( myLine.ToLower() == "stop")
                    {
                        go = false;
                    }
                }
            }
            

        }
    }
}