using System;
using CS301_Spend_Transactions.Models;

namespace CS301_Spend_Transactions.Domain.Builders
{
    public class PointBuilder
    {
        private Points _points;

        public PointBuilder Create(Rule rule, string cardType, string transactionId, decimal amount)
        {
            if (cardType == "scis_shopping")
                _points = new PointsPoint();
            else if (cardType == "scis_platinummiles" || cardType == "scis_premiummiles")
                _points = new Miles();
            else if (cardType == "scis_freedom")
                _points = new CashBack();

            _points.Id = Guid.NewGuid().ToString();
            _points.TransactionId = transactionId;
            _points.Amount = amount * rule.GetReward();
            _points.ProcessedDate = DateTime.UtcNow;
            return this;
        }

        public Points Build()
        {
            return _points;
        }
    }
}