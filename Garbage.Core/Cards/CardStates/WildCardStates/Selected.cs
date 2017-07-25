namespace Garbage.Core.Cards.CardStates.WildCardStates
{
    internal class Selected : ICardState
    {
        public ICardState Start() => this;
        public ICardState Select() => this;
        public ICardState Play() => new Played();
        public ICardState Discard() => new Discarded();
        public ICardState Hide() => this;
        public ICardState Lock() => this;
    }
}
