using System;

namespace CS301_Spend_Transactions.Models
{
    /**
     * Class that serializes data from transaction records sent by the bank
     */
    public class SpendEntry
    {
        public string Id { get; set; }
        public string TransactionId { get; set; }
        public string Merchant { get; set; }
        public string MCC { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string TransactionDate { get; set; }
        public string CardId { get; set; }
        public string CardPan { get; set; }
        public string CardType { get; set; }
    }
}