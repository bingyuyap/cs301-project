using System;
using System.Collections.Generic;
using CS301_Spend_Transactions.Models;

namespace CS301_Spend_Transactions.Models
{
    public abstract class Card
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

        public abstract Reward computeReward(Transaction transaction);
    }

    public class PointCard : Card
    {
        public override Reward computeReward(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }

    public class MilesCard : Card
    {
        public override Reward computeReward(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }

    public class CashbackCard : Card
    {
        public override Reward computeReward(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}