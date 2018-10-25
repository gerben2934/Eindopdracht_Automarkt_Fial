using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Newtonsoft.Json;

namespace SharedData.Packets
{

    /**
            {
                "packetType" : "BidErrorMessage",
                "object" : {
                    "message" : "Your message here!"
                }
            }
     **/

    class BidErrorMessage : IPacket
    {
        public PacketType Type => PacketType.BidErrorMessage;
        public string Message { get; set; }

        public BidErrorMessage(string message)
        {
            this.Message = message;
        }

        public static IPacket ToClass(dynamic json)
        {
            string s = (string)json.data.message;
            return new BidErrorMessage(s);
        }

        IPacket IPacket.ToClass(dynamic json)
        {
            return BidErrorMessage.ToClass(json);
        }

        public dynamic ToJson()
        {
            dynamic json = new
            {
                packetType = nameof(BidErrorMessage),
                data = new
                {
                    message = Message
                }
            };

            return JsonConvert.SerializeObject(json);
        }
    }
}