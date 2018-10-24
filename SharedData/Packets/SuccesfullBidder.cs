using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedData.Packets
{
    public class SuccesfullBidder : IPacket
    {
        /**
        {
            "packetType" : "Succes",
            "object" : {
                "username" : "string name",
                "carId" : "int id",
                "bid" : "10000",
                "time" : "13:00:00",
            }
        }
        **/

        public PacketType Type => PacketType.SuccesfullBidder;
        public Bid Bid { get; set; }

        public SuccesfullBidder(Bid bid)
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
            return new SuccesfullBidder(b);
        }

        IPacket IPacket.ToClass(dynamic json)
        {
            return SuccesfullBidder.ToClass(json);
        }

        public dynamic ToJson()
        {
            dynamic json = new
            {
                packetType = nameof(SuccesfullBidder),
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
