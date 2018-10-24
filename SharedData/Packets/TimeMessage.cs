using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SharedData.Packets
{
    public class TimeMessage : IPacket
    {
        public PacketType Type => PacketType.TimeMessage;
        public string Time { get; set; }

        public TimeMessage(string time)
        {
            this.Time = time;
        }

        public static IPacket ToClass(dynamic json)
        {
            string s = (string)json.data.id;
            return new TimeMessage(s);
        }

        IPacket IPacket.ToClass(dynamic json)
        {
            return TimeMessage.ToClass(json);
        }


        public dynamic ToJson()
        {
            dynamic json = new
            {
                packetType = nameof(TimeMessage),
                data = new
                {
                    time = Time
                }
            };

            return JsonConvert.SerializeObject(json);
        }
    }
}
