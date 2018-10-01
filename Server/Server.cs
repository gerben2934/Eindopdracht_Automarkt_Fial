using SharedData;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static List<Car> cars { get; set; }
        public static List<User> users { get; set; }

        private static TcpListener server;

        public void Main(string[] args)
        {
            server = new TcpListener(10000);
            cars = new List<Car>();
            users = new List<User>();
            server.Start();
            server.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }

        private static void OnConnect(IAsyncResult ar)
        {
            TcpClient client = server.EndAcceptTcpClient(ar);
            users.Add(new User(client));

            server.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }

        public static void Broadcast()
        {
            foreach (User user in users)
            {
                //Do statement
            }
        }

        public static void BroadcastExcept(User user, dynamic data)
        {
            foreach (User u in users.Where(u => u != user))
                u.Send(data);
        }
    }
}
