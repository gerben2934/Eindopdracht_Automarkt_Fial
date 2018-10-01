using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Clienta
{
    public class Client
    {
        private static string ip = "1.1.1.1";

        private static byte[] buffer = new byte[1024];
        private static string totalBuffer = "";
        private static TcpClient client;

        static void Main(string[] args)
        {
            client = new TcpClient();
            client.Connect(ip, 10000);
        }

        private static void OnRead(IAsyncResult ar)
        {
            int rc = client.GetStream().EndRead(ar);
            totalBuffer += Encoding.UTF8.GetString(buffer, 0, rc);

            //if(totalBuffer.)
        }

        public static void send(String data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            client.GetStream().Write(byteData, 0, byteData.Length);
        }
    }
}
