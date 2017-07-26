using Garbage.Core.Cards.CardTypeStates;

namespace Garbage.Core.Cards.CardStates {
    internal class Selected : ICardState {
        private readonly ICardTypeState _cardType;

        public Selected(ICardTypeState cardType) => _cardType = cardType;
        public ICardState Start() => this;
        public ICardState Select() => this;
        public ICardState Play() => _cardType.PlayedCardState;
        public ICardState Discard() => new Discarded(_cardType);
        public ICardState Hide() => this;
        public ICardState Lock() => this;
        public ICardState DeepClone() => new Selected(_cardType);
        public override string ToString() => nameof(Selected);
    }
}