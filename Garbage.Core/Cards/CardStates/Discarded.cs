using Garbage.Core.Cards.CardTypeStates;

namespace Garbage.Core.Cards.CardStates {
    internal class Discarded : ICardState {
        private readonly ICardTypeState _cardType;

        public Discarded(ICardTypeState cardType) => _cardType = cardType;
        public ICardState Start() => this;
        public ICardState Select() => this;
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => new Hidden(_cardType);
        public ICardState Lock() => this;
        public ICardState DeepClone() => new Discarded(_cardType);

        public override string ToString() => nameof(Discarded);
    }
}