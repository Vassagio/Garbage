namespace Garbage.Core.Cards.CardBuilders
{
    public interface ICardSuitBuilder
    {
        ICardValueBuilder WithSuit(Suit suit);
    }
}
