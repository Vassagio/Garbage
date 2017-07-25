namespace Garbage.Core.Cards.CardStates.WildCardStates {
    internal class Discarded : ICardState {
        public ICardState Start() => this;
        public ICardState Select() => this;
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => new Hidden();
        public ICardState Lock() => this;
        public ICardState DeepClone() => new Discarded();
        public override string ToString() => nameof(Discarded);
    }
}