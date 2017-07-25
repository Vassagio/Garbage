namespace Garbage.Core.Cards.CardStates.WildCardStates {
    internal class Hidden : ICardState {
        public ICardState Start() =>  new Started();
        public ICardState Select() => this;
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => this;
        public ICardState Lock() => this;
        public ICardState DeepClone() => new Hidden();
        public override string ToString() => nameof(Hidden);
    }
}