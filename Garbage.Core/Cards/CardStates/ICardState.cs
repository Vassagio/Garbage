using Project.Utilities;

namespace Garbage.Core.Cards.CardStates {
    public interface ICardState: IDeepCloneable<ICardState> { 
        ICardState Start();
        ICardState Select();
        ICardState Play();
        ICardState Discard();
        ICardState Hide();
        ICardState Lock();        
    }
}