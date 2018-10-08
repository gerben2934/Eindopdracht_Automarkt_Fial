using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Presentation;
using SharedData;
using SharedData.Packets;

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
            Socket = new TcpClient("localhost", PORT);
            //Socket.Connect("localhost", PORT);
            Username = username;

            //client.GetStream().BeginRead(buffer, 0, 1024, new AsyncCallback(OnRead), null);
            //Receive();
        }

        public void Receive()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    dynamic data = await MessageUtil.ReadMessage(Socket);
                    dynamic handler = HandlePacket(data);
                    //HandlePacket(data);
                    Form1.GetInstance().UpdateTextBox(handler.ToString());
                    //Debug.WriteLine(MessageUtil.ReadMessage(Socket));
                }
            });
        }

        private dynamic HandlePacket(dynamic jsonData)
        {
            string packetType = jsonData.packetType;
            switch (packetType)
            {
                case nameof(BidMessage):
                    BidMessage bm = SharedData.Packets.BidMessage.ToClass(jsonData);
                    //ClientUpdate(bm);
                    return bm.Bid;
                    break;
                case nameof(CarMessage):
                    CarMessage cm = SharedData.Packets.CarMessage.ToClass(jsonData);
                    //ClientUpdate(cm);
                    return cm.Car;
                    break;
                case nameof(OkMessage):
                    return jsonData;
                    break;

            }

            return null;
        }
    }
}
