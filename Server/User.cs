using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SharedData;
using SharedData.Packets;

namespace Server
{
    public class User
    {
        public TcpClient Client { get; set; }
        public bool Running { get; set; }

        public User(TcpClient client)
        {
            Client = client;
            StartBackgroundReceiver();
        }

        private void StartBackgroundReceiver()
        {
            Running = true;
            Task.Factory.StartNew(async () =>
            {
                while (Running)
                {
                    dynamic msg = await MessageUtil.ReadMessage(Client);
                    IPacket message = JsonDecoder.Decode(msg);
                    switch (message.Type)
                    {
                        case PacketType.BidMessage:
                            HandleBidMessage((BidMessage)message);
                            break;
                        case PacketType.CarMessage:
                            HandleCarMessage((CarMessage)message);
                            break;
                        case PacketType.OkMessage:
                            HandleOkMessage((OkMessage)message);
                            break;
                    }
                }
            });
        }

        private void HandleBidMessage(BidMessage message)
        {
            Console.WriteLine("Received BidMessage");
        }

        private void HandleCarMessage(CarMessage message)
        {
            Console.WriteLine("Received CarMessage");
        }

        private void HandleOkMessage(OkMessage message)
        {
            Console.WriteLine("Received OkMessage");
        }
    }
}