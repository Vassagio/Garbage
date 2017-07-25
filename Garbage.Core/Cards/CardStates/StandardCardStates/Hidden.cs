namespace Garbage.Core.Cards.CardStates.StandardCardStates {
    internal class Hidden : ICardState {
        public ICardState Start() => new Started();
        public ICardState Select() => this;
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => this;
        public ICardState Lock() => this;
    }
}