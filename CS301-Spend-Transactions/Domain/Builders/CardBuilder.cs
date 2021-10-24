using System.Reflection.Metadata.Ecma335;
using CS301_Spend_Transactions.Models;

namespace CS301_Spend_Transactions.Domain.Builders
{
    public class CardBuilder
    {
        private Card _card;

        public CardBuilder Create(string Id, string UserId, string CardPan, string CardType)
        {
            if (CardType == "scis_shopping")
                _card = new PointCard();
            else if (CardType == "scis_platinummiles" || CardType == "scis_premiummiles")
                _card = new MilesCard();
            else if (CardType == "scis_freedom")
                _card = new CashbackCard();
            
            _card.Id = Id;
            _card.UserId = UserId;
            _card.CardPan = CardPan;

            return this;
        }
    }
}