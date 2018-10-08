using SharedData;
using SharedData.Packets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        public TcpClient Client123;
        public static List<Car> Cars { get; set; }
        static List<User> Users = new List<User>();
        public static List<TcpClient> Clients { get; set; }

        private const ushort PORT = 10000;

        private static TcpListener server;

        public static Car ToyotaYaris;


        public static void Main(string[] args)
        {
            server = new TcpListener(PORT);
            Cars = new List<Car>();

            server.Start();
            server.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);

            Console.ReadKey();
        }

        private static void OnConnect(IAsyncResult ar)
        {
            TcpClient client = server.EndAcceptTcpClient(ar);
            Users.Add(new User(client));
            FillCars();

            Broadcast();

            //MessageUtil.sendMessage(new OkMessage("Het werkt"), client.GetStream());
            //MessageUtil.SendMessage(new CarMessage(ToyotaYaris), client.GetStream());
            server.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }

        public static void Broadcast()
        {
            foreach (User user in Users)
            {
                Console.WriteLine("werkt dit?");
                MessageUtil.SendMessage(new CarMessage(ToyotaYaris), user.client.GetStream());
            }
        }

        private void HandlePacket(dynamic jsonData, TcpClient client)
        {
            string packetType = jsonData.packetType;
            switch(packetType)
            {
                case nameof(BidMessage):
                    BidMessage bm = SharedData.Packets.BidMessage.ToClass(jsonData);
                    ClientUpdate(bm);
                    break;
                case nameof(CarMessage):
                    CarMessage cm = SharedData.Packets.CarMessage.ToClass(jsonData);
                    ClientUpdate(cm);
                    break;
            }
        }

        private void NewBid(TcpClient client, BidMessage bid) //bool? voor feedback gebruiker
        {
            
        }

        private void ClientUpdate(dynamic update)
        {

        }

        public static void FillCars()
        {
            ToyotaYaris = new Car(001, "Toyota", "Yaris", "Just a car", 10000, "Red", 2014, Car.Status.FORSALE, Car.FuelType.GAS);
            Cars.Add(ToyotaYaris);
        }
    }
}
