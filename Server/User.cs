using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class User
    {
        private byte[] buffer = new byte[1024];
        private string totalBuffer = "";
        public TcpClient client { get; set; }
        public string username { get; set; }

        public User(TcpClient client)
        {
            this.client = client;
            client.GetStream().BeginRead(buffer, 0, 1024, new AsyncCallback(OnRead), this);
        }


        private void OnRead(IAsyncResult ar)
        {                                                                                                   
            client.GetStream().BeginRead(buffer, 0, 1024, new AsyncCallback(OnRead), this);
        }

        public void Send(String data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            client.GetStream().Write(byteData, 0, byteData.Length);
        }
    }
}
