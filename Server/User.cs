using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SharedData;
using SharedData.Packets;

namespace Server
{
    class User
    {
        public TcpClient client { get; set; }

        public User(TcpClient client)
        {
            this.client = client;
            ReadAsync();
        }
    
        private void ReadAsync()
        {
            Task.Factory.StartNew(() =>
            {
                MessageUtil.SendMessage(new CarMessage(Server.Cars[0]), client.GetStream());
            });
        }
    }
}
