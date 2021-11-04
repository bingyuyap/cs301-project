using System;

namespace CS301_Spend_Transactions.Domain.DTO
{
    /**
     * Data Transfer Object (DTO) corresponding to fields in spend.csv entries
     */
    public class TransactionDTO
    {
        public string Id { get; set; }
        public string TransactionId { get; set; }
        public string Merchant { get; set; }
        public int MCC { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CardId { get; set; }
        public string CardPan { get; set; }
        public string CardType { get; set; }
    }
}