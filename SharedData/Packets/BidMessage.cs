using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedData.Packets
{
    class BidMessage : IPacket
    {
        /**
        {
            "packetType" : "BidMessage",
            "object" : {
                "username" : "string name",
                "carId" : "int id",
                "bid" : "10000",
                "time" : "13:00:00",
            }
        }
        **/
        public PacketType Type => PacketType.BidMessage;
        public Bid Bid { get; set; }

        public BidMessage(Bid bid)
        {
            this.Bid = bid;
        }

        public static IPacket ToClass(dynamic json)
        {
            string username = (string)json.data.username;
            int carId = (int)json.data.carId;
            int amount = (int)json.data.amount;
            DateTime time = (DateTime)json.data.time;
            Bid b = new Bid(username, carId, amount, time);
            return new BidMessage(b);
        }

        IPacket IPacket.ToClass(dynamic json)
        {
            return BidMessage.ToClass(json);
        }

        public dynamic ToJson()
        {
            dynamic json = new
            {
                packetType = nameof(BidMessage),
                data = new
                {
                    username = Bid.Username,
                    carId = Bid.CarId,
                    amount = Bid.Amount,
                    time = Bid.Time
                }
            };
            return JsonConvert.SerializeObject(json);
        }
    }
}
