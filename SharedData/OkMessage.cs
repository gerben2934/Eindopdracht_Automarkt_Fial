using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Newtonsoft.Json;

namespace SharedData
{
    class OkMessage
    {
        public string ToJson()
        {
            dynamic json = new
            {
                status = "ok"
            };

            return JsonConvert.SerializeObject(json);
        }
    }
}
