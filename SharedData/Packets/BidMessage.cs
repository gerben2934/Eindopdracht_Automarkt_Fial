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
                "bid" : "10000",
                "time" : "13:00:00",
            }
        }
        **/

        public Bid Bid { get; set; }

        public BidMessage(Bid bid)
        {
            this.Bid = bid;
        }

        public static IPacket ToClass(dynamic json)
        {
            int bid = (int)json.data.Bid;
            DateTime time = (DateTime)json.data.Time;

            Bid b = new Bid(bid, time);
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
                    amount = Bid.Amount,
                    time = Bid.Time
                }
            };
            return JsonConvert.SerializeObject(json);
        }
    }
}
