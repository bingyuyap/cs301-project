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

        public virtual User User { get; set; }
        
        public virtual ICollection<Rule> Rules { get; set; }
        
        // public virtual ICollection<Exclusion> Exclusions { get; set; }
        //
        // public virtual ICollection<Campaign> Campaigns { get; set; }
        //
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}