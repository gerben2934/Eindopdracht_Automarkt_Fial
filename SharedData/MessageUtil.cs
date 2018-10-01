using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SharedData
{
    class MessageUtil
    {
        public static void sendMessage(OkMessage message, NetworkStream _stream)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message.ToJson()));

                 _stream.WriteAsync(BitConverter.GetBytes(bytes.Length), 0, 4);
                 _stream.WriteAsync(bytes, 0, bytes.Length);
            }
            catch (IOException) { }
        }

        public static dynamic ReadMessage(TcpClient client)
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

            return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data, 0, totalRead));
        }
    }
}
