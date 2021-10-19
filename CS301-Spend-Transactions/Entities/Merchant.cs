using System;
using System.Collections.Generic;

namespace CS301_Spend_Transactions.Models
{
    public class Merchant
    {
        public string Name { get; set; }

        public int MCC { get; set; }

        public ICollection<Campaign> Campaigns { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}