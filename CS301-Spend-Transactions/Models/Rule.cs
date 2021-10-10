using System;
using System.Collections.Generic;

/**
 * Create subtypes of Rule class with entity type hierarch mapping 
 * (https://docs.microsoft.com/en-us/ef/core/modeling/inheritance)
 */
namespace CS301_Spend_Transactions.Models
{
    public abstract class Rule
    {
        public int Id { get; set; }
        // TODO: Change this to enum?
        public string CardType { get; set; }

        public Card Card { get; set; }
        public string CardId { get; set; }
    }

    public class Exclusion : Rule
    {
        public int MCC { get; set; }
    }

    public class Program : Rule
    {
        public int RewardId { get; set; } // references reward table

        public virtual Reward Reward { get; set; } // references reward table
        
        public float Multiplier { get; set; }
        
        public decimal MinSpend { get; set; }
        
        public decimal MaxSpend { get; set; }
        
        public bool ForeignSpend { get; set; }
        
    }

    public class Campaign : Rule
    {
        public int RewardId { get; set; } // references reward table
        // Since this references merchant table I am changing the attribute to Merchant -Bing
        public Reward Reward { get; set; }
        
        public string MerchantName { get; set; } // references merchant table
        
        public Merchant Merchant { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public decimal MinSpend { get; set; }
        
        public decimal? MaxSpend { get; set; }
        
        public bool ForeignSpend { get; set; }
    }
}