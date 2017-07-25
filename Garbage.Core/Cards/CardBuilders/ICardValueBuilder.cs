namespace Garbage.Core.Cards.CardBuilders {
    public interface ICardValueBuilder
    {
        ICardTypeBuilder WithValue(CardValue value);
    }
}