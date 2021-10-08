using System;
using System.Collections.Generic;

namespace CS301_Spend_Transactions.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }

        public ICollection<Points> CreditedPoints { get; set; }
    }
}