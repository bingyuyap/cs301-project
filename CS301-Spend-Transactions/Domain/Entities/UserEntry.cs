using System;

namespace CS301_Spend_Transactions.Models
{
    /**
     * Class that serializes data from user records sent by the bank
     */
    public class UserEntry
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string CardId { get; set; }
        public string CardPan { get; set; }
        public string CardType { get; set; }
    }
}