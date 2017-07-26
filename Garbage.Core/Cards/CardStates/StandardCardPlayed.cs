using Garbage.Core.Cards.CardTypeStates;

namespace Garbage.Core.Cards.CardStates {
    internal class StandardCardPlayed : IPlayedCardState {
        private readonly ICardTypeState _cardType;

        public StandardCardPlayed(ICardTypeState cardType) => _cardType = cardType;
        public ICardState Start() => this;
        public ICardState Select() => this;
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => this;
        public ICardState Lock() => new Locked(_cardType);
        public ICardState DeepClone() => new StandardCardPlayed(_cardType);
        public override string ToString() => nameof(StandardCardPlayed);
    }
}