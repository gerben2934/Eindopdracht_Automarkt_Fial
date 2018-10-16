using System;
using Presentation;
using SharedData;
using SharedData.Packets;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ClientGUI
{
    public class Client
    {
        public string Username { get; }
        public TcpClient Socket { get; }
        public Car CurrentCar { get; set; }
        public bool Running { get; set; }

        private const ushort Port = 10000;

        public Client(string username)
        {
            Socket = new TcpClient("localhost", Port);
            Username = username;
            StartBackgroundReceiver();
        }

        private void StartBackgroundReceiver()
        {
            Running = true;
            Task.Factory.StartNew(async () =>
            {
                while (Running)
                {
                    dynamic msg = await MessageUtil.ReadMessage(Socket);
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
            Console.WriteLine("CLIENT: received bid message");
            Bid b = message.Bid;
            Form1.GetInstance().UpdateTextBox(b.ToString());
        }

        private void HandleCarMessage(CarMessage message)
        {
            Console.WriteLine("CLIENT: received car Message");
            CurrentCar = message.Car;
            Console.WriteLine("Currentcar: " + CurrentCar);
            Form1.GetInstance().UpdateTextBox(CurrentCar.ToString());
        }

        private void HandleOkMessage(OkMessage message)
        {
            Console.WriteLine("CLIENT: received OK message");
        }
    }
}
//                    