using System;
using System.Collections.Generic;
using System.Text;

namespace SharedData
{
    public class Bid
    {
        public int Amount { get; set; }
        public DateTime time { get; }

        public Bid(int amount)
        {
            this.Amount = amount;
            //time = DateTime.Now();
        }

        public override string ToString()
        {
            return $"amount: {Amount}\n, time: {time}";
        }
    }
}