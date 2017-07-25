namespace Garbage.Core.Cards.CardStates {
    public interface ICardState { 
        ICardState Start();
        ICardState Select();
        ICardState Play();
        ICardState Discard();
        ICardState Hide();
        ICardState Lock();
    }
}