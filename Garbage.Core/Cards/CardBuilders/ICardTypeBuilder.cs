namespace Garbage.Core.Cards.CardBuilders {
    public interface ICardTypeBuilder {
        ICardBuilder IsWild();
        Card Build();
    }
}