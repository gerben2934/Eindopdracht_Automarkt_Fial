using System;
using System.Collections.Generic;
using System.Text;

namespace SharedData
{
    public class Bid
    {
        public string Username { get; private set; }
        public int CarId { get; private set; }
        public int Amount { get; set; }
        public DateTime Time { get; set; }

        public Bid(int amount)
        {
            this.Amount = amount;
            this.Time = DateTime.Now;
        }

        public Bid(string username, int carId, int amount, DateTime time)
        {
            this.Username = username;
            this.CarId = carId;
            this.Amount = amount;
            this.Time = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Bieding van: \r\n username: {Username}\r\n amount: {Amount}\r\n time: {Time.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        public string BidMessage()
        {
            return $"Username: {Username} amount: €{Amount}";
        }

        public string ToStringSucces()
        {
            return $"Hoogste bieding: \r\n username: {Username}\r\n amount: {Amount}\r\n time: {Time.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

    }
}