using Garbage.Core.Cards.CardTypeStates;

namespace Garbage.Core.Cards.CardStates {
    internal class Locked : ICardState {
        private readonly ICardTypeState _cardType;

        public Locked(ICardTypeState cardType) => _cardType = cardType;
        public ICardState Start() => this;
        public ICardState Select() => this;
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => this;
        public ICardState Lock() => this;
        public ICardState DeepClone() => new Locked(_cardType);
        public override string ToString() => nameof(Locked);
    }
}