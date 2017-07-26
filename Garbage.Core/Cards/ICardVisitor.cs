using Garbage.Core.Cards.CardStates;
using Garbage.Core.Cards.CardTypeStates;

namespace Garbage.Core.Cards {
    public interface ICardVisitor {
        void Execute(Suit suit, CardValue cardValue, ICardState state, ICardTypeState type);
    }
}