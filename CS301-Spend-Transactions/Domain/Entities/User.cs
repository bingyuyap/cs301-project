using System;
using System.Collections.Generic;

namespace CS301_Spend_Transactions.Models
{
    /**
     * Entity representing a User with basic details 
     */
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}