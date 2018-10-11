﻿using System;
using System.Collections.Generic;
using System.Text;
using SharedData.Packets;

namespace SharedData
{
    public static class JsonDecoder
    {
        public static IPacket Decode(dynamic json)
        {
            PacketType type = (PacketType)json.packetType;
            if (type == PacketType.OkMessage)
                return DecodeOkMessage(json);
            if (type == PacketType.CarMessage)
                return DecodeCarMessage(json);
            if (type == PacketType.BidMessage)
                return DecodeBidMessage(json);
            return null;
        }

        private static BidMessage DecodeBidMessage(dynamic json)
        {
            BidMessage msg = BidMessage.ToClass(json);
            return msg;
        }

        private static CarMessage DecodeCarMessage(dynamic json)
        {
            return CarMessage.ToClass(json);
        }

        private static OkMessage DecodeOkMessage(dynamic json)
        {
            return OkMessage.ToClass(json);
        }
    }
}