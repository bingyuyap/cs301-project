using System;
using System.Collections.Generic;

namespace CS301_Spend_Transactions.Models
{
    public class Points
    {
        public int Id { get; set; }

        public string TransactionId { get; set; } // references Transaction table
        
        public virtual Transaction Transaction { get; set; }
        
        public int PointsTypeId { get; set; } // references PointsType table  
        
        public virtual PointsType PointsType { get; set; }
        
        public decimal Amount { get; set; }
        
        public DateTime ProcessedDate { get; set; }
    }
}