﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.102"), 88));

            byte[] data = new byte[1024];
            int count = clientSocket.Receive(data);
            string msg = Encoding.UTF8.GetString(data, 0, count);
            Console.WriteLine(msg);

            for (int i = 0; i < 100; i++)
            {
                clientSocket.Send(Message.GetBytes(i.ToString() + "信号"));
            }

            Console.ReadKey();
            clientSocket.Close();
        }
    }
}
