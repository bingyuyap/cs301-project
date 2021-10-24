using System.Reflection.Metadata.Ecma335;
using CS301_Spend_Transactions.Models;

namespace CS301_Spend_Transactions.Domain.Builders
{
    public class CardBuilder
    {
        private Card _card;

        public CardBuilder Create(string id, string userId, string cardPan, string cardType)
        {
            if (cardType == "scis_shopping")
                _card = new PointCard();
            else if (cardType == "scis_platinummiles" || cardType == "scis_premiummiles")
                _card = new MilesCard();
            else if (cardType == "scis_freedom")
                _card = new CashbackCard();
            
            _card.Id = id;
            _card.UserId = userId;
            _card.CardPan = cardPan;
            _card.CardType = cardType;

            return this;
        }

        public Card Build()
        {
            return _card;
        }
    }
}