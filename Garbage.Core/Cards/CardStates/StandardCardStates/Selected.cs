namespace Garbage.Core.Cards.CardStates.StandardCardStates {
    internal class Selected : ICardState {
        public ICardState Start() => this;
        public ICardState Select() => this;
        public ICardState Play() => new Played();
        public ICardState Discard() => new Discarded();
        public ICardState Hide() => this;
        public ICardState Lock() => this;
        public ICardState DeepClone() => new Selected();
        public override string ToString() => nameof(Selected);
    }
}