using Garbage.Core.Cards.CardStates;

namespace Garbage.Core.Cards.CardTypeStates {
    public class WildCardType : ICardTypeState {
        public IPlayedCardState PlayedCardState => new WildCardPlayed(this);
        public ICardTypeState Standard() => new StandardCardType();

        public ICardTypeState Wild() => this;

        public ICardTypeState DeepClone() => new WildCardType();
        public override string ToString() => $" (Wild)";
    }
}