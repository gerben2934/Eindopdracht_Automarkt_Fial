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
        public List<Car> Cars { get; set; }
        public List<User> Users { get; }
        public List<TcpClient> Clients { get; set; }

        private const ushort PORT = 10000;

        private readonly TcpListener _server;

        public static Car ToyotaYaris;


        public static void Main(string[] args)
        {
            new Server();
        }

        public Server()
        {
            _server = TcpListener.Create(PORT);
            Cars = new List<Car>();
            Users = new List<User>();
            FillCars();
            _server.Start();
            _server.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);

            Console.ReadKey();
        }

        private void OnConnect(IAsyncResult ar)
        {
            TcpClient client = _server.EndAcceptTcpClient(ar);
            Users.Add(new User(client));
            MessageUtil.SendMessage(new CarMessage(Cars[0]), client.GetStream());
            _server.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
            //Broadcast();

            //MessageUtil.sendMessage(new OkMessage("Het werkt"), client.GetStream());
            //MessageUtil.SendMessage(new CarMessage(ToyotaYaris), client.GetStream());
        }

        public void BroadcastAsync(IPacket packet)
        {
            Console.WriteLine("Broadcast");
            foreach (User user in Users)
            {
                Console.WriteLine("Broadcast");
                //MessageUtil.SendMessage(new CarMessage(ToyotaYaris), user.client.GetStream());
                MessageUtil.SendMessage(packet, user.Client.GetStream());
            }
        }
    
        private void NewBid(Bid bid) //bool? voor feedback gebruiker
        {
            foreach (Car c in Cars)
            {
                if (c.CarID == bid.CarId)
                {
                    c.Bids.Add(bid);
                    Console.WriteLine("Bieding toegevoegd!");
                    BroadcastAsync(new CarMessage(c));
                    Console.WriteLine("Auto gebroadcast!");
                    Console.WriteLine("Aantal biedingen: " + c.Bids.Count());
                }
            }
        }

        private static void ClientUpdate(dynamic update)
        {

        }

        public void FillCars()
        {
            List<Bid> bids = new List<Bid>();
            ToyotaYaris = new Car(001, bids, "Toyota", "Yaris", "Just a car", 10000, "Red", 2014, Car.Status.FORSALE, Car.FuelType.GAS);
            Cars.Add(ToyotaYaris);
        }
    }
}
