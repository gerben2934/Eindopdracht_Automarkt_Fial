using System;
using System.Collections.Generic;
using System.Text;

namespace SharedData
{
    public interface IPacket
    {
        PacketType Type { get; }
        dynamic ToJson();
        IPacket ToClass(dynamic json);
    }

    public enum PacketType
    {
        OkMessage,
        BidMessage,
        CarMessage,
        SuccesfullBidder,
        TimeMessage
    }
}
