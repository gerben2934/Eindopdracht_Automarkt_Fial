using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Newtonsoft.Json;

namespace SharedData.Packets
{

    /**
            {
                "packetType" : "Message",
                "object" : {
                    "message" : "Your message here!"
                }
            }
     **/
    
    class OkMessage : IPacket
    {
        public string Message { get; set; }

        public OkMessage(string message)
        {
            this.Message = message;
        }

        public static IPacket ToClass(dynamic json)
        {
            string s = (string)json.data.id;
            return new OkMessage(s);
        }

        IPacket IPacket.ToClass(dynamic json)
        {
            return OkMessage.ToClass(json);
        }

        public dynamic ToJson()
        {
            dynamic json = new
            {
                packetType = nameof(OkMessage),
                data = new
                {
                    message = Message
                }
            };

            return JsonConvert.SerializeObject(json);
        }

        dynamic IPacket.ToJson()
        {
            dynamic json = new
            {
                packetType = nameof(OkMessage),
                data = new
                {
                    message = Message
                }
            };

            return JsonConvert.SerializeObject(json);
        }
    }
}