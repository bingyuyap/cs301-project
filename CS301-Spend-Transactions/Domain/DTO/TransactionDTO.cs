using System;

namespace CS301_Spend_Transactions.Domain.DTO
{
    public class TransactionDTO
    {
        public string Id { get; set; }
        public string TransactionId { get; set; }
        public string Merchant { get; set; }
        public string MCC { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CardId { get; set; }
        public string CardPan { get; set; }
        public string CardType { get; set; }
    }
}