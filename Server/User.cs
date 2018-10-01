using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SharedData;

namespace Server
{
    class User
    {
        public TcpClient client { get; set; }

        public User(TcpClient client)
        {
            this.client = client;
            //MessageUtil.sendMessage(new OkMessage("Test2.0"), client.GetStream());
        }
    
        private void ReadAsync()
        {
            Task.Factory.StartNew(() =>
            {

            });
        }
    }
}
