﻿using SharedData;
using SharedData.Packets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Server
{
    public class Server
    {
        public static List<Car> Cars { get; set; }
        public static List<User> Users { get; set; }
        public List<TcpClient> Clients { get; set; }
        public static List<Bid> Bids { get; set; }
        public Auction Auction1 { get; set; }
        private readonly System.Timers.Timer sessionTimer;
        private bool StartAuction;

        private const int SESSIONTIME = 30;
        private const ushort PORT = 10000;
        private readonly TcpListener _server;
        public static Car Bmw;

        public static void Main(string[] args)
        {
            new Server();
        }

        public Server()
        {
            _server = TcpListener.Create(PORT);
            Cars = new List<Car>();
            Users = new List<User>();
            Bids = new List<Bid>();
            FillCars();
            _server.Start();
            _server.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
            sessionTimer = new System.Timers.Timer();
            sessionTimer.Interval = 1000;
            sessionTimer.AutoReset = true;
            sessionTimer.Elapsed += SessionProgress;
            sessionTimer.Start();
            Auction1 = new Auction(Users, Cars[0], Bids);
            StartAuction = true;
            Console.ReadKey();
        }

        private void SessionProgress(object sender, ElapsedEventArgs e)
        {
            if (!Auction1.Running) return;

            TimeSpan duration = DateTime.UtcNow - Auction1.StartTime;
            int dur = (int)(SESSIONTIME - duration.TotalSeconds);
            BroadcastAsync(new TimeMessage(dur));

            if (duration.TotalSeconds >= Auction1.AuctionTime)
            {
                Console.WriteLine("Auction ended");
                Auction1.StopSession();
                //Call methods
                Auction1.SaveAuction();
                Bid SuccesfullBid = Auction1.MaxBid;
                Console.WriteLine("Succesfullbidder: " + SuccesfullBid);
                BroadcastAsync(new SuccesfullBidder(SuccesfullBid));
            }
        }

        private void OnConnect(IAsyncResult ar)
        {
            TcpClient client = _server.EndAcceptTcpClient(ar);
            Users.Add(new User(client));

            if (Users.Count >= 2 && StartAuction == true)
            {
                Auction1.StartAuction(SESSIONTIME);
                StartAuction = true;
            }

            MessageUtil.SendMessage(new CarMessage(Cars[0]), client.GetStream());
            _server.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
            //Broadcast();

            //MessageUtil.sendMessage(new OkMessage("Het werkt"), client.GetStream());
            //MessageUtil.SendMessage(new CarMessage(ToyotaYaris), client.GetStream());
        }

        public static void BroadcastAsync(IPacket packet)
        {
            Console.WriteLine("Broadcast");
            foreach (User user in Users)
            {
                Console.WriteLine("Broadcast");
                //MessageUtil.SendMessage(new CarMessage(ToyotaYaris), user.client.GetStream());
                MessageUtil.SendMessage(packet, user.Client.GetStream());
            }
        }

        public void FillCars()
        {
            List<Bid> bids = new List<Bid>();
            Bmw = new Car(1, "Bmw", "M4", "Dikke Bmw", 30000, "Blauw", 2014, Car.Status.FORSALE, Car.FuelType.GAS);
            Cars.Add(Bmw);
        }
    }
}
