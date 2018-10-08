using Newtonsoft.Json;
using SharedData.Packets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SharedData
{
    class MessageUtil
    {

        public static byte[] _totalBuffer = new byte[0];

        public static void SendMessage(IPacket message, NetworkStream stream)
        {
            Console.WriteLine(message.ToJson());
            byte[] lengthPrefix = BitConverter.GetBytes(message.ToJson().Length);
            byte[] data = Encoding.UTF8.GetBytes(message.ToJson());
            byte[] buffer = new byte[lengthPrefix.Length + data.Length];
            lengthPrefix.CopyTo(buffer, 0);
            data.CopyTo(buffer, lengthPrefix.Length);

            stream.WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task<dynamic> ReadMessage(TcpClient client)
        {
            NetworkStream networkStream = client.GetStream();
            byte[] sizeInfo = new byte[4];
            
            int totalRead = 0, read = 0;
            do
            {
                read = networkStream.Read(sizeInfo, totalRead, sizeInfo.Length - totalRead);
                totalRead += read;
            } while (totalRead < sizeInfo.Length && read > 0);
            
            int messageSize = BitConverter.ToInt32(sizeInfo, 0);
            
            byte[] data = new byte[messageSize];
            
            totalRead = 0;
            
            do
            {
                totalRead += read = networkStream.Read(data, totalRead, data.Length - totalRead);
            } while (totalRead < messageSize && read > 0);
            
            dynamic result = JsonConvert.DeserializeObject<dynamic>(Encoding.UTF8.GetString(data, 0, totalRead));
            return result;

        }



    }
}
