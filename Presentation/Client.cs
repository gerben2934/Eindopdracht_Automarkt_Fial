using System;
using System.Diagnostics;
using Presentation;
using SharedData;
using SharedData.Packets;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI
{
    public class Client
    {
        public string Username { get; }
        public TcpClient Socket { get; }
        public Car CurrentCar { get; set; }
        public bool Running { get; set; }

        private const string IP = "127.0.0.1";
        private const ushort PORT = 10000;

        public Client(string username)
        {
            Socket = new TcpClient(IP, PORT);
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
                        case PacketType.SuccesfullBidder:
                            HandleSuccesfullBidderMessage((SuccesfullBidder)message);
                            break;
                        case PacketType.TimeMessage:
                            HandleTimeMessage((TimeMessage)message);
                            break;
                        case PacketType.BidErrorMessage:
                            HandleBidErrorMessage((BidErrorMessage)message);
                            break;
                    }
                }
            });
        }

        private void HandleBidErrorMessage(BidErrorMessage message)
        {
            Console.WriteLine("CLIENT: received BidErrormessage");

            Console.WriteLine(" Message: " + message);
            string m = message.ToString();
            string amount = message.ToString();
            MessageBox.Show("Bied hoger dan: € " + message.Message, "Uw bod was te laag!");
        }

        private void HandleSuccesfullBidderMessage(SuccesfullBidder message)
        {
            Console.WriteLine("CLIENT: received succesfullbidder message");
            Bid b = message.Bid;
            AuctionForm.GetInstance().UpdateTextBox(b.ToStringSucces());
        }

        private void HandleBidMessage(BidMessage message)
        {
            Console.WriteLine("CLIENT: received bid message");
            Bid b = message.Bid;
            AuctionForm.GetInstance().UpdateTextBox(b.BidMessage());
        }

        private void HandleTimeMessage(TimeMessage message)
        {
            int seconds = message.Time;
            TimeSpan t = new TimeSpan(0, 0, seconds);
            string time = t.ToString();
            string timee = time.Substring(3);
            Console.WriteLine("TIJD: " + timee);
            AuctionForm.GetInstance().UpdateTimeBox(timee);
        }

        private void HandleCarMessage(CarMessage message)
        {
            Console.WriteLine("CLIENT: received car Message");
            CurrentCar = message.Car;
            Console.WriteLine("Currentcar: " + CurrentCar);
//            AuctionForm.GetInstance().UpdateTextBox(CurrentCar.ToString());
            AuctionForm.GetInstance().UpdateCar(CurrentCar.Brand, CurrentCar.Model, CurrentCar.Description, CurrentCar.Mileage, CurrentCar.Color, CurrentCar.Year, CurrentCar.CarFuelType);
        }

        private void HandleOkMessage(OkMessage message)
        {
            Console.WriteLine(message);
            Console.WriteLine("CLIENT: received OK message");
        }
    }
}                 