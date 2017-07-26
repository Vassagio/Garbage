namespace Garbage.Core.Cards.CardBuilders {
    internal class CardBuilder: ICardSuitBuilder, ICardValueBuilder, ICardTypeBuilder, ICardBuilder
    {
        private Card _card;
        private Suit _suit;
        private CardValue _cardValue;              

        public static ICardSuitBuilder NewCard() => new CardBuilder();

        private CardBuilder() {}

        public ICardValueBuilder WithSuit(Suit suit) {
            _suit = suit;
            return this;
        }

        public ICardTypeBuilder WithValue(CardValue cardValue) {
            _cardValue = cardValue;
            _card = Card.Create(_suit, _cardValue);
            return this;
        }

        public ICardBuilder IsWild() {
            _card.Wild();
            return this;
        }

        public Card Build() => _card;
    }
}