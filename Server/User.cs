﻿using System;
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

        //        private void HandleBidMessage(BidMessage message)
        //        {
        //            Console.WriteLine("USER Received BidMessage");
        //            Bid b = message.Bid;
        //                foreach (Car c in Server.Cars)
        //                {
        //                    if (c.CarID == b.CarId)
        //                    {
        //                        Car CurrentCar = c;
        //                        Console.WriteLine("Bieding toegevoegd!");
        //                        //Server.BroadcastAsync(new CarMessage(CurrentCar));
        //                        Server.Bids.Add(b);
        //                        Server.BroadcastAsync(new BidMessage(b));
        //                        Console.WriteLine("Auto gebroadcast!");
        //                    
        //                    }
        //            }
        //        }

        private void HandleBidMessage(BidMessage message)
        {
            Bid b = message.Bid;


            int MaxBid = 0;
            foreach (Bid bb in Server.Bids)
            {
                if (bb.Amount > MaxBid)
                {
                    MaxBid = bb.Amount;
                }
            }

            if (b.Amount > MaxBid)
            {
                Server.Bids.Add(b);
                Server.BroadcastAsync(new BidMessage(b));
                Console.WriteLine("Auto gebroadcast!");
            }
            else
            {
                Console.WriteLine("Bid to low!");
                MessageUtil.SendMessage(new BidErrorMessage(MaxBid.ToString()), Client.GetStream());
            }
        }

        private void HandleCarMessage(CarMessage message)
        {
            Console.WriteLine("USER: Received CarMessage");
            Car CurrentCar = message.Car;
        }

        private void HandleOkMessage(OkMessage message)
        {
            Console.WriteLine("USER: Received OkMessage");
        }
    }
}