using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SharedData;

namespace Client
{
    class Client
    {
        private static byte[] buffer = new byte[1024];
        private static string totalBuffer = "";
        static TcpClient client;

        static void Main(string[] args)
        {
            client = new TcpClient();
            client.Connect("localhost", 9876);

            //client.GetStream().BeginRead(buffer, 0, 1024, new AsyncCallback(OnRead), null);
            Receive();
            Console.ReadKey();


        }

        public static void Receive()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine(MessageUtil.ReadMessage(client));
                }
            });
        }

    }
}
