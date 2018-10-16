using SharedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Auction
    {
        public const string SAVELOCATION = @"SavedAuctions\";

        public Car Car { get; private set; }
        public int AuctionID { get; private set; }
        public List<TcpClient> Clients { get; private set; }
        public TcpClient SuccessfullBidder { get; private set; } = null;
        public int AuctionTime { get; set; }
        public DateTime StartTime { get; private set; }
        public bool Running { get; private set; }


        public Auction(List<TcpClient> clients, Car car)
        {
            Clients = clients;
            Car = car;
            AuctionID = car.CarID;
        }

        public void StartAuction(int auctionTime)
        {
            //Car.Bids.Clear();
            AuctionTime = auctionTime;
            Running = true;
            StartTime = DateTime.Now;
        }

        public string ClientsToString(List<TcpClient> clients)
        {
            string ClientList = "Clients in this Room:";
            foreach (TcpClient c in clients)
            {
                //ClientList += $"\r\n- Client: {c.Socket.Client.LocalEndPoint}";
            }
            return ClientList;
        }

//        public string BidsToString(Car car)
//        {
////            string Bids = $"This are all the bids on Car: {car.Brand}, with ID: {car.CarID}:";
////            foreach(Bid b in car.Bids)
////            {
////                Bids += $"\n\rUser: blablabla is bidding: {b.Amount} on: {b.Time}.";
////            }
////            Bids += $"\n\rSuccessfull Bidder: ";
////            return Bids;
//        }

        public string ToString(List<TcpClient> clients, Car car)
        {
            string Auction = "";
            Auction += $"Auction number: {AuctionID}, AuctionTime: {AuctionTime}, Running: {Running}\n\r";
            Auction += $"Clients: {clients.Count()}\n\r\n\r";
            //Auction += BidsToString(car);

            return Auction;
        }

    }
}
