using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SharedData;

namespace Clienta
{
    public class Client
    {
        private static byte[] buffer = new byte[1024];
        private static string totalBuffer = "";
        public TcpClient Socket { get; private set; }

        private const ushort PORT = 10000;

        public Client(TcpClient client)
        {
            Socket = client;
            Socket.Connect("localhost", PORT);

            //client.GetStream().BeginRead(buffer, 0, 1024, new AsyncCallback(OnRead), null);
            Receive();
            Console.ReadKey();
        }

        public static Client FindClientByAdress(List<Client> clients, EndPoint address)
        {
            Client c = clients.Find(x =>
                (x.Socket.Client.RemoteEndPoint == address));
            return c;
        }

        public static void Receive()
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
