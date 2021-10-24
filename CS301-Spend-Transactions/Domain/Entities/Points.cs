using System;
using System.Collections.Generic;

namespace CS301_Spend_Transactions.Models
{
    public class Points
    {
        public string Id { get; set; }
        
        // public int RewardId { get; set; } // references reward table
        
        public string TransactionId { get; set; } // references transaction table
        
        public decimal Amount { get; set; }
        
        public DateTime ProcessedDate { get; set; }
        
        
        public virtual Transaction Transaction { get; set; }
        
        // public virtual Reward Reward { get; set; }
    }

    public class PointsPoint : Points
    {
        
    }

    public class Miles : Points
    {
        
    }
    
    public class CashBack: Points
    {
        
    }
}