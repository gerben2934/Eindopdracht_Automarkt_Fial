using SharedData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Auction
    {
        public const string SAVELOCATION = @"SavedAuctions\";

        public Car Car { get; private set; }
        public List<Bid> Bids { get; private set; }
        public int AuctionID { get; private set; }
        public List<User> Clients { get; private set; }
        public Bid MaxBid { get; private set; } = new Bid("admin", 1, 0, DateTime.Now);
        public int AuctionTime { get; set; }
        public DateTime StartTime { get; private set; }
        public bool Running { get; private set; }


        public Auction(List<User> clients, Car car, List<Bid> bids)
        {
            Clients = clients;
            Car = car;
            AuctionID = car.CarID;
            Bids = bids;
        }

        public void StartAuction(int auctionTime)
        {
            Bids.Clear();
            AuctionTime = auctionTime;
            Running = true;
            StartTime = DateTime.Now;
        }

        public void StopSession() => Running = false;

        public string ClientsToString(List<User> clients)
        {
            string ClientList = "Clients in this Room:";
            foreach (User c in clients)
            {
                //ClientList += $"\r\n- Client: {c.Socket.Client.LocalEndPoint}";
            }
            return ClientList;
        }

        public string BidsToString(Car car)
        {
            string BidsString = $"This are all the bids on Car: {car.Brand}, with ID: {car.CarID}:\r\n";
            foreach (Bid b in Server.Bids)
            {
                if (b.CarId == car.CarID)
                {
                    BidsString += $"\r\nUser: {b.Username} is bidding: {b.Amount} on: {b.Time}.";
                    if (b.Amount > MaxBid.Amount)
                    {
                        MaxBid = b;
                    }
                }
            }
            BidsString += $"\r\nSuccessfull Bidder: {MaxBid.Username} with amount: {MaxBid.Amount}\r\n";
            return BidsString;
        }

        public string ToString(List<User> clients, Car car)
        {
            string Auctionstring = "";
            Auctionstring += $"Auction number: {AuctionID}, AuctionTime: {AuctionTime}, Done: {Running} \r\n";
            Auctionstring += $"Clients: {clients.Count()}\r\n";
            Auctionstring += BidsToString(car);

            Console.WriteLine(Auctionstring);

            return Auctionstring;
        }

        public void SaveAuction()
        {
            string fileName = $"AuctionID {AuctionID} - CarID {Car.CarID} - SuccesfullBidder {MaxBid.Username}.txt";
            Directory.CreateDirectory(SAVELOCATION);
            File.WriteAllText(SAVELOCATION + fileName, ToString(Clients, Car));
        }
    }
}
