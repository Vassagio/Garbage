using Garbage.Core.Cards.CardStates;

namespace Garbage.Core.Tests.Cards.CardStates.CardStateHelper {
    public interface ICardStateTransition {
        ICardStateAnd TransitionTo<TCardState>() where TCardState : ICardState;
    }
}