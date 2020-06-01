using System;
using System.IO;
using System.Net.Sockets;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            TcpClient clientSocket = new TcpClient("localhost", 7000);

            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            //Client med exit command
            Console.WriteLine("if you want to stop type exit.. du er nu klar");
            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "exit")
                {
                    sw.WriteLine(message);
                    break;
                }

                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }

            ns.Close();

            clientSocket.Close();

            Environment.Exit(0);
        }
    }
}
