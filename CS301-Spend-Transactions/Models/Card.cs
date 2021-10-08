using System;
using System.Collections.Generic;

namespace CS301_Spend_Transactions.Models
{
    public class Card
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string CardPan { get; set; }
        public string CardType { get; set; }

        public User User { get; set; }
        public ICollection<Rule> Rules { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}