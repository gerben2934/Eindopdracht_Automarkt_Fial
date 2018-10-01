using System;
using System.Collections.Generic;
using System.Text;

namespace SharedData
{
    interface IPacket
    {
        dynamic ToJson();
        IPacket ToClass(dynamic json);
    }
}
