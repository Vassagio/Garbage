namespace Garbage.Core.Cards.CardStates.StandardCardStates {
    internal class Locked : ICardState {
        public ICardState Start() => this;
        public ICardState Select() => this;
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => this;
        public ICardState Lock() => this;
        public ICardState DeepClone() => new Locked();
        public override string ToString() => nameof(Locked);
    }
}