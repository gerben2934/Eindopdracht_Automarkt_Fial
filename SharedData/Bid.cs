using System;
using System.Collections.Generic;
using System.Text;

namespace SharedData
{
    public class Bid
    {
        public int Amount { get; set; }
        public DateTime Time { get; set; }

        public Bid(int amount)
        {
            this.Amount = amount;
            this.Time = DateTime.Now;
        }

        public Bid(int amount, DateTime time)
        {
            this.Amount = amount;
            this.Time = DateTime.Now;
        }

        public override string ToString()
        {
            return $"amount: {Amount}\n, time: {Time}";
        }
    }
}