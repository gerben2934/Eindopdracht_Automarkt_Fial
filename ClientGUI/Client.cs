﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SharedData;

namespace ClientGUI
{
    class Client
    {
        private static byte[] buffer = new byte[1024];
        private static string totalBuffer = "";
        public static string Username { get; private set; }
        public static TcpClient Socket { get; private set; }
        private const ushort PORT = 10000;

        public Client(string username)
        {
            Socket = new TcpClient();
            Socket.Connect("localhost", PORT);
            Username = username;

            //client.GetStream().BeginRead(buffer, 0, 1024, new AsyncCallback(OnRead), null);
            Receive();
            Console.ReadKey();
        }

        //public Client FindClientByAdress(List<Client> clients, EndPoint address)
        //{
        //    Client c = clients.Find(x =>
        //        (x.Socket.Client.RemoteEndPoint == address));
        //    return c;
        //}

        public void Receive()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine(MessageUtil.ReadMessage(Socket));
                }
            });
        }

    }
}
