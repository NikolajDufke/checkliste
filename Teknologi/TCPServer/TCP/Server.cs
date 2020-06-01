using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    public class Server
    {
        public void DoClient(TcpClient socket)
        {
            using (socket)
            {
                NetworkStream ns = socket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                string line;
                while (true)
                {
                    line = sr.ReadLine();

                    Console.WriteLine("Client: " + line);
                    //skriv ting der skal gøres her 

                    //f.eks.
                    //string[] str = line.Split(" ");
                    //if (str[0].ToLower() == "gennemsnit")
                    //{
                    //  string kmstring = sr.ReadLine();
                    //  Console.WriteLine("Client: " + kmstring );
                    //  sw.WriteLine("Du har indtastet  " + kmstring + " km. Indtast antal liter");
                    //}
                }

            }
        }
        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 7000);
            listener.Start();
            Console.WriteLine("Server started listening");
            while (true)
            {
                TcpClient socket = listener.AcceptTcpClient();
                Console.WriteLine("Accepted a client");
                Task.Run((() =>
                {
                    TcpClient tempsocket = socket;
                    DoClient(tempsocket);
                }));
            }
        }
    }
}
