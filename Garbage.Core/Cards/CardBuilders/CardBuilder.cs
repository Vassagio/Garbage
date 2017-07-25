using Garbage.Core.Cards.CardStates;
using Garbage.Core.Cards.CardStates.StandardCardStates;

namespace Garbage.Core.Cards.CardBuilders {
    public class CardBuilder: ICardSuitBuilder, ICardValueBuilder, ICardTypeBuilder, ICardBuilder
    {
        private Suit _suit;
        private CardValue _cardValue;
        private ICardState _state = new Started();        

        public ICardValueBuilder WithSuit(Suit suit) {
            _suit = suit;
            return this;
        }

        public ICardTypeBuilder WithValue(CardValue cardValue) {
            _cardValue = cardValue;
            return this;
        }

        public ICardBuilder IsWild() {
            _state = new CardStates.WildCardStates.Started();
            return this;
        }

        public Card Build() => new Card(_suit, _cardValue, _state);
    }
}