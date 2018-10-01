using SharedData;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        static List<User> users = new List<User>();
        public static List<TcpClient> Clients { get; set; }

        public static TcpClient client { get; set; }

        private static TcpListener server;

    
        public static void Main(string[] args)
        {
            server = new TcpListener(9876);
            server.Start();
            server.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);

            Console.ReadKey();
        }

        private static void OnConnect(IAsyncResult ar)
        {
            client = server.EndAcceptTcpClient(ar);
            users.Add(new User(client));

            MessageUtil.sendMessage(new OkMessage(), client.GetStream());

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
