using Garbage.Core.Cards.CardTypeStates;

namespace Garbage.Core.Cards.CardStates {
    internal class Hidden : ICardState {
        private readonly ICardTypeState _cardType;

        public Hidden(ICardTypeState cardType) => _cardType = cardType;
        public ICardState Start() => new Started(_cardType);
        public ICardState Select() => this;
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => this;
        public ICardState Lock() => this;
        public ICardState DeepClone() => new Hidden(_cardType);
        public override string ToString() => nameof(Hidden);
    }
}