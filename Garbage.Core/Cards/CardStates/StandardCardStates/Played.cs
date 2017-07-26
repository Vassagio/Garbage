namespace Garbage.Core.Cards.CardStates.StandardCardStates {
    internal class Played : ICardState {
        public ICardState Start() => this;
        public ICardState Select() => this;
        public ICardState Play() => this;
        public ICardState Discard() => this;
        public ICardState Hide() => this;
        public ICardState Lock() => new Locked();
        public ICardState DeepClone() => new Played();
        public override string ToString() => nameof(Played);
    }
}