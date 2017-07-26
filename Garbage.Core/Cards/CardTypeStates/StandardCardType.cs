using Garbage.Core.Cards.CardStates;

namespace Garbage.Core.Cards.CardTypeStates {
    public class StandardCardType : ICardTypeState
    {
        public IPlayedCardState PlayedCardState => new StandardCardPlayed(this);
        public ICardTypeState Standard() => this;

        public ICardTypeState Wild() => new WildCardType();

        public ICardTypeState DeepClone() => new StandardCardType();

        public override string ToString() => string.Empty;
    }
}